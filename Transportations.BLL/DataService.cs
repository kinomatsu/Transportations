using System.Data;
using System.Text;
using Transportations.DAL;

namespace Transportations.BLL
{
    /// <summary>
    /// Сервис работы с таблицами: проверка прав доступа + делегирование в репозиторий.
    /// </summary>
    public class DataService
    {
        private readonly DataRepository _repo;

        /// <summary>PK-столбцы по имени таблицы.</summary>
        private static readonly Dictionary<string, string> PrimaryKeys = new()
        {
            ["Водители"]  = "DriverID",
            ["Грузы"]     = "CargoID",
            ["Клиенты"]   = "ClientID",
            ["Рейсы"]     = "TripID",
            ["Транспорт"] = "VehicleID",
        };

        public DataService(DataRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        /// <summary>Возвращает все строки таблицы.</summary>
        public DataTable GetTable(string tableName) => _repo.GetTable(tableName);

        /// <summary>Поиск по всем столбцам таблицы.</summary>
        public DataTable Search(string tableName, string text) =>
            _repo.SearchTable(tableName, text);

        /// <summary>Возвращает имя PK-столбца для таблицы.</summary>
        public static string GetPrimaryKey(string tableName) =>
            PrimaryKeys.TryGetValue(tableName, out var pk)
                ? pk
                : throw new InvalidOperationException($"PK для '{tableName}' не задан.");

        /// <summary>Добавляет запись (Администратор, Редактор).</summary>
        public void Insert(string tableName, Dictionary<string, object> values)
        {
            EnsureCanEdit();
            _repo.InsertRecord(tableName, values);
        }

        /// <summary>Обновляет запись (Администратор, Редактор).</summary>
        public void Update(string tableName, object pkValue, Dictionary<string, object> values)
        {
            EnsureCanEdit();
            var pk = GetPrimaryKey(tableName);
            _repo.UpdateRecord(tableName, pk, pkValue, values);
        }

        /// <summary>Удаляет запись (только Администратор).</summary>
        public void Delete(string tableName, object pkValue)
        {
            if (!UserSession.IsAdmin)
                throw new UnauthorizedAccessException("Удаление доступно только Администратору.");
            var pk = GetPrimaryKey(tableName);
            _repo.DeleteRecord(tableName, pk, pkValue);
        }

        // ── отчёты ──────────────────────────────────────────────────────────

        public DataTable ReportDriversByStatus() => _repo.ReportDriversByStatus();
        public DataTable ReportTripsByClient()   => _repo.ReportTripsByClient();
        public DataTable ReportVehicleLoad()     => _repo.ReportVehicleLoad();

        /// <summary>
        /// Экспортирует DataTable в CSV (UTF-8, разделитель «;»).
        /// </summary>
        public void ExportToCsv(DataTable table, string filePath)
        {
            ArgumentNullException.ThrowIfNull(table);
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("Путь файла не задан.");

            var sb = new StringBuilder();

            // заголовок
            sb.AppendLine(string.Join(";",
                table.Columns.Cast<DataColumn>().Select(c => CsvEscape(c.ColumnName))));

            // строки
            foreach (DataRow row in table.Rows)
                sb.AppendLine(string.Join(";",
                    row.ItemArray.Select(v => CsvEscape(v?.ToString() ?? ""))));

            File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
        }

        // ── приватные ────────────────────────────────────────────────────────

        private static void EnsureCanEdit()
        {
            if (!UserSession.CanEdit)
                throw new UnauthorizedAccessException("Недостаточно прав для редактирования.");
        }

        private static string CsvEscape(string value) =>
            value.Contains(';') || value.Contains('"') || value.Contains('\n')
                ? $"\"{value.Replace("\"", "\"\"")}\""
                : value;
    }
}
