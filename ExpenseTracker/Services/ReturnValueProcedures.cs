using ExpenseTracker.Data;
using ExpenseTracker.Models;
using ExpenseTracker.Services.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Services
{
    public class ReturnValueProcedures : IReturnValueProcedures
    {
        private readonly ApplicationDbContext _db;

        public ReturnValueProcedures(ApplicationDbContext db)
        {
            _db = db;
        }


        public async Task<TotalExpense> GetTotalUserExpenses(string userName)
        {
            var res = _db.Database.SqlQueryRaw<TotalExpense>($"EXEC GetTotalUserExpenses @username='{userName}'");
            return await res.FirstOrDefaultAsync();
        }

        public async Task<Expenses> GetExpenseFromId(int expenseId)
        {

            var sql = "EXEC GetExpenseFromId @expenseid";
            var parameters = new SqlParameter("@expenseid", expenseId);
            var res = _db.Database.SqlQueryRaw<Expenses>(sql, parameters);

            return res.ToList().FirstOrDefault();
        }

        public async Task<List<ExpenseForCategory>> GetExpensesForCategory(int pageNumber, string categoryName)
        {
            var sql = "EXEC GetExpensesForCategory @pagenumber,@categoryname";
            var parameters = new[]
            {
                new SqlParameter("@pagenumber",pageNumber),
                new SqlParameter("@categoryname",categoryName),
            };
            var res = _db.Database.SqlQueryRaw<ExpenseForCategory>(sql, parameters);

            return await res.ToListAsync();
        }

        public async Task<List<UserExpenses>> GetUserExpenses(int pageNumber, string userName)
        {
            var res = _db.Database.SqlQueryRaw<UserExpenses>($"EXEC GetUserExpenses @pagenumber={pageNumber},@username='{userName}'");

            return await res.ToListAsync();
        }

        public async Task<TotalCost> GetTotalCosts(string username)
        {
            var res = _db.Database.SqlQueryRaw<TotalCost>($"EXEC GetTotalCosts @username='{username}'");

            return res.ToList().FirstOrDefault();
        }
    }
}


