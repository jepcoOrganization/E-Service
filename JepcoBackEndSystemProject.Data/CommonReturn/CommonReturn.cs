using JepcoBackEndSystemProject.Models;
using JepcoBackEndSystemProject.Models.Models;
using JepcoBackEndSysytemProject.LoggerService;
using JepcoBackEndSysytemProject.ResourcesFiles.Resources;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FirebaseAdmin.Auth;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;
using System.Globalization;

namespace JepcoBackEndSystemProject.Data.CommonReturn
{
    public class CommonReturn : ICommonReturn
    {

        public CommonReturnResult ReturnOkData(string Message, object body)
        {
            // context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            CommonReturnResult commontRetrunDto = new CommonReturnResult
            {
                StatusCode = "Success", //context.Response.StatusCode.ToString();
                Message = Message,

                Body = body
            };
            return commontRetrunDto;
        }


        public ErrorDetails ReturnCustomErrorData(string Title, object Error)
        {
            ErrorDetails commontRetrunDto = new ErrorDetails
            {
                Status = 422,// context.Response.StatusCode.ToString();
                Title = Title,
                TraceId = Guid.NewGuid().ToString(),
                ErrorType = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                Errors = Error
            };
            return commontRetrunDto;
        }

        public ErrorDetails ReturnBadData(string Title, string Error)
        {
            ErrorDetails commontRetrunDto = new ErrorDetails
            {
                Status = -1,// context.Response.StatusCode.ToString();
                Title = Title,
                TraceId = Guid.NewGuid().ToString(),
                ErrorType = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                Errors = Error
            };
            return commontRetrunDto;
        }
        public void AddErrorLog(IRepositoryWrapper _repository, string ControllerName, string MethodName, string ErrorMsg, string ErrorStackTrace, string ErrorInnerException, string ErrorCode)
        {
            //LoggerManager _logger = new LoggerManager();



            //TbErrorLogs errorLogsData = new TbErrorLogs
            //{
            //    ControllerName = ControllerName,
            //    ErrorCode = ErrorCode,
            //    ErrorDate = DateTime.Now,
            //    ErrorInnerException = "343",//ErrorInnerException != null ? ErrorInnerException.Replace(System.Environment.NewLine, "---").Replace(@"\", "-") : "" ,
            //    ErrorMsg = ErrorMsg,
            //    ErrorStackTrace = "444" ,//ErrorStackTrace != null ? ErrorStackTrace.Replace(System.Environment.NewLine, "---").Replace(@"\", "-") : "",
            //    MethodName = MethodName,
            //    Status = false
            //};


            //try
            //{
            //    //_repository.ErrorLogs.AddErrorLog(errorLogsData);
            //    // _repository.SaveAsync().ConfigureAwait(false);
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError($"Something went wrong inside AddErrorLog action: {ex.Message}");
            //}

        }

        public string ReturnResourceValue(IStringLocalizer<MessagesAr> _localizerAR, IStringLocalizer<MessagesEn> _localizerEN, string Language, string Value)
        {
            string ReturnValue = string.Empty;

            if (Language.ToLower() == "ar")
            {
                ReturnValue = _localizerAR[Value];
            }
            if (Language.ToLower() == "en")
            {
                ReturnValue = _localizerEN[Value];
            }
            if (string.IsNullOrEmpty(ReturnValue))
            {
                return Value;
            }
            else
            {
                return ReturnValue;
            }
        }

       




          

    }
}
