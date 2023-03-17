using System;
using System.Collections.Generic;

namespace WebAPI.Models1;

public partial class Expense
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Value { get; set; }

    public DateTime Date { get; set; }

    public int ExpenseTypeId { get; set; }

    public int UserId { get; set; }

    public virtual ExpenseType ExpenseType { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
