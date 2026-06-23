using System.Data.OleDb;

namespace Transportations.DAL
{
    /// <summary>
    /// Работа с таблицей Пользователи: авторизация, регистрация, смена пароля.
    /// Все запросы параметризованы — защита от SQL-инъекций.
    /// </summary>
    public class DbManager : IDbManager
    {
        private readonly string _connectionString;

        public DbManager(string connectionString)
        {
            _connectionString = connectionString
                ?? throw new ArgumentNullException(nameof(connectionString));
        }

        /// <inheritdoc/>
        public string? ValidateUser(string login, string hashedPassword)
        {
            const string sql = "SELECT Роль FROM Пользователи WHERE Логин=? AND Пароль=?";
            using var conn = OpenConnection();
            using var cmd = new OleDbCommand(sql, conn);
            cmd.Parameters.AddWithValue("?", login);
            cmd.Parameters.AddWithValue("?", hashedPassword);
            return cmd.ExecuteScalar()?.ToString();
        }

        /// <inheritdoc/>
        public bool CreateUser(string login, string hashedPassword, string role)
        {
            const string sql = "INSERT INTO Пользователи (Логин, Пароль, Роль) VALUES (?, ?, ?)";
            using var conn = OpenConnection();
            using var cmd = new OleDbCommand(sql, conn);
            cmd.Parameters.AddWithValue("?", login);
            cmd.Parameters.AddWithValue("?", hashedPassword);
            cmd.Parameters.AddWithValue("?", role);
            return cmd.ExecuteNonQuery() > 0;
        }

        /// <inheritdoc/>
        public bool ChangePassword(string login, string oldHashedPassword, string newHashedPassword)
        {
            const string sql = "UPDATE Пользователи SET Пароль=? WHERE Логин=? AND Пароль=?";
            using var conn = OpenConnection();
            using var cmd = new OleDbCommand(sql, conn);
            cmd.Parameters.AddWithValue("?", newHashedPassword);
            cmd.Parameters.AddWithValue("?", login);
            cmd.Parameters.AddWithValue("?", oldHashedPassword);
            return cmd.ExecuteNonQuery() > 0;
        }

        /// <inheritdoc/>
        public System.Data.DataTable GetAllUsers()
        {
            const string sql = "SELECT Логин, Роль FROM Пользователи ORDER BY Логин";
            using var conn = OpenConnection();
            using var cmd  = new OleDbCommand(sql, conn);
            using var ada  = new OleDbDataAdapter(cmd);
            var table = new System.Data.DataTable();
            ada.Fill(table);
            return table;
        }

        /// <inheritdoc/>
        public bool UpdateUserRole(string login, string newRole)
        {
            const string sql = "UPDATE Пользователи SET Роль=? WHERE Логин=?";
            using var conn = OpenConnection();
            using var cmd  = new OleDbCommand(sql, conn);
            cmd.Parameters.AddWithValue("?", newRole);
            cmd.Parameters.AddWithValue("?", login);
            return cmd.ExecuteNonQuery() > 0;
        }

        /// <inheritdoc/>
        public bool DeleteUser(string login)
        {
            const string sql = "DELETE FROM Пользователи WHERE Логин=?";
            using var conn = OpenConnection();
            using var cmd  = new OleDbCommand(sql, conn);
            cmd.Parameters.AddWithValue("?", login);
            return cmd.ExecuteNonQuery() > 0;
        }

        private OleDbConnection OpenConnection()
        {
            var conn = new OleDbConnection(_connectionString);
            conn.Open();
            return conn;
        }
    }
}
