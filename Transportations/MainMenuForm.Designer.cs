#nullable enable
namespace Transportations
{
    public partial class MainMenuForm : Form
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
            lblWelcome  = new Label();
            panelCards  = new Panel();
            btnDatabase = new Button();
            btnReports  = new Button();
            btnProfile  = new Button();
            btnUsers    = new Button();
            btnLogout   = new Button();
            btnInfo     = new Button();
            panelTop.SuspendLayout();
            panelCards.SuspendLayout();
            SuspendLayout();

            // panelTop
            panelTop.BackColor = Color.FromArgb(46, 74, 107);
            panelTop.Dock      = DockStyle.Top;
            panelTop.Height    = 70;
            panelTop.Controls.AddRange(new Control[] { lblTitle, lblWelcome });

            lblTitle.Text      = "Транспортная компания";
            lblTitle.Font      = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location  = new Point(20, 18);
            lblTitle.Size      = new Size(340, 34);

            lblWelcome.Font      = new Font("Segoe UI", 9F);
            lblWelcome.ForeColor = Color.FromArgb(200, 220, 255);
            lblWelcome.TextAlign = ContentAlignment.MiddleRight;
            lblWelcome.Location  = new Point(370, 22);
            lblWelcome.Size      = new Size(400, 26);

            // panelCards
            panelCards.Dock      = DockStyle.Fill;
            panelCards.BackColor = Color.FromArgb(244, 246, 250);
            panelCards.Controls.AddRange(new Control[] {
                btnDatabase, btnReports, btnProfile, btnUsers, btnLogout, btnInfo });

            SetCard(btnDatabase, "📋  База данных",         "Просмотр и редактирование",  new Point(50, 60),  btnDatabase_Click);
            SetCard(btnReports,  "📊  Отчёты",              "Аналитика и экспорт CSV",     new Point(300, 60), btnReports_Click);
            SetCard(btnProfile,  "👤  Профиль",             "Личный кабинет",              new Point(50, 200), btnProfile_Click);
            SetCard(btnUsers,    "👥  Пользователи",        "Управление ролями",           new Point(300, 200), btnUsers_Click);
            SetCard(btnLogout,   "🚪  Выйти",               "Завершить сеанс",             new Point(550, 130), btnLogout_Click);
            SetCard(btnInfo, "ℹ️ Информация", "О приложении", new Point(550, 230), btnInfo_Click);
            btnInfo.BackColor = Color.FromArgb(70, 120, 170); btnInfo.Size = new Size(160, 80);
            btnLogout.BackColor = Color.FromArgb(180, 60, 60);
            btnLogout.Size      = new Size(160, 80);

            // Form
            Text          = "Главное меню";
            ClientSize    = new Size(800, 480);
            StartPosition = FormStartPosition.CenterScreen;
            MinimumSize   = new Size(800, 480);
            Controls.AddRange(new Control[] { panelCards, panelTop });
            panelTop.ResumeLayout(false);
            panelCards.ResumeLayout(false);
            ResumeLayout(false);
        }

        private static void SetCard(Button btn, string title, string sub,
            Point loc, EventHandler handler)
        {
            btn.Text      = $"{title}\n{sub}";
            btn.Font      = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn.BackColor = Color.FromArgb(46, 74, 107);
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Location  = loc;
            btn.Size      = new Size(220, 100);
            btn.TextAlign = ContentAlignment.MiddleCenter;
            btn.Click    += handler;
        }

        private Panel  panelTop    = null!;
        private Panel  panelCards  = null!;
        private Label  lblTitle    = null!;
        private Label  lblWelcome  = null!;
        private Button btnDatabase = null!;
        private Button btnReports  = null!;
        private Button btnProfile  = null!;
        private Button btnUsers    = null!;
        private Button btnLogout   = null!;
        private Button btnInfo = null!;
    }
}
