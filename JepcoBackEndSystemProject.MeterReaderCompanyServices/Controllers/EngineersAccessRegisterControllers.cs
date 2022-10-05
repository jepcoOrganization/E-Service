using AutoMapper;
using JepcoBackEndSystemProject.Data;
using JepcoBackEndSystemProject.Data.CommonReturn;
using JepcoBackEndSystemProject.EmergancyAppApis.DataTransferObject.EngineerAccessRegister;
using JepcoBackEndSystemProject.Models;
using JepcoBackEndSystemProject.Models.Models;
using JepcoBackEndSysytemProject.LoggerService;
using JepcoBackEndSysytemProject.ResourcesFiles.Resources;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.Extensions.Localization;
using System;

using System.Threading.Tasks;

namespace JepcoBackEndSystemProject.EmergancyAppApis.Controllers
{
    [Route("EngineerAccessRegister")]
    [ApiController]
    public class EngineersAccessRegisterControllers : ControllerBase
    {
        #region Fields
        private readonly ILoggerManager _logger;
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;
        private readonly ICommonReturn _common;
        private readonly IStringLocalizer<MessagesAr> _localizerAR;
        private readonly IStringLocalizer<MessagesEn> _localizerEN;
        public static Microsoft.AspNetCore.Hosting.IWebHostEnvironment _environment;

        #endregion
        #region Constructor

        public EngineersAccessRegisterControllers(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper,
            ICommonReturn common, IStringLocalizer<MessagesAr> localizerAR, IStringLocalizer<MessagesEn> localizerEN, IWebHostEnvironment environment)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
            _common = common;
            _localizerAR = localizerAR;
            _localizerEN = localizerEN;
            _environment = environment;
        }
        #endregion

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost(Name = "EngineerLogin")]
        [Route("EngineerLogin")]
        public async Task<ActionResult<CommonReturnResult>> EngineerLogin([FromBody] LoginEngineerAccessRegisterRequestDto LoginEngineerAccessRegisterRequest)
        {


            try
            {

                if (LoginEngineerAccessRegisterRequest == null)
                {

                    return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, LoginEngineerAccessRegisterRequest.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, LoginEngineerAccessRegisterRequest.LanguageId, "The user name or password is incorrect")));
                }


                tb_EngineersAccessRegister EngineersAccessRegisterUser = await _repository.EngineersAccessRegisterRepository.GetSingleEngineersAccessRegister(engineer => engineer.UserName == LoginEngineerAccessRegisterRequest.UserName).ConfigureAwait(false);
                EngineersAccessRegisterUser.LoginDateTime = DateTime.Now;

                _repository.EngineersAccessRegisterRepository.UpdateEngineersAccessRegister(null, EngineersAccessRegisterUser);
                await _repository.SaveAsync().ConfigureAwait(false);

                return Ok(_common.ReturnOkData(_common.ReturnResourceValue(_localizerAR, _localizerEN, LoginEngineerAccessRegisterRequest.LanguageId, "You are successfully logged in"), EngineersAccessRegisterUser));

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside EngineerLogin action: {ex.Message + System.Environment.NewLine + ex.InnerException + ex.StackTrace}");
                return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, LoginEngineerAccessRegisterRequest.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, LoginEngineerAccessRegisterRequest.LanguageId, "Internal server error")));
            }

        }





        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost(Name = "EngineerLogOut")]
        [Route("EngineerLogOut")]
        public async Task<ActionResult<CommonReturnResult>> EngineerLogOut([FromBody] LogoutEngineerAccessRegisterRequestDto LogoutEngineerAccessRegisterRequest)
        {


            try
            {

       
                if (LogoutEngineerAccessRegisterRequest == null)
                {

                    return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, LogoutEngineerAccessRegisterRequest.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, LogoutEngineerAccessRegisterRequest.LanguageId, "Someting Wrong in  LogOut")));
                }


                tb_EngineersAccessRegister EngineersAccessRegisterUser = await _repository.EngineersAccessRegisterRepository.GetSingleEngineersAccessRegister(engineer => engineer.UserName == LogoutEngineerAccessRegisterRequest.UserName).ConfigureAwait(false);
                EngineersAccessRegisterUser.LogoutDateTime = DateTime.Now;

                _repository.EngineersAccessRegisterRepository.UpdateEngineersAccessRegister(null, EngineersAccessRegisterUser);
                await _repository.SaveAsync().ConfigureAwait(false);


                return Ok(_common.ReturnOkData(_common.ReturnResourceValue(_localizerAR, _localizerEN, LogoutEngineerAccessRegisterRequest.LanguageId, "You are successfully logged Out"), "UserName: " + EngineersAccessRegisterUser.UserName));

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside EngineerLogOut action: {ex.Message + System.Environment.NewLine + ex.InnerException + ex.StackTrace}");
                return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, LogoutEngineerAccessRegisterRequest.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, LogoutEngineerAccessRegisterRequest.LanguageId, "Internal server error")));
            }

        }















    }
}
