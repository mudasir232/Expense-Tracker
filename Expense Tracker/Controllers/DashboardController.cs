using Expense_Tracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Expense_Tracker.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Last 7 days
            DateTime StartDate = DateTime.Today.AddDays(-6);
            DateTime EndDate = DateTime.Today;

            List<Transaction> SelectedTransactions = await _context.Transactions
                .Include(x => x.Category)
                .Where(y => y.Date >= StartDate && y.Date <= EndDate)
                .ToListAsync();

            // Total Income
            int TotalIncome = SelectedTransactions
                .Where(i => i.Category.Type == "Income")
                .Sum(j => j.Amount);
            ViewBag.TotalIncome = TotalIncome.ToString("C0");

            // Total Expense
            int TotalExpense = SelectedTransactions
                .Where(i => i.Category.Type == "Expense")
                .Sum(j => j.Amount);
            ViewBag.TotalExpense = TotalExpense.ToString("C0");

            // Balance
            int Balance = TotalIncome - TotalExpense;
            ViewBag.Balance = Balance.ToString("C0", new System.Globalization.CultureInfo("en-US"));
            
            //Doughnut Chart - expense by category
            ViewBag.DoughnutChartData = SelectedTransactions
                 .Where(i =>i.Category.Type == "Expense")
                 .GroupBy(j => j.Category.CategoryId)
                 .Select(k => new
                 {
                    categoryTitleWithIcon = k.First().Category.Icon+" "+ k.First().Category.Title,
                   amount = k.Sum(j => j.Amount),
                   formattedAmount = k.Sum(j => j.Amount).ToString("C0"),
                 })
                 .OrderByDescending(l => l.amount)
                 
                 .ToList();

                 //Spline Chart - Income vs Expense
                 //Income
                 List<SplineChartData> IncomeSummary = SelectedTransactions
                 .Where(i => i.Category.Type == "Income")
                 .GroupBy(j => j.Date)
                 .Select(k => new SplineChartData()
                 {
                    day = k.First().Date.ToString("dd-MMM"),
                    Income = k.Sum(l => l.Amount),
                 })
                 .ToList();
                 //Expense
                 List<SplineChartData> ExpenseSummary = SelectedTransactions
                 .Where(i => i.Category.Type == "Expense")
                 .GroupBy(j => j.Date)
                 .Select(k => new SplineChartData()
                 {
                     day = k.First().Date.ToString("dd-MMM"),
                     Expense = k.Sum(l => l.Amount),
                 })
                 .ToList();
                                  
               //Combine Income and Expense
               string[] Last7Days = Enumerable.Range(0, 7)
               .Select(i => StartDate.AddDays(i).ToString("dd-MMM"))
               .ToArray();

               ViewBag.SplineChartData = from day in Last7Days
                                         join income in IncomeSummary on day equals income.day into dayIncomeJoined
                                         from Income in dayIncomeJoined.DefaultIfEmpty()
                                         join expense in ExpenseSummary on day equals expense.day into dayExpenseJoined
                                         from expense in dayExpenseJoined.DefaultIfEmpty()
                                         select new 
                                         {
                                          day = day,
                                          income = Income == null ? 0 : Income.Income,
                                          expense = expense == null ? 0 : expense.Expense,





                                         };

            //Recent Transactions
            ViewBag.RecentTransactions = await _context.Transactions
                .Include(i => i.Category)
                .OrderByDescending(j => j.Date)
                .Take(5)
                .ToListAsync();





            return View();
        }
    

    }

   public class SplineChartData
    {
      public string day;
      public int Income;
      public int Expense;
    
    }



}




