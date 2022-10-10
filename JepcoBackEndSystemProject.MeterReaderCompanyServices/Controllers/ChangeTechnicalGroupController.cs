using AutoMapper;
using JepcoBackEndSystemProject.Data;
using JepcoBackEndSystemProject.Data.CommonReturn;
using JepcoBackEndSystemProject.EmergancyAppApis.DataTransferObject.ChangeTechnicalGroup;
using JepcoBackEndSystemProject.EMRCServices.DataTransferObject;
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
using System.Threading.Tasks;

namespace JepcoBackEndSystemProject.EmergancyAppApis.Controllers
{
 
    [Route("ChangeTechnicalGroupController")]
    [ApiController]
    public class ChangeTechnicalGroupController : ControllerBase
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

        public ChangeTechnicalGroupController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper,
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

    [HttpPost(Name = "GetAllGovernorate")]
    [Route("GetAllGovernorate")]
    public async Task<ActionResult<CommonReturnResult>> GetAllGovernorate([FromBody] LanguageDto languageDto)
    {


        try
        {
                if (languageDto == null)
                {


                    return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, languageDto.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, languageDto.LanguageId, " Complaint object sent from client is null")));
                }
                if (!ModelState.IsValid)
                {

                    return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, languageDto.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, languageDto.LanguageId, "Invalid Complaint object sent from client")));
                }


                IEnumerable<tb_Governorate> lstGovernorateData = await _repository.GovernorateRepository.GetAllGovernorate().ConfigureAwait(false);
              

                return Ok(_common.ReturnOkData(_common.ReturnResourceValue(_localizerAR, _localizerEN, languageDto.LanguageId, "Returned all data from database"), lstGovernorateData));
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong inside GetAllStutuses action: {ex.Message + System.Environment.NewLine + ex.InnerException + ex.StackTrace}");
            return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, languageDto.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, languageDto.LanguageId, "Internal server error")));
        }

    }

        //-------------------------------------------Get group for Governorate ------------------------------------------------------

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost(Name = "GetGroupForGovernorate")]
        [Route("GetGroupForGovernorate")]
        public async Task<ActionResult<CommonReturnResult>> GetGroupForGovernorate([FromBody] GetGroupForGovernorateRequestDto GetGroupForGovernorateRequest)
        {


            try
            {
                if (GetGroupForGovernorateRequest == null)
                {


                    return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, GetGroupForGovernorateRequest.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, GetGroupForGovernorateRequest.LanguageId, " Complaint object sent from client is null")));
                }
                if (!ModelState.IsValid)
                {

                    return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, GetGroupForGovernorateRequest.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, GetGroupForGovernorateRequest.LanguageId, "Invalid Complaint object sent from client")));
                }


                IEnumerable<tb_EmergancyGroups> lstGovernorateGroupData = await _repository.EmergancyGroupsRepository.GetListOfEmergancyGroups(x => x.GovernorateId == GetGroupForGovernorateRequest.GovernorateeID).ConfigureAwait(false);


                return Ok(_common.ReturnOkData(_common.ReturnResourceValue(_localizerAR, _localizerEN, GetGroupForGovernorateRequest.LanguageId, "Returned all data from database"), lstGovernorateGroupData));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllStutuses action: {ex.Message + System.Environment.NewLine + ex.InnerException + ex.StackTrace}");
                return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, GetGroupForGovernorateRequest.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, GetGroupForGovernorateRequest.LanguageId, "Internal server error")));
            }

        }

        //-------------------------------------------Get tecnical for A group ----------------------------------------------------------


        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost(Name = "GetTechnicianForGroup")]
        [Route("GetTechnicianForGroup")]
        public async Task<ActionResult<CommonReturnResult>> GetTechnicianForGroup([FromBody] GetTechnicianForGroupRequestDto GetTechnicianForGroupRequest)
        {


            try
            {
                if (GetTechnicianForGroupRequest == null)
                {


                    return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, GetTechnicianForGroupRequest.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, GetTechnicianForGroupRequest.LanguageId, " Complaint object sent from client is null")));
                }
                if (!ModelState.IsValid)
                {

                    return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, GetTechnicianForGroupRequest.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, GetTechnicianForGroupRequest.LanguageId, "Invalid Complaint object sent from client")));
                }

                IEnumerable<tb_TechnicalGroups> lstTechnicianUserIdGroupData = await _repository.TechnicalGroupsRepository.GetListOfTechnicalGroups(x => x.GroupId == GetTechnicianForGroupRequest.GroupID).ConfigureAwait(false);
                List<tb_Technical> TecnicalOfGroup = new List<tb_Technical>();

                foreach (var techbical in lstTechnicianUserIdGroupData)
                {
                    tb_Technical TechnicianData = await _repository.TechnicalRepository.GetSingleTechnical(x => x.MenaTrackUserID == techbical.UserID).ConfigureAwait(false);
                    TecnicalOfGroup.Add(TechnicianData);
                }
                return Ok(_common.ReturnOkData(_common.ReturnResourceValue(_localizerAR, _localizerEN, GetTechnicianForGroupRequest.LanguageId, "Returned all data from database"), TecnicalOfGroup));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllStutuses action: {ex.Message + System.Environment.NewLine + ex.InnerException + ex.StackTrace}");
                return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, GetTechnicianForGroupRequest.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, GetTechnicianForGroupRequest.LanguageId, "Internal server error")));
            }


        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost(Name = "AddTechnicianForGroup")]
        [Route("AddTechnicianForGroup")]
        public async Task<ActionResult<CommonReturnResult>> AddTechnicianForGroup([FromBody] AddTechnicianForGroupRequestDto AddTechnicianForGroupRequest)
        {


            try
            {
                if (AddTechnicianForGroupRequest == null)
                {


                    return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, AddTechnicianForGroupRequest.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, AddTechnicianForGroupRequest.LanguageId, " Complaint object sent from client is null")));
                }
                if (!ModelState.IsValid)
                {

                    return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, AddTechnicianForGroupRequest.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, AddTechnicianForGroupRequest.LanguageId, "Invalid Complaint object sent from client")));
                }

                IEnumerable<tb_TechnicalGroups> lstTechnicianUserIdGroupData = await _repository.TechnicalGroupsRepository.GetListOfTechnicalGroups(x => x.GroupId == AddTechnicianForGroupRequest.GroupID).ConfigureAwait(false);
                if (lstTechnicianUserIdGroupData != null)
                {
                    foreach (var techbical in lstTechnicianUserIdGroupData)
                    {
                        _repository.TechnicalGroupsRepository.RemoveTechnicalGroups(techbical);
                        await _repository.SaveAsync().ConfigureAwait(false);
                    }
                }



                foreach (var techbical in AddTechnicianForGroupRequest.UserIDList)
                {
                    tb_TechnicalGroups TechnicalGroups = new tb_TechnicalGroups();
                    TechnicalGroups.CREATION_DATE = DateTime.Now;
                    TechnicalGroups.Update_DATE = DateTime.Now;
                    TechnicalGroups.UserID = techbical;
                    TechnicalGroups.GroupId = AddTechnicianForGroupRequest.GroupID;



                    _repository.TechnicalGroupsRepository.AddTechnicalGroups(TechnicalGroups);
                    await _repository.SaveAsync().ConfigureAwait(false);
                }







                return Ok(_common.ReturnOkData(_common.ReturnResourceValue(_localizerAR, _localizerEN, AddTechnicianForGroupRequest.LanguageId, "Returned all data from database"), AddTechnicianForGroupRequest.GroupID));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllStutuses action: {ex.Message + System.Environment.NewLine + ex.InnerException + ex.StackTrace}");
                return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, AddTechnicianForGroupRequest.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, AddTechnicianForGroupRequest.LanguageId, "Internal server error")));
            }


        }
































    }

    }