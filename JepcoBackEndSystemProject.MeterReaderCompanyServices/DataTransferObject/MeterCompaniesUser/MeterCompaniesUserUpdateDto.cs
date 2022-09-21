using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JepcoBackEndSystemProject.Services.DataTransferObject.MeterCompaniesUser
{
    public class MeterCompaniesUserUpdateDto
    {
        [Required]
        public int UserID { get; set; }
        [Required]
        public string User_Name { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public List<PortalScreens> lstPortalScreens { get; set; }
        [Required]
        public string LanguageId { get; set; }
        [Required]
        public bool Active { get; set; }
    }

    
}
