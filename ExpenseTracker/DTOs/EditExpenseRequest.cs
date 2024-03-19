namespace ExpenseTracker.DTOs
{
    public class EditExpenseRequest
    {
        public int ExpenseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string AmountPaid { get; set; }
        public string CategoryName { get; set; }
    }
}

