using AutoMapper;
using JepcoBackEndSystemProject.Data;
using JepcoBackEndSystemProject.Data.CommonReturn;
using JepcoBackEndSystemProject.EmergancyAppApis.DataTransferObject.GeneralTechnicianInf;
using JepcoBackEndSystemProject.Models;
using JepcoBackEndSystemProject.Models.Models;
using JepcoBackEndSysytemProject.LoggerService;
using JepcoBackEndSysytemProject.ResourcesFiles.Resources;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost(Name = "GeneralTechnicianInf")]
        [Route("GeneralTechnicianInf")]
        // BranchId from BranchesModelResource in Resource project to hide value
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
               
                if ( (string.IsNullOrEmpty(GeneralTechnicianInfRequest.ComplaintDateEnd) == true) && string.IsNullOrEmpty(GeneralTechnicianInfRequest.ComplaintTimeStart) == true)
                {
                    DateTime dtScheduleDateFrom = DateTime.ParseExact(GeneralTechnicianInfRequest.ComplaintDateStart, "yyyy-MM-dd",
                    System.Globalization.CultureInfo.InvariantCulture);

                    lstFalutComplaintData = await _repository.FaultCompliantsLookupRepository.GetListOfFaultCompliants(x => x.CompliantDateTime.Date == dtScheduleDateFrom).ConfigureAwait(false);


                } else if ((string.IsNullOrEmpty(GeneralTechnicianInfRequest.ComplaintDateEnd) == true) && string.IsNullOrEmpty(GeneralTechnicianInfRequest.ComplaintTimeStart) == false)
                {
                    DateTime HourFrom = DateTime.ParseExact(GeneralTechnicianInfRequest.ComplaintDateStart + " " + GeneralTechnicianInfRequest.ComplaintTimeStart, "yyyy-MM-dd HH:mm",
                                  System.Globalization.CultureInfo.InvariantCulture);

                    DateTime HourTo = DateTime.ParseExact(GeneralTechnicianInfRequest.ComplaintDateStart + " " + GeneralTechnicianInfRequest.ComplaintTimeEnd, "yyyy-MM-dd HH:mm",
                                          System.Globalization.CultureInfo.InvariantCulture);

                    lstFalutComplaintData = await _repository.FaultCompliantsLookupRepository.GetListOfFaultCompliants(x => x.CompliantDateTime >= HourFrom.AddMinutes(-1) && x.CompliantDateTime <= HourTo.AddMinutes(1)).ConfigureAwait(false);

                }
                else
                {
                    DateTime dtScheduleDateFrom = DateTime.ParseExact(GeneralTechnicianInfRequest.ComplaintDateStart, "yyyy-MM-dd",
                               System.Globalization.CultureInfo.InvariantCulture);

                    DateTime dtScheduleDateEnd = DateTime.ParseExact(GeneralTechnicianInfRequest.ComplaintDateEnd, "yyyy-MM-dd",
                                          System.Globalization.CultureInfo.InvariantCulture);

                    lstFalutComplaintData = await _repository.FaultCompliantsLookupRepository.GetListOfFaultCompliants(x => x.CompliantDateTime >= dtScheduleDateFrom.Date && x.CompliantDateTime <= dtScheduleDateEnd.Date).ConfigureAwait(false);
                }


                if (lstFalutComplaintData == null)
                {

                    return NotFound(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, GeneralTechnicianInfRequest.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, GeneralTechnicianInfRequest.LanguageId, "Complaint with this date hasn't been found in db")));
                }
                else
                {



                    if (string.IsNullOrEmpty(GeneralTechnicianInfRequest.TechnicianName) == false )
                    {
                        lstFalutComplaintData = lstFalutComplaintData.Where(ss => ss.UserName == GeneralTechnicianInfRequest.TechnicianName );
                    }

                    //tb_ElectricalFaultStatus statusDto = await _repository.ElectricalFaultStatusRepository.GetSingleElectricalFaultStatus(x => x.FaultStatusNameAR == GeneralTechnicianInfRequest.FaultStatus ).ConfigureAwait(false);

                    if (string.IsNullOrEmpty(GeneralTechnicianInfRequest.PiorityDesc) == false)
                    {
                        lstFalutComplaintData = lstFalutComplaintData.Where(ss => ss.PiorityDesc == GeneralTechnicianInfRequest.PiorityDesc);
                    }

                   List<GroupCountResponseDto> final= new List<GroupCountResponseDto>();
                  ;

                    var resultmultiplekeylamba = lstFalutComplaintData
                   .GroupBy(stu => new { stu.UserName })
                   .OrderBy(g => g.Key.UserName);
                 

                    foreach (var group in resultmultiplekeylamba)
                    {
                        GroupCountResponseDto GroupCountResponse = new GroupCountResponseDto();
                        List<tb_Fault_Compliants> groupOfComp = new List<tb_Fault_Compliants>();
                        GroupCountResponse.TotalComplaintNum= group.Count();
                        GroupCountResponse.userName = group.Key.UserName;
                        GroupCountResponse.NewComplaintNum=group.Count(ss => ss.FaultStatusID == 1);
                        GroupCountResponse.DeliveredComplaintNum= group.Count(ss => ss.FaultStatusID == 2);
                        GroupCountResponse.ArrivingLocationComplaintNum=group.Count(ss => ss.FaultStatusID == 3);
                        GroupCountResponse.ClosedFromTechnicianComplaintNum = group.Count(ss => ss.FaultStatusID == 4);
                        GroupCountResponse.ReAssingedComplaintNum = group.Count(ss => ss.FaultStatusID == 5);

                        foreach (var _student in group)
                        {
                            groupOfComp.Add(_student);
                           
                        }
                        GroupCountResponse.GroupOfComplaint = groupOfComp;


                        final.Add(GroupCountResponse);
                    }
                    
                    return Ok(_common.ReturnOkData(_common.ReturnResourceValue(_localizerAR, _localizerEN, GeneralTechnicianInfRequest.LanguageId, "Returned ComplaintList with id") , final));
                }
                

            
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetComplaintByID action: {ex.Message + System.Environment.NewLine + ex.InnerException + ex.StackTrace}");
                return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, GeneralTechnicianInfRequest.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, GeneralTechnicianInfRequest.LanguageId, "Internal server error")));

            }
        }

        //----------------------------------------------------------------------------------------------------------------------------
      
        

































    }
}
