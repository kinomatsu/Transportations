#nullable enable
namespace Transportations
{
    public partial class Form1 : Form
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
            lblPassword = new Label();
            txtLogin    = new TextBox();
            txtPassword = new TextBox();
            btnLogin    = new Button();
            btnRegister = new Button();
            panelMain   = new Panel();
            panelMain.SuspendLayout();
            SuspendLayout();

            panelMain.BackColor   = Color.White;
            panelMain.BorderStyle = BorderStyle.FixedSingle;
            panelMain.Location    = new Point(200, 100);
            panelMain.Size        = new Size(400, 340);
            panelMain.Controls.AddRange(new Control[] {
                lblTitle, lblLogin, txtLogin, lblPassword, txtPassword, btnLogin, btnRegister });

            lblTitle.Text      = "Транспортная компания";
            lblTitle.Font      = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(46, 74, 107);
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.Location  = new Point(20, 20);
            lblTitle.Size      = new Size(355, 40);

            lblLogin.Text     = "Логин";
            lblLogin.Font     = new Font("Segoe UI", 10F);
            lblLogin.Location = new Point(40, 80);
            lblLogin.Size     = new Size(60, 22);

            txtLogin.Font     = new Font("Segoe UI", 10F);
            txtLogin.Location = new Point(40, 104);
            txtLogin.Size     = new Size(316, 26);

            lblPassword.Text     = "Пароль";
            lblPassword.Font     = new Font("Segoe UI", 10F);
            lblPassword.Location = new Point(40, 148);
            lblPassword.Size     = new Size(60, 22);

            txtPassword.Font         = new Font("Segoe UI", 10F);
            txtPassword.PasswordChar = '●';
            txtPassword.Location     = new Point(40, 172);
            txtPassword.Size         = new Size(316, 26);
            txtPassword.KeyDown     += txtPassword_KeyDown;

            btnLogin.Text      = "Войти";
            btnLogin.Font      = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogin.BackColor = Color.FromArgb(46, 74, 107);
            btnLogin.ForeColor = Color.White;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.Location  = new Point(40, 222);
            btnLogin.Size      = new Size(316, 38);
            btnLogin.Click    += btnLogin_Click;

            btnRegister.Text      = "Зарегистрироваться";
            btnRegister.Font      = new Font("Segoe UI", 9F);
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.FlatAppearance.BorderColor = Color.FromArgb(46, 74, 107);
            btnRegister.ForeColor = Color.FromArgb(46, 74, 107);
            btnRegister.Location  = new Point(40, 272);
            btnRegister.Size      = new Size(316, 32);
            btnRegister.Click    += btnRegister_Click;

            Text            = "Авторизация";
            ClientSize      = new Size(800, 540);
            BackColor       = Color.FromArgb(244, 246, 250);
            StartPosition   = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox     = false;
            Controls.Add(panelMain);
            panelMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Label   lblTitle    = null!;
        private Label   lblLogin    = null!;
        private Label   lblPassword = null!;
        private TextBox txtLogin    = null!;
        private TextBox txtPassword = null!;
        private Button  btnLogin    = null!;
        private Button  btnRegister = null!;
        private Panel   panelMain   = null!;
    }
}
