using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheOliveBranch.Models
{
    public class FoodType
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "INT", Order = 1)]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        [Column(TypeName = "NVARCHAR", Order = 2)]
        public string Name { get; set; } = null!;
    }
}