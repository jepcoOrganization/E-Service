

using JepcoBackEndSystemProject.Data;
using JepcoBackEndSystemProject.Data.CommonReturn;
using JepcoBackEndSystemProject.EMRCServices.DataTransferObject;
using JepcoBackEndSystemProject.EService.DataTransferObject.MaintenanceRequest;
using JepcoBackEndSystemProject.EService.SAPException;
using JepcoBackEndSystemProject.Models;
using JepcoBackEndSystemProject.Models.Models;
using JepcoBackEndSysytemProject.LoggerService;
using JepcoBackEndSysytemProject.ResourcesFiles.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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



                string SapURL = _config["SAPAPIData:SAPServiceURL"];
                string serviceName = "/Z_CREATE_SRV_N_GOV_SRV/SrvN_GOVSet";



                string ServiceCURLGetCSRF = SapURL + serviceName + "(Vertrag='" + MaintenanceRequest.ContractNumber + "',ApiTyp='G',BuSort1='" + MaintenanceRequest.GroupNumber + "')?$format=json";




                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                ServicePointManager.DefaultConnectionLimit = 1000;

                var options = new RestClientOptions(ServiceCURLGetCSRF)
                {
                    ThrowOnAnyError = false

                };


                var client1 = new RestClient(options);

                var request1 = new RestRequest();

                IEnumerable<string> cookies = new List<string>();

                CookieContainer cookieJar = new CookieContainer();

                request1.AddHeader("x-csrf-token", "fetch");
                var username = _config["SAPAPIData:SAP_UserName"];
                var password = _config["SAPAPIData:SAP_Pass"];



                client1.Authenticator = new HttpBasicAuthenticator(username, password);

                var response1 = new RestSharp.RestResponse();

                response1 = await client1.ExecuteGetAsync(request1, System.Threading.CancellationToken.None);



                if (response1.StatusCode == HttpStatusCode.BadRequest)
                {

                    SAPExceptionRoot objSAPExceptionRoot = null;
                     objSAPExceptionRoot = JsonConvert.DeserializeObject<SAPExceptionRoot>(response1.Content);

                    return BadRequest(_common.ReturnCustomErrorData(_common.ReturnResourceValue(_localizerAR, _localizerEN, "EN", "SAPServiceReturnExepction"), objSAPExceptionRoot));



                }


                EService.DataTransferObject.MaintenanceSAPInsertRequest.MaintenanceSearchSAPResponseDto objSApInqueryResponse = new EService.DataTransferObject.MaintenanceSAPInsertRequest.MaintenanceSearchSAPResponseDto();

                if (response1.StatusCode.ToString().ToLower() == "ok")
                {



                    string xCsrfToken = response1.Headers.ToList().Find(x => x.Name == "x-csrf-token").Value.ToString();
                    var cookies1 = response1.Headers.ToList().FindAll(x => x.Name == "Set-Cookie");


                    var SAPHOst = _config["SAPAPIData:SAPHost"];

                    string serviceName2 = "/sap/opu/odata/SAP/Z_CREATE_SRV_N_GOV_SRV/SrvN_GOVSet";


                    var username1 = _config["SAPAPIData:SAP_UserName"];
                    var password1 = _config["SAPAPIData:SAP_Pass"];


                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                    ServicePointManager.DefaultConnectionLimit = 1000;



                    var client2 = new RestClient(SAPHOst);

                    var request2 = new RestRequest(serviceName2);



                    request2.AddHeader("x-csrf-token", xCsrfToken);

                    string CookieData = "";

                    int count = 0;


                    foreach (HeaderParameter item in cookies1)
                    {

                        if (count == cookies1.Count - 1)
                        {
                            CookieData = CookieData + item.Value;


                        }
                        else
                        {
                            CookieData = CookieData + item.Value + ";";

                        }
                        count++;
                    }



                    request2.AddHeader("Cookie", CookieData);

                    JepcoBackEndSystemProject.EService.DataTransferObject.MaintenanceSAPInsertRequest.MaintenanceSearchSAPResponseDto objMaintenanceSearchSAPResponseDto = new JepcoBackEndSystemProject.EService.DataTransferObject.MaintenanceSAPInsertRequest.MaintenanceSearchSAPResponseDto();

                    JepcoBackEndSystemProject.EService.DataTransferObject.MaintenanceSAPInsertRequest.D objD = new JepcoBackEndSystemProject.EService.DataTransferObject.MaintenanceSAPInsertRequest.D();
                    objD.Vertrag = MaintenanceRequest.ContractNumber.ToString();
                    objD.ApiTyp = "C";
                    objD.BuSort1 = MaintenanceRequest.GroupNumber.ToString();

                    JepcoBackEndSystemProject.EService.DataTransferObject.MaintenanceSAPInsertRequest.ImBp objImBp = new JepcoBackEndSystemProject.EService.DataTransferObject.MaintenanceSAPInsertRequest.ImBp();
                    objImBp.MobileNumber = MaintenanceRequest.MobileNumber.ToString();
                    objD.ImBp = objImBp;

                    JepcoBackEndSystemProject.EService.DataTransferObject.MaintenanceSAPInsertRequest.ImAtt objImAtt = new JepcoBackEndSystemProject.EService.DataTransferObject.MaintenanceSAPInsertRequest.ImAtt();
                    objImAtt.Des1 = MaintenanceRequest.Attachment_gov_Name;
                    objImAtt.Image1 = MaintenanceRequest.Attachment_gov.ToString();
                    objD.ImAtt = objImAtt;

                    JepcoBackEndSystemProject.EService.DataTransferObject.MaintenanceSAPInsertRequest.ImSrvN objImSrvN = new JepcoBackEndSystemProject.EService.DataTransferObject.MaintenanceSAPInsertRequest.ImSrvN();
                    objImSrvN.Priority = "1";
                    objImSrvN.NotifAddr = MaintenanceRequest.StreetName + "-" + MaintenanceRequest.BuildingNumber;
                    objImSrvN.PlntLocCode = MaintenanceRequest.DistrictID .ToString();
                    objImSrvN.TextHeader = MaintenanceRequest.PowerCapacityName;

                    objD.ImSrvN = objImSrvN;


                    objMaintenanceSearchSAPResponseDto.d = objD;

                    client2.Authenticator = new HttpBasicAuthenticator(username1, password1);

                    string requestJson = JsonConvert.SerializeObject(objMaintenanceSearchSAPResponseDto);
                    string datareq = requestJson;
                    request2.AddJsonBody(datareq);


                    try
                    {
                        var response2 = await client2.ExecutePostAsync(request2, System.Threading.CancellationToken.None);

                        // _logger.LogError("SAP Status After Insert: " + response2.StatusCode.ToString().ToLower());

                        if (response2.StatusCode == HttpStatusCode.BadRequest)
                        {

                            SAPExceptionRoot objSAPExceptionRoot = null;
                            objSAPExceptionRoot = JsonConvert.DeserializeObject<SAPExceptionRoot>(response2.Content);

                            return BadRequest(_common.ReturnCustomErrorData(_common.ReturnResourceValue(_localizerAR, _localizerEN, "EN", "SAPServiceReturnExepction"), objSAPExceptionRoot));



                        }


                        if (response2.StatusCode.ToString().ToLower() == "created")
                        {
                            //return Ok("Data inserted Successfully");

                            EService.DataTransferObject.MaintenanceInsertSAPResponse.MaintenanceInsertSAPResponseDto objMaintenanceInsertSAPResponseDto = new EService.DataTransferObject.MaintenanceInsertSAPResponse .MaintenanceInsertSAPResponseDto();

                            objMaintenanceInsertSAPResponseDto = JsonConvert.DeserializeObject<EService.DataTransferObject.MaintenanceInsertSAPResponse.MaintenanceInsertSAPResponseDto>(response2.Content);






                            tb_MaintenanceRequest MaintenanceRequestObj = new tb_MaintenanceRequest();
                            MaintenanceRequestObj.MaintenanceTypeId = MaintenanceRequest.MaintenanceTypeId;
                            MaintenanceRequestObj.ContractNumber = MaintenanceRequest.ContractNumber;
                            MaintenanceRequestObj.GroupNumber = MaintenanceRequest.GroupNumber;
                            MaintenanceRequestObj.MobileNumber = MaintenanceRequest.MobileNumber;
                            MaintenanceRequestObj.GroupNumber = MaintenanceRequest.GroupNumber;
                            MaintenanceRequestObj.GovernateId  = MaintenanceRequest.GovernateId ;
                            MaintenanceRequestObj.DistrictID = MaintenanceRequest.DistrictID;
                            MaintenanceRequestObj.StreetName = MaintenanceRequest.StreetName;
                            MaintenanceRequestObj.BuildingNumber = MaintenanceRequest.BuildingNumber;
                            MaintenanceRequestObj.PowerCapacityId = MaintenanceRequest.PowerCapacityId;
                            MaintenanceRequestObj.Attachment_gov = MaintenanceRequest.Attachment_gov;
                            MaintenanceRequestObj.Attachment_gov_Name  = MaintenanceRequest.Attachment_gov_Name ;
                            MaintenanceRequestObj.SAPNotificationNo = objMaintenanceInsertSAPResponseDto.d.MsgNotifNo;
                            MaintenanceRequestObj.SAP_BP  = objMaintenanceInsertSAPResponseDto.d.MsgSapBpNo ;
                            MaintenanceRequestObj.SAPMsg  = objMaintenanceInsertSAPResponseDto.d.MsgPassFail ;


                            MaintenanceRequestObj.CreatedDate = DateTime.Now;


                            _repository.MaintenanceRequestRepository.AddMaintenanceRequest(MaintenanceRequestObj);
                            await _repository.SaveAsync().ConfigureAwait(false);

                            return Ok(_common.ReturnOkData(_common.ReturnResourceValue(_localizerAR, _localizerEN, MaintenanceRequest.LanguageId, "insert Maintenance Request to  database"), MaintenanceRequestObj));


                        }
                        else
                        {




                            return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, "EN", "SAPServiceReturnExepction"), "SAPServiceReturnExepction"));






                        }


                    }
                    catch (WebException ex)
                    {
                        return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, "EN", "SAPServiceReturnExepction"), ex.Message));

                    }








                }

                else
                {

                    _logger.LogError("ErrorCode 1: " + response1.StatusCode.ToString().ToLower());

                    return BadRequest(_common.ReturnCustomErrorData(_common.ReturnResourceValue(_localizerAR, _localizerEN, "EN", "SAPServiceReturnExepction"), "SAP Exepection"));


                }





















            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside MaintenanceRequestGov action: {ex.Message + System.Environment.NewLine + ex.InnerException + ex.StackTrace}");
                return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, MaintenanceRequest.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, MaintenanceRequest.LanguageId, "Internal server error")));
            }

        }




        // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost(Name = "SearchByContractAndGroupNo")]
        [Route("SearchByContractAndGroupNo")]
        public async Task<ActionResult<CommonReturnResult>> SearchByContractAndGroupNo([FromBody] MaintenanceSearchRequestDto MaintenanceRequest)
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



                string SapURL = _config["SAPAPIData:SAPServiceURL"];
                string serviceName = "/Z_CREATE_SRV_N_GOV_SRV/SrvN_GOVSet";



                string ServiceCURLGetCSRF = SapURL + serviceName + "(Vertrag='" + MaintenanceRequest.ContractNumber  + "',ApiTyp='G',BuSort1='" + MaintenanceRequest.GroupNumber  + "')?$format=json";




                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                ServicePointManager.DefaultConnectionLimit = 1000;

                var options = new RestClientOptions(ServiceCURLGetCSRF)
                {
                    ThrowOnAnyError = false

                };


                var client1 = new RestClient(options);

                var request1 = new RestRequest();

                IEnumerable<string> cookies = new List<string>();

                CookieContainer cookieJar = new CookieContainer();

                request1.AddHeader("x-csrf-token", "fetch");
                var username = _config["SAPAPIData:SAP_UserName"];
                var password = _config["SAPAPIData:SAP_Pass"];



                client1.Authenticator = new HttpBasicAuthenticator(username, password);

                var response1 = new RestSharp.RestResponse();

                response1 = await client1.ExecuteGetAsync(request1, System.Threading.CancellationToken.None);



                if (response1.StatusCode == HttpStatusCode.BadRequest)
                {

                   SAPExceptionRoot objSAPExceptionRoot = null;
                   objSAPExceptionRoot = JsonConvert.DeserializeObject<SAPExceptionRoot>(response1.Content);

                    return BadRequest(_common.ReturnCustomErrorData(_common.ReturnResourceValue(_localizerAR, _localizerEN, "EN", "SAPServiceReturnExepction"), objSAPExceptionRoot));



                }


                EService.DataTransferObject.MaintenanceSAPInsertRequest.MaintenanceSearchSAPResponseDto objSApInqueryResponse = new EService.DataTransferObject.MaintenanceSAPInsertRequest.MaintenanceSearchSAPResponseDto();

                if (response1.StatusCode.ToString().ToLower() == "ok")
                {

                  

                    string xCsrfToken = response1.Headers.ToList().Find(x => x.Name == "x-csrf-token").Value.ToString();


                        objSApInqueryResponse = JsonConvert.DeserializeObject<EService.DataTransferObject.MaintenanceSAPInsertRequest.MaintenanceSearchSAPResponseDto>(response1.Content);

                }

                else
                {

                    _logger.LogError("ErrorCode 1: " + response1.StatusCode.ToString().ToLower());

                }


                return Ok(_common.ReturnOkData(_common.ReturnResourceValue(_localizerAR, _localizerEN, "EN", " informtions Returned  sussfully "), objSApInqueryResponse));








            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside MaintenanceRequestGov action: {ex.Message + System.Environment.NewLine + ex.InnerException + ex.StackTrace}");
                return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, MaintenanceRequest.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, MaintenanceRequest.LanguageId, "Internal server error")));
            }

        }




       























    }
}