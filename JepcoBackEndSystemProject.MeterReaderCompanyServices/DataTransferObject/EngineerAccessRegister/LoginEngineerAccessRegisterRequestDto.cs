using System;
using System.ComponentModel.DataAnnotations;

namespace JepcoBackEndSystemProject.EmergancyAppApis.DataTransferObject.EngineerAccessRegister
{
    public class LoginEngineerAccessRegisterRequestDto
    {
            [Required]
            public string LanguageId { get; set; }
            [Required]
            public string UserName { get; set; }
            [Required]
            public String Password { get; set; }    
    }





    public class LogoutEngineerAccessRegisterRequestDto
    {
        [Required]
        public string LanguageId { get; set; }
        [Required]
        public string UserName { get; set; }
        
      
    }











}
