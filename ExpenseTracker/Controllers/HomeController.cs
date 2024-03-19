using ExpenseTracker.DTOs;
using ExpenseTracker.Models;
using ExpenseTracker.Services.Interfaces;
using ExpenseTracker.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace ExpenseTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IReturnValueProcedures _returnProcedures;
        private readonly ISetValueProcedures _setProcedures;
        private readonly IEnumerable<SelectListItem> CategoriesSelectList;
        public HomeController(ILogger<HomeController> logger, IReturnValueProcedures returnProcedures, ISetValueProcedures setProcedures)
        {
            _logger = logger;
            _returnProcedures = returnProcedures;
            _setProcedures = setProcedures;

            var Categories = new List<string>() { "Groceries", "Utilities", "Transportation" };
            CategoriesSelectList = Categories.Select(opt => new SelectListItem()
            {
                Text = opt,
                Value = opt
            });
        }

        public async Task<IActionResult> Index(int pageNumber)
        {
            List<UserExpenses> item = (pageNumber != 0) ? await _returnProcedures.GetUserExpenses(pageNumber, "john_doe") : await _returnProcedures.GetUserExpenses(1, "john_doe");
            TotalCost totalcost = await _returnProcedures.GetTotalCosts("john_doe");

            return View(new IndexVM()
            {
                UserExpenses = item,
                pageNumber = pageNumber,
                totalcost = totalcost
            });
        }

        public async Task<IActionResult> Details(int expenseId)
        {
            Expenses item = await _returnProcedures.GetExpenseFromId(expenseId);
            return View(new DetailsVM()
            {
                CategoriesSelectList = CategoriesSelectList,
                Expenses = item
            });
        }

        [HttpPost]
        public async Task<IActionResult> Details(DetailsVM detailsVM)
        {
            bool res = await _setProcedures.EditExpense(new EditExpenseRequest()
            {
                ExpenseId = detailsVM.Expenses.ID,
                Title = detailsVM.Expenses.Title,
                AmountPaid = detailsVM.Expenses.AmountPaid,
                Description = detailsVM.Expenses.Description,
                CategoryName = detailsVM.Expenses.CategoryName
            });
            if (res)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(detailsVM);
        }


        public async Task<IActionResult> AddExpense()
        {

            return View(new AddExpenseVM()
            {
                CategoriesSelectList = CategoriesSelectList,
                Expenses = new Expenses()
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddExpense(AddExpenseVM addExpenseVM)
        {
            var res = await _setProcedures.UploadExpense(new UploadExpenseRequest()
            {
                Title = addExpenseVM.Expenses.Title,
                Description = addExpenseVM.Expenses.Description,
                AmountPaid = addExpenseVM.Expenses.AmountPaid,
                UserName = "john_doe",
                CategoryName = addExpenseVM.Expenses.CategoryName
            });
            if (res)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(addExpenseVM);
            }
        }


        public async Task<IActionResult> DeleteExpense(int expenseId)
        {
            return View(new DeleteVM() { Id = expenseId });
        }

        [HttpPost, ActionName("DeleteExpense")]
        public async Task<IActionResult> DeleteExpensePOST(DeleteVM deleteVM)
        {
            var res = await _setProcedures.DeleteExpense(deleteVM.Id);

            if (res)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Error));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}