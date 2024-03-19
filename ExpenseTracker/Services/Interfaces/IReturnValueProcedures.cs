using ExpenseTracker.Models;

namespace ExpenseTracker.Services.Interfaces
{
    public interface IReturnValueProcedures
    {
        /// <summary>
        /// This method gets the total number of all the user's expenses
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<TotalExpense> GetTotalUserExpenses(string userName);

        /// <summary>
        /// This method gets the particular expense using the expenseId
        /// </summary>
        /// <param name="expenseId"></param>
        /// <returns></returns>
        Task<Expenses?> GetExpenseFromId(int expenseId);

        /// <summary>
        /// This method gets all the expenses for a particular category
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="categoryName"></param>
        /// <returns></returns>
        Task<List<ExpenseForCategory>> GetExpensesForCategory(int pageNumber, string categoryName);

        /// <summary>
        /// This method gets the expenses associated with the user
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<List<UserExpenses>> GetUserExpenses(int pageNumber, string userName);

        /// <summary>
        /// This method gets the total cost of all the user's expenses
        /// </summary>
        Task<TotalCost> GetTotalCosts(string username);


    }
}
