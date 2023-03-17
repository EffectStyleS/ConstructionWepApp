using System;
using System.Collections.Generic;

namespace WebAPI.Models1;

public partial class PlannedIncome
{
    public int Id { get; set; }

    public decimal? Sum { get; set; }

    public int IncomeTypeId { get; set; }

    public int BudgetId { get; set; }

    public virtual Budget Budget { get; set; } = null!;

    public virtual IncomeType IncomeType { get; set; } = null!;
}
