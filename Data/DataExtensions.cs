using Microsoft.EntityFrameworkCore;

namespace Assel.Data
{
    internal static class DataExtensions
    {
        public static async Task MigrateDbAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AsselDbContext>();
            await dbContext.Database.MigrateAsync();
        }
    }
}
