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

        private readonly FaultDetailsController _FaultDetailsController;

        #endregion
        #region Constructor

        public FaultCompliantsControllers(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper,
            ICommonReturn common, IStringLocalizer<MessagesAr> localizerAR, IStringLocalizer<MessagesEn> localizerEN, IWebHostEnvironment environment , FaultDetailsController OBJFaultDetailsController)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
            _common = common;
            _localizerAR = localizerAR;
            _localizerEN = localizerEN;
            _environment = environment;
            _FaultDetailsController = OBJFaultDetailsController;
        }
        #endregion

       // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost(Name = "GetParentFaultCompliantList")]
        [Route("GetParentFaultCompliantList")]
        public async Task<ActionResult<CommonReturnResult>> GetParentFaultCompliantList([FromBody] FaultComplaintDto FaultComplaintDto)
        {


            try
            {

                MenaTrackService.CallCenterNewClient objCallCenterNewClient = new MenaTrackService.CallCenterNewClient(MenaTrackService.CallCenterNewClient.EndpointConfiguration.BasicHttpBinding_ICallCenterNew);

                List < MenaTrackService.JEPCOViewRequestsParentsResponse > lstJEPCOViewRequestsParentsResponse =   await objCallCenterNewClient.JEPCO_ViewRequests_ParentsAsync(FaultComplaintDto.UserID, FaultComplaintDto.BranchID).ConfigureAwait(false ) ;


                var lstFalutComplaintALL = await _repository.FaultCompliantsLookupRepository.GetListOfFaultCompliants(x => x.UserID == FaultComplaintDto.UserID
                &&(x.FaultStatusID != 4 && x.FaultStatusID != 5)
             && (x.CompliantParentRefNumber == null || x.CompliantParentRefNumber == "")).ConfigureAwait(false);


                if (lstFalutComplaintALL != null && lstFalutComplaintALL.ToList().Count > 0)
                {

                    foreach (var FalutComplaintALL in lstFalutComplaintALL)
                    {



                        if ( lstJEPCOViewRequestsParentsResponse.Where(x=> x.IssueID == FalutComplaintALL.IssueID ).ToList().Count == 0 )
                            // check if current saved compliant in APP is not closed and reassinged and not exist in retrivted compliants come
                            // from mena Track  that Mean that parnet and childs tieckts need to be deleted
                            // // as it is closed and regisned by dispatcher in Mena Track although tieckt still in a new or delivred and Arrriving  status in APP
                        {

                            IEnumerable<tb_Fault_Compliants> lstChildsFalutComplaintData = await _repository.FaultCompliantsLookupRepository.GetListOfFaultCompliants(x => x.CompliantParentRefNumber  == FalutComplaintALL.ComplaintRefNumber ).ConfigureAwait(false);


                            if (lstChildsFalutComplaintData != null && lstChildsFalutComplaintData.ToList().Count > 0)
                            {
                            /// Delete Child Tieckts 
                                _repository.FaultCompliantsLookupRepository.Remove(lstChildsFalutComplaintData.ToArray() );

                                await _repository.SaveAsync().ConfigureAwait(false);

                            }

                            ComplaintFaultDetailsRequestDto objcomplaintFaultDetailsRequestDto = new ComplaintFaultDetailsRequestDto();

                            objcomplaintFaultDetailsRequestDto.FaultComplaintID = FalutComplaintALL.FaultComplaintID;
                            objcomplaintFaultDetailsRequestDto.LanguageId = "AR";


                            //IEnumerable<tb_FaultDetails> lsttb_FaultDetails = (IEnumerable<tb_FaultDetails>) _FaultDetailsController.GetFaultCompliantDetailsWithOUTImage(objcomplaintFaultDetailsRequestDto); 
                            // await _repository.FaultDetailsRepository .GetListOfFaultDetails(faultDetails => faultDetails.FaultComplaintID  == FalutComplaintALL.FaultComplaintID).ConfigureAwait(false);
                            //await _repository.FaultDetailsRepository .GetListOfFaultDetails(faultDetails => faultDetails.FaultComplaintID  == FalutComplaintALL.FaultComplaintID).ConfigureAwait(false);

                            IEnumerable<tb_FaultDetails> lsttb_FaultDetails = await  _repository.FaultDetailsRepository.GetListOfFaultDetailsWithoutImages (FalutComplaintALL.FaultComplaintID).ConfigureAwait(false) ;

                            if (lsttb_FaultDetails != null && lsttb_FaultDetails.ToList().Count > 0)
                            {

                                _repository.FaultDetailsRepository.Remove(lsttb_FaultDetails.FirstOrDefault());

                            }

                            _repository.FaultCompliantsLookupRepository.Remove(FalutComplaintALL);


                            await _repository.SaveAsync().ConfigureAwait(false);

                        }
                    }

                }



                /// Add  New tieckts retrivted from Mena Track and exist in APP 
                if (lstJEPCOViewRequestsParentsResponse != null && lstJEPCOViewRequestsParentsResponse.Count > 0)
                {
                    foreach ( var jEPCOViewRequest in lstJEPCOViewRequestsParentsResponse)
                    {

                     
                        IEnumerable<tb_Fault_Compliants > lstFalutComplaintData = await _repository.FaultCompliantsLookupRepository.GetListOfFaultCompliants (x => x.IssueID == jEPCOViewRequest.IssueID && x.UserID == FaultComplaintDto.UserID).ConfigureAwait(false) ;

                        if (lstFalutComplaintData == null || lstFalutComplaintData.ToList().Count  ==0)
                        {

                            
                            tb_Fault_Compliants tb_Fault_Compliants =  new tb_Fault_Compliants();
                            tb_Fault_Compliants.ComplaintDescription = jEPCOViewRequest.ComplaintDescription;
                            tb_Fault_Compliants.ComplaintRefNumber = jEPCOViewRequest.Refcode;
                            tb_Fault_Compliants.ComplaintDescription = jEPCOViewRequest.ComplaintDescription.ToString();
                            tb_Fault_Compliants.CompliantCustomerName = jEPCOViewRequest.CustomerName;
                            tb_Fault_Compliants.CompliantDateTime = jEPCOViewRequest.ComplaintDate;

                            if (jEPCOViewRequest.CustomerMobileNumber != null )
                            {


                                if (jEPCOViewRequest.CustomerMobileNumber.StartsWith("+9620"))
                                {
                                    tb_Fault_Compliants.CompliantPhoneNumber = jEPCOViewRequest.CustomerMobileNumber[4..];
                                }
                                else if (jEPCOViewRequest.CustomerMobileNumber.StartsWith("+962"))
                                {

                                    tb_Fault_Compliants.CompliantPhoneNumber = "0" + jEPCOViewRequest.CustomerMobileNumber[4..];


                                }
                                else if (jEPCOViewRequest.CustomerMobileNumber.StartsWith("9620"))
                                {
                                    tb_Fault_Compliants.CompliantPhoneNumber = jEPCOViewRequest.CustomerMobileNumber[3..]; //ComplainPhoneNumber = NewComplaint.ComplainPhoneNumber.Replace("962", "");
                                }
                                else if (jEPCOViewRequest.CustomerMobileNumber.StartsWith("962"))
                                {
                                    tb_Fault_Compliants.CompliantPhoneNumber = "0" + jEPCOViewRequest.CustomerMobileNumber[3..]; //ComplainPhoneNumber = NewComplaint.ComplainPhoneNumber.Replace("962", "");


                                }
                                else if (jEPCOViewRequest.CustomerMobileNumber.StartsWith("009620"))
                                {
                                    tb_Fault_Compliants.CompliantPhoneNumber = jEPCOViewRequest.CustomerMobileNumber[5..];//.Replace("00962", "");
                                }
                                else if (jEPCOViewRequest.CustomerMobileNumber.StartsWith("00962"))
                                {
                                    tb_Fault_Compliants.CompliantPhoneNumber = "0" + jEPCOViewRequest.CustomerMobileNumber[5..];//.Replace("00962", "");
                                }
                                else
                                {
                                    tb_Fault_Compliants.CompliantPhoneNumber = jEPCOViewRequest.CustomerMobileNumber;

                                }
                            }
                            else
                            {
                                tb_Fault_Compliants.CompliantPhoneNumber = jEPCOViewRequest.CustomerMobileNumber;

                            }





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
                            tb_Fault_Compliants.FaultStatusDesc = "جديدة";
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
                            tb_Fault_Compliants.SubstationName  = jEPCOViewRequest.SubstationName ;


                             _repository.FaultCompliantsLookupRepository.AddFaultCompliants(tb_Fault_Compliants);
                             await _repository.SaveAsync().ConfigureAwait(false);
                           



                            tb_FaultDetails tb_Fault_Details = new tb_FaultDetails();
                            tb_Fault_Details.FaultComplaintID = tb_Fault_Compliants.FaultComplaintID;
                            tb_Fault_Details.CreatedDate = DateTime.Now;
                            tb_Fault_Details.UpdateDate = DateTime.Now;
                      
                            _repository.FaultDetailsRepository.AddFaultDetails(tb_Fault_Details);
                            await _repository.SaveAsync().ConfigureAwait(false);

                            //----------------------getChild-------------------------
                            //MenaTrackService.CallCenterNewClient objCallCenterNewClientChild = new MenaTrackService.CallCenterNewClient(MenaTrackService.CallCenterNewClient.EndpointConfiguration.BasicHttpBinding_ICallCenterNew);

                            //List<MenaTrackService.JEPCOViewRequestsParentsResponse> lstJEPCOViewRequestsChildsResponse = await objCallCenterNewClientChild.JEPCO_ViewRequests_ChildsAsync(long.Parse(tb_Fault_Compliants.IssueID.ToString()), tb_Fault_Compliants.BranchID).ConfigureAwait(false);


                            //if (lstJEPCOViewRequestsChildsResponse != null && lstJEPCOViewRequestsChildsResponse.Count > 0)
                            {
                                //foreach (var jEPCOViewRequestChild in lstJEPCOViewRequestsChildsResponse)
                                //{


                                //    IEnumerable<tb_Fault_Compliants> lstFalutComplaintChildData = await _repository.FaultCompliantsLookupRepository.GetListOfFaultCompliants(x => x.IssueID == jEPCOViewRequestChild.IssueID).ConfigureAwait(false);

                                //    if (lstFalutComplaintChildData == null || lstFalutComplaintChildData.ToList().Count == 0)
                                //    {

                                //        tb_Fault_Compliants tb_Fault_CompliantsChild = new tb_Fault_Compliants();
                                //        tb_Fault_CompliantsChild.ComplaintDescription = jEPCOViewRequestChild.ComplaintDescription;
                                //        tb_Fault_CompliantsChild.ComplaintRefNumber = jEPCOViewRequestChild.Refcode;
                                //        tb_Fault_CompliantsChild.ComplaintDescription = jEPCOViewRequestChild.ComplaintDescription.ToString();
                                //        tb_Fault_CompliantsChild.CompliantCustomerName = jEPCOViewRequestChild.CustomerName;
                                //        tb_Fault_CompliantsChild.CompliantDateTime = jEPCOViewRequestChild.ComplaintDate;
                                //        tb_Fault_CompliantsChild.CompliantPhoneNumber = jEPCOViewRequestChild.CustomerMobileNumber;
                                //        tb_Fault_CompliantsChild.SubstationNumber = jEPCOViewRequestChild.SubstationNumber;
                                //        tb_Fault_CompliantsChild.CompliantParentRefNumber = jEPCOViewRequestChild.ParentRefcode;
                                //        tb_Fault_CompliantsChild.CustomerAddress_Latt = jEPCOViewRequestChild.AddressLatt;
                                //        tb_Fault_CompliantsChild.CustomerAddress_Long = jEPCOViewRequestChild.AddressLong;

                                //        tb_Fault_CompliantsChild.DistrictID = jEPCOViewRequestChild.DistrictID;
                                //        tb_Fault_CompliantsChild.DistrictName = jEPCOViewRequestChild.District;
                                //        tb_Fault_CompliantsChild.GovernateId = jEPCOViewRequestChild.GovernateID;
                                //        tb_Fault_CompliantsChild.GovernateName = jEPCOViewRequestChild.Governate;
                                //        tb_Fault_CompliantsChild.ZoneID = jEPCOViewRequestChild.ZoneID;
                                //        tb_Fault_CompliantsChild.ZoneName = jEPCOViewRequestChild.ZoneName;

                                //        tb_Fault_CompliantsChild.StreetID = jEPCOViewRequestChild.StreetID;
                                //        tb_Fault_CompliantsChild.StreetName = jEPCOViewRequestChild.Street;
                                //        tb_Fault_CompliantsChild.FaultStatusID = 1;
                                //        tb_Fault_CompliantsChild.MenaTrackStatusDesc = jEPCOViewRequestChild.StatusDesc;
                                //        tb_Fault_CompliantsChild.MenaTrackStatusID = jEPCOViewRequestChild.StatusID;
                                //        tb_Fault_CompliantsChild.IssueID = jEPCOViewRequestChild.IssueID;
                                //        tb_Fault_CompliantsChild.PiorityID = jEPCOViewRequestChild.PriorityID;
                                //        tb_Fault_CompliantsChild.PiorityDesc = jEPCOViewRequestChild.PriorityDesc;
                                //        tb_Fault_CompliantsChild.UserID = FaultComplaintDto.UserID;
                                //        tb_Fault_CompliantsChild.UserName = FaultComplaintDto.UserName;
                                //        tb_Fault_CompliantsChild.BranchID = FaultComplaintDto.BranchID;
                                //        tb_Fault_CompliantsChild.CreatedDate = DateTime.Now;
                                //        tb_Fault_CompliantsChild.UpdateDate = DateTime.Now;
                                //        tb_Fault_CompliantsChild.LV_Feeder = jEPCOViewRequestChild.LVFeederNumber;
                                //        tb_Fault_CompliantsChild.MV_Feeder = jEPCOViewRequestChild.MVFeederNumber;
                                //        tb_Fault_CompliantsChild.SubstationNumber = jEPCOViewRequestChild.SubstationNumber;
                                //        //tb_Fault_Compliants.SubstationName  = jEPCOViewRequest.s;





                                //        _repository.FaultCompliantsLookupRepository.AddFaultCompliants(tb_Fault_CompliantsChild);
                                //        await _repository.SaveAsync().ConfigureAwait(false);
                                //        //int a = 1;
                                //        //tb_ElectricalFaultStatus tb_ElectricalFaultStatusOBJ = await _repository.ElectricalFaultStatusRepository.GetSingleElectricalFaultStatus(x => x.FaultStatusID == a).ConfigureAwait(false);

                                //        //tb_FaultDetails tb_Fault_DetailsChild = new tb_FaultDetails();
                                //        //tb_Fault_DetailsChild.FaultComplaintID = tb_Fault_Compliants.FaultComplaintID;
                                //        //tb_Fault_DetailsChild.CreatedDate = DateTime.Now;
                                //        //tb_Fault_DetailsChild.UpdateDate = DateTime.Now;

                                //        ////tb_Fault_Details.RepairingStatusID = a;
                                //        ////tb_Fault_Details.FaultDescription = tb_Fault_Compliants.ComplaintDescription;
                                //        //_repository.FaultDetailsRepository.AddFaultDetails(tb_Fault_DetailsChild);
                                //        //await _repository.SaveAsync().ConfigureAwait(false);


                                      
                                //    }


                                //}




                                //tb_Fault_Compliants.ChildTicketsCount = lstJEPCOViewRequestsChildsResponse.Count();
                                //tb_Fault_Compliants.UpdateDate = DateTime.Now;
                                //_repository.FaultCompliantsLookupRepository.Update(null, tb_Fault_Compliants);
                                //await _repository.SaveAsync().ConfigureAwait(false);

                            }
                            //else
                            //{
                                //tb_Fault_Compliants.ChildTicketsCount = 0;
                                //tb_Fault_Compliants.UpdateDate = DateTime.Now;
                                //_repository.FaultCompliantsLookupRepository.Update(null, tb_Fault_Compliants);
                                //await _repository.SaveAsync().ConfigureAwait(false);

                            //}
                            






                          





                        }


                    }



                }



                var lstFalutComplaint = await _repository.FaultCompliantsLookupRepository.GetListOfFaultCompliants (x => x.UserID  == FaultComplaintDto.UserID && 
                (x.FaultStatusID != 4  && x.FaultStatusID != 5 ) 
                && ( x.CompliantParentRefNumber == null || x.CompliantParentRefNumber == "") ).ConfigureAwait(false) ;

                if ( lstFalutComplaint != null && lstFalutComplaint.ToList().Count > 0)
                {
                    lstFalutComplaint = lstFalutComplaint.OrderByDescending(x => x.PiorityID).ThenBy(comparer => comparer.CompliantDateTime).ThenBy(comparer1 => comparer1.FaultStatusID);

                }

                return Ok(_common.ReturnOkData(_common.ReturnResourceValue(_localizerAR, _localizerEN, FaultComplaintDto.LanguageId, "Returned all Fault Complaints for Technication"), lstFalutComplaint));

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

                MenaTrackService.CallCenterNewClient objCallCenterNewClient = new MenaTrackService.CallCenterNewClient(MenaTrackService.CallCenterNewClient.EndpointConfiguration.BasicHttpBinding_ICallCenterNew);

                List<MenaTrackService.JEPCOViewRequestsParentsResponse > lstJEPCOViewRequestsChildsResponse = await objCallCenterNewClient.JEPCO_ViewRequests_ChildsAsync(FaultComplaintDto.IssueID , FaultComplaintDto.BranchID).ConfigureAwait(false);

                IEnumerable<tb_Fault_Compliants> lstFalutComplaintData = await _repository.FaultCompliantsLookupRepository.GetListOfFaultCompliants(x => x.IssueID == FaultComplaintDto.IssueID).ConfigureAwait(false);



                if (lstJEPCOViewRequestsChildsResponse != null && lstJEPCOViewRequestsChildsResponse.Count > 0)
                {
                    foreach (var jEPCOViewRequest in lstJEPCOViewRequestsChildsResponse)
                    {



                        if (lstFalutComplaintData == null || lstFalutComplaintData.ToList().Count == 0 )
                        {

                            tb_Fault_Compliants tb_Fault_Compliants = new tb_Fault_Compliants();
                            tb_Fault_Compliants.ComplaintDescription = jEPCOViewRequest.ComplaintDescription;
                            tb_Fault_Compliants.ComplaintRefNumber = jEPCOViewRequest.Refcode;
                            tb_Fault_Compliants.ComplaintDescription = jEPCOViewRequest.ComplaintDescription.ToString();
                            tb_Fault_Compliants.CompliantCustomerName = jEPCOViewRequest.CustomerName;
                            tb_Fault_Compliants.CompliantDateTime = jEPCOViewRequest.ComplaintDate;

                            if (jEPCOViewRequest.CustomerMobileNumber != null)
                            {


                                if (jEPCOViewRequest.CustomerMobileNumber.StartsWith("+9620"))
                                {
                                    tb_Fault_Compliants.CompliantPhoneNumber = jEPCOViewRequest.CustomerMobileNumber[4..];
                                }
                                else if (jEPCOViewRequest.CustomerMobileNumber.StartsWith("+962"))
                                {

                                    tb_Fault_Compliants.CompliantPhoneNumber = "0" + jEPCOViewRequest.CustomerMobileNumber[4..];


                                }
                                else if (jEPCOViewRequest.CustomerMobileNumber.StartsWith("9620"))
                                {
                                    tb_Fault_Compliants.CompliantPhoneNumber = jEPCOViewRequest.CustomerMobileNumber[3..]; //ComplainPhoneNumber = NewComplaint.ComplainPhoneNumber.Replace("962", "");
                                }
                                else if (jEPCOViewRequest.CustomerMobileNumber.StartsWith("962"))
                                {
                                    tb_Fault_Compliants.CompliantPhoneNumber = "0" + jEPCOViewRequest.CustomerMobileNumber[3..]; //ComplainPhoneNumber = NewComplaint.ComplainPhoneNumber.Replace("962", "");


                                }
                                else if (jEPCOViewRequest.CustomerMobileNumber.StartsWith("009620"))
                                {
                                    tb_Fault_Compliants.CompliantPhoneNumber = jEPCOViewRequest.CustomerMobileNumber[5..];//.Replace("00962", "");
                                }
                                else if (jEPCOViewRequest.CustomerMobileNumber.StartsWith("00962"))
                                {
                                    tb_Fault_Compliants.CompliantPhoneNumber = "0" + jEPCOViewRequest.CustomerMobileNumber[5..];//.Replace("00962", "");
                                }
                                else
                                {
                                    tb_Fault_Compliants.CompliantPhoneNumber = jEPCOViewRequest.CustomerMobileNumber;

                                }
                            }
                            else
                            {
                                tb_Fault_Compliants.CompliantPhoneNumber = jEPCOViewRequest.CustomerMobileNumber;

                            }


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
                            //int a = 1;
                            //tb_ElectricalFaultStatus tb_ElectricalFaultStatusOBJ = await _repository.ElectricalFaultStatusRepository.GetSingleElectricalFaultStatus(x => x.FaultStatusID == a).ConfigureAwait(false);

                            //tb_FaultDetails tb_Fault_Details = new tb_FaultDetails();
                            //tb_Fault_Details.FaultComplaintID = tb_Fault_Compliants.FaultComplaintID;
                            //tb_Fault_Details.CreatedDate = DateTime.Now;
                            //tb_Fault_Details.UpdateDate = DateTime.Now;

                            ////tb_Fault_Details.RepairingStatusID = a;
                            ////tb_Fault_Details.FaultDescription = tb_Fault_Compliants.ComplaintDescription;
                            //_repository.FaultDetailsRepository.AddFaultDetails(tb_Fault_Details);
                            //await _repository.SaveAsync().ConfigureAwait(false);
                        }


                    }

                    lstFalutComplaintData.FirstOrDefault().ChildTicketsCount = lstJEPCOViewRequestsChildsResponse.Count();
                    lstFalutComplaintData.FirstOrDefault().UpdateDate = DateTime.Now;
                    _repository.FaultCompliantsLookupRepository.Update(null, lstFalutComplaintData.FirstOrDefault());
                    await _repository.SaveAsync().ConfigureAwait(false);

                }
                else{

                    lstFalutComplaintData.FirstOrDefault().ChildTicketsCount = 0;
                    lstFalutComplaintData.FirstOrDefault().UpdateDate = DateTime.Now; 
                    _repository.FaultCompliantsLookupRepository.Update(null, lstFalutComplaintData.FirstOrDefault());
                    await _repository.SaveAsync().ConfigureAwait(false);

                }



                var lstFalutComplaint = await _repository.FaultCompliantsLookupRepository.GetListOfFaultCompliants(x => x.UserID == FaultComplaintDto.UserID && x.CompliantParentRefNumber == FaultComplaintDto.ComplaintRefCode &&
                (x.FaultStatusID != 4 && x.FaultStatusID != 5)).ConfigureAwait(false);


                return Ok(_common.ReturnOkData(_common.ReturnResourceValue(_localizerAR, _localizerEN, FaultComplaintDto.LanguageId, "Returned NEW Fault Complaints fro Technication"), lstFalutComplaint));

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetChildFaultCompliantList action: {ex.Message + System.Environment.NewLine + ex.InnerException + ex.StackTrace}");
                return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, FaultComplaintDto.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, FaultComplaintDto.LanguageId, "Internal server error")));
            }

        }

        //----------------------------------------------------------------------------------------------------------

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost(Name = "PushTicket")]
        [Route("PushTicket")]
        public async Task<ActionResult<CommonReturnResult>> PushTicket([FromBody] List<PushRequestDTO> PushRequest)
        {


            try
            {
          
                if (PushRequest != null && PushRequest.Count > 0)
                {
                    foreach (var jEPCOViewRequest in PushRequest)
                    {


                        IEnumerable<tb_Fault_Compliants> lstFalutComplaintData = await _repository.FaultCompliantsLookupRepository.GetListOfFaultCompliants(x => x.IssueID == jEPCOViewRequest.IssueID).ConfigureAwait(false);

                        if (lstFalutComplaintData == null || lstFalutComplaintData.ToList().Count == 0)
                        {

                            tb_Fault_Compliants tb_Fault_Compliants = new tb_Fault_Compliants();

                            tb_Fault_Compliants.ComplaintDescription = jEPCOViewRequest.ComplaintDescription;
                            tb_Fault_Compliants.ComplaintRefNumber = jEPCOViewRequest.ComplaintRefNumber;
                            tb_Fault_Compliants.ComplaintDescription = jEPCOViewRequest.ComplaintDescription.ToString();
                            tb_Fault_Compliants.CompliantCustomerName = jEPCOViewRequest.CompliantCustomerName;
                            tb_Fault_Compliants.CompliantDateTime = jEPCOViewRequest.CompliantDateTime;
                            tb_Fault_Compliants.CompliantPhoneNumber = jEPCOViewRequest.CompliantPhoneNumber;
                            tb_Fault_Compliants.SubstationNumber = jEPCOViewRequest.SubstationNumber;
                            tb_Fault_Compliants.CompliantParentRefNumber = jEPCOViewRequest.CompliantParentRefNumber;
                            tb_Fault_Compliants.CustomerAddress_Latt = jEPCOViewRequest.CustomerAddress_Latt;
                            tb_Fault_Compliants.CustomerAddress_Long = jEPCOViewRequest.CustomerAddress_Long;

                            tb_Fault_Compliants.DistrictID = jEPCOViewRequest.DistrictID;
                            tb_Fault_Compliants.DistrictName = jEPCOViewRequest.DistrictName;
                            tb_Fault_Compliants.GovernateId = jEPCOViewRequest.GovernateId;
                            tb_Fault_Compliants.GovernateName = jEPCOViewRequest.GovernateName;
                            tb_Fault_Compliants.ZoneID = jEPCOViewRequest.ZoneID;
                            tb_Fault_Compliants.ZoneName = jEPCOViewRequest.ZoneName;

                            tb_Fault_Compliants.StreetID = jEPCOViewRequest.StreetID;
                            tb_Fault_Compliants.StreetName = jEPCOViewRequest.ZoneName;
                            tb_Fault_Compliants.FaultStatusID = 1;
                            tb_Fault_Compliants.MenaTrackStatusDesc = jEPCOViewRequest.MenaTrackStatusDesc;
                            tb_Fault_Compliants.MenaTrackStatusID = jEPCOViewRequest.MenaTrackStatusID;
                            tb_Fault_Compliants.IssueID = jEPCOViewRequest.IssueID;
                            tb_Fault_Compliants.PiorityID = jEPCOViewRequest.PiorityID;
                            tb_Fault_Compliants.PiorityDesc = jEPCOViewRequest.PiorityDesc;
                            tb_Fault_Compliants.UserID = jEPCOViewRequest.UserID;
                            tb_Fault_Compliants.UserName = jEPCOViewRequest.UserName;
                            tb_Fault_Compliants.BranchID = jEPCOViewRequest.BranchID;
                            tb_Fault_Compliants.CreatedDate = DateTime.Now;
                            tb_Fault_Compliants.UpdateDate = DateTime.Now;
                            tb_Fault_Compliants.LV_Feeder = jEPCOViewRequest.LV_Feeder;
                            tb_Fault_Compliants.MV_Feeder = jEPCOViewRequest.MV_Feeder;
                            tb_Fault_Compliants.SubstationNumber = jEPCOViewRequest.SubstationNumber;
                            //tb_Fault_Compliants.SubstationName  = jEPCOViewRequest.s;





                            _repository.FaultCompliantsLookupRepository.AddFaultCompliants(tb_Fault_Compliants);
                            await _repository.SaveAsync().ConfigureAwait(false);

                       
                        
                          
                            //int a = 1;
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



               


                return Ok(_common.ReturnResourceValue(_localizerAR, _localizerEN, "AR", "Save all new Fault Complaints for Technication"));

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside PushTicket action: {ex.Message + System.Environment.NewLine + ex.InnerException + ex.StackTrace}");
                return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, "AR", "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, "AR", "Internal server error")));
            }

        }


    }
}