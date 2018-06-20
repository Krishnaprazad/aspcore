using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Pages
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _dbContext;

        //Need to bind data
        [BindProperty]
        public Employee Employee { get; set; }

        [TempData]
        public string Message { get; set; }

        public EditModel(AppDbContext dbContext) { _dbContext = dbContext; }

        public async Task OnGetAsync(int id)
        {
            Employee = await _dbContext.Employees.FindAsync(id);

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //Add the employee to the list
            _dbContext.Attach(Employee).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {

                throw;
            }
            //Save changes
            

            //Message = @"Employee {Employee.Name} successfully changed.";

            return RedirectToPage("/Index");
        }
    }
}