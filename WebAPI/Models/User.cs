namespace WebAPI.Models
{
    public class User
    {
        public User()
        {
            this.Budget = new HashSet<Budget>();
            this.Expense = new HashSet<Expense>();
            this.Income = new HashSet<Income>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }

        public virtual ICollection<Budget> Budget { get; set; }
        public virtual ICollection<Expense> Expense { get; set; }
        public virtual ICollection<Income> Income { get; set; }
    }
}
