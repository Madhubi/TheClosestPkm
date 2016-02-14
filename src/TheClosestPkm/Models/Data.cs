using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;

namespace TheClosestPkm.Models
{
    public class Data
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.TimeTable.Any())
            {
                var GdanskGlowny = context.StationsTable.Add(
                    new StationsTable { StationName = "GdanskGlowny" }).Entity;
                var GdanskStoczni = context.StationsTable.Add(
                    new StationsTable { StationName = "GdanskStoczni" }).Entity;
                var Wrzeszcz = context.StationsTable.Add(
                    new StationsTable { StationName = "Wrzeszcz" }).Entity;

                context.TimeTable.AddRange(
                    new TimeTable()
                    {
                        Time = 4,
                        T1 = "4:00",
                        T2 = "5:00",
                        T3 = "6:00",
                        T4 = "7:00"
                    },
                    new TimeTable()
                    {
                        Time = 5,
                        T1 = "4:15",
                        T2 = "5:15",
                        T3 = "6:15",
                        T4 = "7:15"
                    },
                    new TimeTable()
                    {
                        Time = 6,
                        T1 = "4:30",
                        T2 = "5:30",
                        T3 = "6:30",
                        T4 = "7:30"
                    },
                    new TimeTable()
                    {
                        Time = 7,
                        T1 = "4:45",
                        T2 = "5:45",
                        T3 = "6:45",
                        T4 = "7:45"
                    }
                   );
                context.SaveChanges();
            }

        }
    }
}
