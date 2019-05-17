using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laborator2.Models.Data
{
    public static class TasksDbSeeder
    {
        public static void Initialize(TasksDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any flowers.
            if (context.Tasks.Any())
            {
                return;   // DB has been seeded
            }

            context.Tasks.AddRange(
                new Task
                {
                    Title = "update console app",
                    Description = "update",
                    DateAdded =new DateTime(2019-05-09, 12,23),
                    TaskImportance = 0,
                    Status = 0,
                    ClosedAt = new DateTime(2019 - 06 - 01, 12, 23)
                },
                new Task
                {
                    Title = "do something",
                    Description = "anything",
                    DateAdded = new DateTime(2019 - 06 - 01, 12, 23),
                    TaskImportance = 0,
                    Status = 0,
                    ClosedAt = new DateTime(2020 - 06 - 01, 12, 23),
                }
            );
            context.SaveChanges(); // commit transaction
        }
    }
}
