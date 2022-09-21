using JepcoBackEndSystemProject.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JepcoBackEndSystemProject.Services.DataTransferObject.MeterCompaniesUser
{
    public class UserLoginDto
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string LanguageId { get; set; }
    }


    public class UserLoginReslutDto
    {
        public int UserID { get; set; }
        public string User_Name { get; set; }
        public string Password { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public string CompanyCode { get; set; }
        public int RoleID { get; set; }
        public bool Active { get; set; }
        //public List<tbPortalScreens> UserScreens { get; set; }
        //public List<TbMeterReadersCompanies > MeterReadersCompanies { get; set; }


    }

    public class UserModel
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string Emails { get; set; }
        [Required]
        public string source { get; set; }
    } 
}
