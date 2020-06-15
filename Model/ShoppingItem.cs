using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class ShoppingItem
    {

        public int ShoppingItemId { get; set; }

        [Range(1,100)]
        public int Quantity { get; set; }
        
        // Foreign key ShoppingBag
        public int ShoppingBagId { get; set; } //FK not null!
        public ShoppingBag ShoppingBag { get; set; }

        // Foreign key Product
        public int ProductId { get; set; } //FK not null!
        public Product Product { get; set; }
        
        [NotMapped]
        [Column(TypeName = "decimal(18,2)")]
        public decimal SubTotaal { get; set; } 

       

    }
}
