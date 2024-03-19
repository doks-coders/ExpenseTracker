using ExpenseTracker.DTOs;

namespace ExpenseTracker.Services.Interfaces
{
    public interface ISetValueProcedures
    {
        /// <summary>
        /// This method deletes the expense from the database
        /// </summary>
        /// <param name="expenseId"></param>
        /// <returns></returns>
        Task<bool> DeleteExpense(int expenseId);

        /// <summary>
        /// This method edits the expense in the database
        /// </summary>
        /// <param name="editExpense"></param>
        /// <returns></returns>
        Task<bool> EditExpense(EditExpenseRequest editExpense);

        /// <summary>
        /// This method uploads the expense in the database
        /// </summary>
        /// <param name="uploadExpense"></param>
        /// <returns></returns>
        Task<bool> UploadExpense(UploadExpenseRequest uploadExpense);

    }
}
