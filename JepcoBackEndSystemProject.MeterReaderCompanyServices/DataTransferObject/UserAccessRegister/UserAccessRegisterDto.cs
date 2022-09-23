using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using JepcoBackEndSystemProject.Models.Models;


namespace JepcoBackEndSystemProject.Services.DataTransferObject.FaultComplaint
{
    public class LoginUserAccessRegisterDto
    {
     
        [Required]
        public string LanguageId { get; set; }      
        [Required]
        public string UserName { get; set; }
        [Required]
        public String Password { get; set; }
        [Required]
        public string LoginLatt { get; set; }
        [Required]
        public string LoginLong { get; set; }


    }


    public class LogOutUserAccessRegisterDto
    {

        [Required]
        public string LanguageId { get; set; }
        [Required]
        public int UserSerialID { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        public int BranchID { get; set; }
        [Required]
        public string LogOutLatt { get; set; }
        [Required]
        public string LogOutLong { get; set; }


    }





}
