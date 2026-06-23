using System.Data;
using Transportations.BLL;

namespace Transportations
{
    /// <summary>
    /// Форма отчётов с экспортом в CSV.
    /// </summary>
    public partial class ReportsForm
    {
        private readonly DataService _data;
        private DataTable _current = new();

        public ReportsForm(DataService data)
        {
            _data = data ?? throw new ArgumentNullException(nameof(data));
            InitializeComponent();
        }

        private void btnDrivers_Click(object? sender, EventArgs e) =>
            LoadReport(() => _data.ReportDriversByStatus(), "Водители по статусу");

        private void btnTrips_Click(object? sender, EventArgs e) =>
            LoadReport(() => _data.ReportTripsByClient(), "Рейсы по клиентам");

        private void btnVehicles_Click(object? sender, EventArgs e) =>
            LoadReport(() => _data.ReportVehicleLoad(), "Загрузка транспорта");

        private void btnExport_Click(object? sender, EventArgs e) => Export();
        private void btnClose_Click(object? sender, EventArgs e)  => Close();

        private void LoadReport(Func<DataTable> fn, string title)
        {
            try
            {
                _current           = fn();
                dgvReport.DataSource = _current;
                dgvReport.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                lblTitle.Text      = title;
                btnExport.Enabled  = true;
            }
            catch (Exception ex) { ShowError(ex.Message); }
        }

        private void Export()
        {
            if (_current.Rows.Count == 0) { ShowError("Нет данных для экспорта."); return; }

            using var dlg = new SaveFileDialog
            {
                Title      = "Экспорт в CSV",
                Filter     = "CSV файл (*.csv)|*.csv",
                FileName   = $"{lblTitle.Text}_{DateTime.Now:yyyyMMdd_HHmm}.csv",
                DefaultExt = "csv",
            };
            if (dlg.ShowDialog() != DialogResult.OK) return;

            try
            {
                _data.ExportToCsv(_current, dlg.FileName);
                MessageBox.Show($"Сохранено:\n{dlg.FileName}",
                    "Экспорт завершён", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { ShowError(ex.Message); }
        }

        private static void ShowError(string msg) =>
            MessageBox.Show(msg, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}
