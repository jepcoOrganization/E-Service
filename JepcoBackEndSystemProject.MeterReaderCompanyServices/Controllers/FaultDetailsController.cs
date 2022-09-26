using AutoMapper;
using JepcoBackEndSystemProject.Data;
using JepcoBackEndSystemProject.Data.CommonReturn;
using JepcoBackEndSystemProject.EmergancyAppApis.DataTransferObject.FaultClassfication;
using JepcoBackEndSystemProject.EmergancyAppApis.DataTransferObject.FaultComplaint;
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
    [Route("FaultDetails")]
    [ApiController]
    public class FaultDetailsController : ControllerBase
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

        public FaultDetailsController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper,
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
        [HttpPost(Name = "GetFaultCompliantDetails")]
        [Route("GetFaultCompliantDetails")]
        // BranchId from BranchesModelResource in Resource project to hide value
        public async Task<ActionResult<CommonReturnResult>> GetChildFaultCompliantDetails([FromBody] ComplaintFaultDetailsRequestDto ComplaintFaultDetailsRequest)
        {

            try
            {
                if (ComplaintFaultDetailsRequest == null)
                {


                    return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, ComplaintFaultDetailsRequest.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, ComplaintFaultDetailsRequest.LanguageId, " Complaint object sent from client is null")));
                }
                if (!ModelState.IsValid)
                {



                    return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, ComplaintFaultDetailsRequest.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, ComplaintFaultDetailsRequest.LanguageId, "Invalid Complaint object sent from client")));
                }

                tb_FaultDetails ComplaintFaultDetails = await _repository.FaultDetailsRepository.GetSingleFaultDetails(faultDetails => faultDetails.FaultComplaintID == ComplaintFaultDetailsRequest.FaultComplaintID).ConfigureAwait(false);


                if (ComplaintFaultDetails == null)
                {
                    //   _logger.LogError($"Branch with id: {Branch.Id}, hasn't been found in db.");

                    //Call API for add error log inside TbErrorLogs

                    return NotFound(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, ComplaintFaultDetailsRequest.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, ComplaintFaultDetailsRequest.LanguageId, "Complaint with id hasn't been found in db") + ComplaintFaultDetailsRequest.FaultComplaintID));

                }
                else
                {
                    //BranchesReturnDto BranchResult = _mapper.Map<BranchesReturnDto>(branch);
                    //    // _logger.LogInfo($"Returned Branch with id: {Branch.Id}");
                    return Ok(_common.ReturnOkData(_common.ReturnResourceValue(_localizerAR, _localizerEN, ComplaintFaultDetailsRequest.LanguageId, "Returned Complaint with id") + ComplaintFaultDetails.FaultComplaintID, ComplaintFaultDetails));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetComplaintByID action: {ex.Message + System.Environment.NewLine + ex.InnerException + ex.StackTrace}");

                //Call API for add error log inside TbErrorLogs

                // _common.AddErrorLog(_repository,"Branches", "GetBranchByID", $"Something went wrong inside GetBranchByID action: {ex.Message + System.Environment.NewLine + ex.InnerException + ex.StackTrace }", ex.StackTrace, ex.Message, "400");

                return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, ComplaintFaultDetailsRequest.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, ComplaintFaultDetailsRequest.LanguageId, "Internal server error")));

            }
        }

        //----------------------------------------------------------------------------------------------------------------------------
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost(Name = "DelivredCompliant")]
        [Route("DelivredCompliant")]
        // BranchId from BranchesModelResource in Resource project to hide value
        public async Task<ActionResult<CommonReturnResult>> Deliverd([FromBody] DelivredCompliantRequestDto DelivredCompliantRequest)
        {

            try
            {
                if (DelivredCompliantRequest == null)
                {


                    return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, DelivredCompliantRequest.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, DelivredCompliantRequest.LanguageId, " Complaint object sent from client is null")));
                }
                if (!ModelState.IsValid)
                {



                    return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, DelivredCompliantRequest.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, DelivredCompliantRequest.LanguageId, "Invalid Complaint object sent from client")));
                }
                tb_Fault_Compliants Fault_Compliants = await _repository.FaultCompliantsLookupRepository.GetSingleFaultCompliant(X => X.FaultComplaintID == DelivredCompliantRequest.FaultComplaintID).ConfigureAwait(false);
                tb_FaultDetails ComplaintFaultDetails = await _repository.FaultDetailsRepository.GetSingleFaultDetails(faultDetails => faultDetails.FaultComplaintID == DelivredCompliantRequest.FaultComplaintID).ConfigureAwait(false);


                if (ComplaintFaultDetails == null || Fault_Compliants == null)
                {
                    //   _logger.LogError($"Branch with id: {Branch.Id}, hasn't been found in db.");

                    //Call API for add error log inside TbErrorLogs

                    return NotFound(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, DelivredCompliantRequest.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, DelivredCompliantRequest.LanguageId, "Complaint with id hasn't been found in db") + DelivredCompliantRequest.FaultComplaintID));

                }
                else
                {
                    // tb_FaultDetails ComplaintFaultDetailsUpdate = new tb_FaultDetails();
                    ComplaintFaultDetails.DeliveredDateTime = DateTime.Now;
                    ComplaintFaultDetails.UpdateDate = DateTime.Now;
                    //ComplaintFaultDetails.FaultDetailsId = ComplaintFaultDetails.FaultDetailsId;
                    //ComplaintFaultDetailsUpdate.FaultComplaintID = ComplaintFaultDetails.FaultComplaintID;




                    //  _mapper.Map(ComplaintFaultDetailsUpdate, ComplaintFaultDetails);//Assign Updateed Fields For Orginal Model
                    _repository.FaultDetailsRepository.UpdateFaultDetails(null, ComplaintFaultDetails);
                    await _repository.SaveAsync().ConfigureAwait(false);

                    //------------------------------------------------------------------------------------------------------------------------------------
                    //tb_Fault_Compliants ComplaintUpdate = new tb_Fault_Compliants();
                    //ComplaintUpdate.FaultComplaintID = Fault_Compliants.FaultComplaintID;
                    //ComplaintUpdate.ComplaintRefNumber = Fault_Compliants.ComplaintRefNumber;
                    //ComplaintUpdate.CompliantDateTime = Fault_Compliants.CompliantDateTime;
                    //ComplaintUpdate.CompliantCustomerName = Fault_Compliants.CompliantCustomerName;
                    //ComplaintUpdate.CompliantPhoneNumber = Fault_Compliants.CompliantPhoneNumber;
                    //ComplaintUpdate.UserName = Fault_Compliants.UserName;
                    //ComplaintUpdate.UserID = Fault_Compliants.UserID;
                    //ComplaintUpdate.CreatedDate = Fault_Compliants.CreatedDate;

                    //ComplaintUpdate.IssueID = Fault_Compliants.IssueID;
                    //ComplaintUpdate.BranchID = Fault_Compliants.BranchID;





                    //_mapper.Map(ComplaintUpdate, Fault_Compliants);//Assign Updateed Fields For Orginal Model

                    Fault_Compliants.FaultStatusID = 2;
                    Fault_Compliants.UpdateDate = DateTime.Now;
                    _repository.FaultCompliantsLookupRepository.UpdateFaultCompliants(null, Fault_Compliants);
                    await _repository.SaveAsync().ConfigureAwait(false);
                    //-------------------------------------------------------------------------------------------------------------------------------------
                    IEnumerable<tb_Fault_Compliants> lstFalutComplaintData = await _repository.FaultCompliantsLookupRepository.GetListOfFaultCompliants(x => x.CompliantParentRefNumber == Fault_Compliants.ComplaintRefNumber).ConfigureAwait(false);
                    if (lstFalutComplaintData != null)
                    {
                        foreach (var objComplainChildtUpdate in lstFalutComplaintData)
                        {
                            //tb_Fault_Compliants ComplaintChildUpdate = new tb_Fault_Compliants();
                            //ComplaintUpdate.FaultComplaintID = ComplainChildtUpdatelist.FaultComplaintID;
                            //ComplaintUpdate.ComplaintRefNumber = ComplainChildtUpdatelist.ComplaintRefNumber;
                            //ComplaintUpdate.CompliantDateTime = ComplainChildtUpdatelist.CompliantDateTime;
                            //ComplaintUpdate.CompliantCustomerName = ComplainChildtUpdatelist.CompliantCustomerName;
                            //ComplaintUpdate.CompliantPhoneNumber = ComplainChildtUpdatelist.CompliantPhoneNumber;
                            //ComplaintUpdate.UserName = ComplainChildtUpdatelist.UserName;
                            //ComplaintUpdate.UserID = ComplainChildtUpdatelist.UserID;
                            //ComplaintUpdate.CreatedDate = ComplainChildtUpdatelist.CreatedDate;
                            //ComplaintUpdate.FaultStatusID = 2;
                            //ComplaintUpdate.UpdateDate = DateTime.Now;
                            //ComplaintUpdate.IssueID = ComplainChildtUpdatelist.IssueID;
                            //ComplaintUpdate.BranchID = ComplainChildtUpdatelist.BranchID;


                            //_mapper.Map(ComplaintChildUpdate, ComplainChildtUpdatelist);//Assign Updateed Fields For Orginal Model

                            objComplainChildtUpdate.FaultStatusID = 2;
                            objComplainChildtUpdate.UpdateDate = DateTime.Now;

                            _repository.FaultCompliantsLookupRepository.UpdateFaultCompliants(null, objComplainChildtUpdate);
                            await _repository.SaveAsync().ConfigureAwait(false);

                        }
                    }




                    //------------------------------------------------------------------------------------------------------------------------------------
                    return Ok(_common.ReturnOkData(_common.ReturnResourceValue(_localizerAR, _localizerEN, DelivredCompliantRequest.LanguageId, "Returned Complaint with id") + ComplaintFaultDetails.FaultComplaintID, ComplaintFaultDetails));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetComplaintByID action: {ex.Message + System.Environment.NewLine + ex.InnerException + ex.StackTrace}");

                //Call API for add error log inside TbErrorLogs

                // _common.AddErrorLog(_repository,"Branches", "GetBranchByID", $"Something went wrong inside GetBranchByID action: {ex.Message + System.Environment.NewLine + ex.InnerException + ex.StackTrace }", ex.StackTrace, ex.Message, "400");

                return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, DelivredCompliantRequest.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, DelivredCompliantRequest.LanguageId, "Internal server error")));

            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        [HttpPost(Name = "ArrivingLocation")]
        [Route("ArrivingLocation")]
        // BranchId from BranchesModelResource in Resource project to hide value
        public async Task<ActionResult<CommonReturnResult>> ArrivingLocation([FromBody] ArrivingLocationCompliantRequestDto ArrivingLocationCompliantRequestDto)
        {

            try
            {
                if (ArrivingLocationCompliantRequestDto == null)
                {


                    return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, ArrivingLocationCompliantRequestDto.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, ArrivingLocationCompliantRequestDto.LanguageId, " Complaint object sent from client is null")));
                }
                if (!ModelState.IsValid)
                {



                    return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, ArrivingLocationCompliantRequestDto.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, ArrivingLocationCompliantRequestDto.LanguageId, "Invalid Complaint object sent from client")));
                }
                tb_Fault_Compliants Fault_Compliants = await _repository.FaultCompliantsLookupRepository.GetSingleFaultCompliant(X => X.FaultComplaintID == ArrivingLocationCompliantRequestDto.FaultComplaintID).ConfigureAwait(false);
                tb_FaultDetails ComplaintFaultDetails = await _repository.FaultDetailsRepository.GetSingleFaultDetails(faultDetails => faultDetails.FaultComplaintID == ArrivingLocationCompliantRequestDto.FaultComplaintID).ConfigureAwait(false);


                if (ComplaintFaultDetails == null || Fault_Compliants == null)
                {
                    //   _logger.LogError($"Branch with id: {Branch.Id}, hasn't been found in db.");

                    //Call API for add error log inside TbErrorLogs

                    return NotFound(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, ArrivingLocationCompliantRequestDto.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, ArrivingLocationCompliantRequestDto.LanguageId, "Complaint with id hasn't been found in db") + ArrivingLocationCompliantRequestDto.FaultComplaintID));

                }
                else
                {
                    ComplaintFaultDetails.ArrivingLocationDateTime = DateTime.Now;
                    ComplaintFaultDetails.ArrivingLocationImage = ArrivingLocationCompliantRequestDto.ArrivingLocationImage;
                    ComplaintFaultDetails.ArrivingLocationLatt  = ArrivingLocationCompliantRequestDto.ArrivingLocationLatt;
                    ComplaintFaultDetails.ArrivingLocationLong  = ArrivingLocationCompliantRequestDto.ArrivingLocationLong;
                    ComplaintFaultDetails.UpdateDate = DateTime.Now; 
                    _repository.FaultDetailsRepository.UpdateFaultDetails(null, ComplaintFaultDetails);
                    await _repository.SaveAsync().ConfigureAwait(false);

                    //------------------------------------------------------------------------------------------------------------------------------------

                    Fault_Compliants.FaultStatusID = 3;
                    Fault_Compliants.UpdateDate = DateTime.Now;
                     _repository.FaultCompliantsLookupRepository.UpdateFaultCompliants(null, Fault_Compliants);
                    await _repository.SaveAsync().ConfigureAwait(false);
                    //-------------------------------------------------------------------------------------------------------------------------------------
                    IEnumerable<tb_Fault_Compliants> lstFalutComplaintData = await _repository.FaultCompliantsLookupRepository.GetListOfFaultCompliants(x => x.CompliantParentRefNumber == Fault_Compliants.ComplaintRefNumber).ConfigureAwait(false);
                    if (lstFalutComplaintData != null)
                    {
                        foreach (var objComplainChildtUpdate in lstFalutComplaintData)
                        {
                            // tb_Fault_Compliants ComplaintChildUpdate = new tb_Fault_Compliants();

                            objComplainChildtUpdate.FaultStatusID = 3;
                            objComplainChildtUpdate.UpdateDate = DateTime.Now;
                            
                            _repository.FaultCompliantsLookupRepository.UpdateFaultCompliants(null, objComplainChildtUpdate);
                            await _repository.SaveAsync().ConfigureAwait(false);

                        }
                    }




                    //------------------------------------------------------------------------------------------------------------------------------------
                    return Ok(_common.ReturnOkData(_common.ReturnResourceValue(_localizerAR, _localizerEN, ArrivingLocationCompliantRequestDto.LanguageId, "Returned Complaint with id") + ComplaintFaultDetails.FaultComplaintID, ComplaintFaultDetails));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside ArrivingLocation action: {ex.Message + System.Environment.NewLine + ex.InnerException + ex.StackTrace}");

                //Call API for add error log inside TbErrorLogs

                // _common.AddErrorLog(_repository,"Branches", "GetBranchByID", $"Something went wrong inside GetBranchByID action: {ex.Message + System.Environment.NewLine + ex.InnerException + ex.StackTrace }", ex.StackTrace, ex.Message, "400");

                return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, ArrivingLocationCompliantRequestDto.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, ArrivingLocationCompliantRequestDto.LanguageId, "Internal server error")));

            }
        }


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        [HttpPost(Name = "RepairandCloseComplaint")]
        [Route("RepairandCloseComplaint")]
        // BranchId from BranchesModelResource in Resource project to hide value
        public async Task<ActionResult<CommonReturnResult>> RepairandCloseComplaint([FromBody] RepairandCloseComplaintRequestDto RepairandCloseComplaintRequestDto)
        {

            try
            {
                if (RepairandCloseComplaintRequestDto == null)
                {


                    return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, RepairandCloseComplaintRequestDto.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, RepairandCloseComplaintRequestDto.LanguageId, " Complaint object sent from client is null")));
                }
                if (!ModelState.IsValid)
                {



                    return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, RepairandCloseComplaintRequestDto.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, RepairandCloseComplaintRequestDto.LanguageId, "Invalid Complaint object sent from client")));
                }
                tb_Fault_Compliants Fault_Compliants = await _repository.FaultCompliantsLookupRepository.GetSingleFaultCompliant(X => X.FaultComplaintID == RepairandCloseComplaintRequestDto.FaultComplaintID).ConfigureAwait(false);
                tb_FaultDetails ComplaintFaultDetails = await _repository.FaultDetailsRepository.GetSingleFaultDetails(faultDetails => faultDetails.FaultComplaintID == RepairandCloseComplaintRequestDto.FaultComplaintID).ConfigureAwait(false);


                if (ComplaintFaultDetails == null || Fault_Compliants == null)
                {
                    //   _logger.LogError($"Branch with id: {Branch.Id}, hasn't been found in db.");

                    //Call API for add error log inside TbErrorLogs

                    return NotFound(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, RepairandCloseComplaintRequestDto.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, RepairandCloseComplaintRequestDto.LanguageId, "Complaint with id hasn't been found in db") + RepairandCloseComplaintRequestDto.FaultComplaintID));

                }
                else
                {
                    ComplaintFaultDetails.RepairingClosingDatetime = DateTime.Now;
                    ComplaintFaultDetails.FaultClassficationID   = RepairandCloseComplaintRequestDto.FaultClassficationID ;
                    ComplaintFaultDetails.FaultClassficationName  = RepairandCloseComplaintRequestDto.FaultClassficationName;

                    ComplaintFaultDetails.FaultSubClassficationID  = RepairandCloseComplaintRequestDto.FaultSubClassficationID;
                    ComplaintFaultDetails.FaultSubClassficationName = RepairandCloseComplaintRequestDto.FaultSubClassficationName;

                    ComplaintFaultDetails.UpdatedLV_Feeder  = RepairandCloseComplaintRequestDto.UpdatedLV_Feeder;
                    
                    ComplaintFaultDetails.UpdatedSubstationLatt  = RepairandCloseComplaintRequestDto.UpdatedSubstationLatt;
                    ComplaintFaultDetails.UpdatedSubstationLong  = RepairandCloseComplaintRequestDto.UpdatedSubstationLong;
                    ComplaintFaultDetails.UpdateSubstationID  = RepairandCloseComplaintRequestDto.UpdateSubstationID;
                    ComplaintFaultDetails.UpdateSubstationName  = RepairandCloseComplaintRequestDto.UpdateSubstationName;
                    
                    ComplaintFaultDetails.RepairingImage1 = RepairandCloseComplaintRequestDto.RepairingImage1;
                    ComplaintFaultDetails.RepairingStatusID = RepairandCloseComplaintRequestDto.RepairingStatusID;

                    ComplaintFaultDetails.FaultDescription = RepairandCloseComplaintRequestDto.FaultDescription;
                    ComplaintFaultDetails.FaultReason  = RepairandCloseComplaintRequestDto.FaultReason;
                    ComplaintFaultDetails.TechnicationNote = RepairandCloseComplaintRequestDto.TechnicationNote;
                    ComplaintFaultDetails.UpdateDate = DateTime.Now; 


                    _repository.FaultDetailsRepository.UpdateFaultDetails(null, ComplaintFaultDetails);
                    await _repository.SaveAsync().ConfigureAwait(false);

                    //------------------------------------------------------------------------------------------------------------------------------------

                    Fault_Compliants.FaultStatusID = 4;
                    Fault_Compliants.UpdateDate = DateTime.Now;
                    _repository.FaultCompliantsLookupRepository.UpdateFaultCompliants(null, Fault_Compliants);
                    await _repository.SaveAsync().ConfigureAwait(false);
                    //-------------------------------------------------------------------------------------------------------------------------------------
                    IEnumerable<tb_Fault_Compliants> lstFalutComplaintData = await _repository.FaultCompliantsLookupRepository.GetListOfFaultCompliants(x => x.CompliantParentRefNumber == Fault_Compliants.ComplaintRefNumber).ConfigureAwait(false);
                    if (lstFalutComplaintData != null)
                    {
                        foreach (var objComplainChildtUpdate in lstFalutComplaintData)
                        {
                           // tb_Fault_Compliants ComplaintChildUpdate = new tb_Fault_Compliants();

                            objComplainChildtUpdate.FaultStatusID = 4;
                            objComplainChildtUpdate.UpdateDate = DateTime.Now;

                            _repository.FaultCompliantsLookupRepository.UpdateFaultCompliants(null, objComplainChildtUpdate);
                            await _repository.SaveAsync().ConfigureAwait(false);

                        }
                    }

                    //------------------------------------------------------------------------------------------------------------------------------------
                    return Ok(_common.ReturnOkData(_common.ReturnResourceValue(_localizerAR, _localizerEN, RepairandCloseComplaintRequestDto.LanguageId, "Returned Complaint with id") + ComplaintFaultDetails.FaultComplaintID, ComplaintFaultDetails));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside RepairandCloseComplaint action: {ex.Message + System.Environment.NewLine + ex.InnerException + ex.StackTrace}");

                //Call API for add error log inside TbErrorLogs

                // _common.AddErrorLog(_repository,"Branches", "GetBranchByID", $"Something went wrong inside GetBranchByID action: {ex.Message + System.Environment.NewLine + ex.InnerException + ex.StackTrace }", ex.StackTrace, ex.Message, "400");

                return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, RepairandCloseComplaintRequestDto.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, RepairandCloseComplaintRequestDto.LanguageId, "Internal server error")));

            }
        }


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost(Name = "ReassignCompliant")]
        [Route("ReassignCompliant")]
        // BranchId from BranchesModelResource in Resource project to hide value
        public async Task<ActionResult<CommonReturnResult>> ReassignCompliant([FromBody] ReassignCompliantDto ReassignCompliantDto)
        {

            try
            {
                if (ReassignCompliantDto == null)
                {


                    return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, ReassignCompliantDto.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, ReassignCompliantDto.LanguageId, " Complaint object sent from client is null")));
                }
                if (!ModelState.IsValid)
                {



                    return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, ReassignCompliantDto.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, ReassignCompliantDto.LanguageId, "Invalid Complaint object sent from client")));
                }
                tb_Fault_Compliants Fault_Compliants = await _repository.FaultCompliantsLookupRepository.GetSingleFaultCompliant(X => X.FaultComplaintID == ReassignCompliantDto.FaultComplaintID).ConfigureAwait(false);
                tb_FaultDetails ComplaintFaultDetails = await _repository.FaultDetailsRepository.GetSingleFaultDetails(faultDetails => faultDetails.FaultComplaintID == ReassignCompliantDto.FaultComplaintID).ConfigureAwait(false);


                if (ComplaintFaultDetails == null || Fault_Compliants == null)
                {
                    //   _logger.LogError($"Branch with id: {Branch.Id}, hasn't been found in db.");

                    //Call API for add error log inside TbErrorLogs

                    return NotFound(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, ReassignCompliantDto.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, ReassignCompliantDto.LanguageId, "Complaint with id hasn't been found in db") + ReassignCompliantDto.FaultComplaintID));

                }
                else
                {
                    ComplaintFaultDetails.ReassignDate  = DateTime.Now;
                    ComplaintFaultDetails.ReassignClassficationID  = ReassignCompliantDto.ReassignClassficationID ;
                    ComplaintFaultDetails.ReassignClassficationName  = ReassignCompliantDto.ReassignClassficationName ;

                    ComplaintFaultDetails.ReassignReason   = ReassignCompliantDto.ReassignReason;
                    

                    ComplaintFaultDetails.UpdateDate = DateTime.Now;


                    _repository.FaultDetailsRepository.UpdateFaultDetails(null, ComplaintFaultDetails);
                    await _repository.SaveAsync().ConfigureAwait(false);

                    //------------------------------------------------------------------------------------------------------------------------------------

                    Fault_Compliants.FaultStatusID = 5;
                    Fault_Compliants.UpdateDate = DateTime.Now;
                    _repository.FaultCompliantsLookupRepository.UpdateFaultCompliants(null, Fault_Compliants);
                    await _repository.SaveAsync().ConfigureAwait(false);
                    //-------------------------------------------------------------------------------------------------------------------------------------
                    IEnumerable<tb_Fault_Compliants> lstFalutComplaintData = await _repository.FaultCompliantsLookupRepository.GetListOfFaultCompliants(x => x.CompliantParentRefNumber == Fault_Compliants.ComplaintRefNumber).ConfigureAwait(false);
                    if (lstFalutComplaintData != null)
                    {
                        foreach (var objComplainChildtUpdate in lstFalutComplaintData)
                        {
                            // tb_Fault_Compliants ComplaintChildUpdate = new tb_Fault_Compliants();

                            objComplainChildtUpdate.FaultStatusID = 5;
                            objComplainChildtUpdate.UpdateDate = DateTime.Now;

                            _repository.FaultCompliantsLookupRepository.UpdateFaultCompliants(null, objComplainChildtUpdate);
                            await _repository.SaveAsync().ConfigureAwait(false);

                        }
                    }

                    //------------------------------------------------------------------------------------------------------------------------------------
                    return Ok(_common.ReturnOkData(_common.ReturnResourceValue(_localizerAR, _localizerEN, ReassignCompliantDto.LanguageId, "Returned Complaint with id") + ComplaintFaultDetails.FaultComplaintID, ComplaintFaultDetails));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside ReassignCompliant action: {ex.Message + System.Environment.NewLine + ex.InnerException + ex.StackTrace}");

                //Call API for add error log inside TbErrorLogs

                // _common.AddErrorLog(_repository,"Branches", "GetBranchByID", $"Something went wrong inside GetBranchByID action: {ex.Message + System.Environment.NewLine + ex.InnerException + ex.StackTrace }", ex.StackTrace, ex.Message, "400");

                return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, ReassignCompliantDto.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, ReassignCompliantDto.LanguageId, "Internal server error")));

            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        [HttpPost(Name = "FaultClassficationLookup")]
        [Route("FaultClassficationLookup")]
        // BranchId from BranchesModelResource in Resource project to hide value
        public async Task<ActionResult<CommonReturnResult>> FaultClassficationLookup([FromBody] FaultClassficationRequestDto FaultClassficationRequestDto)
        {

            try
            {
                if (FaultClassficationRequestDto == null)
                {


                    return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, FaultClassficationRequestDto.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, FaultClassficationRequestDto.LanguageId, " FaultClassficationRequestDto object sent from client is null")));
                }

                List<FaultClassficationResponsetDto> lstFaultClassficationResponsetDto = new List<FaultClassficationResponsetDto>();

                MenaTrackService.CallCenterNewClient objCallCenterNewClient = new MenaTrackService.CallCenterNewClient(MenaTrackService.CallCenterNewClient.EndpointConfiguration.BasicHttpsBinding_ICallCenterNew);

                List<MenaTrackService.ClassficationLookupResponse > lstClassficationLookupResponse = await objCallCenterNewClient.MainCalssficationsAsync ().ConfigureAwait(false);


                if (lstClassficationLookupResponse !=null && lstClassficationLookupResponse.Count > 0)
                {

                    foreach ( var obClassficationLookupResponse in lstClassficationLookupResponse)
                    {

                        FaultClassficationResponsetDto objFaultClassficationResponsetDto = new FaultClassficationResponsetDto();
                        objFaultClassficationResponsetDto.FaultClassficationID = obClassficationLookupResponse.FieldValue ;
                        objFaultClassficationResponsetDto.FaultClassficationName = obClassficationLookupResponse.FieldDesc  ;
                        lstFaultClassficationResponsetDto.Add(objFaultClassficationResponsetDto);

                    }


                }


               





                //------------------------------------------------------------------------------------------------------------------------------------
                return Ok(_common.ReturnOkData(_common.ReturnResourceValue(_localizerAR, _localizerEN, FaultClassficationRequestDto.LanguageId, "Fault Calssfication Lookup returened Susscuflly") , lstFaultClassficationResponsetDto));
                
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside FaultClassficationLookup action: {ex.Message + System.Environment.NewLine + ex.InnerException + ex.StackTrace}");

                //Call API for add error log inside TbErrorLogs

                // _common.AddErrorLog(_repository,"Branches", "GetBranchByID", $"Something went wrong inside GetBranchByID action: {ex.Message + System.Environment.NewLine + ex.InnerException + ex.StackTrace }", ex.StackTrace, ex.Message, "400");

                return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, FaultClassficationRequestDto.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, FaultClassficationRequestDto.LanguageId, "Internal server error")));

            }
        }



        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        [HttpPost(Name = "FaultSubClassficationLookup")]
        [Route("FaultSubClassficationLookup")]
        // BranchId from BranchesModelResource in Resource project to hide value
        public async Task<ActionResult<CommonReturnResult>> FaultSubClassficationLookup([FromBody] FaultSubClassficationRequestDto FaultSubClassficationRequestDto)
        {

            try
            {
                if (FaultSubClassficationRequestDto == null)
                {


                    return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, FaultSubClassficationRequestDto.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, FaultSubClassficationRequestDto.LanguageId, " FaultSubClassficationRequestDto object sent from client is null")));
                }

                List<FaultSubClassficationResponsetDto> lstFaultsubClassficationResponsetDto = new List<FaultSubClassficationResponsetDto>();



                if (FaultSubClassficationRequestDto.FaultClassficationID == 1
                    || FaultSubClassficationRequestDto.FaultClassficationID == 2
                    || FaultSubClassficationRequestDto.FaultClassficationID == 4

                    )
                {



                    MenaTrackService.CallCenterNewClient objCallCenterNewClient = new MenaTrackService.CallCenterNewClient(MenaTrackService.CallCenterNewClient.EndpointConfiguration.BasicHttpsBinding_ICallCenterNew);

                    List<MenaTrackService.ClassficationLookupResponse> lstClassficationLookupResponse = await objCallCenterNewClient.SubMainCalssficationsAsync(FaultSubClassficationRequestDto.FaultClassficationID).ConfigureAwait(false);



                    if (lstClassficationLookupResponse != null && lstClassficationLookupResponse.Count > 0)
                    {

                        foreach (var obClassficationLookupResponse in lstClassficationLookupResponse)
                        {

                            FaultSubClassficationResponsetDto objFaultSubClassficationResponsetDto = new FaultSubClassficationResponsetDto();
                            objFaultSubClassficationResponsetDto.FaultClassficationID = FaultSubClassficationRequestDto.FaultClassficationID;
                            objFaultSubClassficationResponsetDto.FaultSubClassficationID  = obClassficationLookupResponse.FieldValue ;

                            objFaultSubClassficationResponsetDto.FaultSubClassficationName  = obClassficationLookupResponse.FieldDesc;
                            lstFaultsubClassficationResponsetDto.Add(objFaultSubClassficationResponsetDto);

                        }


                    }




                }
                    
               

                //------------------------------------------------------------------------------------------------------------------------------------
                return Ok(_common.ReturnOkData(_common.ReturnResourceValue(_localizerAR, _localizerEN, FaultSubClassficationRequestDto.LanguageId, "Fault Calssfication Lookup returened Susscuflly"), lstFaultsubClassficationResponsetDto));

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside FaultSubClassficationLookup action: {ex.Message + System.Environment.NewLine + ex.InnerException + ex.StackTrace}");

                //Call API for add error log inside TbErrorLogs

                // _common.AddErrorLog(_repository,"Branches", "GetBranchByID", $"Something went wrong inside GetBranchByID action: {ex.Message + System.Environment.NewLine + ex.InnerException + ex.StackTrace }", ex.StackTrace, ex.Message, "400");

                return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, FaultSubClassficationRequestDto.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, FaultSubClassficationRequestDto.LanguageId, "Internal server error")));

            }
        }


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost(Name = "ReassingClassficationLookup")]
        [Route("ReassingClassficationLookup")]
        // BranchId from BranchesModelResource in Resource project to hide value
        public async Task<ActionResult<CommonReturnResult>> ReassingClassficationLookup([FromBody] ReassingClassficationRequestDto ReassingClassficationRequestDto)
        {

            try
            {
                if (ReassingClassficationRequestDto == null)
                {


                    return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, ReassingClassficationRequestDto.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, ReassingClassficationRequestDto.LanguageId, " FaultClassficationRequestDto object sent from client is null")));
                }

                List<ReassingClassficationResponsetDto > lstReassingClassficationResponsetDto = new List<ReassingClassficationResponsetDto>();

                MenaTrackService.CallCenterNewClient objCallCenterNewClient = new MenaTrackService.CallCenterNewClient(MenaTrackService.CallCenterNewClient.EndpointConfiguration.BasicHttpsBinding_ICallCenterNew);

                List<MenaTrackService.ClassficationLookupResponse> lstClassficationLookupResponse = await objCallCenterNewClient.ReassingCallsficationCalssficationsAsync ().ConfigureAwait(false);


                if (lstClassficationLookupResponse != null && lstClassficationLookupResponse.Count > 0)
                {

                    foreach (var obClassficationLookupResponse in lstClassficationLookupResponse)
                    {

                        ReassingClassficationResponsetDto objReassingClassficationResponsetDto = new ReassingClassficationResponsetDto();
                        objReassingClassficationResponsetDto.ReassingClassficationID  = obClassficationLookupResponse.FieldValue;
                        objReassingClassficationResponsetDto.ReassingClassficationName  = obClassficationLookupResponse.FieldDesc;
                        lstReassingClassficationResponsetDto.Add(objReassingClassficationResponsetDto);

                    }


                }








                //------------------------------------------------------------------------------------------------------------------------------------
                return Ok(_common.ReturnOkData(_common.ReturnResourceValue(_localizerAR, _localizerEN, ReassingClassficationRequestDto.LanguageId, "Fault Calssfication Lookup returened Susscuflly"), lstReassingClassficationResponsetDto));

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside FaultClassficationLookup action: {ex.Message + System.Environment.NewLine + ex.InnerException + ex.StackTrace}");

                //Call API for add error log inside TbErrorLogs

                // _common.AddErrorLog(_repository,"Branches", "GetBranchByID", $"Something went wrong inside GetBranchByID action: {ex.Message + System.Environment.NewLine + ex.InnerException + ex.StackTrace }", ex.StackTrace, ex.Message, "400");

                return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, ReassingClassficationRequestDto.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, ReassingClassficationRequestDto.LanguageId, "Internal server error")));

            }
        }
























    }
}
