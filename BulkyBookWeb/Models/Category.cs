using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [DisplayName("Display Order")]
        [Range(0, 100, ErrorMessage ="Display Order must be between 1 and 100 only!!")]
        public int DisplayOrder { get; set; }
        public DateTime CreateDateTime { get; set; } = DateTime.Now;    // The defualt value will automatically be assigned to the created DateTime when create an object of this class.
    }
}
