﻿namespace ASPNetCoreWebAPI.Models
{
    public class PlannedIncomes
    {
        public int Id { get; set; }
        public Nullable<decimal> Sum { get; set; }
        public int IncomeTypeId { get; set; }
        public int BudgetId { get; set; }

        public virtual Budget Budget { get; set; }
        public virtual IncomeType IncomeType { get; set; }
    }
}
