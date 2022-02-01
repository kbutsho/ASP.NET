using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Form.Models
{
    public class Form
    {
        [Required(ErrorMessage ="Name is required!")]
        [StringLength(10, ErrorMessage = "Name length must not exceed 10")]
        public string Name { get; set; }
        [EmailAddress(ErrorMessage = "Type Valid Email")]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Password { get; set; }
    }
}