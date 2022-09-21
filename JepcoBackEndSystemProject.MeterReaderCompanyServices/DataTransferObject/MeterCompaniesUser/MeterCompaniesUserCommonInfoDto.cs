using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JepcoBackEndSystemProject.Services.DataTransferObject.MeterCompaniesUser
{
    public class MeterCompaniesUserCommonInfoDto
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public string LanguageId { get; set; }
        
   
      
    }
}
