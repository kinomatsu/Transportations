namespace Transportations.BLL
{
    /// <summary>
    /// Статический контейнер текущей сессии пользователя.
    /// Роли: Администратор, Редактор, Сотрудник, Наблюдатель.
    /// </summary>
    public static class UserSession
    {
        public static string? CurrentLogin { get; private set; }
        public static string? CurrentRole  { get; private set; }

        public static bool IsAuthenticated  => CurrentLogin != null;
        public static bool IsAdmin          => CurrentRole == "Администратор";
        public static bool CanEdit          => CurrentRole is "Администратор" or "Редактор";
        public static bool CanViewReports   => CurrentRole is "Администратор" or "Редактор" or "Сотрудник";

        /// <summary>Запускает сессию после успешной авторизации.</summary>
        public static void Start(string login, string role)
        {
            CurrentLogin = login ?? throw new ArgumentNullException(nameof(login));
            CurrentRole  = role  ?? throw new ArgumentNullException(nameof(role));
        }

        /// <summary>Очищает сессию при выходе.</summary>
        public static void Clear()
        {
            CurrentLogin = null;
            CurrentRole  = null;
        }
    }
}
