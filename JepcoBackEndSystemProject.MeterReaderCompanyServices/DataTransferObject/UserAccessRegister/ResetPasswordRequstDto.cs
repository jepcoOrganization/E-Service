using System;
using System.ComponentModel.DataAnnotations;

namespace JepcoBackEndSystemProject.EmergancyAppApis.DataTransferObject.UserAccessRegister
{
    public class ResetPasswordRequstDto
    {
        [Required]
        public string LanguageId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public String Confirmtion_Code { get; set; }
        [Required]
        public String Password { get; set; }
   

        [Required]
        public String Confirmtion_Password { get; set; }

        //[Required]
        //public string EmployeeMobileNumber { get; set; }

    }
}
