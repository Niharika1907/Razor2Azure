using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CompanyWeb.Models.CompanyDB;

namespace CompanyWeb.Pages.Reports
{
    public class EmployeeCountsModel : PageModel
    {
        private readonly CompanyContext _context;

        public EmployeeCountsModel(CompanyContext context)
        {
            _context = context;
        }

        public IList<DepartmentCount> DepartmentCounts { get; set; } = new List<DepartmentCount>();

        public class DepartmentCount
        {
            public string DepartmentName { get; set; } = string.Empty;
            public int EmployeeCount { get; set; }
        }

        public async Task OnGetAsync()
        {
            DepartmentCounts = await _context.Employees
                .GroupBy(e => e.Department.DepartmentName)
                .Select(g => new DepartmentCount
                {
                    DepartmentName = g.Key,
                    EmployeeCount = g.Count()
                })
                .ToListAsync();
        }
    }
}
