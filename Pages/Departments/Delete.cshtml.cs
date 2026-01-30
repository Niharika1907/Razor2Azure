using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CompanyWeb.Models.CompanyDB;

namespace CompanyWeb.Pages.Departments
{
    public class DeleteModel : PageModel
    {
        private readonly CompanyContext _context;

        public DeleteModel(CompanyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Department Department { get; set; } = new Department();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var dept = await _context.Departments.FindAsync(id);
            if (dept == null) return NotFound();
            Department = dept;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var dept = await _context.Departments.FindAsync(Department.DepartmentId);
            if (dept != null)
            {
                _context.Departments.Remove(dept);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("Index");
        }
    }
}
