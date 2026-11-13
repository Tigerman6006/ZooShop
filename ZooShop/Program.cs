using Microsoft.Extensions.DependencyInjection;

namespace ZooShop
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var serviceProvider = DependencyInjection.ConfigureServices();

            Application.Run(serviceProvider.GetRequiredService<Form1>());
        }
    }
}