using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestFinal.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Input name")]
        public string FullName { get; set; }

        [StringLength(100)]
        [Required]
        public string Address { get; set; }

        
        [RegularExpression(@"^((09(\d){8})|(086(\d){7})|(088(\d){7})|(089(\d){7})|(01(\d){9}))$", ErrorMessage ="Invalid phone")]
        [Required]
        public string Phone { get; set; }

        [Required]
        public bool Gender { get; set; }

        [Required]
        public int TypeId { get; set; }

        public virtual CustomerType CustomerType { get; set; }

    }
}