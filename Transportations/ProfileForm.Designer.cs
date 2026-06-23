#nullable enable
namespace Transportations
{
    public partial class ProfileForm : Form
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
            lblTitle       = new Label();
            lblLogin       = new Label();
            lblLoginValue  = new Label();
            lblRole        = new Label();
            lblRoleValue   = new Label();
            grpPassword    = new GroupBox();
            lblOld         = new Label();
            txtOld         = new TextBox();
            lblNew         = new Label();
            txtNew         = new TextBox();
            lblConfirmLbl  = new Label();
            txtConfirm     = new TextBox();
            btnChange      = new Button();
            btnClose       = new Button();
            grpPassword.SuspendLayout();
            SuspendLayout();

            // lblTitle
            lblTitle.Text      = "Личный кабинет";
            lblTitle.Font      = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(46, 74, 107);
            lblTitle.Location  = new Point(20, 16);
            lblTitle.Size      = new Size(360, 30);

            // info rows
            Row(lblLogin, lblLoginValue, "Логин:", 62);
            Row(lblRole,  lblRoleValue,  "Роль:",  92);
            lblRoleValue.ForeColor = Color.FromArgb(46, 74, 107);

            // grpPassword
            grpPassword.Text     = "Смена пароля";
            grpPassword.Font     = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpPassword.Location = new Point(20, 130);
            grpPassword.Size     = new Size(360, 224);
            grpPassword.Controls.AddRange(new Control[] {
                lblOld, txtOld, lblNew, txtNew, lblConfirmLbl, txtConfirm, btnChange });

            GrpRow(lblOld,       txtOld,     "Старый пароль",  28);
            GrpRow(lblNew,       txtNew,     "Новый пароль",   84);
            GrpRow(lblConfirmLbl, txtConfirm, "Повторите новый", 140);

            txtOld.PasswordChar     = '●';
            txtNew.PasswordChar     = '●';
            txtConfirm.PasswordChar = '●';

            btnChange.Text      = "Сменить пароль";
            btnChange.Font      = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnChange.BackColor = Color.FromArgb(46, 74, 107);
            btnChange.ForeColor = Color.White;
            btnChange.FlatStyle = FlatStyle.Flat;
            btnChange.FlatAppearance.BorderSize = 0;
            btnChange.Location  = new Point(10, 184);
            btnChange.Size      = new Size(340, 30);
            btnChange.Click    += new EventHandler(btnChange_Click);

            // btnClose
            btnClose.Text      = "Закрыть";
            btnClose.Font      = new Font("Segoe UI", 9F);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderColor = Color.Gray;
            btnClose.Location  = new Point(20, 368);
            btnClose.Size      = new Size(360, 30);
            btnClose.Click    += new EventHandler(btnClose_Click);

            // Form
            Text            = "Профиль";
            ClientSize      = new Size(400, 418);
            BackColor       = Color.White;
            StartPosition   = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox     = false;
            Controls.AddRange(new Control[] {
                lblTitle, lblLogin, lblLoginValue, lblRole, lblRoleValue,
                grpPassword, btnClose });
            grpPassword.ResumeLayout(false);
            ResumeLayout(false);
        }

        private static void Row(Label lbl, Label val, string text, int y)
        {
            lbl.Text     = text;
            lbl.Font     = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbl.Location = new Point(20, y);
            lbl.Size     = new Size(80, 22);

            val.Font     = new Font("Segoe UI", 10F);
            val.Location = new Point(110, y);
            val.Size     = new Size(260, 22);
        }

        private static void GrpRow(Label lbl, TextBox txt, string text, int y)
        {
            lbl.Text     = text;
            lbl.Font     = new Font("Segoe UI", 9F);
            lbl.Location = new Point(10, y);
            lbl.Size     = new Size(130, 20);

            txt.Font     = new Font("Segoe UI", 10F);
            txt.Location = new Point(148, y - 2);
            txt.Size     = new Size(200, 26);
        }

        private Label    lblTitle      = null!;
        private Label    lblLogin      = null!;
        private Label    lblLoginValue = null!;
        private Label    lblRole       = null!;
        private Label    lblRoleValue  = null!;
        private GroupBox grpPassword   = null!;
        private Label    lblOld        = null!;
        private Label    lblNew        = null!;
        private Label    lblConfirmLbl = null!;
        private TextBox  txtOld        = null!;
        private TextBox  txtNew        = null!;
        private TextBox  txtConfirm    = null!;
        private Button   btnChange     = null!;
        private Button   btnClose      = null!;
    }
}

