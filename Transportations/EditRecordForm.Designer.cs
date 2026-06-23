#nullable enable
namespace Transportations
{
    public partial class EditRecordForm : Form
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
            panelFields = new Panel();
            btnSave     = new Button();
            btnCancel   = new Button();
            SuspendLayout();

            // panelFields
            panelFields.AutoScroll = true;
            panelFields.BackColor  = Color.White;
            panelFields.Location   = new Point(0, 0);
            panelFields.Size       = new Size(460, 360);
            panelFields.Anchor     = AnchorStyles.Top | AnchorStyles.Left |
                                     AnchorStyles.Right | AnchorStyles.Bottom;

            // btnSave
            btnSave.Text      = "Сохранить";
            btnSave.Font      = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.BackColor = Color.FromArgb(46, 74, 107);
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Location  = new Point(10, 374);
            btnSave.Size      = new Size(210, 36);
            btnSave.Anchor    = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSave.Click    += new EventHandler(btnSave_Click);

            // btnCancel
            btnCancel.Text      = "Отмена";
            btnCancel.Font      = new Font("Segoe UI", 10F);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderColor = Color.Gray;
            btnCancel.Location  = new Point(240, 374);
            btnCancel.Size      = new Size(210, 36);
            btnCancel.Anchor    = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCancel.Click    += new EventHandler(btnCancel_Click);

            // Form
            Text            = "Запись";
            ClientSize      = new Size(460, 424);
            BackColor       = Color.White;
            StartPosition   = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox     = false;
            Controls.AddRange(new Control[] { panelFields, btnSave, btnCancel });
            ResumeLayout(false);
        }

        private Panel  panelFields = null!;
        private Button btnSave     = null!;
        private Button btnCancel   = null!;
    }
}

