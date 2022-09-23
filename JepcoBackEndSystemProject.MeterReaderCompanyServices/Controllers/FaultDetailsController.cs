using AutoMapper;
using JepcoBackEndSystemProject.Data;
using JepcoBackEndSystemProject.Data.CommonReturn;
using JepcoBackEndSystemProject.EmergancyAppApis.DataTransferObject.FaultComplaint;
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





        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
                    tb_FaultDetails ComplaintFaultDetailsUpdate = new tb_FaultDetails();
                    ComplaintFaultDetailsUpdate.DeliveredDateTime = DateTime.Now;
                    ComplaintFaultDetailsUpdate.FaultDetailsId = ComplaintFaultDetails.FaultDetailsId;
                    ComplaintFaultDetailsUpdate.FaultComplaintID = ComplaintFaultDetails.FaultComplaintID;




                    _mapper.Map(ComplaintFaultDetailsUpdate, ComplaintFaultDetails);//Assign Updateed Fields For Orginal Model
                    _repository.FaultDetailsRepository.UpdateFaultDetails(null, ComplaintFaultDetailsUpdate);
                    await _repository.SaveAsync().ConfigureAwait(false);

//------------------------------------------------------------------------------------------------------------------------------------
                    tb_Fault_Compliants ComplaintUpdate = new tb_Fault_Compliants();
                    ComplaintUpdate.FaultComplaintID = Fault_Compliants.FaultComplaintID;
                    ComplaintUpdate.ComplaintRefNumber = Fault_Compliants.ComplaintRefNumber;
                    ComplaintUpdate.CompliantDateTime = Fault_Compliants.CompliantDateTime;
                    ComplaintUpdate.CompliantCustomerName = Fault_Compliants.CompliantCustomerName;
                    ComplaintUpdate.CompliantPhoneNumber = Fault_Compliants.CompliantPhoneNumber;
                    ComplaintUpdate.UserName = Fault_Compliants.UserName;
                    ComplaintUpdate.UserID = Fault_Compliants.UserID;
                    ComplaintUpdate.CreatedDate = Fault_Compliants.CreatedDate;
                    ComplaintUpdate.FaultStatusID = 2;
                    ComplaintUpdate.UpdateDate = DateTime.Now;
                    ComplaintUpdate.IssueID = Fault_Compliants.IssueID;
                    ComplaintUpdate.BranchID = Fault_Compliants.BranchID;





                    _mapper.Map(ComplaintUpdate, Fault_Compliants);//Assign Updateed Fields For Orginal Model
                    _repository.FaultCompliantsLookupRepository.UpdateFaultCompliants(null, ComplaintUpdate);
                    await _repository.SaveAsync().ConfigureAwait(false);
                    //-------------------------------------------------------------------------------------------------------------------------------------
                    IEnumerable<tb_Fault_Compliants> lstFalutComplaintData = await _repository.FaultCompliantsLookupRepository.GetListOfFaultCompliants(x => x.CompliantParentRefNumber == ComplaintUpdate.ComplaintRefNumber).ConfigureAwait(false);
                    if (lstFalutComplaintData != null)
                    {
                        foreach (var ComplainChildtUpdatelist in lstFalutComplaintData)
                        {
                            tb_Fault_Compliants ComplaintChildUpdate = new tb_Fault_Compliants();
                            ComplaintUpdate.FaultComplaintID = ComplainChildtUpdatelist.FaultComplaintID;
                            ComplaintUpdate.ComplaintRefNumber = ComplainChildtUpdatelist.ComplaintRefNumber;
                            ComplaintUpdate.CompliantDateTime = ComplainChildtUpdatelist.CompliantDateTime;
                            ComplaintUpdate.CompliantCustomerName = ComplainChildtUpdatelist.CompliantCustomerName;
                            ComplaintUpdate.CompliantPhoneNumber = ComplainChildtUpdatelist.CompliantPhoneNumber;
                            ComplaintUpdate.UserName = ComplainChildtUpdatelist.UserName;
                            ComplaintUpdate.UserID = ComplainChildtUpdatelist.UserID;
                            ComplaintUpdate.CreatedDate = ComplainChildtUpdatelist.CreatedDate;
                            ComplaintUpdate.FaultStatusID = 2;
                            ComplaintUpdate.UpdateDate = DateTime.Now;
                            ComplaintUpdate.IssueID = ComplainChildtUpdatelist.IssueID;
                            ComplaintUpdate.BranchID = ComplainChildtUpdatelist.BranchID;


                            _mapper.Map(ComplaintChildUpdate, ComplainChildtUpdatelist);//Assign Updateed Fields For Orginal Model
                            _repository.FaultCompliantsLookupRepository.UpdateFaultCompliants(null, ComplaintChildUpdate);
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
































    }
}
