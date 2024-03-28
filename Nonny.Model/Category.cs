using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Nonny.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Category Name")]
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [DisplayName("Display Name")] //This will display any name yoy want it to display
        [Range(1, 100, ErrorMessage = "Display order must be between 1-100")]
        public int DisplayOrder { get; set; }
    }
}
