using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASquaredRonModels.Models
{
    public class ContactMeModel
    {
        public int ContactId { get; set; } = 0;

        [Required]
        public string? FullName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Unable to validate email, please try again!")]
        public string? Email { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Minimum 10 characters to limit spam.")]
        [MaxLength(8192, ErrorMessage = "Maximum 8192 characters for brevity.")]
        public string? Message { get; set; }
    }
}
