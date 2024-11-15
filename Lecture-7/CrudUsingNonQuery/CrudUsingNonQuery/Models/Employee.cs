using System.ComponentModel.DataAnnotations;

namespace CrudUsingNonQuery.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
