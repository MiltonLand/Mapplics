using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapplicsEjercicio2.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public required string Name { get; set; }
        [Required]
        [Column("Price", TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        [MaxLength(200)]
        public string? Description { get; set; }
        [Required]
        public required Category Category { get; set; }
    }
}
