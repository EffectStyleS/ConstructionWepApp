using System;
using System.Collections.Generic;

namespace WebAPI.Models1;

public partial class Budget
{
    public int Id { get; set; }

    public DateTime StartDate { get; set; }

    public int TimePeriodId { get; set; }

    public int UserId { get; set; }

    public virtual ICollection<PlannedExpense> PlannedExpenses { get; } = new List<PlannedExpense>();

    public virtual ICollection<PlannedIncome> PlannedIncomes { get; } = new List<PlannedIncome>();

    public virtual TimePeriod TimePeriod { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
