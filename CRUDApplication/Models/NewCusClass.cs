using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CRUDApplication.Models
{
    public class NewCusClass
    {
        [Key]
        [Required(ErrorMessage ="Enter Customer ID")]
        public int customerID { get; set; }
        [Required(ErrorMessage = "Enter Customer Name")]
        public string name { get; set; }
        [Required(ErrorMessage = "Enter Customer Code")]
        public string code { get; set; }
        [Required(ErrorMessage = "Enter Customer Address")]
        public string address { get; set; }
    }
}
