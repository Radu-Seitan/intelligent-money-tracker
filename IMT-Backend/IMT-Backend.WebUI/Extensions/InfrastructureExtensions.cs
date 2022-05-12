using IMT_Backend.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace IMT_Backend.WebUI.Extensions
{
    public static class InfrastructureExtensions
    {
        public static void MigrateDatabase(this WebApplication webApplication)
        {
            using var scope = webApplication.Services.CreateScope();

            scope.ServiceProvider.GetRequiredService<AppDbContext>().Database.Migrate();
        }
    }
}
