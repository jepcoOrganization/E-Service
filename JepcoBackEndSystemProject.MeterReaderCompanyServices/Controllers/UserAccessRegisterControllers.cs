using AutoMapper;
using JepcoBackEndSystemProject.Data;
using JepcoBackEndSystemProject.Data.CommonReturn;
using JepcoBackEndSystemProject.EmergancyAppApis.DataTransferObject.UserAccessRegister;
using JepcoBackEndSystemProject.EMRCServices.DataTransferObject;
using JepcoBackEndSystemProject.Models;
using JepcoBackEndSystemProject.Models.Models;
using JepcoBackEndSystemProject.Services.DataTransferObject.FaultComplaint;
using JepcoBackEndSysytemProject.LoggerService;
using JepcoBackEndSysytemProject.ResourcesFiles.Resources;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JepcoBackEndSystemProject.EmergancyAppApis.Controllers
{
    [Route("UserAccessRegister")]
    [ApiController]
    public class UserAccessRegisterControllers : ControllerBase
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

        public UserAccessRegisterControllers(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper,
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



        [HttpPost(Name = "GetUserAccessRegisterBYID")]
        [Route("GetUserAccessRegisterBYID")]
      //  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        // CityId from CitiesModelResource in Resource project to hide value
        public async Task<ActionResult<CommonReturnResult>> GetUserAccessRegisterBYID([FromBody] UserAccessRegisterRequestDto UserAccessRegisterRequestDto)
        {

            try
            {
                if (UserAccessRegisterRequestDto == null)
                {
                    _logger.LogError($"{0}:UserAccessRegisterRequestDto object sent from client is null.");
                    return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, UserAccessRegisterRequestDto.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, UserAccessRegisterRequestDto.LanguageId, "UserAccessRegisterRequestDto object sent from client is null")));
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError($"{0}:Invalid UserAccessRegisterRequestDto object sent from client.");
                    return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, UserAccessRegisterRequestDto.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, UserAccessRegisterRequestDto.LanguageId, "Invalid UserAccessRegisterRequestDto object sent from client")));
                }

                tb_UserAccessRegister  objUserAccessRegister = await _repository.UserAccessRegisterLookupRepository .GetSingleUserAccessRegister (cty => cty.ID == UserAccessRegisterRequestDto.ID).ConfigureAwait(false);

                if (objUserAccessRegister == null)
                {
                    _logger.LogError($"UserAccessRegister with id: {UserAccessRegisterRequestDto.ID}, hasn't been found in db.");
                    return NotFound(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, UserAccessRegisterRequestDto.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, UserAccessRegisterRequestDto.LanguageId, "UserAccessRegister with id hasn't been found in db") + UserAccessRegisterRequestDto.ID));
                }
                else
                {
                    return Ok(_common.ReturnOkData("Returned UserRegister with id " + objUserAccessRegister.ID + ".", objUserAccessRegister));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetUserAccessRegisterBYID action: {ex.Message + System.Environment.NewLine + ex.InnerException + ex.StackTrace}");


                return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, UserAccessRegisterRequestDto.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, UserAccessRegisterRequestDto.LanguageId, "Internal server error")));
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost(Name = "TechnicianLogin")]
        [Route("TechnicianLogin")]
        public async Task<ActionResult<CommonReturnResult>> TechnicianLogin([FromBody] LoginUserAccessRegisterDto LoginUserAccessRegisterDto)
        {


            try
            {

                

                tb_Technical technical = await _repository.TechnicalRepository.GetSingleTechnical(x => x.EmployeeNumber == LoginUserAccessRegisterDto.UserName && x.EmployeePassword== LoginUserAccessRegisterDto.Password).ConfigureAwait(false);

                if (technical == null)
                {
                    return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, LoginUserAccessRegisterDto.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, LoginUserAccessRegisterDto.LanguageId, "you have error at your password or user name")));
                }
                if (technical.SystemActive == false)
                {
                    return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, LoginUserAccessRegisterDto.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, LoginUserAccessRegisterDto.LanguageId, "This User not Active")));
                }


                MenaTrackService.CallCenterNewClient objCallCenterNewClient = new MenaTrackService.CallCenterNewClient(MenaTrackService.CallCenterNewClient.EndpointConfiguration.BasicHttpsBinding_ICallCenterNew );

                MenaTrackService.CallLoginResponses objCallLoginResponses = await objCallCenterNewClient.JepcoLoginAsync(LoginUserAccessRegisterDto.UserName, technical.MenaTrackPassword).ConfigureAwait(false);


                if (objCallLoginResponses == null || objCallLoginResponses.UserID == 0)
                {

                    return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, LoginUserAccessRegisterDto.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, LoginUserAccessRegisterDto.LanguageId, "The user name or password is incorrect")));
                }


         

                tb_UserAccessRegister objtbUserAccessRegister = new tb_UserAccessRegister();

                objtbUserAccessRegister.UserID = objCallLoginResponses.UserID;
                objtbUserAccessRegister.FullName = technical.EmployeeNumber+"-"+technical.FullName;
                objtbUserAccessRegister.BranchId = objCallLoginResponses.BranchID;
                objtbUserAccessRegister.LoginDateTime = DateTime.Now;
                objtbUserAccessRegister.LoginLatt = LoginUserAccessRegisterDto.LoginLatt;
                objtbUserAccessRegister.LoginLong  = LoginUserAccessRegisterDto.LoginLong  ;
                objtbUserAccessRegister.UserName = LoginUserAccessRegisterDto.UserName;
                objtbUserAccessRegister.VehiclePlateNumber = LoginUserAccessRegisterDto.VehiclePlateNumber ;
                //objtbUserAccessRegister.TechnicationEmployeeNumber2 = LoginUserAccessRegisterDto.TechnicationEmployeeNumber2;
                //objtbUserAccessRegister.TechnicationFullName2  = LoginUserAccessRegisterDto.TechnicationFullName2;

                _repository.UserAccessRegisterLookupRepository.Add(objtbUserAccessRegister);
                await _repository.SaveAsync().ConfigureAwait(false);


                return Ok(_common.ReturnOkData(_common.ReturnResourceValue(_localizerAR, _localizerEN, LoginUserAccessRegisterDto.LanguageId, "You are successfully logged in"), objtbUserAccessRegister));

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside TechnicianLogin action: {ex.Message + System.Environment.NewLine + ex.InnerException + ex.StackTrace}");
                return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, LoginUserAccessRegisterDto.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, LoginUserAccessRegisterDto.LanguageId, "Internal server error")));
            }

        }
        //------------------------------------------------------------------------------------------------
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost(Name = "UpdateTechnicianLogin")]
        [Route("UpdateTechnicianLogin")]
        public async Task<ActionResult<CommonReturnResult>> UpdateTechnicianLogin ([FromBody] UpdateLoginUserAccessRegisterDto UpdateLoginUserAccessRegister)
        {


            try
            {



                tb_UserAccessRegister UserAccessRegisterRec = await _repository.UserAccessRegisterLookupRepository.GetSingleUserAccessRegister(x => x.ID == UpdateLoginUserAccessRegister.UserRegisterID ).ConfigureAwait(false);

                if (UserAccessRegisterRec == null)
                {
                    return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, UpdateLoginUserAccessRegister.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, UpdateLoginUserAccessRegister.LanguageId, "you have error at your User ID")));
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, UpdateLoginUserAccessRegister.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, UpdateLoginUserAccessRegister.LanguageId, "Invalid  object sent from client")));

                }




                UserAccessRegisterRec.VehiclePlateNumber = UpdateLoginUserAccessRegister.VehiclePlateNumber;
                UserAccessRegisterRec.TechnicationEmployeeNumber2 = UpdateLoginUserAccessRegister.TechnicationEmployeeNumber2;
                UserAccessRegisterRec.TechnicationFullName2 = UpdateLoginUserAccessRegister.TechnicationFullName2;

                _repository.UserAccessRegisterLookupRepository.Update(null, UserAccessRegisterRec);
                await _repository.SaveAsync().ConfigureAwait(false);


                return Ok(_common.ReturnOkData(_common.ReturnResourceValue(_localizerAR, _localizerEN, UpdateLoginUserAccessRegister.LanguageId, "You are successfully update in"), UserAccessRegisterRec));

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateTechnicianLogin action: {ex.Message + System.Environment.NewLine + ex.InnerException + ex.StackTrace}");
                return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, UpdateLoginUserAccessRegister.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, UpdateLoginUserAccessRegister.LanguageId, "Internal server error")));
            }

        }





        //----------------------------------------------------------------------------------
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost(Name = "TechnicianLogOut")]
        [Route("TechnicianLogOut")]
        public async Task<ActionResult<CommonReturnResult>> TechnicianLogOut([FromBody] LogOutUserAccessRegisterDto LogOutUserAccessRegisterDto)
        {



            try
            {

                IEnumerable<tb_Fault_Compliants> lstFalutComplaintData = await _repository.FaultCompliantsLookupRepository.GetListOfFaultCompliants(x => x.UserID == LogOutUserAccessRegisterDto.UserID && (x.FaultStatusID ==1 || x.FaultStatusID == 2 || x.FaultStatusID == 3)).ConfigureAwait(false);


                if (lstFalutComplaintData != null && lstFalutComplaintData.ToList().Count > 0)
                {

                    return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, LogOutUserAccessRegisterDto.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, LogOutUserAccessRegisterDto.LanguageId, "You must Close or ReAssinged all Compliants before you logout")));
                }


                tb_UserAccessRegister objUserAccessRegister = await _repository.UserAccessRegisterLookupRepository.GetSingleUserAccessRegister(x => x.ID == LogOutUserAccessRegisterDto.UserSerialID ).ConfigureAwait(false);


                objUserAccessRegister.LogOutLatt = LogOutUserAccessRegisterDto.LogOutLatt;
                objUserAccessRegister.LogOutLong  = LogOutUserAccessRegisterDto.LogOutLong;
                objUserAccessRegister.LogoutDateTime = DateTime.Now; 

                _repository.UserAccessRegisterLookupRepository.Update(null,objUserAccessRegister);
                await _repository.SaveAsync().ConfigureAwait(false);




                MenaTrackService.CallCenterNewClient objCallCenterNewClient = new MenaTrackService.CallCenterNewClient(MenaTrackService.CallCenterNewClient.EndpointConfiguration.BasicHttpsBinding_ICallCenterNew);

                bool objLogOut = await objCallCenterNewClient.JepcoLogoutAsync(LogOutUserAccessRegisterDto.UserID, LogOutUserAccessRegisterDto.BranchID).ConfigureAwait(false);


                if (objLogOut == false)
                {

                    return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, LogOutUserAccessRegisterDto.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, LogOutUserAccessRegisterDto.LanguageId, "Someting Wrong in  LogOut")));
                }



                return Ok(_common.ReturnOkData(_common.ReturnResourceValue(_localizerAR, _localizerEN, LogOutUserAccessRegisterDto.LanguageId, "You are successfully logged Out"), objUserAccessRegister));

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside TechnicianLogOut action: {ex.Message + System.Environment.NewLine + ex.InnerException + ex.StackTrace}");
                return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, LogOutUserAccessRegisterDto.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, LogOutUserAccessRegisterDto.LanguageId, "Internal server error")));
            }

        }

        //---------------------------------------------------resetpassword

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost(Name = "ResetPassword")]
        [Route("ResetPassword")]
        public async Task<ActionResult<CommonReturnResult>> ResetPassword([FromBody] ResetPasswordRequstDto ResetPasswordRequst)
        {


            try
            {


                tb_Technical technical = await _repository.TechnicalRepository.GetSingleTechnical(x => x.EmployeeNumber == ResetPasswordRequst.UserName).ConfigureAwait(false);

                if (technical == null)
                {
                    return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, ResetPasswordRequst.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, ResetPasswordRequst.LanguageId, "YOU not have any user name")));
                }



                //MenaTrackService.CallCenterNewClient objCallCenterNewClient = new MenaTrackService.CallCenterNewClient(MenaTrackService.CallCenterNewClient.EndpointConfiguration.BasicHttpsBinding_ICallCenterNew);

                //MenaTrackService.CallLoginResponses objCallLoginResponses = await objCallCenterNewClient.JepcoLoginAsync(LoginUserAccessRegisterDto.UserName, technical.MenaTrackPassword).ConfigureAwait(false);


                //if (objCallLoginResponses == null || objCallLoginResponses.UserID == 0)
                //{

                //    return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, LoginUserAccessRegisterDto.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, LoginUserAccessRegisterDto.LanguageId, "The user name or password is incorrect")));
                //}




                technical.EmployeePassword = ResetPasswordRequst.Password;
                _repository.TechnicalRepository.Update(null, technical);
                await _repository.SaveAsync().ConfigureAwait(false);




                return Ok(_common.ReturnOkData(_common.ReturnResourceValue(_localizerAR, _localizerEN, ResetPasswordRequst.LanguageId, "You are successfully logged in"), technical));

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside TechnicianLogin action: {ex.Message + System.Environment.NewLine + ex.InnerException + ex.StackTrace}");
                return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, ResetPasswordRequst.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, ResetPasswordRequst.LanguageId, "Internal server error")));
            }

//------------------------------------------------------------------------------------------------------------------


























        }



















    }
}