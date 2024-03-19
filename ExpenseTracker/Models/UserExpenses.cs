namespace ExpenseTracker.Models
{
    public class UserExpenses
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string AmountPaid { get; set; }
        public string UserID { get; set; }
        public string CategoryID { get; set; }
    }
}
