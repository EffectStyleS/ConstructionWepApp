using System;
using System.Collections.Generic;

namespace WebAPI.Models1;

public partial class IncomeType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Income> Incomes { get; } = new List<Income>();

    public virtual ICollection<PlannedIncome> PlannedIncomes { get; } = new List<PlannedIncome>();
}
