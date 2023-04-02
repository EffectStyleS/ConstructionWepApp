using WebAPI.Models;

namespace WebAPI.Data
{
    public static class FFAContextSeed
    {
        public static async Task SeedAsync(FFAContext context)
        {
            try
            {
                context.Database.EnsureCreated();

                if(context.Budget.Any())
                {
                    return;
                }

                var users = new List<User>()
                {
                    new User
                    {
                        UserName = "Сергей",
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
                        UserId = context.User.Where(x => x.UserName == "Сергей").FirstOrDefault().Id,
                        StartDate = DateTime.Now,
                        TimePeriodId = context.TimePeriod.Where(t => t.Name == "Месяц").FirstOrDefault().Id
                    },

                    new Budget
                    {
                        UserId = context.User.Where(x => x.UserName == "Сергей").FirstOrDefault().Id,
                        StartDate = new DateTime(2023, 4, 1),
                        TimePeriodId = context.TimePeriod.Where(t => t.Name == "Год").FirstOrDefault().Id
                    },
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
