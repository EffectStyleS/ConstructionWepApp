using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace WebAPI.Models
{
    public partial class FFAContext : IdentityDbContext<User>
    {
        #region Constructor
        //public FFAContext(DbContextOptions<FFAContext>
        //options)
        //: base(options)
        //{ }

        protected readonly IConfiguration Configuration;

        public FFAContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }
        #endregion

        public virtual DbSet<Budget> Budget { get; set; }
        public virtual DbSet<Expense> Expense { get; set; }
        public virtual DbSet<ExpenseType> ExpenseType { get; set; }
        public virtual DbSet<Income> Income { get; set; }
        public virtual DbSet<IncomeType> IncomeType { get; set; }
        public virtual DbSet<PlannedExpenses> PlannedExpenses { get; set; }
        public virtual DbSet<PlannedIncomes> PlannedIncomes { get; set; }
        public virtual DbSet<TimePeriod> TimePeriod { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Budget>(entity =>
            {
                entity.HasOne(d => d.User)
                .WithMany(p => p.Budget)
                .HasForeignKey(d => d.UserId);
            });


        }

    }
}
