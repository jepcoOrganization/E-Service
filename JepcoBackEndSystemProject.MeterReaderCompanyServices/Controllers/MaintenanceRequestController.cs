

using JepcoBackEndSystemProject.Data;
using JepcoBackEndSystemProject.Data.CommonReturn;
using JepcoBackEndSystemProject.EMRCServices.DataTransferObject;
using JepcoBackEndSystemProject.EService.DataTransferObject.MaintenanceRequest;
using JepcoBackEndSystemProject.Models;
using JepcoBackEndSystemProject.Models.Models;
using JepcoBackEndSysytemProject.LoggerService;
using JepcoBackEndSysytemProject.ResourcesFiles.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JepcoBackEndSystemProject.Services.Controllers
{
    [Route("MaintenanceRequest")]
    [ApiController]
    public class MaintenanceRequestController : ControllerBase
    
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

        public MaintenanceRequestController(IConfiguration config, ILoggerManager logger, IRepositoryWrapper repository,
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



        // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost(Name = "DistrictLookup")]
        [Route("DistrictLookup")]
        public async Task<ActionResult<CommonReturnResult>> DistrictLookup([FromBody] DistrictLookupRequestDto DistrictLookupRequest)
        {


            try
            {
                if (DistrictLookupRequest == null)
                {


                    return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, DistrictLookupRequest.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, DistrictLookupRequest.LanguageId, "  object sent from client is null")));
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, DistrictLookupRequest.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, DistrictLookupRequest.LanguageId, "Invalid  object sent from client")));

                }
                IEnumerable<tb_District> AllDistrict = await _repository.DistrictRepository.GetListOfDistrict(D => D.ID == DistrictLookupRequest.GovernateId).ConfigureAwait(false);


                return Ok(_common.ReturnOkData(_common.ReturnResourceValue(_localizerAR, _localizerEN, DistrictLookupRequest.LanguageId, "Returned All District data from database"), AllDistrict));

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DistrictLookup action: {ex.Message + System.Environment.NewLine + ex.InnerException + ex.StackTrace}");
                return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, DistrictLookupRequest.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, DistrictLookupRequest.LanguageId, "Internal server error")));
            }

        }




        // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost(Name = "GovernateLookup")]
        [Route("GovernateLookup")]
        public async Task<ActionResult<CommonReturnResult>> GovernateLookup([FromBody] LanguageDto languageDto)
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
                IEnumerable<tb_Governate> AllGovernate = await _repository.GovernateRepository.GetAllGovernate().ConfigureAwait(false);


                return Ok(_common.ReturnOkData(_common.ReturnResourceValue(_localizerAR, _localizerEN, languageDto.LanguageId, "Returned All Governate data from database"), AllGovernate));

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GovernateLookup action: {ex.Message + System.Environment.NewLine + ex.InnerException + ex.StackTrace}");
                return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, languageDto.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, languageDto.LanguageId, "Internal server error")));
            }

        }


 
        // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost(Name = "FazPowerCapacityLookup")]
        [Route("FazPowerCapacityLookup")]
        public async Task<ActionResult<CommonReturnResult>> FazPowerCapacityLookup([FromBody] LanguageDto languageDto)
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
                IEnumerable<tb_FazPowerCapacity> AllFazPowerCapacity = await _repository.FazPowerCapacityRepository.GetAllFazPowerCapacity().ConfigureAwait(false);


                return Ok(_common.ReturnOkData(_common.ReturnResourceValue(_localizerAR, _localizerEN, languageDto.LanguageId, "Returned All Faz Power Capacity Lookup data from database"), AllFazPowerCapacity));

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside FazPowerCapacityLookup action: {ex.Message + System.Environment.NewLine + ex.InnerException + ex.StackTrace}");
                return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, languageDto.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, languageDto.LanguageId, "Internal server error")));
            }

        }



        // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost(Name = "Gov")]
        [Route("Gov")]
        public async Task<ActionResult<CommonReturnResult>> Gov([FromBody] MaintenanceRequestDto MaintenanceRequest)
        {
            

            try
            {
                if (MaintenanceRequest == null)
                {


                    return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, MaintenanceRequest.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, MaintenanceRequest.LanguageId, "  object sent from client is null")));
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, MaintenanceRequest.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, MaintenanceRequest.LanguageId, "Invalid  object sent from client")));

                }







                tb_MaintenanceRequest MaintenanceRequestObj = new tb_MaintenanceRequest();
                MaintenanceRequestObj.MaintenanceTypeId = MaintenanceRequest.MaintenanceTypeId;
                MaintenanceRequestObj.ContractNumber = MaintenanceRequest.ContractNumber;
                MaintenanceRequestObj.GroupNumber = MaintenanceRequest.GroupNumber;
                MaintenanceRequestObj.MobileNumber = MaintenanceRequest.MobileNumber;
                MaintenanceRequestObj.GroupNumber = MaintenanceRequest.GroupNumber;
                MaintenanceRequestObj.DistrictID = MaintenanceRequest.DistrictID;
                MaintenanceRequestObj.StreetName = MaintenanceRequest.StreetName;
                MaintenanceRequestObj.BuildingNumber = MaintenanceRequest.BuildingNumber;
                MaintenanceRequestObj.PowerCapacityId = MaintenanceRequest.PowerCapacityId;
                MaintenanceRequestObj.Attachment_gov = MaintenanceRequest.Attachment_gov;
                MaintenanceRequestObj.CreatedDate = DateTime.Now;


                _repository.MaintenanceRequestRepository.AddMaintenanceRequest(MaintenanceRequestObj);
                await _repository.SaveAsync().ConfigureAwait(false);

                return Ok(_common.ReturnOkData(_common.ReturnResourceValue(_localizerAR, _localizerEN, MaintenanceRequest.LanguageId, "insert Maintenance Request to  database"), MaintenanceRequestObj));

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside MaintenanceRequestGov action: {ex.Message + System.Environment.NewLine + ex.InnerException + ex.StackTrace}");
                return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, MaintenanceRequest.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, MaintenanceRequest.LanguageId, "Internal server error")));
            }

        }



























    } 
}