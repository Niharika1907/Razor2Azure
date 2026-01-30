using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CompanyWeb.Models.CompanyDB;

namespace CompanyWeb.Pages.Reports
{
    public class EmployeesByDepartmentModel : PageModel
    {
        private readonly CompanyContext _context;

        public EmployeesByDepartmentModel(CompanyContext context)
        {
            _context = context;
        }

        public IList<CompanyWeb.Models.CompanyDB.Department> Departments { get; set; } = new List<CompanyWeb.Models.CompanyDB.Department>();

        public async Task OnGetAsync()
        {
            Departments = await _context.Departments
                .Include(d => d.Employees)
                .ToListAsync();
        }
    }
}
