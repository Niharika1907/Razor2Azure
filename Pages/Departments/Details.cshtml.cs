using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CompanyWeb.Models.CompanyDB;

namespace CompanyWeb.Pages.Departments
{
    public class DetailsModel : PageModel
    {
        private readonly CompanyContext _context;

        public DetailsModel(CompanyContext context)
        {
            _context = context;
        }

        public Department Department { get; set; } = new Department();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var dept = await _context.Departments.FindAsync(id);
            if (dept == null) return NotFound();
            Department = dept;
            return Page();
        }
    }
}
