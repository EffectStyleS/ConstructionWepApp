using System;
using System.Collections.Generic;

namespace WebAPI.Models1;

public partial class PlannedExpense
{
    public int Id { get; set; }

    public decimal? Sum { get; set; }

    public int ExpenseTypeId { get; set; }

    public int BudgetId { get; set; }

    public virtual Budget Budget { get; set; } = null!;

    public virtual ExpenseType ExpenseType { get; set; } = null!;
}
