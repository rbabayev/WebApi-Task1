using System.ComponentModel.DataAnnotations;

namespace ASP_Task2.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is requires")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Desc is requires")]
        [MinLength(3, ErrorMessage = "Should be more 3 chareacters")]
        public string Description { get; set; }
        [Range(1, 100, ErrorMessage = "Should between 1-100")]
        public int Discount { get; set; }
    }
}
