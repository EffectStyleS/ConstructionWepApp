using WebAPI.Models;
using WebAPI.Models1;

namespace WebAPI.Data
{
    public static class FFAContextSeed
    {
        public static async Task SeedAsync(FFAContext context)
        {
            try
            {
                context.Database.EnsureCreated();

                if(context.User.Any())
                {
                    return;
                }

                var users = new List<User>()
                {
                    new User
                    {
                        Name = "Сергей",
                        Login = "Сергей",
                        Password = "kpi1",
                        Role = 1
                    },

                    new User
                    {
                        Name = "Алексей",
                        Login = "Алёша",
                        Password = "kpi2",
                        Role = 1
                    },

                    new User
                    {
                        Name = "Наталья",
                        Login = "Le Maman",
                        Password = "kpi3",
                        Role = 0
                    },
                };

                foreach (var user in users)
                {
                    context.User.Add(user);
                }

                await context.SaveChangesAsync();

                var timePeriods = new List<TimePeriod>()
                {
                    new TimePeriod
                    {
                        Name = "Месяц"
                    },

                    new TimePeriod
                    {
                        Name = "Квартал"
                    },

                    new TimePeriod
                    {
                        Name = "Год"
                    }
                };

                foreach (var timePeriod in timePeriods)
                {
                    context.TimePeriod.Add(timePeriod);
                }

                await context.SaveChangesAsync();

                var budgets = new List<Budget>()
                {
                    new Budget
                    {
                        UserId = 25,
                        StartDate = DateTime.Now,
                        TimePeriodId = 16
                    },

                    new Budget
                    {
                        UserId = 25,
                        StartDate = new DateTime(2023, 4, 1),
                        TimePeriodId = 18
                    }
                };

                foreach (var budget in budgets)
                {
                    context.Budget.Add(budget);
                }

                await context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
