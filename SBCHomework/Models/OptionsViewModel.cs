using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SBCHomework.Models
{
    public class OptionsViewModel
    {
        [Required(ErrorMessage = "User name is not defined!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is not defined!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is not defined!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool ShowAcc { get; set; }
        public int UniqKey { get; set; }
    }
}
