using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CompanyWeb.Models.CompanyDB;

namespace CompanyWeb.Pages.Departments
{
    public class IndexModel : PageModel
    {
        private readonly CompanyContext _context;

        public IndexModel(CompanyContext context)
        {
            _context = context;
        }

        public IList<CompanyWeb.Models.CompanyDB.Department> DepartmentList { get; set; } = new List<CompanyWeb.Models.CompanyDB.Department>();

        public async Task OnGetAsync()
        {
            DepartmentList = await _context.Departments.ToListAsync();
        }
    }
}
