using Transportations.BLL;

namespace Transportations
{
    /// <summary>
    /// Личный кабинет: отображение логина/роли и смена пароля.
    /// </summary>
    public partial class ProfileForm
    {
        private readonly AuthService _auth;

        public ProfileForm(AuthService auth)
        {
            _auth = auth ?? throw new ArgumentNullException(nameof(auth));
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            lblLoginValue.Text = UserSession.CurrentLogin ?? "—";
            lblRoleValue.Text  = UserSession.CurrentRole  ?? "—";
        }

        private void btnChange_Click(object? sender, EventArgs e) => TryChangePassword();
        private void btnClose_Click(object? sender, EventArgs e)  => Close();

        private void TryChangePassword()
        {
            if (!InputIsValid()) return;
            try
            {
                bool ok = _auth.ChangePassword(txtOld.Text, txtNew.Text);
                if (ok)
                {
                    MessageBox.Show("Пароль успешно изменён.",
                        "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                }
                else { ShowError("Старый пароль введён неверно."); }
            }
            catch (Exception ex) { ShowError(ex.Message); }
        }

        private bool InputIsValid()
        {
            if (string.IsNullOrWhiteSpace(txtOld.Text))
            { ShowError("Введите старый пароль."); txtOld.Focus(); return false; }

            if (txtNew.Text.Length < 6)
            { ShowError("Новый пароль — минимум 6 символов."); txtNew.Focus(); return false; }

            if (txtNew.Text != txtConfirm.Text)
            { ShowError("Новые пароли не совпадают."); txtConfirm.Focus(); return false; }

            return true;
        }

        private void ClearFields()
        {
            txtOld.Clear();
            txtNew.Clear();
            txtConfirm.Clear();
        }

        private static void ShowError(string msg) =>
            MessageBox.Show(msg, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}
