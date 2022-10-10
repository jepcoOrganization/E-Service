using System;
using System.ComponentModel.DataAnnotations;

namespace JepcoBackEndSystemProject.Services.DataTransferObject.SmsVerification
{
    public class SmsVerificationCommonDto
    {
        [Required]
        public string EmployeeNumber { get; set; }
        [Required]
        public string MobileNumber { get; set; }

        [Required]
        public string NewPassword { get; set; }
        [Required]
        public string Smscode { get; set; }
        [Required]
        public string LanguageId { get; set; }
    }

}
