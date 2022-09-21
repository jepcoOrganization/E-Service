using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using JepcoBackEndSystemProject.Models.Models;


namespace JepcoBackEndSystemProject.Services.DataTransferObject.MeterCompaniesUser
{
    public class MeterCompaniesRegistrationCommonDto
    {
     
        [Required]
        public string LanguageId { get; set; }
    }

    #region ReturnComplantData class
    public class ReturnMeterCompaniesRegistrationData
    {
        //public List<TbMeterReadersCompanies> MeterReadersCompanies { get; set; }
        //public List<tbPortalScreens> PortalScreens { get; set; }
        //public List<TbCompanyBranches> CompanyBranches { get; set; }
    }

    public class ReturnAllMeterCompaniesUsersData
    {
        //public List<TbMeterReadersCompanies> MeterReadersCompanies { get; set; }
        //public List<tbPortalScreens> PortalScreens { get; set; }
        //public List<TbCompanyBranches> CompanyBranches { get; set; }
        //public List<TbUsers> Users { get; set; }

    }

    #endregion
}
