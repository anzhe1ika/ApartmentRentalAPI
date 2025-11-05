using ApartmentRental.DAL;
using Microsoft.EntityFrameworkCore;

namespace ApartmentRentalAPI
{
    public static class ServicesExtensions
    {
        public static void MigrateDatabase(this IHost app)
        {
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<Context>();

            context.Database.Migrate();
        }
    }
}
