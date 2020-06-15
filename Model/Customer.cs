using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string FirstName { get; set; }

        //FK ShoppingBag
        public int? ShoppingBagID { get; set; } //FK can be null.
        public ICollection<ShoppingBag> ShoppingBags { get; set; }
        
        [NotMapped] //
        [Display(Name = "Full name")]
        public string FullName
        {
            get { return FirstName + " " + Name; }
        }

    }
}
