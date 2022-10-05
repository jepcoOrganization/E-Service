using AutoMapper;
using JepcoBackEndSystemProject.Data;
using JepcoBackEndSystemProject.Data.CommonReturn;
using JepcoBackEndSystemProject.EmergancyAppApis.DataTransferObject.EngineerReassignTechnical;
using JepcoBackEndSystemProject.Models;
using JepcoBackEndSystemProject.Models.Models;
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
using System.Threading.Tasks;

namespace JepcoBackEndSystemProject.EmergancyAppApis.Controllers
{

    [Route("EngineerReassignTechnical")]
    [ApiController]
    public class EngineerReassignTechnical : ControllerBase
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

        public EngineerReassignTechnical(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper,
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

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost(Name = "GetFaultCompliantToReassign")]
        [Route("GetFaultCompliantToReassign")]
        // BranchId from BranchesModelResource in Resource project to hide value
        public async Task<ActionResult<CommonReturnResult>> GetFaultCompliantToReassign([FromBody] FaultCompliantToReassignRequestDto FaultCompliantToReassignRequest)
        {

            try
            {
                if (FaultCompliantToReassignRequest == null)
                {


                    return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, FaultCompliantToReassignRequest.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, FaultCompliantToReassignRequest.LanguageId, " Complaint object sent from client is null")));
                }
                if (!ModelState.IsValid)
                {

                    return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, FaultCompliantToReassignRequest.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, FaultCompliantToReassignRequest.LanguageId, "Invalid Complaint object sent from client")));
                }


                IEnumerable<tb_Fault_Compliants> lstFalutComplaintData = await _repository.FaultCompliantsLookupRepository.GetListOfFaultCompliants(x => x.UserName == FaultCompliantToReassignRequest.EmployeeNumber && x.FaultStatusID == 1 || x.FaultStatusID == 2 || x.FaultStatusID == 3).ConfigureAwait(false);


                if (lstFalutComplaintData == null)
                {

                    return NotFound(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, FaultCompliantToReassignRequest.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, FaultCompliantToReassignRequest.LanguageId, "Complaint with id hasn't been found in db") ));

                }
                else
                {


                    return Ok(_common.ReturnOkData(_common.ReturnResourceValue(_localizerAR, _localizerEN, FaultCompliantToReassignRequest.LanguageId, "Returned Complaint  Details with id")  , lstFalutComplaintData));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetFaultCompliantDetails action: {ex.Message + System.Environment.NewLine + ex.InnerException + ex.StackTrace}");

                //Call API for add error log inside TbErrorLogs

                // _common.AddErrorLog(_repository,"Branches", "GetBranchByID", $"Something went wrong inside GetBranchByID action: {ex.Message + System.Environment.NewLine + ex.InnerException + ex.StackTrace }", ex.StackTrace, ex.Message, "400");

                return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, FaultCompliantToReassignRequest.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, FaultCompliantToReassignRequest.LanguageId, "Internal server error")));

            }
        }





























    }
}
