using System.ComponentModel.DataAnnotations;

namespace WebApplication1
{
    public class Employee
     {
        public int Id { get; set; }

        //Minimal length for employee name
        [Required, StringLength(10)]
        public string Name { get; set; }
    }
}