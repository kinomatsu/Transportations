using Transportations.BLL;
using Microsoft.Extensions.DependencyInjection;

namespace Transportations
{
    /// <summary>
    /// Главное меню: навигационные карточки разделов.
    /// </summary>
    public partial class MainMenuForm
    {
        private readonly AuthService      _auth;
        private readonly IServiceProvider _sp;

        public MainMenuForm(AuthService auth, IServiceProvider sp)
        {
            _auth = auth ?? throw new ArgumentNullException(nameof(auth));
            _sp   = sp   ?? throw new ArgumentNullException(nameof(sp));
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            lblWelcome.Text = $"  {UserSession.CurrentLogin}  [{UserSession.CurrentRole}]";
            btnUsers.Visible = UserSession.IsAdmin;
        }

        private void btnDatabase_Click(object? sender, EventArgs e) =>
            _sp.GetRequiredService<DatabaseForm>().ShowDialog(this);

        private void btnReports_Click(object? sender, EventArgs e)
        {
            if (!UserSession.CanViewReports)
            { Warn("Отчёты доступны Администратору, Редактору и Сотруднику."); return; }
            _sp.GetRequiredService<ReportsForm>().ShowDialog(this);
        }

        private void btnProfile_Click(object? sender, EventArgs e) =>
            _sp.GetRequiredService<ProfileForm>().ShowDialog(this);

        private void btnUsers_Click(object? sender, EventArgs e) =>
            _sp.GetRequiredService<UsersForm>().ShowDialog(this);

        private void btnLogout_Click(object? sender, EventArgs e)
        {
            _auth.LogOut();
            Close();
        }

        private static void Warn(string msg) =>
            MessageBox.Show(msg, "Доступ запрещён", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}
