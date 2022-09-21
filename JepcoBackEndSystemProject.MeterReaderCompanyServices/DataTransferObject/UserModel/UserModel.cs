using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JepcoBackEndSystemProject.EMRCServices.DataTransferObject.UserModel
{
    public class LoginModel
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
    }

    public class UserModel
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string Emails { get; set; }
        [Required]
        public string source { get; set; }
    } 
}
