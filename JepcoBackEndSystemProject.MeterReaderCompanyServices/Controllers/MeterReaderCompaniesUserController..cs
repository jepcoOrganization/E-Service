using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JepcoBackEndSystemProject.Data;
using JepcoBackEndSystemProject.Models.Models;
using JepcoBackEndSysytemProject.LoggerService;
using Microsoft.AspNetCore.Mvc;
using JepcoBackEndSystemProject.Services.DataTransferObject.MeterCompaniesUser;
using AutoMapper;
using JepcoBackEndSystemProject.Models;
using JepcoBackEndSystemProject.Data.CommonReturn;
using Microsoft.Extensions.Localization;
using JepcoBackEndSysytemProject.ResourcesFiles.Resources;
using System.Linq;
using Microsoft.IdentityModel.Protocols;
using System.Configuration;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JepcoBackEndSystemProject.Services.Controllers
{
    [Route("MeterReaderCompaniesUser")]
    [ApiController]
    public class MeterReaderCompaniesUserController : ControllerBase
    {
      //  #region Fields
      //  private readonly ILoggerManager _logger;
      //  private readonly IRepositoryWrapper _repository;
      //  private readonly IMapper _mapper;
      //  private readonly ICommonReturn _common;
      //  private readonly IStringLocalizer<MessagesAr> _localizerAR;
      //  private readonly IStringLocalizer<MessagesEn> _localizerEN;

      //  #endregion
      //  #region Constructor

      //  public MeterReaderCompaniesUserController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper,
      //      ICommonReturn common, IStringLocalizer<MessagesAr> localizerAR, IStringLocalizer<MessagesEn> localizerEN)
      //  {
      //      _logger = logger;
      //      _repository = repository;
      //      _mapper = mapper;
      //      _common = common;
      //      _localizerAR = localizerAR;
      //      _localizerEN = localizerEN;
      //  }
      //  #endregion
    
      //  #region GetData
      //  // POST: api/Add Complaint
      //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
      //  [HttpPost(Name = "getMeterCompaniesUserRegistrationData")]
      // [Route("getMeterCompaniesUserRegistrationData")]
      //  public async Task<IActionResult> getMeterCompaniesUserRegistrationData([FromBody] MeterCompaniesRegistrationCommonDto meterCompaniesRegistrationCommonDto)
      //  {
      //      // CommonReturnResult commontRetrunDto = new CommonReturnResult();
      //      try
      //      {
      //          if (meterCompaniesRegistrationCommonDto == null)
      //          {
      //              _logger.LogError($"{0}:meterCompaniesRegistration object sent from client is null.");
      //              return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, meterCompaniesRegistrationCommonDto.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, meterCompaniesRegistrationCommonDto.LanguageId, "Data object sent from client is null")));
      //          }
      //          if (!ModelState.IsValid)
      //          {
      //              _logger.LogError($"{0}:Invalid meterCompaniesRegistrationCommon object sent from client.");
      //              return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, meterCompaniesRegistrationCommonDto.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, meterCompaniesRegistrationCommonDto.LanguageId, "Invalid Data object sent from client")));
      //          }

      //          IEnumerable <TbMeterReadersCompanies> lstMeterReadersCompanies =  await _repository.MeterReadersCompanies.GetAllMeterReadersCompanies();

      //          IEnumerable<tbPortalScreens> lstPortalScreens = await _repository.PortalScreens.GetListOfPortalScreens (portalscreen => portalscreen.RoleId ==2 && portalscreen.Active == true);

      //          IEnumerable<TbCompanyBranches > lstCompanybranches  = await _repository.CompanyBranches.GetAllCompanyBranches();


      //          string internalnumber = lstCompanybranches.OrderByDescending(u => u.INTERNAL_NUMBER).FirstOrDefault().INTERNAL_NUMBER;

      //          lstCompanybranches = lstCompanybranches.Where(a => a.INTERNAL_NUMBER == internalnumber).ToList() ;


      //          ReturnMeterCompaniesRegistrationData returnMeterCompaniesRegistrationData = new ReturnMeterCompaniesRegistrationData
      //              {
                     
      //                  MeterReadersCompanies = (List<TbMeterReadersCompanies>)lstMeterReadersCompanies ,
      //                  PortalScreens = (List<tbPortalScreens>)lstPortalScreens,
      //              CompanyBranches = (List<TbCompanyBranches>)lstCompanybranches
      //          };

      //          var returnMeterCompaniesRegistrationReturnResult = returnMeterCompaniesRegistrationData;
      //              return Ok(_common.ReturnOkData(_common.ReturnResourceValue(_localizerAR, _localizerEN, meterCompaniesRegistrationCommonDto.LanguageId, "meter Companies Registration Info"), returnMeterCompaniesRegistrationReturnResult));
                        

      //      }
      //      catch (Exception ex)
      //      {
      //          _logger.LogError($"Something went wrong inside getRegistrationData action: {ex.Message + System.Environment.NewLine + ex.InnerException + ex.StackTrace }");
      //          return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, meterCompaniesRegistrationCommonDto.LanguageId, "Internal server error"), ex.Message));
      //      }

      //  }

      //  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
      //  [HttpPost(Name = "getAllMeterCompaniesUsersData")]
      //  [Route("getAllMeterCompaniesUsersData")]
      //  public async Task<IActionResult> getAllMeterCompaniesUsersData([FromBody] MeterCompaniesRegistrationCommonDto meterCompaniesRegistrationCommonDto)
      //  {
      //      // CommonReturnResult commontRetrunDto = new CommonReturnResult();
      //      try
      //      {
      //          if (meterCompaniesRegistrationCommonDto == null)
      //          {
      //              _logger.LogError($"{0}:meterCompaniesRegistration object sent from client is null.");
      //              return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, meterCompaniesRegistrationCommonDto.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, meterCompaniesRegistrationCommonDto.LanguageId, "Data object sent from client is null")));
      //          }
      //          if (!ModelState.IsValid)
      //          {
      //              _logger.LogError($"{0}:Invalid meterCompaniesRegistrationCommon object sent from client.");
      //              return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, meterCompaniesRegistrationCommonDto.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, meterCompaniesRegistrationCommonDto.LanguageId, "Invalid Data object sent from client")));
      //          }



      //          IEnumerable<TbUsers> lstUsers = await _repository.Users.GetAllUsers(ss => ss.UsersScreens);

      //          if (lstUsers != null)
      //          {
      //              lstUsers = lstUsers.Where(ss => ss.RoleID == 2).ToList();

      //          }


      //          IEnumerable <TbMeterReadersCompanies> lstMeterReadersCompanies = await _repository.MeterReadersCompanies.GetAllMeterReadersCompanies();

      //          IEnumerable<tbPortalScreens> lstPortalScreens = await _repository.PortalScreens.GetListOfPortalScreens(portalscreen => portalscreen.RoleId == 2 && portalscreen.Active == true);

      //          IEnumerable<TbCompanyBranches> lstCompanybranches = await _repository.CompanyBranches.GetAllCompanyBranches();

      //          string internalnumber = lstCompanybranches.OrderByDescending(u => u.INTERNAL_NUMBER).FirstOrDefault().INTERNAL_NUMBER;

      //          lstCompanybranches = lstCompanybranches.Where(a => a.INTERNAL_NUMBER == internalnumber).ToList(); 


      //          ReturnAllMeterCompaniesUsersData ReturnAllMeterCompaniesUsersData = new ReturnAllMeterCompaniesUsersData
      //          {

      //              MeterReadersCompanies = (List<TbMeterReadersCompanies>)lstMeterReadersCompanies,
      //              PortalScreens = (List<tbPortalScreens>)lstPortalScreens,
      //              CompanyBranches = (List<TbCompanyBranches >)lstCompanybranches,
      //              Users = lstUsers == null ? null: (List<TbUsers>)lstUsers
      //          };

      //          var returnMeterCompaniesRegistrationReturnResult = ReturnAllMeterCompaniesUsersData;
      //          return Ok(_common.ReturnOkData(_common.ReturnResourceValue(_localizerAR, _localizerEN, meterCompaniesRegistrationCommonDto.LanguageId, "All Meters Companies Users Info"), returnMeterCompaniesRegistrationReturnResult));

      //      }
      //      catch (Exception ex)
      //      {
      //          _logger.LogError($"Something went wrong inside getAllMeterCompaniesUsersData action: {ex.Message + System.Environment.NewLine + ex.InnerException + ex.StackTrace }");
      //          return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, meterCompaniesRegistrationCommonDto.LanguageId, "Internal server error"), ex.Message));
      //      }

      //  }

      //  #endregion
      //  #region Add and Save
      //  // POST: api/Add Complaint
      //  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
      //  [HttpPost(Name = "AddMeterCompanyUser")]
      //  [Route("AddMeterCompanyUser")]
      //  public async Task<IActionResult> AddMeterCompanyUser([FromBody] MeterCompaniesUserAddDto MeterCompanyAddDto)
      //  {
      //      // CommonReturnResult commontRetrunDto = new CommonReturnResult();
      //      try
      //      {
      //          if (MeterCompanyAddDto == null)
      //          {
      //              _logger.LogError($"{0}:MeterCompanyAdd object sent from client is null.");
      //              return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, MeterCompanyAddDto.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, MeterCompanyAddDto.LanguageId, "Data object sent from client is null")));
      //          }
      //          if (!ModelState.IsValid)
      //          {
      //              _logger.LogError($"{0}:Invalid MeterCompanyAdd object sent from client.");
      //              return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, MeterCompanyAddDto.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, MeterCompanyAddDto.LanguageId, "Invalid Data object sent from client")));
      //          }


      //          TbUsers tbusers =  new TbUsers();
      //          tbusers.Active = true;
      //          tbusers.CompanyID = MeterCompanyAddDto.CompanyID;
      //          tbusers.CompanyCode = MeterCompanyAddDto.CompanyCode;
      //          tbusers.User_Name = MeterCompanyAddDto.User_Name;
      //          tbusers.Password  = MeterCompanyAddDto.Password;
      //          tbusers.RoleID =2 ;
      //          tbusers.CreatedDate = System.DateTime.Now ;
      //          tbusers.UpdateDate = System.DateTime.Now;

                
      //          _repository.Users.Add(tbusers);

      //              await _repository.SaveAsync().ConfigureAwait(false);



      //          foreach (PortalScreens item in MeterCompanyAddDto.lstPortalScreens)
      //          {
      //              //tbPortalScreens tbPortalScreens = await _repository.PortalScreens.GetSinglePortalScreens(s => s.ScreenID == item.ScreenID && s.RoleId == 2);

      //              // tbusers.tb_PortalScreens.Add(tbPortalScreens);

      //              tbUsersScreens tbUsersScreens = new tbUsersScreens();
      //              tbUsersScreens.ScreenID = item.ScreenID;
      //              tbUsersScreens.UserID  = tbusers.UserID;
      //              _repository.UsersScreens.AddUsersScreens(tbUsersScreens);

      //          }
      //          await _repository.SaveAsync().ConfigureAwait(false);


      //          return Ok(_common.ReturnOkData(_common.ReturnResourceValue(_localizerAR, _localizerEN, MeterCompanyAddDto.LanguageId, "New Meter reading Comany User has been Added"), tbusers)) ;
      //      }
      //      catch (Exception ex)
      //      {
      //          _logger.LogError($"Something went wrong inside AddMeterCompanyUser action: {ex.Message + System.Environment.NewLine + ex.InnerException + ex.StackTrace }");
      //          return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, MeterCompanyAddDto.LanguageId, "Internal server error"), ex.Message));
      //      }
      //  }
      //  #endregion

      //  #region   Update and Save
      //  // POST: api/Add Complaint
      // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
      //  [HttpPost(Name = "UpdateMeterCompanyUser")]
      //  [Route("UpdateMeterCompanyUser")]
      //  public async Task<IActionResult> UpdateMeterCompanyUser([FromBody] MeterCompaniesUserUpdateDto MeterCompaniesUserUpdateDto)
      //  {
      //      // CommonReturnResult commontRetrunDto = new CommonReturnResult();
      //      try
      //      {
      //          if (MeterCompaniesUserUpdateDto == null)
      //          {
      //              _logger.LogError($"{0}:MeterCompaniesUserUpdateDto object sent from client is null.");
      //              return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, MeterCompaniesUserUpdateDto.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, MeterCompaniesUserUpdateDto.LanguageId, "Data object sent from client is null")));
      //          }
      //          if (!ModelState.IsValid)
      //          {
      //              _logger.LogError($"{0}:Invalid MeterCompaniesUserUpdateDto object sent from client.");
      //              return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, MeterCompaniesUserUpdateDto.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, MeterCompaniesUserUpdateDto.LanguageId, "Invalid Data object sent from client")));
      //          }

      //          var UserEntity = await _repository.Users.GetSingleUser(a => a.UserID == MeterCompaniesUserUpdateDto.UserID).ConfigureAwait(false);

      //          if (UserEntity == null)
      //          {
      //              _logger.LogError($"User with id: {MeterCompaniesUserUpdateDto.UserID }, hasn't been found in db.");
      //              return NotFound(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, MeterCompaniesUserUpdateDto.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, MeterCompaniesUserUpdateDto.LanguageId, "User with id hasn't been found in db") + MeterCompaniesUserUpdateDto.UserID));
      //          }


      //          TbUsers tbusers = new TbUsers();
      //          tbusers.UserID = MeterCompaniesUserUpdateDto.UserID;
      //          tbusers.Active = MeterCompaniesUserUpdateDto.Active;
      //          tbusers.User_Name = MeterCompaniesUserUpdateDto.User_Name;
      //          tbusers.Password = MeterCompaniesUserUpdateDto.Password;
      //          tbusers.UpdateDate = System.DateTime.Now;
      //          tbusers.CreatedDate = UserEntity.CreatedDate;
      //          tbusers.RoleID = UserEntity.RoleID;
      //          tbusers.CompanyID = UserEntity.CompanyID;
      //          tbusers.CompanyCode = UserEntity.CompanyCode;







      //          string[] excludeProp = new string[5] { "UserID", "CompanyID", "CompanyCode", "RoleID", "CreateDate" };


      //          _repository.Users.UpdateUser(excludeProp,tbusers);




      //          IEnumerable<tbUsersScreens> lstUserScreens = await _repository.UsersScreens.GetListOfUsersScreens(ss => ss.UserID == MeterCompaniesUserUpdateDto.UserID);

      //          foreach (tbUsersScreens Userscreenitem in lstUserScreens)
      //          {



      //              _repository.UsersScreens.Remove(Userscreenitem);


      //          }



      //          foreach (PortalScreens item in MeterCompaniesUserUpdateDto.lstPortalScreens)
      //          {
      //              tbUsersScreens tbUsersScreens = new tbUsersScreens();
      //              tbUsersScreens.ScreenID = item.ScreenID;
      //              tbUsersScreens.UserID = tbusers.UserID;
      //              _repository.UsersScreens.AddUsersScreens(tbUsersScreens);
      //          }

      //          await _repository.SaveAsync().ConfigureAwait(false);


      //          return Ok(_common.ReturnOkData(_common.ReturnResourceValue(_localizerAR, _localizerEN, MeterCompaniesUserUpdateDto.LanguageId, "Meter reading Comany User Data has been Updated"), tbusers)) ;
      //      }
      //      catch (Exception ex)
      //      {
      //          _logger.LogError($"Something went wrong inside UpdateMeterCompanyUser action: {ex.Message + System.Environment.NewLine + ex.InnerException + ex.StackTrace }");
      //          return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, MeterCompaniesUserUpdateDto.LanguageId, "Internal server error"), ex.Message));
      //      }
      //  }
      //  #endregion

      //  #region RemoveMeterCompanyUser

      //  [HttpPost(Name = "RemoveMeterCompanyUser")]
      //  [Route("RemoveMeterCompanyUser")]
      // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
      //  public async Task<ActionResult> RemoveMeterCompanyUser(MeterCompaniesUserCommonInfoDto MeterCompaniesUserCommonInfoDto)
      //  {


      //      try
      //      {
      //          if (MeterCompaniesUserCommonInfoDto == null)
      //          {
      //              _logger.LogError($"{0}:Invalid MeterCompaniesUserCommonInfoDto object sent from client.");

      //              //Call API for add error log inside TbErrorLogs


      //              return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, MeterCompaniesUserCommonInfoDto.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, MeterCompaniesUserCommonInfoDto.LanguageId, "Data object sent from client is null")));

      //          }

      //          if (!ModelState.IsValid)
      //          {
      //              _logger.LogError($"{0}:Invalid MeterCompaniesUserCommonInfoDto object sent from client.");

      //              //Call API for add error log inside TbErrorLogs


      //              return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, MeterCompaniesUserCommonInfoDto.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, MeterCompaniesUserCommonInfoDto.LanguageId, "Invalid Data object sent from client")));
      //          }

      //          TbUsers  response = await _repository.Users.GetSingleUser(userInfo => userInfo.UserID == MeterCompaniesUserCommonInfoDto.UserId);

      //          if (response == null)
      //          {
      //              _logger.LogError($"User with id: {MeterCompaniesUserCommonInfoDto.UserId }, hasn't been found in db.");
      //              return NotFound(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, MeterCompaniesUserCommonInfoDto.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, MeterCompaniesUserCommonInfoDto.LanguageId, "User with id hasn't been found in db") + MeterCompaniesUserCommonInfoDto.UserId));
      //          }


      //          IEnumerable<tbUsersScreens> lstUserScreens = await _repository.UsersScreens.GetListOfUsersScreens(ss => ss.UserID == MeterCompaniesUserCommonInfoDto.UserId);

      //          foreach (tbUsersScreens Userscreenitem in lstUserScreens)
      //          {

      //              _repository.UsersScreens.Remove(Userscreenitem);

      //          }

      //          _repository.Users.RemoveUser (response);
      //          await _repository.SaveAsync();
      //          return Ok(_common.ReturnOkData(_common.ReturnResourceValue(_localizerAR, _localizerEN, MeterCompaniesUserCommonInfoDto.LanguageId, "User Info"), _common.ReturnResourceValue(_localizerAR, _localizerEN, MeterCompaniesUserCommonInfoDto.LanguageId, "User has been Deleted")));


      //      }
      //      catch (Exception ex)
      //      {
      //          _logger.LogError($"Something went wrong inside RemoveMeterCompanyUser action: {ex.Message + System.Environment.NewLine + ex.InnerException + ex.StackTrace }");

      //          //Call API for add error log inside TbErrorLogs


      //          return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, MeterCompaniesUserCommonInfoDto.LanguageId, "Internal server error"), ex.Message));
      //      }
      //  }

      //  #endregion

      //  #region UserLogin


      //  [HttpPost(Name = "UserLogin")]
      //  [Route("UserLogin")]
      //  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
      //  public async Task<ActionResult> UserLogin(UserLoginDto UserLoginDto)
      //  {


      //      try
      //      {
      //          if (UserLoginDto == null)
      //          {
      //              _logger.LogError($"{0}: UserLoginDto object sent from client.");

      //              //Call API for add error log inside TbErrorLogs


      //              return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, UserLoginDto.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, UserLoginDto.LanguageId, "Data object sent from client is null")));

      //          }

      //          if (!ModelState.IsValid)
      //          {
      //              _logger.LogError($"{0}:Invalid UserLogin object sent from client");

      //              //Call API for add error log inside TbErrorLogs


      //              return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, UserLoginDto.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, UserLoginDto.LanguageId, "Invalid Data object sent from client")));
      //          }



      //          TbUsers response = await _repository.Users.GetSingleUser(userInfo => userInfo.User_Name  == UserLoginDto.username  && userInfo.Password == UserLoginDto.password);



      //          if (response == null)
      //          {
      //              return NotFound(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, UserLoginDto.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, UserLoginDto.LanguageId, "The user name or password is incorrect")));
      //          }


      //          if (response.Active== false)
      //          {
      //              return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, UserLoginDto.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, UserLoginDto.LanguageId, "Requsted User is Inactive , please conatct Adminstrator")));

      //          }


      //          IEnumerable<tbPortalScreens> lstPortalScreens = await _repository.UsersScreens.AtciveUsersScreens(response.UserID);
      //          IEnumerable<TbMeterReadersCompanies> lstMeterReadersCompanies = await _repository.MeterReadersCompanies.GetAllMeterReadersCompanies();


      //          UserLoginReslutDto objUserLoginReslutDto = new UserLoginReslutDto();
      //          objUserLoginReslutDto.Active = response.Active;
      //          objUserLoginReslutDto.CompanyCode = response.CompanyCode;
      //            objUserLoginReslutDto.CompanyID = response.CompanyID;
      //          objUserLoginReslutDto.Password  = response.Password;
      //          objUserLoginReslutDto.RoleID = response.RoleID;
      //          objUserLoginReslutDto.UserID = response.UserID;
      //          objUserLoginReslutDto.User_Name = response.User_Name;
      //          objUserLoginReslutDto.UserScreens = lstPortalScreens.ToList();
      //          objUserLoginReslutDto.MeterReadersCompanies = lstMeterReadersCompanies.ToList(); 

      //          return Ok(_common.ReturnOkData(_common.ReturnResourceValue(_localizerAR, _localizerEN, UserLoginDto.LanguageId, "You are successfully logged in"), objUserLoginReslutDto));


      //      }
      //      catch (Exception ex)
      //      {
      //          _logger.LogError($"Something went wrong inside UserLogin action: {ex.Message + System.Environment.NewLine + ex.InnerException + ex.StackTrace }");

      //          //Call API for add error log inside TbErrorLogs


      //          return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, UserLoginDto.LanguageId, "Internal server error"), ex.Message));
      //      }
      //  }


      //  #endregion





    }




}
