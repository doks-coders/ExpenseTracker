using ExpenseTracker.DTOs;

namespace ExpenseTracker.Services.Interfaces
{
    public interface ISetValueProcedures
    {
        Task<bool> DeleteExpense(int expenseId);

        Task<bool> EditExpense(EditExpenseRequest editExpense);

        Task<bool> UploadExpense(UploadExpenseRequest uploadExpense);

    }
}
