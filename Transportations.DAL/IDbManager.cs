namespace Transportations.DAL
{
    /// <summary>
    /// Контракт менеджера пользователей БД — позволяет мокировать в тестах.
    /// </summary>
    public interface IDbManager
    {
        /// <summary>Проверяет пару логин/хеш-пароль. Возвращает роль или null.</summary>
        string? ValidateUser(string login, string hashedPassword);

        /// <summary>Создаёт нового пользователя.</summary>
        bool CreateUser(string login, string hashedPassword, string role);

        /// <summary>Обновляет хеш пароля пользователя.</summary>
        bool ChangePassword(string login, string oldHashedPassword, string newHashedPassword);

        /// <summary>Возвращает всех пользователей (логин + роль).</summary>
        System.Data.DataTable GetAllUsers();

        /// <summary>Обновляет роль пользователя.</summary>
        bool UpdateUserRole(string login, string newRole);

        /// <summary>Удаляет пользователя по логину.</summary>
        bool DeleteUser(string login);
    }
}
