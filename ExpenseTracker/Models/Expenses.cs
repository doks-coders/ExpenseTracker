namespace ExpenseTracker.Models
{
    public class Expenses
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string AmountPaid { get; set; }
        public DateTime DateCreated { get; set; }
        public string CategoryName { get; set; }
        public string CategoryID { get; set; }

    }
}
