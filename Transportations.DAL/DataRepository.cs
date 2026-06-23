using System.Data;
using System.Data.OleDb;

namespace Transportations.DAL
{
    /// <summary>
    /// Универсальные CRUD-операции над рабочими таблицами БД.
    /// Таблица Пользователи намеренно исключена из списка доступных.
    /// </summary>
    public class DataRepository
    {
        private readonly string _connectionString;

        /// <summary>Таблицы, доступные через этот репозиторий.</summary>
        public static readonly string[] AllowedTables =
            { "Водители", "Грузы", "Клиенты", "Рейсы", "Транспорт" };

        public DataRepository(string connectionString)
        {
            _connectionString = connectionString
                ?? throw new ArgumentNullException(nameof(connectionString));
        }

        /// <summary>Возвращает все строки таблицы.</summary>
        public DataTable GetTable(string tableName)
        {
            EnsureAllowed(tableName);
            return ExecuteQuery($"SELECT * FROM [{tableName}]");
        }

        /// <summary>
        /// Возвращает строки таблицы, у которых хотя бы одно поле содержит
        /// <paramref name="searchText"/> (без учёта регистра).
        /// </summary>
        public DataTable SearchTable(string tableName, string searchText)
        {
            EnsureAllowed(tableName);
            var full = GetTable(tableName);
            if (string.IsNullOrWhiteSpace(searchText))
                return full;

            var matched = full.AsEnumerable()
                .Where(r => r.ItemArray.Any(v =>
                    v?.ToString()?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true));

            return matched.Any() ? matched.CopyToDataTable() : full.Clone();
        }

        /// <summary>Вставляет запись. Словарь: имя_столбца → значение (без PK).</summary>
        public void InsertRecord(string tableName, Dictionary<string, object> values)
        {
            EnsureAllowed(tableName);
            var cols  = string.Join(", ", values.Keys.Select(k => $"[{k}]"));
            var marks = string.Join(", ", values.Keys.Select(_ => "?"));
            ExecuteNonQuery(
                $"INSERT INTO [{tableName}] ({cols}) VALUES ({marks})",
                values.Values.ToArray());
        }

        /// <summary>Обновляет запись по PK.</summary>
        public void UpdateRecord(string tableName, string pkColumn, object pkValue,
            Dictionary<string, object> values)
        {
            EnsureAllowed(tableName);
            var setClause = string.Join(", ", values.Keys.Select(k => $"[{k}]=?"));
            var parameters = values.Values.Append(pkValue).ToArray();
            ExecuteNonQuery(
                $"UPDATE [{tableName}] SET {setClause} WHERE [{pkColumn}]=?",
                parameters);
        }

        /// <summary>Удаляет запись по PK. Каскадное удаление задано в схеме Access.</summary>
        public void DeleteRecord(string tableName, string pkColumn, object pkValue)
        {
            EnsureAllowed(tableName);
            ExecuteNonQuery(
                $"DELETE FROM [{tableName}] WHERE [{pkColumn}]=?",
                new[] { pkValue });
        }

        // ── агрегированные запросы для отчётов ──────────────────────────────

        /// <summary>Водители по статусу.</summary>
        public DataTable ReportDriversByStatus() =>
            ExecuteQuery("SELECT Статус, Count(DriverID) AS [Кол-во] FROM Водители GROUP BY Статус");

        /// <summary>Рейсы и выручка по клиентам.</summary>
        public DataTable ReportTripsByClient() =>
            ExecuteQuery(
                "SELECT К.Название, Count(Р.TripID) AS [Рейсов], Sum(Р.Стоимость) AS [Выручка] " +
                "FROM Клиенты К INNER JOIN Рейсы Р ON К.ClientID=Р.КлиентID " +
                "GROUP BY К.Название");

        /// <summary>Загрузка транспорта.</summary>
        public DataTable ReportVehicleLoad() =>
            ExecuteQuery(
                "SELECT Т.ГосНомер, Т.Марка, Count(Р.TripID) AS [Рейсов] " +
                "FROM Транспорт Т LEFT JOIN Рейсы Р ON Т.VehicleID=Р.ТранспортID " +
                "GROUP BY Т.ГосНомер, Т.Марка");

        //приватные вспомогательные

        private DataTable ExecuteQuery(string sql, object[]? parameters = null)
        {
            using var conn    = OpenConnection();
            using var cmd     = new OleDbCommand(sql, conn);
            if (parameters != null)
                foreach (var p in parameters)
                    cmd.Parameters.AddWithValue("?", p);
            using var adapter = new OleDbDataAdapter(cmd);
            var table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        private void ExecuteNonQuery(string sql, object[] parameters)
        {
            using var conn = OpenConnection();
            using var cmd  = new OleDbCommand(sql, conn);
            foreach (var p in parameters)
                cmd.Parameters.AddWithValue("?", p);
            cmd.ExecuteNonQuery();
        }

        private OleDbConnection OpenConnection()
        {
            var conn = new OleDbConnection(_connectionString);
            conn.Open();
            return conn;
        }

        private static void EnsureAllowed(string tableName)
        {
            if (!AllowedTables.Contains(tableName))
                throw new InvalidOperationException($"Таблица '{tableName}' недоступна.");
        }
    }
}
