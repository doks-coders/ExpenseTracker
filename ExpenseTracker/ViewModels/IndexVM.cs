using ExpenseTracker.Models;

namespace ExpenseTracker.ViewModels
{
    public class IndexVM
    {
        public List<UserExpenses> UserExpenses { get; set; }
        public int pageNumber { get; set; }
        public TotalCost totalcost { get; set; }

    }
}
