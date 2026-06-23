using Transportations.DAL;

namespace Transportations.BLL
{
    /// <summary>
    /// Авторизация, регистрация, смена пароля.
    /// Брутфорс-защита: 3 ошибки → блокировка на 30 минут.
    /// </summary>
    public class AuthService
    {
        private readonly IDbManager _db;
        private int      _failedAttempts;
        private DateTime? _lockoutEnd;

        public AuthService(IDbManager db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        /// <summary>
        /// Выполняет вход по логину и открытому паролю.
        /// Бросает <see cref="Exception"/> при активной блокировке.
        /// </summary>
        public bool Login(string login, string plainPassword)
        {
            if (IsLockedOut())
                ThrowLockoutException();

            var hashed = PasswordHasher.Hash(plainPassword);
            var role   = _db.ValidateUser(login, hashed);

            if (role != null)
            {
                ResetFailures();
                UserSession.Start(login, role);
                return true;
            }

            RegisterFailedAttempt();
            return false;
        }

        /// <summary>
        /// Регистрирует нового пользователя с ролью «Наблюдатель».
        /// </summary>
        public bool Register(string login, string plainPassword)
        {
            if (string.IsNullOrWhiteSpace(login))
                throw new ArgumentException("Логин не может быть пустым.");
            if (plainPassword.Length < 6)
                throw new ArgumentException("Пароль должен содержать не менее 6 символов.");

            var hashed = PasswordHasher.Hash(plainPassword);
            return _db.CreateUser(login.Trim(), hashed, "Наблюдатель");
        }

        /// <summary>Меняет пароль текущего пользователя.</summary>
        public bool ChangePassword(string oldPlain, string newPlain)
        {
            if (!UserSession.IsAuthenticated)
                throw new InvalidOperationException("Пользователь не авторизован.");
            if (newPlain.Length < 6)
                throw new ArgumentException("Новый пароль должен содержать не менее 6 символов.");

            var oldHashed = PasswordHasher.Hash(oldPlain);
            var newHashed = PasswordHasher.Hash(newPlain);
            return _db.ChangePassword(UserSession.CurrentLogin!, oldHashed, newHashed);
        }

        /// <summary>Завершает сессию.</summary>
        public void LogOut() => UserSession.Clear();

        /// <summary>Возвращает всех пользователей (только Администратор).</summary>
        public System.Data.DataTable GetAllUsers()
        {
            if (!UserSession.IsAdmin)
                throw new UnauthorizedAccessException("Только Администратор может управлять пользователями.");
            return _db.GetAllUsers();
        }

        /// <summary>Меняет роль пользователя (только Администратор).</summary>
        public bool UpdateUserRole(string login, string newRole)
        {
            if (!UserSession.IsAdmin)
                throw new UnauthorizedAccessException("Только Администратор может менять роли.");
            if (string.IsNullOrWhiteSpace(login)) throw new ArgumentException("Логин не задан.");
            if (string.IsNullOrWhiteSpace(newRole)) throw new ArgumentException("Роль не задана.");
            return _db.UpdateUserRole(login, newRole);
        }

        /// <summary>Удаляет пользователя (только Администратор, нельзя удалить себя).</summary>
        public bool DeleteUser(string login)
        {
            if (!UserSession.IsAdmin)
                throw new UnauthorizedAccessException("Только Администратор может удалять пользователей.");
            if (login == UserSession.CurrentLogin)
                throw new InvalidOperationException("Нельзя удалить собственную учётную запись.");
            return _db.DeleteUser(login);
        }

        // ── приватные вспомогательные ────────────────────────────────────────

        private bool IsLockedOut() =>
            _lockoutEnd.HasValue && DateTime.Now < _lockoutEnd.Value;

        private void ThrowLockoutException()
        {
            var remaining = (int)Math.Ceiling((_lockoutEnd!.Value - DateTime.Now).TotalMinutes);
            throw new Exception($"Слишком много попыток. Повторите через {remaining} мин.");
        }

        private void ResetFailures()
        {
            _failedAttempts = 0;
            _lockoutEnd     = null;
        }

        private void RegisterFailedAttempt()
        {
            _failedAttempts++;
            if (_failedAttempts >= 3)
                _lockoutEnd = DateTime.Now.AddMinutes(30);
        }
    }
}
