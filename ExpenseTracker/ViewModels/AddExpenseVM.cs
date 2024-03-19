using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExpenseTracker.ViewModels
{
    public class AddExpenseVM
    {
        public Expenses Expenses { get; set; }
        public IEnumerable<SelectListItem> CategoriesSelectList { get; set; }
    }
}
