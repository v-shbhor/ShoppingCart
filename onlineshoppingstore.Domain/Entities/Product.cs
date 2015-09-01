using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace onlineshoppingstore.Domain.Entities
{
    public class Product
    {
        [HiddenInput(DisplayValue = false)]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Enter Product Name")]
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required]
        [Range(0.01,double.MaxValue,ErrorMessage ="please enter a positive price")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; }
    }
}
