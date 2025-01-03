using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheOliveBranch.Models
{
    public class Category
    {
        [Key]
        [Required]
        [Column(TypeName = "INT", Order = 1)]
        [DisplayName("Category Id")]
        public int Id { get; set; }

        [StringLength(25)]
        [Column(TypeName = "NVARCHAR", Order = 2)]
        [DisplayName("Category Id")]
        public string CategoryName { get; set; } = null!;

        [DisplayName("Display Order")]
        [Column(TypeName = "INT", Order = 3)]
        public int DisplayOrder { get; set; }
    }
}
