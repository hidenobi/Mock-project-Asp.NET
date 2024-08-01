using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
    public class TypeOfBusiness {
        [Required]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string? BusinessName { get; set; }
        [Required]
        [RegularExpression(@"^\d{4}$")]
        public string? SicCode { get; set; }
    }
}