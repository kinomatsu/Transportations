#nullable enable
namespace Transportations
{
    public partial class DatabaseForm : Form
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
            panelLeft    = new Panel();
            lblTables    = new Label();
            lstTables    = new ListBox();
            panelTop     = new Panel();
            lblTableName = new Label();
            lblSearch    = new Label();
            txtSearch    = new TextBox();
            panelBottom  = new Panel();
            btnAdd       = new Button();
            btnEdit      = new Button();
            btnDelete    = new Button();
            btnRefresh   = new Button();
            dgvData      = new DataGridView();
            panelLeft.SuspendLayout();
            panelTop.SuspendLayout();
            panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            SuspendLayout();

            // panelLeft
            panelLeft.BackColor = Color.FromArgb(46, 74, 107);
            panelLeft.Dock      = DockStyle.Left;
            panelLeft.Width     = 160;
            panelLeft.Controls.AddRange(new Control[] { lblTables, lstTables });

            lblTables.Text      = "Таблицы";
            lblTables.Font      = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTables.ForeColor = Color.White;
            lblTables.Location  = new Point(10, 12);
            lblTables.Size      = new Size(140, 26);

            lstTables.Font        = new Font("Segoe UI", 10F);
            lstTables.Location    = new Point(0, 46);
            lstTables.Size        = new Size(160, 500);
            lstTables.BorderStyle = BorderStyle.None;
            lstTables.BackColor   = Color.FromArgb(60, 90, 130);
            lstTables.ForeColor   = Color.White;
            lstTables.SelectedIndexChanged += new EventHandler(lstTables_SelectedIndexChanged);

            // panelTop
            panelTop.BackColor = Color.White;
            panelTop.Dock      = DockStyle.Top;
            panelTop.Height    = 54;
            panelTop.Controls.AddRange(new Control[] { lblTableName, lblSearch, txtSearch });

            lblTableName.Text      = "—";
            lblTableName.Font      = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTableName.ForeColor = Color.FromArgb(46, 74, 107);
            lblTableName.Location  = new Point(12, 14);
            lblTableName.Size      = new Size(200, 26);

            lblSearch.Text     = "Поиск:";
            lblSearch.Font     = new Font("Segoe UI", 10F);
            lblSearch.Location = new Point(240, 16);
            lblSearch.Size     = new Size(52, 22);

            txtSearch.Font     = new Font("Segoe UI", 10F);
            txtSearch.Location = new Point(296, 14);
            txtSearch.Size     = new Size(240, 26);
            txtSearch.TextChanged += new EventHandler(txtSearch_TextChanged);

            // panelBottom
            panelBottom.BackColor = Color.FromArgb(244, 246, 250);
            panelBottom.Dock      = DockStyle.Bottom;
            panelBottom.Height    = 50;
            panelBottom.Controls.AddRange(new Control[] { btnRefresh, btnAdd, btnEdit, btnDelete });

            SetBtn(btnRefresh, "Обновить",  Color.FromArgb(80, 120, 160),  new Point(10, 10),  btnRefresh_Click);
            SetBtn(btnAdd,     "Добавить",  Color.FromArgb(46, 130, 90),   new Point(130, 10), btnAdd_Click);
            SetBtn(btnEdit,    "Изменить",  Color.FromArgb(46, 74, 107),   new Point(250, 10), btnEdit_Click);
            SetBtn(btnDelete,  "Удалить",   Color.FromArgb(180, 60, 60),   new Point(370, 10), btnDelete_Click);

            // dgvData
            dgvData.Dock                 = DockStyle.Fill;
            dgvData.AllowUserToAddRows   = false;
            dgvData.AllowUserToDeleteRows = false;
            dgvData.ReadOnly             = true;
            dgvData.SelectionMode        = DataGridViewSelectionMode.FullRowSelect;
            dgvData.BackgroundColor      = Color.White;
            dgvData.BorderStyle          = BorderStyle.None;
            dgvData.RowHeadersVisible    = false;
            dgvData.AutoSizeColumnsMode  = DataGridViewAutoSizeColumnsMode.Fill;
            dgvData.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(46, 74, 107);
            dgvData.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvData.ColumnHeadersDefaultCellStyle.Font      = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvData.EnableHeadersVisualStyles = false;

            // Form
            Text          = "База данных";
            ClientSize    = new Size(960, 600);
            StartPosition = FormStartPosition.CenterScreen;
            Controls.AddRange(new Control[] { dgvData, panelBottom, panelTop, panelLeft });
            panelLeft.ResumeLayout(false);
            panelTop.ResumeLayout(false);
            panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            ResumeLayout(false);
        }

        private static void SetBtn(Button btn, string text, Color color,
            Point loc, EventHandler handler)
        {
            btn.Text      = text;
            btn.Font      = new Font("Segoe UI", 9F, FontStyle.Bold);
            btn.BackColor = color;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Location  = loc;
            btn.Size      = new Size(110, 30);
            btn.Click    += handler;
        }

        private Panel        panelLeft   = null!;
        private Panel        panelTop    = null!;
        private Panel        panelBottom = null!;
        private Label        lblTables   = null!;
        private Label        lblTableName = null!;
        private Label        lblSearch   = null!;
        private ListBox      lstTables   = null!;
        private TextBox      txtSearch   = null!;
        private Button       btnAdd      = null!;
        private Button       btnEdit     = null!;
        private Button       btnDelete   = null!;
        private Button       btnRefresh  = null!;
        private DataGridView dgvData     = null!;
    }
}

