using System.ComponentModel.DataAnnotations;

namespace WebApplication1
{
    public class Employee

    {
        public int EmpId { get; set; }

        //Minimal length for employee name
        [Required, StringLength(5)]
        public string Name { get; set; }
    }
}