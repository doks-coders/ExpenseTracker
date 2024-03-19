using ExpenseTracker.Data;
using ExpenseTracker.DTOs;
using ExpenseTracker.Services.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ExpenseTracker.Services
{
    public class SetValueProcedures : ISetValueProcedures
    {
        private readonly ApplicationDbContext _db;

        public SetValueProcedures(ApplicationDbContext db)
        {
            _db = db;
        }


        public async Task<bool> DeleteExpense(int expenseId)
        {
            var result = await _db.Database.ExecuteSqlRawAsync($"EXEC DeleteExpense @expenseid = {expenseId}");
            if (result > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> EditExpense(EditExpenseRequest editExpense)
        {
            var sql = "EXEC EditExpense @expenseid, @title, @description,@amountpaid,@userid, @CategoryName";
            var parameters = new[]
            {
                new SqlParameter("@title",editExpense.Title),
                new SqlParameter("@description",editExpense.Description),
                new SqlParameter("@amountpaid",editExpense.AmountPaid),
                new SqlParameter("@CategoryName",editExpense.CategoryName),
                new SqlParameter("@userid",""),
                new SqlParameter("@expenseid",editExpense.ExpenseId),
            };
            var result = await _db.Database.ExecuteSqlRawAsync(sql, parameters);
            if (result > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> UploadExpense(UploadExpenseRequest uploadExpense)
        {
            var sql = "EXEC UploadExpense @title, @description, @amountpaid, @username,@CategoryName";
            var parameters = new[]
            {
                new SqlParameter("@title", uploadExpense.Title),
                new SqlParameter("@description", uploadExpense.Description),
                new SqlParameter("@amountpaid", SqlDbType.VarChar) { Value = uploadExpense.AmountPaid },
                new SqlParameter("@username", uploadExpense.UserName),
                new SqlParameter("@CategoryName", uploadExpense.CategoryName)
            };
            var result = await _db.Database.ExecuteSqlRawAsync(sql, parameters);

            if (result > 0)
            {
                return true;
            }
            return false;
        }
    }
}











//await _context.Database.ExecuteSqlRawAsync("EXEC DeleteExpense @expenseid = 8");
//await _context.Database.ExecuteSqlRawAsync("EditExpense @expenseid = 12,@title='Test Payment Edit'");
/*
  await _context.Database.ExecuteSqlRawAsync(
	$"EXEC UploadExpense @title='Buy Fruits',@description='Buy Fruits',@amountpaid=100,@username='john_doe',@CategoryName='Groceries'"
	);
 */