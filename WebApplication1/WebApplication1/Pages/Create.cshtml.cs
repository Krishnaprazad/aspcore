using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _dbContext;

        //Need to bind data
        [BindProperty]
        public Employee Employee { get; set; }

        [TempData]
        public string Message { get; set; }

        public CreateModel(AppDbContext dbContext) { _dbContext = dbContext; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //Add the employee to the list
            _dbContext.Employees.Add(Employee);

            //Save changes
            await _dbContext.SaveChangesAsync();

            Message = @"Employee {Employee.Name} added successfully.";

            return RedirectToPage("/Index");
        }
    }
}