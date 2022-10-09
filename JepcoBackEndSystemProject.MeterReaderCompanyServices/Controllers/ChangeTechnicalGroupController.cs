using AutoMapper;
using JepcoBackEndSystemProject.Data;
using JepcoBackEndSystemProject.Data.CommonReturn;
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
    //[Route("api/[controller]")]
    //[ApiController]
    //public class ChangeTechnicalGroupController : ControllerBase
    //{
    //}
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
        public async Task<ActionResult<CommonReturnResult>> GetGroupForGovernorate([FromBody] LanguageDto languageDto)
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















    }

}