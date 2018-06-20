using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _dbContext;

        //Need to bind data
        [BindProperty]
        public IList<Employee> Employees { get; set; }

        [TempData]
        public string Message { get; set; }

        public IndexModel(AppDbContext dbContext)
        {
            _dbContext = dbContext;


        }

        public async Task OnGetAsync()
        {
            Employees = await _dbContext.Employees.AsNoTracking().ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            //find out the employee
            var employee = _dbContext.Employees.Find(id);

            //remove the employee
            _dbContext.Employees.Remove(employee);
            try
            {
                //save the changes
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {

                throw new Exception(@"Customer {employee.Name} could not be deleted.");
            }
            return RedirectToPage();
        }
    }
}
