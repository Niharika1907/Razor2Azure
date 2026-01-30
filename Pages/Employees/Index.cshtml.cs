using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CompanyWeb.Models.CompanyDB;

namespace CompanyWeb.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly CompanyContext _context;

        public IndexModel(CompanyContext context)
        {
            _context = context;
        }

        public IList<CompanyWeb.Models.CompanyDB.Employee> EmployeeList { get; set; } = new List<CompanyWeb.Models.CompanyDB.Employee>();

        public async Task OnGetAsync()
        {
            EmployeeList = await _context.Employees
                                         .Include(e => e.Department)
                                         .ToListAsync();
        }
    }
}
