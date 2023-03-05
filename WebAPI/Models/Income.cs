namespace WebAPI.Models
{
    public class Income
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public System.DateTime Date { get; set; }
        public int UserId { get; set; }
        public int IncomeTypeId { get; set; }

        public virtual IncomeType IncomeType { get; set; }
        public virtual User User { get; set; }
    }
}
