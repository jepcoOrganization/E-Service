using AutoMapper;
using JepcoBackEndSystemProject.Data;
using JepcoBackEndSystemProject.Data.CommonReturn;
using JepcoBackEndSystemProject.EmergancyAppApis.DataTransferObject.FaultComplaint;
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
    [Route("FaultCompliants")]
    [ApiController]
    public class FaultCompliantsControllers : ControllerBase
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

        public FaultCompliantsControllers(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper,
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
        [HttpPost(Name = "GetParentFaultCompliantList")]
        [Route("GetParentFaultCompliantList")]
        public async Task<ActionResult<CommonReturnResult>> GetParentFaultCompliantList([FromBody] FaultComplaintDto FaultComplaintDto)
        {


            try
            {

                MenaTrackService.CallCenterNewClient objCallCenterNewClient = new MenaTrackService.CallCenterNewClient(MenaTrackService.CallCenterNewClient.EndpointConfiguration.BasicHttpsBinding_ICallCenterNew);

                List < MenaTrackService.JEPCOViewRequestsParentsResponse > lstJEPCOViewRequestsParentsResponse =   await objCallCenterNewClient.JEPCO_ViewRequests_ParentsAsync(FaultComplaintDto.UserID, FaultComplaintDto.BranchID).ConfigureAwait(false ) ;


                if (lstJEPCOViewRequestsParentsResponse != null && lstJEPCOViewRequestsParentsResponse.Count > 0)
                {
                    foreach ( var jEPCOViewRequest in lstJEPCOViewRequestsParentsResponse)
                    {


                        IEnumerable<tb_Fault_Compliants > lstFalutComplaintData = await _repository.FaultCompliantsLookupRepository.GetListOfFaultCompliants (x => x.IssueID == jEPCOViewRequest.IssueID).ConfigureAwait(false) ;

                        if (lstFalutComplaintData == null || lstFalutComplaintData.ToList().Count  ==0)
                        {

                            tb_Fault_Compliants tb_Fault_Compliants =  new tb_Fault_Compliants();
                            tb_Fault_Compliants.ComplaintDescription = jEPCOViewRequest.ComplaintDescription;
                            tb_Fault_Compliants.ComplaintRefNumber = jEPCOViewRequest.Refcode;
                            tb_Fault_Compliants.ComplaintDescription = jEPCOViewRequest.ComplaintDescription.ToString();
                            tb_Fault_Compliants.CompliantCustomerName = jEPCOViewRequest.CustomerName;
                            tb_Fault_Compliants.CompliantDateTime = jEPCOViewRequest.ComplaintDate;
                            tb_Fault_Compliants.CompliantPhoneNumber = jEPCOViewRequest.CustomerMobileNumber;
                            tb_Fault_Compliants.SubstationNumber = jEPCOViewRequest.SubstationNumber;
                            tb_Fault_Compliants.CompliantParentRefNumber = jEPCOViewRequest.ParentRefcode;
                            tb_Fault_Compliants.CustomerAddress_Latt = jEPCOViewRequest.AddressLatt;
                            tb_Fault_Compliants.CustomerAddress_Long = jEPCOViewRequest.AddressLong;

                            tb_Fault_Compliants.DistrictID = jEPCOViewRequest.DistrictID;
                            tb_Fault_Compliants.DistrictName = jEPCOViewRequest.District;
                            tb_Fault_Compliants.GovernateId = jEPCOViewRequest.GovernateID;
                            tb_Fault_Compliants.GovernateName = jEPCOViewRequest.Governate;
                            tb_Fault_Compliants.ZoneID = jEPCOViewRequest.ZoneID;
                            tb_Fault_Compliants.ZoneName = jEPCOViewRequest.ZoneName;

                            tb_Fault_Compliants.StreetID = jEPCOViewRequest.StreetID;
                            tb_Fault_Compliants.StreetName = jEPCOViewRequest.Street;
                            tb_Fault_Compliants.FaultStatusID = 1;
                            tb_Fault_Compliants.MenaTrackStatusDesc = jEPCOViewRequest.StatusDesc;
                            tb_Fault_Compliants.MenaTrackStatusID = jEPCOViewRequest.StatusID;
                            tb_Fault_Compliants.IssueID = jEPCOViewRequest.IssueID;
                            tb_Fault_Compliants.PiorityID = jEPCOViewRequest.PriorityID;
                            tb_Fault_Compliants.PiorityDesc = jEPCOViewRequest.PriorityDesc;
                            tb_Fault_Compliants.UserID = FaultComplaintDto.UserID;
                            tb_Fault_Compliants.UserName = FaultComplaintDto.UserName;
                            tb_Fault_Compliants.BranchID = FaultComplaintDto.BranchID;
                            tb_Fault_Compliants.CreatedDate = DateTime.Now;
                            tb_Fault_Compliants.UpdateDate  = DateTime.Now;
                            tb_Fault_Compliants.LV_Feeder = jEPCOViewRequest.LVFeederNumber;
                            tb_Fault_Compliants.MV_Feeder  = jEPCOViewRequest.MVFeederNumber;
                            tb_Fault_Compliants.SubstationNumber  = jEPCOViewRequest.SubstationNumber;
                            //tb_Fault_Compliants.SubstationName  = jEPCOViewRequest.s;





                             _repository.FaultCompliantsLookupRepository.AddFaultCompliants(tb_Fault_Compliants);
                             await _repository.SaveAsync().ConfigureAwait(false);
                            int a = 1;
                            //tb_ElectricalFaultStatus tb_ElectricalFaultStatusOBJ = await _repository.ElectricalFaultStatusRepository.GetSingleElectricalFaultStatus(x => x.FaultStatusID == a).ConfigureAwait(false);

                            tb_FaultDetails tb_Fault_Details = new tb_FaultDetails();
                            tb_Fault_Details.FaultComplaintID = tb_Fault_Compliants.FaultComplaintID;
                            tb_Fault_Details.CreatedDate = DateTime.Now;
                            tb_Fault_Details.UpdateDate = DateTime.Now;

                            //tb_Fault_Details.RepairingStatusID = a;
                            //tb_Fault_Details.FaultDescription = tb_Fault_Compliants.ComplaintDescription;
                            _repository.FaultDetailsRepository.AddFaultDetails(tb_Fault_Details);
                            await _repository.SaveAsync().ConfigureAwait(false);

                        }


                    }



                }



                var lstFalutComplaint = await _repository.FaultCompliantsLookupRepository.GetListOfFaultCompliants (x => x.UserID  == FaultComplaintDto.UserID && x.FaultStatusID != 4).ConfigureAwait(false) ;


                return Ok(_common.ReturnOkData(_common.ReturnResourceValue(_localizerAR, _localizerEN, FaultComplaintDto.LanguageId, "Returned all Fault Complaints fro Technication"), lstFalutComplaint));

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetParentFaultCompliantList action: {ex.Message + System.Environment.NewLine + ex.InnerException + ex.StackTrace}");
                return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, FaultComplaintDto.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, FaultComplaintDto.LanguageId, "Internal server error")));
            }

        }

       [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost(Name = "GetChildFaultCompliantList")]
        [Route("GetChildFaultCompliantList")]
        public async Task<ActionResult<CommonReturnResult>> GetChildFaultCompliantList([FromBody] ChildFaultComplaintDto FaultComplaintDto)
        {


            try
            {

                MenaTrackService.CallCenterNewClient objCallCenterNewClient = new MenaTrackService.CallCenterNewClient(MenaTrackService.CallCenterNewClient.EndpointConfiguration.BasicHttpsBinding_ICallCenterNew);

                List<MenaTrackService.JEPCOViewRequestsParentsResponse > lstJEPCOViewRequestsChildsResponse = await objCallCenterNewClient.JEPCO_ViewRequests_ChildsAsync(FaultComplaintDto.IssueID , FaultComplaintDto.BranchID).ConfigureAwait(false);



                if (lstJEPCOViewRequestsChildsResponse != null && lstJEPCOViewRequestsChildsResponse.Count > 0)
                {
                    foreach (var jEPCOViewRequest in lstJEPCOViewRequestsChildsResponse)
                    {


                        IEnumerable<tb_Fault_Compliants> lstFalutComplaintData = await _repository.FaultCompliantsLookupRepository.GetListOfFaultCompliants(x => x.IssueID == jEPCOViewRequest.IssueID).ConfigureAwait(false);

                        if (lstFalutComplaintData == null || lstFalutComplaintData.ToList().Count == 0 )
                        {

                            tb_Fault_Compliants tb_Fault_Compliants = new tb_Fault_Compliants();
                            tb_Fault_Compliants.ComplaintDescription = jEPCOViewRequest.ComplaintDescription;
                            tb_Fault_Compliants.ComplaintRefNumber = jEPCOViewRequest.Refcode;
                            tb_Fault_Compliants.ComplaintDescription = jEPCOViewRequest.ComplaintDescription.ToString();
                            tb_Fault_Compliants.CompliantCustomerName = jEPCOViewRequest.CustomerName;
                            tb_Fault_Compliants.CompliantDateTime = jEPCOViewRequest.ComplaintDate;
                            tb_Fault_Compliants.CompliantPhoneNumber = jEPCOViewRequest.CustomerMobileNumber;
                            tb_Fault_Compliants.SubstationNumber = jEPCOViewRequest.SubstationNumber;
                            tb_Fault_Compliants.CompliantParentRefNumber = jEPCOViewRequest.ParentRefcode;
                            tb_Fault_Compliants.CustomerAddress_Latt = jEPCOViewRequest.AddressLatt;
                            tb_Fault_Compliants.CustomerAddress_Long = jEPCOViewRequest.AddressLong;

                            tb_Fault_Compliants.DistrictID = jEPCOViewRequest.DistrictID;
                            tb_Fault_Compliants.DistrictName = jEPCOViewRequest.District;
                            tb_Fault_Compliants.GovernateId = jEPCOViewRequest.GovernateID;
                            tb_Fault_Compliants.GovernateName = jEPCOViewRequest.Governate;
                            tb_Fault_Compliants.ZoneID = jEPCOViewRequest.ZoneID;
                            tb_Fault_Compliants.ZoneName = jEPCOViewRequest.ZoneName;

                            tb_Fault_Compliants.StreetID = jEPCOViewRequest.StreetID;
                            tb_Fault_Compliants.StreetName = jEPCOViewRequest.Street;
                            tb_Fault_Compliants.FaultStatusID = 1;
                            tb_Fault_Compliants.MenaTrackStatusDesc = jEPCOViewRequest.StatusDesc;
                            tb_Fault_Compliants.MenaTrackStatusID = jEPCOViewRequest.StatusID;
                            tb_Fault_Compliants.IssueID = jEPCOViewRequest.IssueID;
                            tb_Fault_Compliants.PiorityID = jEPCOViewRequest.PriorityID;
                            tb_Fault_Compliants.PiorityDesc = jEPCOViewRequest.PriorityDesc;
                            tb_Fault_Compliants.UserID = FaultComplaintDto.UserID;
                            tb_Fault_Compliants.UserName = FaultComplaintDto.UserName;
                            tb_Fault_Compliants.BranchID = FaultComplaintDto.BranchID;
                            tb_Fault_Compliants.CreatedDate = DateTime.Now;
                            tb_Fault_Compliants.UpdateDate = DateTime.Now;
                            tb_Fault_Compliants.LV_Feeder = jEPCOViewRequest.LVFeederNumber;
                            tb_Fault_Compliants.MV_Feeder = jEPCOViewRequest.MVFeederNumber;
                            tb_Fault_Compliants.SubstationNumber = jEPCOViewRequest.SubstationNumber;
                            //tb_Fault_Compliants.SubstationName  = jEPCOViewRequest.s;





                            _repository.FaultCompliantsLookupRepository.AddFaultCompliants(tb_Fault_Compliants);
                            await _repository.SaveAsync().ConfigureAwait(false);
                            int a = 1;
                            //tb_ElectricalFaultStatus tb_ElectricalFaultStatusOBJ = await _repository.ElectricalFaultStatusRepository.GetSingleElectricalFaultStatus(x => x.FaultStatusID == a).ConfigureAwait(false);

                            tb_FaultDetails tb_Fault_Details = new tb_FaultDetails();
                            tb_Fault_Details.FaultComplaintID = tb_Fault_Compliants.FaultComplaintID;
                            tb_Fault_Details.CreatedDate = DateTime.Now;
                            tb_Fault_Details.UpdateDate = DateTime.Now;

                            //tb_Fault_Details.RepairingStatusID = a;
                            //tb_Fault_Details.FaultDescription = tb_Fault_Compliants.ComplaintDescription;
                            _repository.FaultDetailsRepository.AddFaultDetails(tb_Fault_Details);
                            await _repository.SaveAsync().ConfigureAwait(false);
                        }


                    }



                }



                var lstFalutComplaint = await _repository.FaultCompliantsLookupRepository.GetListOfFaultCompliants(x => x.UserID == FaultComplaintDto.UserID && x.CompliantParentRefNumber == FaultComplaintDto.ComplaintRefCode &&   x.FaultStatusID != 4).ConfigureAwait(false);


                return Ok(_common.ReturnOkData(_common.ReturnResourceValue(_localizerAR, _localizerEN, FaultComplaintDto.LanguageId, "Returned all Fault Complaints fro Technication"), lstFalutComplaint));

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetParentFaultCompliantList action: {ex.Message + System.Environment.NewLine + ex.InnerException + ex.StackTrace}");
                return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, FaultComplaintDto.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, FaultComplaintDto.LanguageId, "Internal server error")));
            }

        }

        //----------------------------------------------------------------------------------------------------------

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost(Name = "PushTicket")]
        [Route("PushTicket")]
        public async Task<ActionResult<CommonReturnResult>> PushTicket([FromBody] PushRequestDTO PushRequest)
        {


            try
            {

                MenaTrackService.CallCenterNewClient objCallCenterNewClient = new MenaTrackService.CallCenterNewClient(MenaTrackService.CallCenterNewClient.EndpointConfiguration.BasicHttpsBinding_ICallCenterNew);

                List<MenaTrackService.JEPCOViewRequestsParentsResponse> lstJEPCOViewRequestsParentsResponse = await objCallCenterNewClient.JEPCO_ViewRequests_ParentsAsync(PushRequest.UserID, PushRequest.BranchID).ConfigureAwait(false);


                if (lstJEPCOViewRequestsParentsResponse != null && lstJEPCOViewRequestsParentsResponse.Count > 0)
                {
                    foreach (var jEPCOViewRequest in lstJEPCOViewRequestsParentsResponse)
                    {


                        IEnumerable<tb_Fault_Compliants> lstFalutComplaintData = await _repository.FaultCompliantsLookupRepository.GetListOfFaultCompliants(x => x.IssueID == jEPCOViewRequest.IssueID).ConfigureAwait(false);

                        if (lstFalutComplaintData == null || lstFalutComplaintData.ToList().Count == 0)
                        {

                            tb_Fault_Compliants tb_Fault_Compliants = new tb_Fault_Compliants();
                            tb_Fault_Compliants.ComplaintDescription = jEPCOViewRequest.ComplaintDescription;
                            tb_Fault_Compliants.ComplaintRefNumber = jEPCOViewRequest.Refcode;
                            tb_Fault_Compliants.ComplaintDescription = jEPCOViewRequest.ComplaintDescription.ToString();
                            tb_Fault_Compliants.CompliantCustomerName = jEPCOViewRequest.CustomerName;
                            tb_Fault_Compliants.CompliantDateTime = jEPCOViewRequest.ComplaintDate;
                            tb_Fault_Compliants.CompliantPhoneNumber = jEPCOViewRequest.CustomerMobileNumber;
                            tb_Fault_Compliants.SubstationNumber = jEPCOViewRequest.SubstationNumber;
                            tb_Fault_Compliants.CompliantParentRefNumber = jEPCOViewRequest.ParentRefcode;
                            tb_Fault_Compliants.CustomerAddress_Latt = jEPCOViewRequest.AddressLatt;
                            tb_Fault_Compliants.CustomerAddress_Long = jEPCOViewRequest.AddressLong;

                            tb_Fault_Compliants.DistrictID = jEPCOViewRequest.DistrictID;
                            tb_Fault_Compliants.DistrictName = jEPCOViewRequest.District;
                            tb_Fault_Compliants.GovernateId = jEPCOViewRequest.GovernateID;
                            tb_Fault_Compliants.GovernateName = jEPCOViewRequest.Governate;
                            tb_Fault_Compliants.ZoneID = jEPCOViewRequest.ZoneID;
                            tb_Fault_Compliants.ZoneName = jEPCOViewRequest.ZoneName;

                            tb_Fault_Compliants.StreetID = jEPCOViewRequest.StreetID;
                            tb_Fault_Compliants.StreetName = jEPCOViewRequest.Street;
                            tb_Fault_Compliants.FaultStatusID = 1;
                            tb_Fault_Compliants.MenaTrackStatusDesc = jEPCOViewRequest.StatusDesc;
                            tb_Fault_Compliants.MenaTrackStatusID = jEPCOViewRequest.StatusID;
                            tb_Fault_Compliants.IssueID = jEPCOViewRequest.IssueID;
                            tb_Fault_Compliants.PiorityID = jEPCOViewRequest.PriorityID;
                            tb_Fault_Compliants.PiorityDesc = jEPCOViewRequest.PriorityDesc;
                            tb_Fault_Compliants.UserID = PushRequest.UserID;
                            tb_Fault_Compliants.UserName = PushRequest.UserName;
                            tb_Fault_Compliants.BranchID = PushRequest.BranchID;
                            tb_Fault_Compliants.CreatedDate = DateTime.Now;
                            tb_Fault_Compliants.UpdateDate = DateTime.Now;
                            tb_Fault_Compliants.LV_Feeder = jEPCOViewRequest.LVFeederNumber;
                            tb_Fault_Compliants.MV_Feeder = jEPCOViewRequest.MVFeederNumber;
                            tb_Fault_Compliants.SubstationNumber = jEPCOViewRequest.SubstationNumber;
                            //tb_Fault_Compliants.SubstationName  = jEPCOViewRequest.s;





                            _repository.FaultCompliantsLookupRepository.AddFaultCompliants(tb_Fault_Compliants);
                            await _repository.SaveAsync().ConfigureAwait(false);


                            int a = 1;
                            //tb_ElectricalFaultStatus tb_ElectricalFaultStatusOBJ = await _repository.ElectricalFaultStatusRepository.GetSingleElectricalFaultStatus(x => x.FaultStatusID == a).ConfigureAwait(false);

                            tb_FaultDetails tb_Fault_Details = new tb_FaultDetails();
                            tb_Fault_Details.FaultComplaintID = tb_Fault_Compliants.FaultComplaintID;
                            tb_Fault_Details.CreatedDate = DateTime.Now;
                            tb_Fault_Details.UpdateDate = DateTime.Now;

                            //tb_Fault_Details.RepairingStatusID = a;
                            //tb_Fault_Details.FaultDescription = tb_Fault_Compliants.ComplaintDescription;
                            _repository.FaultDetailsRepository.AddFaultDetails(tb_Fault_Details);
                            await _repository.SaveAsync().ConfigureAwait(false);

                        }


                    }



                }



                var lstFalutComplaint = await _repository.FaultCompliantsLookupRepository.GetListOfFaultCompliants(x => x.UserID == FaultComplaintDto.UserID && x.FaultStatusID != 4).ConfigureAwait(false);


                return Ok(_common.ReturnOkData(_common.ReturnResourceValue(_localizerAR, _localizerEN, FaultComplaintDto.LanguageId, "Returned all Fault Complaints fro Technication"), lstFalutComplaint));

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetParentFaultCompliantList action: {ex.Message + System.Environment.NewLine + ex.InnerException + ex.StackTrace}");
                return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, FaultComplaintDto.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, FaultComplaintDto.LanguageId, "Internal server error")));
            }

        }



















    }
}