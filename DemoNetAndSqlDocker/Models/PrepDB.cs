using DemoNetAndSqlDocker.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace DemoNetAndSqlDocker.Models
{
    public static class PrepDB
    {
        public static void PrepPolpulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<ColourContext>());
            }
        }

        public static void SeedData(ColourContext context)
        {
            System.Console.WriteLine("Appling Migrations......");

            context.Database.Migrate();
            if (!context.ColourItems.Any())
            {
                System.Console.WriteLine("Adding data - seeding......");
                context.ColourItems.AddRange(
                    new Colour() { ColourName = "Red" },
                    new Colour() { ColourName = "Orange" },
                    new Colour() { ColourName = "Yellow" },
                    new Colour() { ColourName = "Green" },
                    new Colour() { ColourName = "Blue" }
                );
                context.SaveChanges();
            }
            else
            {
                System.Console.WriteLine("Already have data - not Seeding");
            }
        }
    }
}
