#nullable enable
namespace Transportations
{
    public partial class RegisterForm : Form
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
            lblTitle    = new Label();
            lblLogin    = new Label();
            txtLogin    = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblConfirm  = new Label();
            txtConfirm  = new TextBox();
            btnRegister = new Button();
            btnCancel   = new Button();
            SuspendLayout();

            // lblTitle
            lblTitle.Text      = "Регистрация";
            lblTitle.Font      = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(46, 74, 107);
            lblTitle.Location  = new Point(20, 16);
            lblTitle.Size      = new Size(320, 34);
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // lblLogin
            lblLogin.Text     = "Логин";
            lblLogin.Font     = new Font("Segoe UI", 10F);
            lblLogin.Location = new Point(30, 64);
            lblLogin.Size     = new Size(100, 22);

            // txtLogin
            txtLogin.Font     = new Font("Segoe UI", 10F);
            txtLogin.Location = new Point(30, 88);
            txtLogin.Size     = new Size(300, 26);

            // lblPassword
            lblPassword.Text     = "Пароль";
            lblPassword.Font     = new Font("Segoe UI", 10F);
            lblPassword.Location = new Point(30, 128);
            lblPassword.Size     = new Size(100, 22);

            // txtPassword
            txtPassword.Font         = new Font("Segoe UI", 10F);
            txtPassword.PasswordChar = '●';
            txtPassword.Location     = new Point(30, 152);
            txtPassword.Size         = new Size(300, 26);

            // lblConfirm
            lblConfirm.Text     = "Повторите пароль";
            lblConfirm.Font     = new Font("Segoe UI", 10F);
            lblConfirm.Location = new Point(30, 192);
            lblConfirm.Size     = new Size(150, 22);

            // txtConfirm
            txtConfirm.Font         = new Font("Segoe UI", 10F);
            txtConfirm.PasswordChar = '●';
            txtConfirm.Location     = new Point(30, 216);
            txtConfirm.Size         = new Size(300, 26);

            // btnRegister
            btnRegister.Text      = "Зарегистрироваться";
            btnRegister.Font      = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRegister.BackColor = Color.FromArgb(46, 74, 107);
            btnRegister.ForeColor = Color.White;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.Location  = new Point(30, 264);
            btnRegister.Size      = new Size(300, 36);
            btnRegister.Click    += new EventHandler(btnRegister_Click);

            // btnCancel
            btnCancel.Text      = "Отмена";
            btnCancel.Font      = new Font("Segoe UI", 9F);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderColor = Color.Gray;
            btnCancel.Location  = new Point(30, 310);
            btnCancel.Size      = new Size(300, 30);
            btnCancel.Click    += new EventHandler(btnCancel_Click);

            // Form
            Text            = "Регистрация";
            ClientSize      = new Size(360, 364);
            BackColor       = Color.White;
            StartPosition   = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox     = false;
            Controls.AddRange(new Control[] {
                lblTitle, lblLogin, txtLogin, lblPassword, txtPassword,
                lblConfirm, txtConfirm, btnRegister, btnCancel });
            ResumeLayout(false);
        }

        private Label   lblTitle    = null!;
        private Label   lblLogin    = null!;
        private Label   lblPassword = null!;
        private Label   lblConfirm  = null!;
        private TextBox txtLogin    = null!;
        private TextBox txtPassword = null!;
        private TextBox txtConfirm  = null!;
        private Button  btnRegister = null!;
        private Button  btnCancel   = null!;
    }
}

