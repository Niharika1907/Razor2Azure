using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CompanyWeb.Models.CompanyDB;
using Microsoft.EntityFrameworkCore;

namespace CompanyWeb.Pages.Employees
{
    public class CreateModel : PageModel
    {
        private readonly CompanyContext _context;

        public CreateModel(CompanyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Employee Employee { get; set; } = new Employee();

        public void PopulateDepartments()
        {
            ViewData["DepartmentList"] = new SelectList(_context.Departments.OrderBy(d => d.DepartmentName), "DepartmentId", "DepartmentName");
        }

        public IActionResult OnGet()
        {
            PopulateDepartments();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                PopulateDepartments();
                return Page();
            }

            _context.Employees.Add(Employee);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
