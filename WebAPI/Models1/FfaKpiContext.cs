using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models1;

public partial class FfaKpiContext : DbContext
{
    public FfaKpiContext()
    {
    }

    public FfaKpiContext(DbContextOptions<FfaKpiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Budget> Budgets { get; set; }

    public virtual DbSet<Expense> Expenses { get; set; }

    public virtual DbSet<ExpenseType> ExpenseTypes { get; set; }

    public virtual DbSet<Income> Incomes { get; set; }

    public virtual DbSet<IncomeType> IncomeTypes { get; set; }

    public virtual DbSet<PlannedExpense> PlannedExpenses { get; set; }

    public virtual DbSet<PlannedIncome> PlannedIncomes { get; set; }

    public virtual DbSet<TimePeriod> TimePeriods { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=FFA_KPI;Trusted_Connection=True;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Budget>(entity =>
        {
            entity.ToTable("Budget");

            entity.HasIndex(e => e.TimePeriodId, "IX_Budget_TimePeriodId");

            entity.HasIndex(e => e.UserId, "IX_Budget_UserId");

            entity.HasOne(d => d.TimePeriod).WithMany(p => p.Budgets).HasForeignKey(d => d.TimePeriodId);

            entity.HasOne(d => d.User).WithMany(p => p.Budgets).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Expense>(entity =>
        {
            entity.ToTable("Expense");

            entity.HasIndex(e => e.ExpenseTypeId, "IX_Expense_ExpenseTypeId");

            entity.HasIndex(e => e.UserId, "IX_Expense_UserId");

            entity.Property(e => e.Value).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.ExpenseType).WithMany(p => p.Expenses).HasForeignKey(d => d.ExpenseTypeId);

            entity.HasOne(d => d.User).WithMany(p => p.Expenses).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<ExpenseType>(entity =>
        {
            entity.ToTable("ExpenseType");
        });

        modelBuilder.Entity<Income>(entity =>
        {
            entity.ToTable("Income");

            entity.HasIndex(e => e.IncomeTypeId, "IX_Income_IncomeTypeId");

            entity.HasIndex(e => e.UserId, "IX_Income_UserId");

            entity.Property(e => e.Value).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IncomeType).WithMany(p => p.Incomes).HasForeignKey(d => d.IncomeTypeId);

            entity.HasOne(d => d.User).WithMany(p => p.Incomes).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<IncomeType>(entity =>
        {
            entity.ToTable("IncomeType");
        });

        modelBuilder.Entity<PlannedExpense>(entity =>
        {
            entity.HasIndex(e => e.BudgetId, "IX_PlannedExpenses_BudgetId");

            entity.HasIndex(e => e.ExpenseTypeId, "IX_PlannedExpenses_ExpenseTypeId");

            entity.Property(e => e.Sum).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Budget).WithMany(p => p.PlannedExpenses).HasForeignKey(d => d.BudgetId);

            entity.HasOne(d => d.ExpenseType).WithMany(p => p.PlannedExpenses).HasForeignKey(d => d.ExpenseTypeId);
        });

        modelBuilder.Entity<PlannedIncome>(entity =>
        {
            entity.HasIndex(e => e.BudgetId, "IX_PlannedIncomes_BudgetId");

            entity.HasIndex(e => e.IncomeTypeId, "IX_PlannedIncomes_IncomeTypeId");

            entity.Property(e => e.Sum).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Budget).WithMany(p => p.PlannedIncomes).HasForeignKey(d => d.BudgetId);

            entity.HasOne(d => d.IncomeType).WithMany(p => p.PlannedIncomes).HasForeignKey(d => d.IncomeTypeId);
        });

        modelBuilder.Entity<TimePeriod>(entity =>
        {
            entity.ToTable("TimePeriod");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
