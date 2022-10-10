using System;
using System.ComponentModel.DataAnnotations;

namespace JepcoBackEndSystemProject.Services.DataTransferObject.SmsVerification
{
    public class SmsOldMobileVerificationCommonDto
    {
        [Required]
        public string NewMobileNumber { get; set; }
        [Required]
        public string NewMobileDeviceId { get; set; }
        [Required]
        
        public string OldMobileNumber { get; set; }
        [Required]
        public string Smscode { get; set; }
        [Required]
        public string LanguageId { get; set; }
    }

}
