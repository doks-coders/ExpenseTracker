namespace ExpenseTracker.DTOs
{
    public class UploadExpenseRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string AmountPaid { get; set; }
        public string UserName { get; set; }
        public string CategoryName { get; set; }
    }
}

