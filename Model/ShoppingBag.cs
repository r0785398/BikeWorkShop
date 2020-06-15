using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class ShoppingBag
    {
        public int ShoppingBagId { get; set; }

        [Required]
        [DisplayName("Order date")]
        [DataType(DataType.Date)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }

        //FK Customer
        [DisplayName("Customer")]
        public int CustomerId { get; set; } //FK not null.
        public Customer Customer { get; set; }
        
        //FK ShoppingItem - collection
        [DisplayName("Item")]
        [DisplayFormat(NullDisplayText = "No item")]
        public int? ShoppingItemId { get; set; } //FK can be null.
        public ICollection<ShoppingItem> ShoppingItems { get; set; }

        [NotMapped]
        public int TotaalQty { get; set; }

        [NotMapped]
        [Column(TypeName ="decimal(18,2)")]
        public decimal SubTotaal { get; set; }

        [NotMapped]
        [Column(TypeName = "decimal(18,2)")]
        public decimal DisountProcent { get; set; }

        [NotMapped]
        [Column(TypeName = "decimal(18,2)")]
        public decimal DiscountValue { get; set; }

        [NotMapped]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Totaal { get; set; }
    }
}
