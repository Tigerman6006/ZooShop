using Microsoft.Extensions.DependencyInjection;

namespace ZooShop
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            using var serviceProvider =
                DependencyInjection.ConfigureServices();

            using var scope = serviceProvider.CreateScope();

            Application.Run(
                scope.ServiceProvider.GetRequiredService<MainForm>()
            );
        }
    }
}