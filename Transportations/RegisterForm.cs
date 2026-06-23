using Transportations.BLL;

namespace Transportations
{
    /// <summary>
    /// Форма регистрации нового пользователя (роль «Наблюдатель»).
    /// </summary>
    public partial class RegisterForm
    {
        private readonly AuthService _auth;

        public RegisterForm(AuthService auth)
        {
            _auth = auth ?? throw new ArgumentNullException(nameof(auth));
            InitializeComponent();
        }

        private void btnRegister_Click(object? sender, EventArgs e) => TryRegister();
        private void btnCancel_Click(object? sender, EventArgs e)   => Close();

        private void TryRegister()
        {
            if (!InputIsValid()) return;
            try
            {
                bool ok = _auth.Register(txtLogin.Text.Trim(), txtPassword.Text);
                if (ok)
                {
                    MessageBox.Show("Регистрация успешна! Теперь войдите.",
                        "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    ShowError("Не удалось создать пользователя. Логин уже занят.");
                }
            }
            catch (Exception ex) { ShowError(ex.Message); }
        }

        private bool InputIsValid()
        {
            if (string.IsNullOrWhiteSpace(txtLogin.Text))
            { ShowError("Введите логин."); txtLogin.Focus(); return false; }

            if (txtPassword.Text.Length < 6)
            { ShowError("Пароль — минимум 6 символов."); txtPassword.Focus(); return false; }

            if (txtPassword.Text != txtConfirm.Text)
            { ShowError("Пароли не совпадают."); txtConfirm.Focus(); return false; }

            return true;
        }

        private static void ShowError(string msg) =>
            MessageBox.Show(msg, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}
