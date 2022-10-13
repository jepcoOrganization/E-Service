using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using JepcoBackEndSystemProject.Models.Models;
using JepcoBackEndSysytemProject.LoggerService;
using Microsoft.EntityFrameworkCore;
using ZainReference;
 

namespace JepcoBackEndSystemProject.Data.Smsverifications
{
    public class SmsverificationRepository : RepositoryBase<TbSmsverification>, ISmsverificationRepository
    {
        public SmsverificationRepository(DBJEPCOBackEndContext repositoryContext, ILoggerManager logger)
           : base(repositoryContext, logger)
        {
        }

        public async Task<TbSmsverification> GetSingleSmsVerif(Expression<Func<TbSmsverification, bool>> where, params Expression<Func<TbSmsverification, object>>[] navigationProperties)
        {
            return (TbSmsverification)await GetList(where, navigationProperties).FirstOrDefaultAsync();
        }

        public void AddSmsVerification(TbSmsverification smsVerifData)
        {
            Add(smsVerifData);
        }


        public bool SendSmsChangePassword(string MobileNumber, string smsCode)
        {

            string MsgText = "رمز التحقق الخاص بتغير كلمة السر على تطبيق طوارى شركة الكهرباء الاردنية هو:  " + smsCode;
            ZainReference.ZainApiClient client = new ZainReference.ZainApiClient(ZainReference.ZainApiClient.EndpointConfiguration.BasicHttpBinding_IZainApi   );
            Task<bool> sended =  client.SendSMSAsync(MobileNumber, MsgText);
            if (sended.Result == true)
            {
                client.CloseAsync();
                return true;
            }
            else
            {
                client.CloseAsync();
                return false;
            }
            //client.SendSMSAsync(MobileNumber, MsgText);
           // Thread.Sleep(2000);
            
            
        }

        public void UpdateSmsVerification(string[] excludedProperties, params TbSmsverification[] smsVerifData)
        {
            Update(excludedProperties, smsVerifData);
        }


    }
}
