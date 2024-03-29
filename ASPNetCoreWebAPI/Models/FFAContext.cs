﻿using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace ASPNetCoreWebAPI.Models
{
    public class FFAContext : DbContext
    {
        #region Constructor
        public FFAContext(DbContextOptions<FFAContext> options)
            : base(options)
        { }
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
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Login).IsRequired();
            });

            modelBuilder.Entity<Budget>(entity =>
            {
                entity.HasOne(d => d.User)
                   .WithMany(b => b.Budget)
                   .HasForeignKey(d => d.UserId);
            });
        }

    }
}
