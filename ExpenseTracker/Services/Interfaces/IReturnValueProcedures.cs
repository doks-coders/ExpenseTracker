using ExpenseTracker.Models;

namespace ExpenseTracker.Services.Interfaces
{
    public interface IReturnValueProcedures
    {
        Task<TotalExpense> GetTotalUserExpenses(string userName);

        Task<Expenses?> GetExpenseFromId(int expenseId);

        Task<List<ExpenseForCategory>> GetExpensesForCategory(int pageNumber, string categoryName);

        Task<List<UserExpenses>> GetUserExpenses(int pageNumber, string userName);

        Task<TotalCost> GetTotalCosts(string username);


    }
}
