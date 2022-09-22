using System;

using Microsoft.AspNetCore.Mvc;


using Microsoft.AspNetCore.Authorization;

using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JepcoBackEndSystemProject.EMRCServices.DataTransferObject;
using JepcoBackEndSystemProject.EMRCServices.DataTransferObject.UserModel;
using JepcoBackEndSystemProject.Data;
using JepcoBackEndSystemProject.Models.Models;
using JepcoBackEndSysytemProject.LoggerService;
using JepcoBackEndSysytemProject.ResourcesFiles.ModelsResources;

using AutoMapper;
using JepcoBackEndSystemProject.Data.CommonReturn;
using JepcoBackEndSysytemProject.ResourcesFiles.Resources;
using Microsoft.Extensions.Localization;

namespace JWTAuthentication.Controllers
{
    [Route("ApisLoginController")]
    [ApiController]
    public class ApisLoginController : Controller
    {
        #region Fields
        private readonly ILoggerManager _logger;
        private readonly IRepositoryWrapper _repository;
        //private readonly IMapper _mapper;
        private readonly ICommonReturn _common;
        private readonly IStringLocalizer<MessagesAr> _localizerAR;
        private readonly IStringLocalizer<MessagesEn> _localizerEN;
        #endregion

        #region Constructor

       
        #endregion

        private IConfiguration _config;

        public ApisLoginController(IConfiguration config, ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper,
            DBJEPCOBackEndContext contextdb, ICommonReturn common, Microsoft.AspNetCore.Hosting.IWebHostEnvironment environment
            , IStringLocalizer<MessagesAr> localizerAR, IStringLocalizer<MessagesEn> localizerEN)
        {
            _config = config;
            _logger = logger;
            _repository = repository;
            //_mapper = mapper;
            _common = common;
            _localizerAR = localizerAR;
            _localizerEN = localizerEN;
        }
        [AllowAnonymous]
        [HttpPost(Name = "Login")]
        [Route("Login")]
        public IActionResult Login([FromBody] LoginModel login)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response =  Ok(_common.ReturnOkData("Returned token for user" , new { token = tokenString }));

            }

            return response;
        }

        private string GenerateJSONWebToken(UserModel userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            double expiredinMIuntes = 0;
            if (userInfo.username == _config["Jwt:MeterPortalUserName"]) {

                expiredinMIuntes = double.Parse(_config["Jwt:MeterPortalTokenExpirtioninMinutes"].ToString());

            }
            
           

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(expiredinMIuntes),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private UserModel AuthenticateUser(LoginModel login)
        {
            UserModel user = null;

            //Validate the User Credentials    
            
            if (login.username == _config["Jwt:EmergancyAppUserName"] && login.password == _config["Jwt:EmergancyAppPassword"])
            {
                user = new UserModel { username = "Emergancy App Integration User", Emails = "EmergancyApp@JEPCO.com.jo" };
            }
           
            return user;
        }
    }
}