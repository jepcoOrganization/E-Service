using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using JepcoBackEndSystemProject.Models.Models;

namespace JepcoBackEndSystemProject.Data.Smsverifications
{
  public  interface ISmsverificationRepository : IRepositoryBase<TbSmsverification>
    { /// <summary>
      /// Get single record from Sms Verification table.
      /// </summary>
      /// <param name="where">The where.</param>
      /// <param name="navigationProperties">The navigation properties.</param>
      /// <returns>Generic of type T.</returns>
        Task<TbSmsverification> GetSingleSmsVerif(Expression<Func<TbSmsverification, bool>> where, params Expression<Func<TbSmsverification, object>>[] navigationProperties);

        /// <summary>
        /// Adds Sms Verification record in SMs Verification Table.
        /// </summary>
        /// <param name="smsVerifData">The branch.</param>
        void AddSmsVerification(TbSmsverification smsVerifData);

        /// <summary>
        /// Send Sms Code To Customer.
        /// </summary>
        /// <param name="MobileNumber">The mobile number.</param>
        /// <param name="smsCode">The Sms Code.</param>
        bool SendSmsChangePassword(String MobileNumber, String smsCode);

        /// <summary>
        /// Updates SMS Verification items.
        /// </summary>
        /// <param name="smsVerifData">The Sms Verifcation properties.</param>
        void UpdateSmsVerification(string[] excludedProperties, params TbSmsverification[] smsVerifData);

    }
}
