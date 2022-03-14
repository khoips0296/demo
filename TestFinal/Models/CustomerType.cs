using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestFinal.Models
{
    public class CustomerType
    {
        [Key]
        public int TypeId { get; set; }

        [StringLength(100)]
        [Required]
        public string TypeName { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}