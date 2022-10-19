using AutoMapper;
using JepcoBackEndSystemProject.Data;
using JepcoBackEndSystemProject.Data.CommonReturn;
using JepcoBackEndSystemProject.EmergancyAppApis.DataTransferObject.FaultComplaint;
using JepcoBackEndSystemProject.EmergancyAppApis.DataTransferObject.GeneralTechnicianInf;
using JepcoBackEndSystemProject.EMRCServices.DataTransferObject;
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
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace JepcoBackEndSystemProject.EmergancyAppApis.Controllers
{
    [Route("EngineersDashBoard")]
    [ApiController]
    public class EngineersDashBoardControllers : ControllerBase
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

        public EngineersDashBoardControllers(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper,
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
       // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost(Name = "GeneralTechnicianInf")]
        [Route("GeneralTechnicianInf")]

        public async Task<ActionResult<CommonReturnResult>> GeneralTechnicianInf([FromBody] GeneralTechnicianInfRequestDto GeneralTechnicianInfRequest)
        {

            try
            {
                if (GeneralTechnicianInfRequest == null)
                {

                    return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, GeneralTechnicianInfRequest.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, GeneralTechnicianInfRequest.LanguageId, " Complaint object sent from client is null")));
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, GeneralTechnicianInfRequest.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, GeneralTechnicianInfRequest.LanguageId, "Invalid Complaint object sent from client")));

                }



                IEnumerable<tb_Fault_Compliants> lstFalutComplaintData = new tb_Fault_Compliants[] { };

                if ((string.IsNullOrEmpty(GeneralTechnicianInfRequest.ComplaintDateEnd) == true) && string.IsNullOrEmpty(GeneralTechnicianInfRequest.ComplaintTimeStart) == true)
                {
                    DateTime dtScheduleDateFrom = DateTime.ParseExact(GeneralTechnicianInfRequest.ComplaintDateStart, "yyyy-MM-dd",
                    System.Globalization.CultureInfo.InvariantCulture);
                    if (string.IsNullOrEmpty(GeneralTechnicianInfRequest.EmployeeNumber) == false)
                    {


                        if (string.IsNullOrEmpty(GeneralTechnicianInfRequest.PiorityID) == false)
                        {

                            lstFalutComplaintData = await _repository.FaultCompliantsLookupRepository.GetListOfFaultCompliants(x => x.CompliantDateTime.Date == dtScheduleDateFrom && string.IsNullOrEmpty(x.CompliantParentRefNumber) == true && x.PiorityID == int.Parse(GeneralTechnicianInfRequest.PiorityID) && x.UserName == GeneralTechnicianInfRequest.EmployeeNumber).ConfigureAwait(false);
                        }
                        else
                        {
                            lstFalutComplaintData = await _repository.FaultCompliantsLookupRepository.GetListOfFaultCompliants(x => x.CompliantDateTime.Date == dtScheduleDateFrom && string.IsNullOrEmpty(x.CompliantParentRefNumber) == true && x.UserName == GeneralTechnicianInfRequest.EmployeeNumber).ConfigureAwait(false);
                        }




                    } else if (string.IsNullOrEmpty(GeneralTechnicianInfRequest.PiorityID) == false) {

                        lstFalutComplaintData = await _repository.FaultCompliantsLookupRepository.GetListOfFaultCompliants(x => x.CompliantDateTime.Date == dtScheduleDateFrom && x.PiorityID == int.Parse(GeneralTechnicianInfRequest.PiorityID) && string.IsNullOrEmpty(x.CompliantParentRefNumber) == true).ConfigureAwait(false);





                    }
                    else
                    {
                        lstFalutComplaintData = await _repository.FaultCompliantsLookupRepository.GetListOfFaultCompliants(x => x.CompliantDateTime.Date == dtScheduleDateFrom && string.IsNullOrEmpty(x.CompliantParentRefNumber) == true).ConfigureAwait(false);
                    }



                }
                else if ((string.IsNullOrEmpty(GeneralTechnicianInfRequest.ComplaintDateEnd) == true) && string.IsNullOrEmpty(GeneralTechnicianInfRequest.ComplaintTimeStart) == false)
                {
                    DateTime HourFrom = DateTime.ParseExact(GeneralTechnicianInfRequest.ComplaintDateStart + " " + GeneralTechnicianInfRequest.ComplaintTimeStart, "yyyy-MM-dd HH:mm",
                                  System.Globalization.CultureInfo.InvariantCulture);

                    DateTime HourTo = DateTime.ParseExact(GeneralTechnicianInfRequest.ComplaintDateStart + " " + GeneralTechnicianInfRequest.ComplaintTimeEnd, "yyyy-MM-dd HH:mm",
                                          System.Globalization.CultureInfo.InvariantCulture);

                    if (string.IsNullOrEmpty(GeneralTechnicianInfRequest.EmployeeNumber) == false)
                    {

                        if (string.IsNullOrEmpty(GeneralTechnicianInfRequest.PiorityID) == false) {

                            lstFalutComplaintData = await _repository.FaultCompliantsLookupRepository.GetListOfFaultCompliants(x => x.CompliantDateTime >= HourFrom.AddMinutes(-1) && x.CompliantDateTime <= HourTo.AddMinutes(1) && string.IsNullOrEmpty(x.CompliantParentRefNumber) == true && x.PiorityID == int.Parse(GeneralTechnicianInfRequest.PiorityID) && x.UserName == GeneralTechnicianInfRequest.EmployeeNumber).ConfigureAwait(false);

                        }
                        else {

                            lstFalutComplaintData = await _repository.FaultCompliantsLookupRepository.GetListOfFaultCompliants(x => x.CompliantDateTime >= HourFrom.AddMinutes(-1) && x.CompliantDateTime <= HourTo.AddMinutes(1) && string.IsNullOrEmpty(x.CompliantParentRefNumber) == true && x.UserName == GeneralTechnicianInfRequest.EmployeeNumber).ConfigureAwait(false);
                        }







                    }
                    else if(string.IsNullOrEmpty(GeneralTechnicianInfRequest.PiorityID) == false) {



                        lstFalutComplaintData = await _repository.FaultCompliantsLookupRepository.GetListOfFaultCompliants(x => x.CompliantDateTime >= HourFrom.AddMinutes(-1) && x.CompliantDateTime <= HourTo.AddMinutes(1) && string.IsNullOrEmpty(x.CompliantParentRefNumber) == true && x.PiorityID == int.Parse(GeneralTechnicianInfRequest.PiorityID)).ConfigureAwait(false);



                    }
                    else
                    {

                    lstFalutComplaintData = await _repository.FaultCompliantsLookupRepository.GetListOfFaultCompliants(x => x.CompliantDateTime >= HourFrom.AddMinutes(-1) && x.CompliantDateTime <= HourTo.AddMinutes(1) && string.IsNullOrEmpty(x.CompliantParentRefNumber) == true).ConfigureAwait(false);
                    }
                }






                else
                {
                    DateTime dtScheduleDateFrom = DateTime.ParseExact(GeneralTechnicianInfRequest.ComplaintDateStart, "yyyy-MM-dd",
                               System.Globalization.CultureInfo.InvariantCulture);

                    DateTime dtScheduleDateEnd = DateTime.ParseExact(GeneralTechnicianInfRequest.ComplaintDateEnd, "yyyy-MM-dd",
                                          System.Globalization.CultureInfo.InvariantCulture);

                    if (string.IsNullOrEmpty(GeneralTechnicianInfRequest.EmployeeNumber) == false)
                    {


                        if (string.IsNullOrEmpty(GeneralTechnicianInfRequest.PiorityID) == false)
                        {
                            lstFalutComplaintData = await _repository.FaultCompliantsLookupRepository.GetListOfFaultCompliants(x => x.CompliantDateTime.Date > dtScheduleDateFrom.Date.AddDays(-1) && x.CompliantDateTime.Date < dtScheduleDateEnd.Date.AddDays(1) && string.IsNullOrEmpty(x.CompliantParentRefNumber) == true && x.PiorityID == int.Parse(GeneralTechnicianInfRequest.PiorityID) && x.UserName == GeneralTechnicianInfRequest.EmployeeNumber).ConfigureAwait(false);

                        }
                        else
                        {
                            lstFalutComplaintData = await _repository.FaultCompliantsLookupRepository.GetListOfFaultCompliants(x => x.CompliantDateTime.Date > dtScheduleDateFrom.Date.AddDays(-1) && x.CompliantDateTime.Date < dtScheduleDateEnd.Date.AddDays(1) && string.IsNullOrEmpty(x.CompliantParentRefNumber) == true && x.UserName == GeneralTechnicianInfRequest.EmployeeNumber).ConfigureAwait(false);

                        }





                    }
                    else if (string.IsNullOrEmpty(GeneralTechnicianInfRequest.PiorityID) == false) {
                        lstFalutComplaintData = await _repository.FaultCompliantsLookupRepository.GetListOfFaultCompliants(x => x.CompliantDateTime.Date > dtScheduleDateFrom.Date.AddDays(-1) && x.CompliantDateTime.Date < dtScheduleDateEnd.Date.AddDays(1)&& x.PiorityID == int.Parse(GeneralTechnicianInfRequest.PiorityID) && string.IsNullOrEmpty(x.CompliantParentRefNumber) == true).ConfigureAwait(false);


                    }
                    else
                    {

                        lstFalutComplaintData = await _repository.FaultCompliantsLookupRepository.GetListOfFaultCompliants(x => x.CompliantDateTime.Date > dtScheduleDateFrom.Date.AddDays(-1) && x.CompliantDateTime.Date < dtScheduleDateEnd.Date.AddDays(1) && string.IsNullOrEmpty(x.CompliantParentRefNumber) == true).ConfigureAwait(false);
                    }
                }









                if (lstFalutComplaintData == null && lstFalutComplaintData.ToList().Count == 0)
                {
                    return Ok(_common.ReturnOkData(_common.ReturnResourceValue(_localizerAR, _localizerEN, GeneralTechnicianInfRequest.LanguageId, "Returned NO Complaint IN List"), lstFalutComplaintData));
                }







                else
                    {

                        List<GroupCountResponseDto> final = new List<GroupCountResponseDto>();

                        var resultmultiplekeylamba = lstFalutComplaintData
                       .GroupBy(stu => new { stu.UserName })
                       .OrderBy(g => g.Key.UserName);


                        foreach (var group in resultmultiplekeylamba)

                        {
                            tb_Technical technical = await _repository.TechnicalRepository.GetSingleTechnical(x => x.EmployeeNumber == group.Key.UserName).ConfigureAwait(false);
                         
                            GroupCountResponseDto GroupCountResponse = new GroupCountResponseDto();
                            List<tb_Fault_Compliants> groupOfComp = new List<tb_Fault_Compliants>();
                            GroupCountResponse.FullName = technical.FullName;
                            GroupCountResponse.TotalComplaintNum = group.Count();
                            GroupCountResponse.EmployeeNumber = group.Key.UserName;                         
                            GroupCountResponse.NewComplaintNum = group.Count(ss => ss.FaultStatusID == 1);
                            GroupCountResponse.DeliveredComplaintNum = group.Count(ss => ss.FaultStatusID == 2);
                            GroupCountResponse.ArrivingLocationComplaintNum = group.Count(ss => ss.FaultStatusID == 3);
                            GroupCountResponse.ClosedFromTechnicianComplaintNum = group.Count(ss => ss.FaultStatusID == 4);
                            GroupCountResponse.ReAssingedComplaintNum = group.Count(ss => ss.FaultStatusID == 5);

                            foreach (var _complaint in group)
                            {
                                groupOfComp.Add(_complaint);

                            }
                            GroupCountResponse.GroupOfComplaint = groupOfComp;


                            final.Add(GroupCountResponse);
                        }
                        return Ok(_common.ReturnOkData(_common.ReturnResourceValue(_localizerAR, _localizerEN, GeneralTechnicianInfRequest.LanguageId, "Returned ComplaintList and there Num"), final));

                    }





                

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GeneralTechnicianInf action: {ex.Message + System.Environment.NewLine + ex.InnerException + ex.StackTrace}");
                return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, GeneralTechnicianInfRequest.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, GeneralTechnicianInfRequest.LanguageId, "Internal server error")));

            }
        }

        //----------------------------------------------------------------------------------------------------------------------------


       // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost(Name = "TechnicianLoginHistory")]
        [Route("TechnicianLoginHistory")]

        public async Task<ActionResult<CommonReturnResult>> TechnicianLoginHistory([FromBody] TechnicianLoginHistoryRequestDto TechnicianLoginHistoryRequest)
        {

            try
            {
                if (TechnicianLoginHistoryRequest == null)
                {


                    return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, TechnicianLoginHistoryRequest.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, TechnicianLoginHistoryRequest.LanguageId, " History object sent from client is null")));
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, TechnicianLoginHistoryRequest.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, TechnicianLoginHistoryRequest.LanguageId, "Invalid history object sent from client")));

                }



                IEnumerable<tb_UserAccessRegister> lstUserAccessRegisterData = new tb_UserAccessRegister[] { };


                if ((string.IsNullOrEmpty(TechnicianLoginHistoryRequest.HistoryDateEnd) == true))
                {
                    DateTime dtScheduleDateFrom = DateTime.ParseExact(TechnicianLoginHistoryRequest.HistoryDateStart, "yyyy-MM-dd",
                  CultureInfo.InvariantCulture);

                    lstUserAccessRegisterData = await _repository.UserAccessRegisterLookupRepository.GetListOfUserAccessRegister(x => x.LoginDateTime.Date == dtScheduleDateFrom && x.UserName == TechnicianLoginHistoryRequest.EmployeeNumber).ConfigureAwait(false);


                }
                else
                {
                    DateTime dtScheduleDateFrom = DateTime.ParseExact(TechnicianLoginHistoryRequest.HistoryDateStart, "yyyy-MM-dd",
                             CultureInfo.InvariantCulture);

                    DateTime dtScheduleDateEnd = DateTime.ParseExact(TechnicianLoginHistoryRequest.HistoryDateEnd, "yyyy-MM-dd",
                                       CultureInfo.InvariantCulture);

                    lstUserAccessRegisterData = await _repository.UserAccessRegisterLookupRepository.GetListOfUserAccessRegister(x => x.LoginDateTime.Date >= dtScheduleDateFrom && x.LoginDateTime.Date <= dtScheduleDateEnd && x.UserName== TechnicianLoginHistoryRequest.EmployeeNumber).ConfigureAwait(false);
                }

            

                foreach (var group in lstUserAccessRegisterData)

                {


                    
                    char[] spearator = { '-' };
                    String[] strlist = group.FullName.Split(spearator);
                    group.FullName= strlist[1];


               


                }


                return Ok(_common.ReturnOkData(_common.ReturnResourceValue(_localizerAR, _localizerEN, TechnicianLoginHistoryRequest.LanguageId, "Returned History List "), lstUserAccessRegisterData));
                



            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside TechnicianLoginHistory action: {ex.Message + System.Environment.NewLine + ex.InnerException + ex.StackTrace}");
                return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, TechnicianLoginHistoryRequest.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, TechnicianLoginHistoryRequest.LanguageId, "Internal server error")));

            }
        }

        //-------------------------------------------------------------------------------------------------------
       // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost(Name = "TechnicalLookup")]
        [Route("TechnicalLookup")]
        public async Task<ActionResult<CommonReturnResult>> GetAllAllTechnical([FromBody] LanguageDto languageDto)
        {


            try
            {
                if (languageDto == null)
                {


                    return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, languageDto.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, languageDto.LanguageId, "  object sent from client is null")));
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, languageDto.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, languageDto.LanguageId, "Invalid  object sent from client")));

                }
                IEnumerable<tb_Technical> AllTechnical = await _repository.TechnicalRepository.GetAllTechnical().ConfigureAwait(false);


                return Ok(_common.ReturnOkData(_common.ReturnResourceValue(_localizerAR, _localizerEN, languageDto.LanguageId, "Returned AllTechnical data from database"), AllTechnical));

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside TechnicalLookup action: {ex.Message + System.Environment.NewLine + ex.InnerException + ex.StackTrace}");
                return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, languageDto.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, languageDto.LanguageId, "Internal server error")));
            }

        }
        //-----------------------------------------------------------------------------------
      //  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost(Name = "SingleTechnical")]
        [Route("SingleTechnical")]
        public async Task<ActionResult<CommonReturnResult>> SingleTechnical([FromBody] SingleTechnicalRequestDto SingleTechnicalRequest)
        {


            try
            {
                if (SingleTechnicalRequest == null)
                {


                    return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, SingleTechnicalRequest.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, SingleTechnicalRequest.LanguageId, "  object sent from client is null")));
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, SingleTechnicalRequest.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, SingleTechnicalRequest.LanguageId, "Invalid  object sent from client")));

                }
                tb_Technical technical = await _repository.TechnicalRepository.GetSingleTechnical(x => x.EmployeeNumber == SingleTechnicalRequest.EmployeeNumber).ConfigureAwait(false);


                return Ok(_common.ReturnOkData(_common.ReturnResourceValue(_localizerAR, _localizerEN, SingleTechnicalRequest.LanguageId, "Returned AllTechnical data from database"), technical));

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside TechnicalLookup action: {ex.Message + System.Environment.NewLine + ex.InnerException + ex.StackTrace}");
                return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, SingleTechnicalRequest.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, SingleTechnicalRequest.LanguageId, "Internal server error")));
            }

        }
        //---------------------------------------------------------------------------------------------------------
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost(Name = "ActiveTechnical")]
        [Route("ActiveTechnical")]
        public async Task<ActionResult<CommonReturnResult>> ActiveTechnical([FromBody] ActiveTechnicalRequestDto ActiveTechnicalRequest)
        {


            try
            {

                if (ActiveTechnicalRequest == null)
                {


                    return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, ActiveTechnicalRequest.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, ActiveTechnicalRequest.LanguageId, "  object sent from client is null")));
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, ActiveTechnicalRequest.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, ActiveTechnicalRequest.LanguageId, "Invalid  object sent from client")));

                }



                tb_Technical technical = await _repository.TechnicalRepository.GetSingleTechnical(x => x.EmployeeNumber == ActiveTechnicalRequest.EmployeeNumber).ConfigureAwait(false);
                if (technical.SystemActive != ActiveTechnicalRequest.ActiveStatus)
                {

                    technical.SystemActive=ActiveTechnicalRequest.ActiveStatus;
                    _repository.TechnicalRepository.UpdateTechnical(null, technical);
                    await _repository.SaveAsync().ConfigureAwait(false);
                    return Ok(_common.ReturnOkData(_common.ReturnResourceValue(_localizerAR, _localizerEN, ActiveTechnicalRequest.LanguageId, "Change status  for ") + technical.FullName + " to", technical.SystemActive));

                }
                else
                {
                    return Ok(_common.ReturnOkData(_common.ReturnResourceValue(_localizerAR, _localizerEN, ActiveTechnicalRequest.LanguageId, "No Change status  for ") + technical.FullName + " it is ", technical.SystemActive));

                }


            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside ActiveTechnical action: {ex.Message + System.Environment.NewLine + ex.InnerException + ex.StackTrace}");
                return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, ActiveTechnicalRequest.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, ActiveTechnicalRequest.LanguageId, "Internal server error")));
            }

        }

        //----------------------------------------------------------------------------------------------------------------
      //  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost(Name = "Monitor")]
        [Route("Monitor")]
        public async Task<ActionResult<CommonReturnResult>> Monitor([FromBody] MonitorRequestDto MonitorRequest)
        {


            try
            {

                if (MonitorRequest == null)
                {


                    return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, MonitorRequest.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, MonitorRequest.LanguageId, "  object sent from client is null")));
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, MonitorRequest.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, MonitorRequest.LanguageId, "Invalid  object sent from client")));

                }



                tb_Technical technical = await _repository.TechnicalRepository.GetSingleTechnical(x => x.EmployeeNumber == MonitorRequest.EmployeeNumber).ConfigureAwait(false);
                IEnumerable<tb_Fault_Compliants> lstFalutComplaintData = await _repository.FaultCompliantsLookupRepository.GetListOfFaultCompliants(x => x.UserName == MonitorRequest.EmployeeNumber && x.FaultStatusID == 3 && string.IsNullOrEmpty(x.CompliantParentRefNumber) == true).ConfigureAwait(false);
                IEnumerable<tb_Fault_Compliants> lstFalutComplaintNew = await _repository.FaultCompliantsLookupRepository.GetListOfFaultCompliants(x => x.UserName == MonitorRequest.EmployeeNumber && x.FaultStatusID == 1).ConfigureAwait(false);

                if (technical == null   )
                {

                    return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, MonitorRequest.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, MonitorRequest.LanguageId, "he is not afound")));
                }


                tb_Fault_Compliants LastArrivecompliant = null;
                tb_FaultDetails LastComplaintFaultDetails = null;


                if (lstFalutComplaintData != null && lstFalutComplaintData.ToList().Count > 0)
                {
                    LastArrivecompliant = lstFalutComplaintData.First();
                    LastComplaintFaultDetails = await _repository.FaultDetailsRepository.GetSingleFaultDetails(faultDetails => faultDetails.FaultComplaintID == lstFalutComplaintData.First().FaultComplaintID).ConfigureAwait(false);

                    if (lstFalutComplaintData.Count() > 1)

                    {
                        foreach (var Arrivecompliant in lstFalutComplaintData)
                        {
                            tb_FaultDetails ComplaintFaultDetails = await _repository.FaultDetailsRepository.GetSingleFaultDetails(faultDetails => faultDetails.FaultComplaintID == Arrivecompliant.FaultComplaintID).ConfigureAwait(false);

                            if (ComplaintFaultDetails.ArrivingLocationDateTime > LastComplaintFaultDetails.ArrivingLocationDateTime)
                            {
                                LastArrivecompliant = Arrivecompliant;
                                LastComplaintFaultDetails = ComplaintFaultDetails;
                            }

                        }
                    }
                }



                MonitorResponseDto MonitorResponse = new MonitorResponseDto();

                IEnumerable<tb_UserAccessRegister> catnum = await _repository.UserAccessRegisterLookupRepository.GetListOfUserAccessRegister(x => x.UserName == MonitorRequest.EmployeeNumber).ConfigureAwait(false);

                if (catnum != null && catnum.ToList().Count() > 0)
                {
                    DateTime timelog = catnum.Max(ss => ss.LoginDateTime);
                    catnum = catnum.Where(ss => ss.LoginDateTime == timelog);



                    MonitorResponse.TechnicianName = technical.FullName;
                    MonitorResponse.TechnicianStatus = technical.SystemActive;

                    MonitorResponse.LastTechnicianPlace = LastArrivecompliant != null ? LastArrivecompliant.DistrictName + " / " + LastArrivecompliant.ZoneName : "-";
                    MonitorResponse.ComplaintRefNumberisworking = LastArrivecompliant != null ? LastArrivecompliant.ComplaintRefNumber : "لا يوجد";

                    MonitorResponse.NewComplaintNum = lstFalutComplaintNew == null && lstFalutComplaintNew.Count() == 0 ? 0 : lstFalutComplaintNew.Count();
                    MonitorResponse.VehiclePlateNumber = catnum.First().VehiclePlateNumber;
                }
                else
                {
                    //MonitorResponse = null;
                    
                }


                return Ok(_common.ReturnOkData(_common.ReturnResourceValue(_localizerAR, _localizerEN, MonitorRequest.LanguageId, "The response is ") , MonitorResponse));


            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside ActiveTechnical action: {ex.Message + System.Environment.NewLine + ex.InnerException + ex.StackTrace}");
                return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, MonitorRequest.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, MonitorRequest.LanguageId, "Internal server error")));
            }

        }
        //-----------------------------------------------------------------------------
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //[HttpPost(Name = "TechnicalLookup")]
        //[Route("TechnicalLookup")]
        //public async Task<ActionResult<CommonReturnResult>> GetAllAllTechnical([FromBody] LanguageDto languageDto)
        //{


        //    try
        //    {
        //        if (languageDto == null)
        //        {


        //            return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, languageDto.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, languageDto.LanguageId, "  object sent from client is null")));
        //        }
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, languageDto.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, languageDto.LanguageId, "Invalid  object sent from client")));

        //        }
        //        IEnumerable<tb_Technical> AllTechnical = await _repository.TechnicalRepository.GetAllTechnical().ConfigureAwait(false);


        //        return Ok(_common.ReturnOkData(_common.ReturnResourceValue(_localizerAR, _localizerEN, languageDto.LanguageId, "Returned AllTechnical data from database"), AllTechnical));

        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Something went wrong inside TechnicalLookup action: {ex.Message + System.Environment.NewLine + ex.InnerException + ex.StackTrace}");
        //        return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, languageDto.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, languageDto.LanguageId, "Internal server error")));
        //    }

        //}

































    }

}
