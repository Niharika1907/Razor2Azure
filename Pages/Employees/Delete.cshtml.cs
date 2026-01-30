using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CompanyWeb.Models.CompanyDB;

namespace CompanyWeb.Pages.Employees
{
    public class DeleteModel : PageModel
    {
        private readonly CompanyContext _context;

        public DeleteModel(CompanyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Employee Employee { get; set; } = new Employee();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var emp = await _context.Employees.Include(e => e.Department).FirstOrDefaultAsync(e => e.EmployeeId == id);
            if (emp == null) return NotFound();
            Employee = emp;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var emp = await _context.Employees.FindAsync(Employee.EmployeeId);
            if (emp != null)
            {
                _context.Employees.Remove(emp);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("Index");
        }
    }
}
