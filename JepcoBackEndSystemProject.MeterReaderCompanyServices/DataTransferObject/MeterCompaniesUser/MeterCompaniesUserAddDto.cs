using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using JepcoBackEndSystemProject.Models.Models;


namespace JepcoBackEndSystemProject.Services.DataTransferObject.MeterCompaniesUser
{
    public class MeterCompaniesUserAddDto
    {
        [Required]
        public int UserID { get; set; }
        [Required]
        public string User_Name { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public Nullable<int> CompanyID { get; set; }
        [Required]
        public string CompanyCode { get; set; }
       
        [Required]
        public List<PortalScreens> lstPortalScreens { get; set; }
        [Required]
        public string LanguageId { get; set; }
    }

    public class PortalScreens
    {
        public int ScreenID { get; set; }

    }


}
