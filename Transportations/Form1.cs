using Transportations.BLL;
using Microsoft.Extensions.DependencyInjection;

namespace Transportations
{
    /// <summary>
    /// Форма авторизации — стартовое окно приложения.
    /// </summary>
    public partial class Form1
    {
        private readonly AuthService     _auth;
        private readonly IServiceProvider _sp;

        public Form1(AuthService auth, IServiceProvider sp)
        {
            _auth = auth ?? throw new ArgumentNullException(nameof(auth));
            _sp   = sp   ?? throw new ArgumentNullException(nameof(sp));
            InitializeComponent();
        }

        //события

        private void btnLogin_Click(object? sender, EventArgs e) => TryLogin();

        private void btnRegister_Click(object? sender, EventArgs e) => OpenRegisterForm();

        private void txtPassword_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) TryLogin();
        }

        //логика

        private void TryLogin()
        {
            if (!InputIsValid()) return;
            try
            {
                bool ok = _auth.Login(txtLogin.Text.Trim(), txtPassword.Text);
                if (ok)
                    OpenMainMenu();
                else
                    ShowLoginError();
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private bool InputIsValid()
        {
            if (string.IsNullOrWhiteSpace(txtLogin.Text))
            {
                ShowError("Введите логин."); txtLogin.Focus(); return false;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                ShowError("Введите пароль."); txtPassword.Focus(); return false;
            }
            return true;
        }

        private void ShowLoginError()
        {
            ShowError("Неверный логин или пароль.");
            txtPassword.Clear();
            txtPassword.Focus();
        }

        private void OpenMainMenu()
        {
            var menu = _sp.GetRequiredService<MainMenuForm>();
            menu.FormClosed += (_, _) =>
            {
                txtPassword.Clear();
                Show();
            };
            Hide();
            menu.Show();
        }

        private void OpenRegisterForm()
        {
            using var reg = _sp.GetRequiredService<RegisterForm>();
            reg.ShowDialog(this);
        }

        private static void ShowError(string msg) =>
            MessageBox.Show(msg, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}
