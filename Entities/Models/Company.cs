using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Company
    {
        [Column("CompanyId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage ="Company name cannot be empty")]
        [MaxLength(255)]
        public string? Name { get; set; }

        public ICollection<Employee>? Employees { get; set; }

    }
}
