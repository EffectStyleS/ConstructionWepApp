using System;
using System.Collections.Generic;

namespace WebAPI.Models1;

public partial class Income
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Value { get; set; }

    public DateTime Date { get; set; }

    public int UserId { get; set; }

    public int IncomeTypeId { get; set; }

    public virtual IncomeType IncomeType { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
