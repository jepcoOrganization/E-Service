using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using JepcoBackEndSystemProject.Models.Models;


namespace JepcoBackEndSystemProject.Services.DataTransferObject.FaultComplaint
{
    public class UserAccessRegisterRequestDto
    {
     
        [Required]
        public string LanguageId { get; set; }      
        [Required]
        public long ID { get; set; }
       

       

    }







}
