using System;
using System.ComponentModel.DataAnnotations;

namespace EmailServiceServerlessAPI.Models
{
    public class EmailEnquiryModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        public string Company { get; set; }

        [Required]
        public string ContactNumber { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string SenderEmailAddress { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Message { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
