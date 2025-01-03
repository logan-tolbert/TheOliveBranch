using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OliveBranch.Web.Models
{
    public class Category
    {
        [Key]
        [Required]
        [Column(TypeName = "INT", Order = 1)]
        public int Id { get; set; }

        [Column(TypeName = "NVARCHAR", Order = 2)]
        [StringLength(25)]
        public string ItemName { get; set; }

        [Column(TypeName = "INT", Order = 3)]
        public int DisplayOrder { get; set; }
    }
}
