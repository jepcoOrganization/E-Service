using JepcoBackEndSystemProject.Data.CommonReturn;
using JepcoBackEndSystemProject.Models.Models;
using JepcoBackEndSysytemProject.LoggerService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JepcoBackEndSystemProject.Data.UserAccessRegister
{
    public class UserAccessRegisterLookupRepository : RepositoryBase<tb_UserAccessRegister>, IUserAccessRegisterLookupRepository
    {
        public UserAccessRegisterLookupRepository(DBJEPCOBackEndContext repositoryContext, ILoggerManager logger)
            : base(repositoryContext, logger)
        {
        }


        #region GetData
        public async Task<IEnumerable<tb_UserAccessRegister>> GetAllUserAccessRegister(params Expression<Func<tb_UserAccessRegister, object>>[] navigationProperties)
        {
            try
            {
                return await GetAll(navigationProperties).ToListAsync();
            }
            catch (Exception)
            {
                throw;

            }

        }
        public async Task<IEnumerable<tb_UserAccessRegister>> GetListOfUserAccessRegister(Expression<Func<tb_UserAccessRegister, bool>> where, params Expression<Func<tb_UserAccessRegister, object>>[] navigationProperties)
        {
            return await GetList(where, navigationProperties).ToListAsync();
        }
        public async Task<tb_UserAccessRegister> GetSingleUserAccessRegister(Expression<Func<tb_UserAccessRegister, bool>> where, params Expression<Func<tb_UserAccessRegister, object>>[] navigationProperties)
        {
            return (tb_UserAccessRegister)await GetList(where, navigationProperties).FirstOrDefaultAsync();
        }
        #endregion

        #region Add UserAccessRegister
        /// <summary>
        /// Add City items.
        /// </summary>
        /// <param name="UserAccessRegister">The UserAccessRegister.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void AddUserAccessRegister(params tb_UserAccessRegister[] UserAccessRegister)
        {
            Add(UserAccessRegister);
        }
        #endregion

        #region Edit UserAccessRegister
        ///// <summary>
        ///// Updates City items.
        ///// </summary>
        ///// <param name="UserAccessRegister">The UserAccessRegister.</param>
        ///// <exception cref="System.NotImplementedException"></exception>
        public void UpdateUserAccessRegister(string[] excludedProperties, params tb_UserAccessRegister[] UserAccessRegister)
        {
            Update(excludedProperties, UserAccessRegister);
        }
        #endregion

        #region Remove UserAccessRegister
        /// <summary>
        /// Removes City items.
        /// </summary>
        /// <param name="UserAccessRegister">The UserAccessRegister.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void RemoveUserAccessRegister(params tb_UserAccessRegister[] UserAccessRegister)
        {
            Remove(UserAccessRegister);
        }
        #endregion

    }
}
