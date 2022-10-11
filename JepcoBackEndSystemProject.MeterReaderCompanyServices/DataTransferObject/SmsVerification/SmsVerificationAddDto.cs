using System;
using System.ComponentModel.DataAnnotations;

namespace JepcoBackEndSystemProject.Services.DataTransferObject.SmsVerification
{
    public class SmsVerificationAddDto
    {
      
        [Required]
        public string EmployeeNumber { get; set; }
        [Required]
        public string LanguageId { get; set; }
    }
}
