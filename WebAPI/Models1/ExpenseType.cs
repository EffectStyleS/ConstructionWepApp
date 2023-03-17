using System;
using System.Collections.Generic;

namespace WebAPI.Models1;

public partial class ExpenseType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Expense> Expenses { get; } = new List<Expense>();

    public virtual ICollection<PlannedExpense> PlannedExpenses { get; } = new List<PlannedExpense>();
}
