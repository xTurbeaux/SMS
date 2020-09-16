using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; //added for validation and formatting 


namespace SMS.UI.MVC.Models
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Subject { get; set; }
        [Required(ErrorMessage = "message is required")]
        [UIHint("MultilineText")]
        public string Message { get; set; }
    }
}