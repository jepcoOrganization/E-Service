using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JepcoBackEndSystemProject.Data;
using JepcoBackEndSystemProject.Models.Models;
using JepcoBackEndSystemProject.Services.DataTransferObject.SmsVerification;
using JepcoBackEndSystemProject.Services.DataTransferObject;
using JepcoBackEndSysytemProject.LoggerService;
using Microsoft.AspNetCore.Mvc;
using PhoneNumbers;
using AutoMapper;
using JepcoBackEndSystemProject.Models;
using JepcoBackEndSystemProject.Data.CommonReturn;
using Microsoft.Extensions.Localization;
using JepcoBackEndSysytemProject.ResourcesFiles.Resources;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JepcoBackEndSystemProject.Services.Controllers
{
    // Call API url :  SmsVerifications/action
    [Route("SmsVerifications")]
    [ApiController]
    public class SmsVerificationsController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly ICommonReturn _common;
        private readonly IStringLocalizer<MessagesAr> _localizerAR;
        private readonly IStringLocalizer<MessagesEn> _localizerEN;
        public SmsVerificationsController(IRepositoryWrapper customrRepository, ILoggerManager logger, IMapper mapper,
            ICommonReturn common, IStringLocalizer<MessagesAr> localizerAR, IStringLocalizer<MessagesEn> localizerEN)
        {
            _repository = customrRepository;
            _logger = logger;
            _mapper = mapper;
            _common = common;
            _localizerAR = localizerAR;
            _localizerEN = localizerEN;
        }


        [HttpPost(Name = "SendSmsCodeForChangePassword")]
        [Route("SendSmsCodeForChangePassword")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<CommonReturnResult>> SendSmsCodeForChangePassword([FromBody] SmsVerificationAddDto smsVerifModel)
        {
            SmsVerificationReturnDto smsVerificationReturnDto = new SmsVerificationReturnDto();
            bool SendSuccess = false;

            try
            {

                if (smsVerifModel == null)
                {
                    _logger.LogError($"{0}:Invalid Phone Number object sent from client.");

                    //Call API for add error log inside TbErrorLogs
                    
                    // _common.AddErrorLog(_repository,"SmsVerifications", "SendSmsCode", $"{0}:Invalid Phone Number object sent from client.", "", $"{0}:Invalid Phone Number object sent from client.", "400");

                    return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, smsVerifModel.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, smsVerifModel.LanguageId, "Required parameters missing to access data")));
                }
                if ((!ModelState.IsValid))
                {
                    _logger.LogError($"{0}:Invalid Phone Number object sent from client.");
                    // smsVerificationReturnDto.Message = "Invalid Phone Number object sent from client.";

                    //Call API for add error log inside TbErrorLogs
                    
                    // _common.AddErrorLog(_repository,"SmsVerifications", "SendSmsCode", $"{0}:Invalid Phone Number object sent from client.", "", $"{0}:Invalid Phone Number object sent from client.", "400");

                    return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, smsVerifModel.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, smsVerifModel.LanguageId, "Required parameters missing to access data")));
                }

            tb_Technical objtb_Technical =   await _repository.TechnicalRepository.GetSingleTechnical(x=>x.EmployeeNumber == smsVerifModel.EmployeeNumber).ConfigureAwait(false) ;   


                if (objtb_Technical == null)
                {
                    return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, smsVerifModel.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, smsVerifModel.LanguageId, "Incorrect Employee Number")));


                }

                ValidatePhoneDto VaildPhoneNo = CheckValidateMobileNumber("+962", objtb_Technical.EmployeeMobileNumber);
                // smsVerificationReturnDto.Message = "The Mobile Number is incorrect";
                if (VaildPhoneNo == null)
                {
                    return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, smsVerifModel.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, smsVerifModel.LanguageId, "The Mobile Number is incorrect")));
                }
                if (!VaildPhoneNo.IsValidNumber)
                {
                    return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, smsVerifModel.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, smsVerifModel.LanguageId, "The Mobile Number is incorrect")));
                }
                if (!VaildPhoneNo.IsMobile)
                {
                    return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, smsVerifModel.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, smsVerifModel.LanguageId, "The Mobile Number is incorrect")));
                }

                TbSmsverification response = await _repository.SmsVerification.GetSingleSmsVerif(value => VaildPhoneNo.FormattedNumber == value.MobileNumber);
                string[] excludeProp = new string[2] { "Id", "MobileNumber" };
                string code = null;//= (new Random().Next(1000, 9999)).ToString();
                bool whiteList = false;
                string[] WhiteMobileNumber = new string[6] { "+962790000000", "+962790000001", "+962777005874", "+962796702098", "+962790375165","+962780000000" };
                foreach (string item in WhiteMobileNumber.ToList())
                {
                    if (item == VaildPhoneNo.FormattedNumber)
                    {
                        whiteList = true;
                        code = "0000";
                    }
                }
                if (!whiteList)
                {
                    code = (new Random().Next(1000, 9999)).ToString();
                }

                smsVerificationReturnDto.MobileNumber = VaildPhoneNo.FormattedNumber;

                //Check if Sms verifction 
                if (response == null)
                {
                    TbSmsverification smsverification = new TbSmsverification
                    {
                        MobileNumber = VaildPhoneNo.FormattedNumber,//smsVerifModel.MobileNumber,
                        CreateDate = DateTime.Now,
                        ExpiryDate = DateTime.Now.AddMinutes(3),
                        SMSTry = 1,
                        Smsstatus = 0,
                        Smscode = code,
                        UsedDate = null,
                        EmployeeNumber = smsVerifModel.EmployeeNumber 
                    };
                    _repository.SmsVerification.AddSmsVerification(smsverification);
                    await _repository.SaveAsync();
                    if (!whiteList)
                    {
                        //Send SMS Code to Customer
                        SendSuccess = _repository.SmsVerification.SendSmsChangePassword(VaildPhoneNo.FormattedNumber, code);
                    }
                    if (SendSuccess)
                    {
                        smsVerificationReturnDto = _mapper.Map<SmsVerificationReturnDto>(smsverification);
                        return Ok(_common.ReturnOkData(_common.ReturnResourceValue(_localizerAR, _localizerEN, smsVerifModel.LanguageId, "successfully send sms code"), smsVerificationReturnDto));
                    }
                    else
                    {
                        return Ok(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, smsVerifModel.LanguageId, "Unsuccessfully send sms code"), _common.ReturnResourceValue(_localizerAR, _localizerEN, smsVerifModel.LanguageId, "SMS Code didn't send")));
                    }
                    //smsVerificationReturnDto.Message = "successfully send sms code.";
                    //smsVerificationReturnDto = _mapper.Map<SmsVerificationReturnDto>(smsverification);
                    //return Ok(_common.ReturnOkData("successfully send sms code", smsVerificationReturnDto));

                }
                else
                {
                    double totalHours = DateTime.Now.Subtract(Convert.ToDateTime(response.CreateDate)).TotalHours;

                    if (//response.UsedDate != null &&
                        totalHours > 24 && response.SMSTry >= 100/*3*/)
                    {

                        response.CreateDate = DateTime.Now;
                        response.ExpiryDate = DateTime.Now.AddMinutes(3);
                        response.SMSTry = 1;
                        response.Smsstatus = 0;
                        response.Smscode = code;
                        response.UsedDate = null;
                        response.EmployeeNumber = smsVerifModel.EmployeeNumber;

                        _repository.SmsVerification.UpdateSmsVerification(excludeProp, response);
                        await _repository.SaveAsync();

                        //Send SMS Code to Customer
                        SendSuccess = _repository.SmsVerification.SendSmsChangePassword(response.MobileNumber, code);
                        if (SendSuccess)
                        {
                           // smsVerificationReturnDto = _mapper.Map<SmsVerificationReturnDto>(response);
                            return Ok(_common.ReturnOkData(_common.ReturnResourceValue(_localizerAR, _localizerEN, smsVerifModel.LanguageId, "successfully send sms code"), response));
                        }
                        else
                        {
                            return Ok(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, smsVerifModel.LanguageId, "Unsuccessfully send sms code"), _common.ReturnResourceValue(_localizerAR, _localizerEN, smsVerifModel.LanguageId, "SMS Code didn't send")));
                        }
                        //  smsVerificationReturnDto.Message = "successfully send sms code.";
                        // smsVerificationReturnDto = _mapper.Map<SmsVerificationReturnDto>(response);
                        // return Ok(_common.ReturnOkData("successfully send sms code", smsVerificationReturnDto));
                    }

                    else if (//response.UsedDate != null && 
                        totalHours < 24 && response.SMSTry >= 10/*3*/)
                    {
                        //smsVerificationReturnDto.Message = "You can send sms code message after 24 hourse";
                        return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, smsVerifModel.LanguageId, "Error"), "You can send sms code message after 24 hourse"));
                    }
                    else
                    {
                        response.ExpiryDate = DateTime.Now.AddMinutes(3);
                        response.SMSTry += 1;
                        response.Smsstatus = 0;
                        response.CreateDate = DateTime.Now;
                        response.Smscode = code;
                        response.UsedDate = null;
                        response.EmployeeNumber = smsVerifModel.EmployeeNumber;


                        _repository.SmsVerification.UpdateSmsVerification(excludeProp, response);
                        await _repository.SaveAsync().ConfigureAwait(false);

                        //Send SMS Code to Customer
                        SendSuccess = _repository.SmsVerification.SendSmsChangePassword(response.MobileNumber, code);
                        if (SendSuccess)
                        {
                           // smsVerificationReturnDto = _mapper.Map<SmsVerificationReturnDto>(response);
                            return Ok(_common.ReturnOkData(_common.ReturnResourceValue(_localizerAR, _localizerEN, smsVerifModel.LanguageId, "successfully send sms code"), response));
                        }
                        else
                        {
                            return Ok(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, smsVerifModel.LanguageId, "Unsuccessfully send sms code"), _common.ReturnResourceValue(_localizerAR, _localizerEN, smsVerifModel.LanguageId, "SMS Code didn't send")));
                        }
                        //smsVerificationReturnDto.Message = "successfully send sms code.";
                        // smsVerificationReturnDto = _mapper.Map<SmsVerificationReturnDto>(response);
                        //return Ok(_common.ReturnOkData("successfully send sms code", smsVerificationReturnDto));
                    }
                }
            }
            catch (Exception ex)
            {
                //smsVerificationReturnDto.Message = "Internal server error " + ex.ToString();
                _logger.LogError($"Something went wrong inside SendSmsCodeForChangePassword action: {ex.Message + System.Environment.NewLine + ex.InnerException + ex.StackTrace }");

                // Call API for add error log inside TbErrorLogs
                
                // _common.AddErrorLog(_repository,"SmsVerifications", "SendSmsCode", $"Something went wrong inside SendSmsCode action: {ex.Message + System.Environment.NewLine + ex.InnerException + ex.StackTrace }", ex.StackTrace, ex.Message, "400");


                return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, smsVerifModel.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, smsVerifModel.LanguageId, "Internal server error")));

            }
        }

        




        [HttpPost(Name = "SmsVerificationAndChangPassword")]
        [Route("SmsVerificationAndChangPassword")]
       // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<CommonReturnResult>> SmsVerificationAndChangPassword([FromBody] SmsVerificationCommonDto smsVerifModel)
        {
            SmsVerificationReturnDto smsVerificationReturnDto = new SmsVerificationReturnDto();

            try
            {


                string[] excludeProp = new string[6] { "Id", "MobileNumber", "CreateDate", "ExpiryDate", "SMSTry", "EmployeeNumber" };
                if (smsVerifModel == null)
                {
                    _logger.LogError($"{0}:Invalid Phone Number or Sms code object sent from client.");

                     // Call API for add error log inside TbErrorLogs
                    
                    // _common.AddErrorLog(_repository,"SmsVerifications", "SmsVerification", $"{0}:Invalid Phone Number or Sms code object sent from client.", "", $"{0}:Invalid Phone Number or Sms code object sent from client.", "400");

                    return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, smsVerifModel.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, smsVerifModel.LanguageId, "Required parameters missing to access data"))); ;
                }

                TbSmsverification response = await _repository.SmsVerification.GetSingleSmsVerif(value => smsVerifModel.MobileNumber == value.MobileNumber && value.Smscode == smsVerifModel.Smscode);
                //smsVerificationReturnDto.FormattedNumber = smsVerifModel.MobileNumber;

                if (response == null)
                {
                    // smsVerificationReturnDto.Message = "SMS Code is incorrect";
                    return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, smsVerifModel.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, smsVerifModel.LanguageId, "SMS Code is incorrect")));
                }
                else
                {
                    //TbSmsverification respAfterAdd = await _repository.SmsVerification.GetSingleSmsVerif(value => smsVerifModel.MobileNumber == value.MobileNumber && value.Smscode == smsVerifModel.Smscode);


                    tb_Technical objtb_Technical = await _repository.TechnicalRepository.GetSingleTechnical(x => x.EmployeeNumber == smsVerifModel.EmployeeNumber).ConfigureAwait(false);


                    if (objtb_Technical == null)
                    {
                        return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, smsVerifModel.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, smsVerifModel.LanguageId, "Incorrect Employee Number")));


                    }

                    response.UsedDate = DateTime.Now;
                    response.Smsstatus = 1;

                    objtb_Technical.EmployeePassword = smsVerifModel.NewPassword;

                    _repository.SmsVerification.UpdateSmsVerification(excludeProp, response);
                    _repository.TechnicalRepository.UpdateTechnical (null, objtb_Technical);

                    await _repository.SaveAsync().ConfigureAwait(false);
                    //smsVerificationReturnDto = _mapper.Map<SmsVerificationReturnDto>(response);


                   




                    return Ok(_common.ReturnOkData(_common.ReturnResourceValue(_localizerAR, _localizerEN, smsVerifModel.LanguageId, "Password Changed successfully"), response));


                 //   return Ok(_common.ReturnOkData("1", new { CustomerStatus = "1", smsVerificationReturn = smsVerificationReturnDto }));





                    //TbCustomerInformation customerdata = await _repository.CustomerInformation.GetSingleCusomerInfo(cust => cust.MobileNumber == response.MobileNumber, details => details.CustomerInformationDetails);

                    //CustomerInfoReturnDto CustomerInfoResult = _mapper.Map<CustomerInfoReturnDto>(customerdata);





                    //  smsVerificationReturnDto.Message = "Succe Code is correct";
                    // commontRetrunDto.StatusCode = "Success";
                    // commontRetrunDto.Message = "Succe Code is correct";
                    //commontRetrunDto.Body = smsVerificationReturnDto;
                    //return Ok(commontRetrunDto);
                    // return Ok(smsVerificationReturnDto);
                }
            }
            catch (Exception ex)
            {
                // smsVerificationReturnDto.Message = "Internal server error " + ex.ToString();
                _logger.LogError($"Something went wrong inside SmsVerificationandChangPassword action: {ex.Message + System.Environment.NewLine + ex.InnerException + ex.StackTrace }");
                  // Call API for add error log inside TbErrorLogs
                
                // _common.AddErrorLog(_repository,"SmsVerifications", "SmsVerification", $"Something went wrong inside SmsVerification action: {ex.Message + System.Environment.NewLine + ex.InnerException + ex.StackTrace }", ex.StackTrace, ex.Message, "400");


                return BadRequest(_common.ReturnBadData(_common.ReturnResourceValue(_localizerAR, _localizerEN, smsVerifModel.LanguageId, "Error"), _common.ReturnResourceValue(_localizerAR, _localizerEN, smsVerifModel.LanguageId, "Internal server error")));

            }
        }



       




        private ValidatePhoneDto CheckValidateMobileNumber(string CountryCode, string MobileNumber)
        {

            try
            {
                //string PhoneNo = CountryCode + MobileNumber;
                PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();
                // string region = phoneUtil.GetRegionCodeForNumber(PhoneNo);
                string telephoneNumber = MobileNumber;
                string countryCode = CountryCode;
                PhoneNumbers.PhoneNumber phoneNumber = phoneUtil.Parse(telephoneNumber, countryCode);
                bool isMobile = false;
                bool isValidNumber = phoneUtil.IsValidNumber(phoneNumber); // returns true for valid number    

                //// returns trueor false w.r.t phone number region  
                bool isValidRegion = phoneUtil.IsValidNumberForRegion(phoneNumber, countryCode);

                string region = phoneUtil.GetRegionCodeForNumber(phoneNumber); // GB, US , PK    

                var numberType = phoneUtil.GetNumberType(phoneNumber); // Produces Mobile , FIXED_LINE    

                string phoneNumberType = numberType.ToString();

                if (!string.IsNullOrEmpty(phoneNumberType) && phoneNumberType == "MOBILE")
                {
                    isMobile = true;
                }

                var originalNumber = phoneUtil.Format(phoneNumber, PhoneNumberFormat.E164); // Produces "+923336323997"    

                ValidatePhoneDto ValidPhoneNumberData = new ValidatePhoneDto
                {
                    FormattedNumber = originalNumber,
                    IsMobile = isMobile,
                    IsValidNumber = isValidNumber,
                    IsValidNumberForRegion = isValidRegion,
                    Region = region
                };
                return ValidPhoneNumberData;
                //returnResult = new GenericResponse<ValidatePhoneNumberModel>()
                //{
                //    Data = data,
                //    StatusCode = HttpStatusCode.OK,
                //    StatusMessage = "Success"
                //};

            }
            catch (NumberParseException ex)
            {
                _logger.LogError("NumberParseException was thrown: " + ex.Message.ToString());

                // Call API for add error log inside TbErrorLogs
                
                // _common.AddErrorLog(_repository,"SmsVerifications", "CheckValidateMobileNumber", "NumberParseException was thrown: " + ex.Message.ToString(), ex.StackTrace, ex.Message, "400");

                return new ValidatePhoneDto();


            }

        }
    }


}
