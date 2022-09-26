﻿using AutoMapper;
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

                if ( GeneralTechnicianInfRequest.ComplaintDateEnd == "" || GeneralTechnicianInfRequest.ComplaintDateEnd == null && GeneralTechnicianInfRequest.ComplaintDateStart == "" || GeneralTechnicianInfRequest.ComplaintTimeStart == null)
                {
                    DateTime dtScheduleDateFrom = DateTime.ParseExact(GeneralTechnicianInfRequest.ComplaintDateStart, "yyyy-MM-dd",
                    System.Globalization.CultureInfo.InvariantCulture);

                    lstFalutComplaintData = await _repository.FaultCompliantsLookupRepository.GetListOfFaultCompliants(x => x.CompliantDateTime.Date == dtScheduleDateFrom).ConfigureAwait(false);


                } else if (GeneralTechnicianInfRequest.ComplaintDateEnd == "" || GeneralTechnicianInfRequest.ComplaintDateEnd == null && GeneralTechnicianInfRequest.ComplaintDateStart != "" || GeneralTechnicianInfRequest.ComplaintTimeStart != null) 
                {
                    DateTime HourFrom = DateTime.ParseExact(GeneralTechnicianInfRequest.ComplaintDateStart + " " + GeneralTechnicianInfRequest.ComplaintTimeStart, "yyyy-MM-dd HH:mm",
                                  System.Globalization.CultureInfo.InvariantCulture);

                    DateTime HourTo = DateTime.ParseExact(GeneralTechnicianInfRequest.ComplaintDateStart + " " + GeneralTechnicianInfRequest.ComplaintTimeEnd, "yyyy-MM-dd HH:mm",
                                          System.Globalization.CultureInfo.InvariantCulture);

                    lstFalutComplaintData = await _repository.FaultCompliantsLookupRepository.GetListOfFaultCompliants(x => x.CompliantDateTime >= HourFrom.AddMinutes(-1) && x.CompliantDateTime <= HourTo.AddMinutes(1)).ConfigureAwait(false);

                }
                else
                {
                    //DateTime dtScheduleDateFrom = DateTime.ParseExact(GeneralTechnicianInfRequest.ComplaintDateStart, "yyyy-MM-dd",
                    //           System.Globalization.CultureInfo.InvariantCulture);

                    //DateTime dtScheduleDateEnd = DateTime.ParseExact(GeneralTechnicianInfRequest.ComplaintDateEnd , "yyyy-MM-dd",
                    //                      System.Globalization.CultureInfo.InvariantCulture);

                    //lstFalutComplaintData = await _repository.FaultCompliantsLookupRepository.GetListOfFaultCompliants(x => x.CompliantDateTime >= dtScheduleDateFrom.Date && x.CompliantDateTime <= dtScheduleDateEnd.Date).ConfigureAwait(false);
                }


                if (lstFalutComplaintData == null)
                {

                    return NotFound(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, GeneralTechnicianInfRequest.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, GeneralTechnicianInfRequest.LanguageId, "Complaint with this date hasn't been found in db")));
                }
                else
                {


                    //if (lstFalutComplaintData != null && lstFalutComplaintData.ToList().Count > 0)
                    //{


                        //DateTime internalnumber = lstFalutComplaintData.OrderByDescending(u => u.CreatedDate).FirstOrDefault().CreatedDate;

                        //lstFalutComplaintData = lstFalutComplaintData.Where(a => a.CreatedDate == internalnumber).ToList();




                        //if (string.IsNullOrEmpty(UnreadedMetersDto.ContractStatrtingDateFrom) == false && string.IsNullOrEmpty(UnreadedMetersDto.ContractStatrtingDateTo) == false)
                        //{

                        //    DateTime dtContractStatrtingDateFrom = DateTime.ParseExact(UnreadedMetersDto.ContractStatrtingDateFrom.ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                        //    DateTime dtContractStatrtingDateTo = DateTime.ParseExact(UnreadedMetersDto.ContractStatrtingDateTo.ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture);

                        //    lstUnreadedMeters = lstUnreadedMeters.Where(ss => ss.CONTRACT_STARTING_DATE >= dtContractStatrtingDateTo && ss.CONTRACT_STARTING_DATE <= dtContractStatrtingDateTo);

                        //}


                    //}




                    return Ok(_common.ReturnOkData(_common.ReturnResourceValue(_localizerAR, _localizerEN, GeneralTechnicianInfRequest.LanguageId, "Returned Complaint with id") + lstFalutComplaintData, lstFalutComplaintData));
                }
                //return Ok(_common.ReturnOkData(_common.ReturnResourceValue(_localizerAR, _localizerEN, GeneralTechnicianInfRequest.LanguageId, "Returned Complaint with id")+ lstFalutComplaintData, lstFalutComplaintData));

            //}
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetComplaintByID action: {ex.Message + System.Environment.NewLine + ex.InnerException + ex.StackTrace}");

                //Call API for add error log inside TbErrorLogs

                // _common.AddErrorLog(_repository,"Branches", "GetBranchByID", $"Something went wrong inside GetBranchByID action: {ex.Message + System.Environment.NewLine + ex.InnerException + ex.StackTrace }", ex.StackTrace, ex.Message, "400");

                return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, GeneralTechnicianInfRequest.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, GeneralTechnicianInfRequest.LanguageId, "Internal server error")));

            }
        }

        //----------------------------------------------------------------------------------------------------------------------------
      
        

































    }
}