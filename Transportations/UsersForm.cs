using System.Data;
using Transportations.BLL;

namespace Transportations
{
    /// <summary>
    /// Управление пользователями — только для Администратора.
    /// Позволяет просматривать список, менять роли и удалять пользователей.
    /// </summary>
    public partial class UsersForm
    {
        private readonly AuthService _auth;

        private static readonly string[] Roles =
            { "Администратор", "Редактор", "Сотрудник", "Наблюдатель" };

        public UsersForm(AuthService auth)
        {
            _auth = auth ?? throw new ArgumentNullException(nameof(auth));
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            cmbRole.Items.AddRange(Roles);
            LoadUsers();
        }

        //события

        private void dgvUsers_SelectionChanged(object? sender, EventArgs e) =>
            FillRoleCombo();

        private void btnSaveRole_Click(object? sender, EventArgs e) =>
            TrySaveRole();

        private void btnDelete_Click(object? sender, EventArgs e) =>
            TryDeleteUser();

        private void btnRefresh_Click(object? sender, EventArgs e) =>
            LoadUsers();

        private void btnClose_Click(object? sender, EventArgs e) =>
            Close();

        //логика

        private void LoadUsers()
        {
            try
            {
                dgvUsers.DataSource = _auth.GetAllUsers();
                dgvUsers.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception ex) { ShowError(ex.Message); }
        }

        private void FillRoleCombo()
        {
            if (dgvUsers.CurrentRow == null) return;
            var role = dgvUsers.CurrentRow.Cells["Роль"].Value?.ToString() ?? "";
            cmbRole.SelectedItem = role;
        }

        private void TrySaveRole()
        {
            if (dgvUsers.CurrentRow == null) { ShowError("Выберите пользователя."); return; }
            if (cmbRole.SelectedItem == null) { ShowError("Выберите роль."); return; }

            var login   = dgvUsers.CurrentRow.Cells["Логин"].Value?.ToString() ?? "";
            var newRole = cmbRole.SelectedItem.ToString()!;

            try
            {
                bool ok = _auth.UpdateUserRole(login, newRole);
                if (ok)
                {
                    MessageBox.Show($"Роль пользователя «{login}» изменена на «{newRole}».",
                        "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUsers();
                }
                else { ShowError("Не удалось изменить роль."); }
            }
            catch (Exception ex) { ShowError(ex.Message); }
        }

        private void TryDeleteUser()
        {
            if (dgvUsers.CurrentRow == null) { ShowError("Выберите пользователя."); return; }

            var login = dgvUsers.CurrentRow.Cells["Логин"].Value?.ToString() ?? "";
            var res = MessageBox.Show(
                $"Удалить пользователя «{login}»?",
                "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res != DialogResult.Yes) return;

            try
            {
                _auth.DeleteUser(login);
                LoadUsers();
            }
            catch (Exception ex) { ShowError(ex.Message); }
        }

        private static void ShowError(string msg) =>
            MessageBox.Show(msg, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}
