using System;
using System.Collections.Generic;

namespace WebAPI.Models1;

public partial class TimePeriod
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Budget> Budgets { get; } = new List<Budget>();
}
