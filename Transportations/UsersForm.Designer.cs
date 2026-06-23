#nullable enable
namespace Transportations
{
    public partial class UsersForm : Form
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
            panelTop    = new Panel();
            lblTitle    = new Label();
            dgvUsers    = new DataGridView();
            panelBottom = new Panel();
            lblRole     = new Label();
            cmbRole     = new ComboBox();
            btnSaveRole = new Button();
            btnDelete   = new Button();
            btnRefresh  = new Button();
            btnClose    = new Button();
            panelTop.SuspendLayout();
            panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            SuspendLayout();

            // panelTop
            panelTop.BackColor = Color.FromArgb(46, 74, 107);
            panelTop.Dock      = DockStyle.Top;
            panelTop.Height    = 50;
            panelTop.Controls.Add(lblTitle);

            lblTitle.Text      = "Управление пользователями";
            lblTitle.Font      = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location  = new Point(16, 10);
            lblTitle.Size      = new Size(400, 30);

            // dgvUsers
            dgvUsers.Dock                  = DockStyle.Fill;
            dgvUsers.AllowUserToAddRows    = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.ReadOnly              = true;
            dgvUsers.SelectionMode         = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.MultiSelect           = false;
            dgvUsers.BackgroundColor       = Color.White;
            dgvUsers.BorderStyle           = BorderStyle.None;
            dgvUsers.RowHeadersVisible     = false;
            dgvUsers.AutoSizeColumnsMode   = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(46, 74, 107);
            dgvUsers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvUsers.ColumnHeadersDefaultCellStyle.Font      = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvUsers.EnableHeadersVisualStyles = false;
            dgvUsers.SelectionChanged += new EventHandler(dgvUsers_SelectionChanged);

            // panelBottom
            panelBottom.BackColor = Color.FromArgb(244, 246, 250);
            panelBottom.Dock      = DockStyle.Bottom;
            panelBottom.Height    = 56;
            panelBottom.Controls.AddRange(new Control[] {
                lblRole, cmbRole, btnSaveRole, btnDelete, btnRefresh, btnClose });

            lblRole.Text     = "Роль:";
            lblRole.Font     = new Font("Segoe UI", 10F);
            lblRole.Location = new Point(10, 16);
            lblRole.Size     = new Size(40, 22);

            cmbRole.Font          = new Font("Segoe UI", 10F);
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.Location      = new Point(54, 13);
            cmbRole.Size          = new Size(160, 26);

            SetBtn(btnSaveRole, "Сохранить роль", Color.FromArgb(46, 74, 107),   new Point(228, 13), btnSaveRole_Click);
            SetBtn(btnDelete,   "Удалить",         Color.FromArgb(180, 60, 60),   new Point(358, 13), btnDelete_Click);
            SetBtn(btnRefresh,  "Обновить",        Color.FromArgb(80, 120, 160),  new Point(488, 13), btnRefresh_Click);
            SetBtn(btnClose,    "Закрыть",         Color.FromArgb(120, 120, 120), new Point(618, 13), btnClose_Click);

            // Form
            Text            = "Пользователи";
            ClientSize      = new Size(760, 440);
            StartPosition   = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox     = false;
            Controls.AddRange(new Control[] { dgvUsers, panelBottom, panelTop });
            panelTop.ResumeLayout(false);
            panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
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
            btn.Size      = new Size(120, 30);
            btn.Click    += handler;
        }

        private Panel        panelTop    = null!;
        private Panel        panelBottom = null!;
        private Label        lblTitle    = null!;
        private Label        lblRole     = null!;
        private DataGridView dgvUsers    = null!;
        private ComboBox     cmbRole     = null!;
        private Button       btnSaveRole = null!;
        private Button       btnDelete   = null!;
        private Button       btnRefresh  = null!;
        private Button       btnClose    = null!;
    }
}
