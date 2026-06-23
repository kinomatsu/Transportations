using System.Data;
using Transportations.BLL;
using Transportations.DAL;
using Microsoft.Extensions.DependencyInjection;

namespace Transportations
{
    /// <summary>
    /// Форма работы с таблицами: просмотр, поиск, сортировка, CRUD.
    /// </summary>
    public partial class DatabaseForm
    {
        private readonly DataService      _data;
        private readonly IServiceProvider _sp;

        private string    _currentTable = string.Empty;
        private DataTable _currentData  = new();

        public DatabaseForm(DataService data, IServiceProvider sp)
        {
            _data = data ?? throw new ArgumentNullException(nameof(data));
            _sp   = sp   ?? throw new ArgumentNullException(nameof(sp));
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ConfigureButtonsByRole();
            LoadTableList();
        }

        private void lstTables_SelectedIndexChanged(object? sender, EventArgs e) =>
            LoadSelectedTable();

        private void txtSearch_TextChanged(object? sender, EventArgs e) =>
            ApplySearch();

        private void btnAdd_Click(object? sender, EventArgs e)     => OpenEditDialog(isNew: true);
        private void btnEdit_Click(object? sender, EventArgs e)    => OpenEditDialog(isNew: false);
        private void btnDelete_Click(object? sender, EventArgs e)  => DeleteSelectedRow();
        private void btnRefresh_Click(object? sender, EventArgs e) => ReloadCurrentTable();

        //данные

        private void LoadTableList()
        {
            lstTables.Items.Clear();
            foreach (var t in DataRepository.AllowedTables)
                lstTables.Items.Add(t);
        }

        private void LoadSelectedTable()
        {
            if (lstTables.SelectedItem == null) return;
            _currentTable = lstTables.SelectedItem.ToString()!;
            ReloadCurrentTable();
        }

        private void ReloadCurrentTable()
        {
            if (string.IsNullOrEmpty(_currentTable)) return;
            try
            {
                _currentData       = _data.GetTable(_currentTable);
                dgvData.DataSource = _currentData;
                dgvData.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                lblTableName.Text  = _currentTable;
                txtSearch.Clear();
            }
            catch (Exception ex) { ShowError(ex.Message); }
        }

        private void ApplySearch()
        {
            if (string.IsNullOrEmpty(_currentTable)) return;
            try
            {
                dgvData.DataSource = _data.Search(_currentTable, txtSearch.Text);
            }
            catch (Exception ex) { ShowError(ex.Message); }
        }

        //CRUD

        private void OpenEditDialog(bool isNew)
        {
            if (string.IsNullOrEmpty(_currentTable)) { ShowError("Выберите таблицу."); return; }
            if (!isNew && dgvData.CurrentRow == null) { ShowError("Выберите строку."); return; }

            var form = _sp.GetRequiredService<EditRecordForm>();
            form.Init(_currentTable, isNew ? null : GetCurrentRowValues());
            if (form.ShowDialog(this) == DialogResult.OK)
                ReloadCurrentTable();
        }

        private void DeleteSelectedRow()
        {
            if (string.IsNullOrEmpty(_currentTable)) { ShowError("Выберите таблицу."); return; }
            if (dgvData.CurrentRow == null)           { ShowError("Выберите строку."); return; }

            var res = MessageBox.Show(
                "Удалить выбранную запись? Связанные данные тоже будут удалены (каскад).",
                "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res != DialogResult.Yes) return;

            try
            {
                var pk      = DataService.GetPrimaryKey(_currentTable);
                var pkValue = dgvData.CurrentRow.Cells[pk].Value;
                _data.Delete(_currentTable, pkValue);
                ReloadCurrentTable();
            }
            catch (Exception ex) { ShowError(ex.Message); }
        }

        private Dictionary<string, object> GetCurrentRowValues() =>
            dgvData.CurrentRow!.Cells
                .Cast<DataGridViewCell>()
                .ToDictionary(c => c.OwningColumn.Name, c => c.Value ?? DBNull.Value);

        private void ConfigureButtonsByRole()
        {
            btnAdd.Visible    = UserSession.CanEdit;
            btnEdit.Visible   = UserSession.CanEdit;
            btnDelete.Visible = UserSession.IsAdmin;
        }

        private static void ShowError(string msg) =>
            MessageBox.Show(msg, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}
