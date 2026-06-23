using System.Configuration;
using Transportations.BLL;
using Transportations.DAL;
using Microsoft.Extensions.DependencyInjection;

namespace Transportations
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection();
            ConfigureServices(services);
            var provider = services.BuildServiceProvider();

            Application.Run(provider.GetRequiredService<Form1>());
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            var cs = ConfigurationManager.ConnectionStrings["TransportDB"]?.ConnectionString
                     ?? throw new InvalidOperationException("Строка подключения 'TransportDB' не найдена в App.config.");

            // DAL
            services.AddSingleton<IDbManager>(new DbManager(cs));
            services.AddSingleton(new DataRepository(cs));

            // BLL
            services.AddSingleton<AuthService>();
            services.AddSingleton<DataService>();

            // UI — LoginForm как синглтон, остальные transient
            services.AddSingleton<Form1>();
            services.AddTransient<MainMenuForm>();
            services.AddTransient<DatabaseForm>();
            services.AddTransient<EditRecordForm>();
            services.AddTransient<ProfileForm>();
            services.AddTransient<ReportsForm>();
            services.AddTransient<RegisterForm>();
            services.AddTransient<UsersForm>();

            // передаём provider сам в себя для открытия форм
            services.AddSingleton<IServiceProvider>(sp => sp);
        }
    }
}
