#nullable enable
namespace Transportations
{
    public partial class ReportsForm : Form
    {
        private System.ComponentModel.IContainer? components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            panelLeft = new Panel();
            lblMenu = new Label();
            btnDrivers = new Button();
            btnTrips = new Button();
            btnVehicles = new Button();
            panelTop = new Panel();
            lblTitle = new Label();
            panelBottom = new Panel();
            btnExport = new Button();
            btnClose = new Button();
            dgvReport = new DataGridView();
            panelLeft.SuspendLayout();
            panelTop.SuspendLayout();
            panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReport).BeginInit();
            SuspendLayout();
            // 
            // panelLeft
            // 
            panelLeft.BackColor = Color.FromArgb(46, 74, 107);
            panelLeft.Controls.Add(lblMenu);
            panelLeft.Controls.Add(btnDrivers);
            panelLeft.Controls.Add(btnTrips);
            panelLeft.Controls.Add(btnVehicles);
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Location = new Point(0, 0);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(200, 520);
            panelLeft.TabIndex = 3;
            // 
            // lblMenu
            // 
            lblMenu.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblMenu.ForeColor = Color.White;
            lblMenu.Location = new Point(10, 14);
            lblMenu.Name = "lblMenu";
            lblMenu.Size = new Size(180, 28);
            lblMenu.TabIndex = 0;
            lblMenu.Text = "Отчёты";
            // 
            // btnDrivers
            // 
            btnDrivers.Location = new Point(0, 0);
            btnDrivers.Name = "btnDrivers";
            btnDrivers.Size = new Size(75, 23);
            btnDrivers.TabIndex = 1;
            // 
            // btnTrips
            // 
            btnTrips.Location = new Point(0, 0);
            btnTrips.Name = "btnTrips";
            btnTrips.Size = new Size(75, 23);
            btnTrips.TabIndex = 2;
            // 
            // btnVehicles
            // 
            btnVehicles.Location = new Point(0, 0);
            btnVehicles.Name = "btnVehicles";
            btnVehicles.Size = new Size(75, 23);
            btnVehicles.TabIndex = 3;
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.White;
            panelTop.Controls.Add(lblTitle);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(200, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(660, 46);
            panelTop.TabIndex = 2;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(46, 74, 107);
            lblTitle.Location = new Point(14, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(600, 26);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Выберите отчёт";
            // 
            // panelBottom
            // 
            panelBottom.BackColor = Color.FromArgb(244, 246, 250);
            panelBottom.Controls.Add(btnExport);
            panelBottom.Controls.Add(btnClose);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(200, 472);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(660, 48);
            panelBottom.TabIndex = 1;
            // 
            // btnExport
            // 
            btnExport.BackColor = Color.FromArgb(46, 130, 90);
            btnExport.Enabled = false;
            btnExport.FlatAppearance.BorderSize = 0;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnExport.ForeColor = Color.White;
            btnExport.Location = new Point(10, 10);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(140, 30);
            btnExport.TabIndex = 0;
            btnExport.Text = "Экспорт в CSV";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += btnExport_Click;
            // 
            // btnClose
            // 
            btnClose.FlatAppearance.BorderColor = Color.Gray;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 9F);
            btnClose.Location = new Point(164, 10);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(110, 30);
            btnClose.TabIndex = 1;
            btnClose.Text = "Закрыть";
            btnClose.Click += btnClose_Click;
            // 
            // dgvReport
            // 
            dgvReport.AllowUserToAddRows = false;
            dgvReport.AllowUserToDeleteRows = false;
            dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReport.BackgroundColor = Color.White;
            dgvReport.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(46, 74, 107);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvReport.Dock = DockStyle.Fill;
            dgvReport.EnableHeadersVisualStyles = false;
            dgvReport.Location = new Point(200, 46);
            dgvReport.Name = "dgvReport";
            dgvReport.ReadOnly = true;
            dgvReport.RowHeadersVisible = false;
            dgvReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReport.Size = new Size(660, 426);
            dgvReport.TabIndex = 0;
            // 
            // ReportsForm
            // 
            ClientSize = new Size(860, 520);
            Controls.Add(dgvReport);
            Controls.Add(panelBottom);
            Controls.Add(panelTop);
            Controls.Add(panelLeft);
            Name = "ReportsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Отчёты";
            panelLeft.ResumeLayout(false);
            panelTop.ResumeLayout(false);
            panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvReport).EndInit();
            ResumeLayout(false);
        }

        private static void SetRptBtn(Button btn, string text, Point loc, EventHandler h)
        {
            btn.Text      = text;
            btn.Font      = new Font("Segoe UI", 9F);
            btn.BackColor = Color.FromArgb(60, 100, 150);
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Padding   = new Padding(8, 0, 0, 0);
            btn.Location  = loc;
            btn.Size      = new Size(180, 54);
            btn.Click    += h;
        }

        private Panel        panelLeft   = null!;
        private Panel        panelTop    = null!;
        private Panel        panelBottom = null!;
        private Label        lblMenu     = null!;
        private Label        lblTitle    = null!;
        private Button       btnDrivers  = null!;
        private Button       btnTrips    = null!;
        private Button       btnVehicles = null!;
        private Button       btnExport   = null!;
        private Button       btnClose    = null!;
        private DataGridView dgvReport   = null!;
    }
}

