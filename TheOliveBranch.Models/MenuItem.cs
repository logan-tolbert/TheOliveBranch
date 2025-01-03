using System;
using System.Collections.Generic;
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

        [Required]
        [Range(0, 50)]
        [Column(TypeName = "decimal(10,2)", Order = 4)]
        public decimal Price { get; set; }

        // Foreign Key property
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        // Navigation property to the parent Category
        public virtual Category Category { get; set; }

    }
}
