using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }

        [Display(Name = "Enter Name")]
        [StringLength(7)]
        [Required(ErrorMessage = "Name length at least 7 characters")]
        public string Name { get; set; }

        [Display(Name = "Enter SurName")]
        [StringLength(10)]
        [Required(ErrorMessage = "Name length at least 10 characters")]
        public string SurName { get; set; }

        [Display(Name = "Enter Address")]
        [StringLength(7)]
        [Required(ErrorMessage = "Address length at least 15 characters")]
        public string  Address { get; set; }

        [Display(Name = "Enter Phone number")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(10)]
        [Required(ErrorMessage = "Phone number at least 10 characters")]
        public string Phone { get; set; }

        [Display(Name = "Enter Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(15)]
        [Required(ErrorMessage = "Name length at least 15 characters")]
        public string  Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime { get; set; }
        
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
