namespace WebAPI.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public System.DateTime Date { get; set; }
        public int ExpenseTypeId { get; set; }
        public int UserId { get; set; }

        public virtual ExpenseType ExpenseType { get; set; }
        public virtual User User { get; set; }
    }
}
