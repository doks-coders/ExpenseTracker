namespace ExpenseTracker.Models
{
    public class ExpenseForCategory
    {
        public string Name { get; set; }
        public string Fullname { get; set; }
        public string Title { get; set; }
        public string Username { get; set; }
        public int ExpenseID { get; set; }
        public int UserID { get; set; }
    }
}
