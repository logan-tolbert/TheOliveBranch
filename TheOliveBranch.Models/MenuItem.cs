using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheOliveBranch.Models
{
    public class MenuItem
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "INT", Order = 1)]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        [Column(TypeName = "NVARCHAR", Order = 2)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(255)]
        [Column(TypeName = "NVARCHAR", Order = 3)]
        public string Description { get; set; } = null!;
        [Required(ErrorMessage = "A valid image must be provided to create a new menu item.")]
        [Column(TypeName = "NVARCHAR(255)", Order = 4)]
        public string Image { get; set; } = null!;

        [Required]
        [Range(0, 50)]
        [Column(TypeName = "decimal(10,2)", Order = 5)]
        public decimal Price { get; set; }

        [DisplayName("Display Order")]
        [Column(TypeName = "INT", Order = 6)]
        public int DisplayOrder { get; set; }
        [Column(TypeName = "INT", Order = 7)]
        public int FoodTypeId { get; set; }
        [ForeignKey("FoodTypeId")]
        public virtual FoodType FoodType { get; set; }
        [Column(TypeName = "INT", Order = 8)]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category {get;set;}
    }
}
