using JepcoBackEndSystemProject.Models;
using JepcoBackEndSystemProject.Models.Models;
using JepcoBackEndSysytemProject.ResourcesFiles.Resources;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JepcoBackEndSystemProject.Data.CommonReturn
{
    public interface ICommonReturn
    {
        CommonReturnResult ReturnOkData(string Message, object body);
        ErrorDetails ReturnBadData(string Title, string Error);
        ErrorDetails ReturnCustomErrorData(string Title, string Error);
        void AddErrorLog(IRepositoryWrapper _repository, string ControllerName, string MethodName, string ErrorMsg, string ErrorStackTrace, string ErrorInnerException, string ErrorCode);
        public string ReturnResourceValue(IStringLocalizer<MessagesAr> _localizerAR, IStringLocalizer<MessagesEn> _localizerEN, string Language, string Value);
        
    }
}
