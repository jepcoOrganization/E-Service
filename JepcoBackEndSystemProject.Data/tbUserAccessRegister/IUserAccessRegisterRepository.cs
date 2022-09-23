using JepcoBackEndSystemProject.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace JepcoBackEndSystemProject.Data.UserAccessRegister
{
    public interface IUserAccessRegisterLookupRepository : IRepositoryBase<tb_UserAccessRegister>
    {

        Task<IEnumerable<tb_UserAccessRegister>> GetAllUserAccessRegister(params Expression<Func<tb_UserAccessRegister, object>>[] navigationProperties);

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>List of type T.</returns>
        Task<IEnumerable<tb_UserAccessRegister>> GetListOfUserAccessRegister(Expression<Func<tb_UserAccessRegister, bool>> where, params Expression<Func<tb_UserAccessRegister, object>>[] navigationProperties);

        /// <summary>
        /// Gets the single.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>Generic of type T.</returns>
        Task<tb_UserAccessRegister> GetSingleUserAccessRegister(Expression<Func<tb_UserAccessRegister, bool>> where, params Expression<Func<tb_UserAccessRegister, object>>[] navigationProperties);
        /// <summary>
        /// Adds City items.
        /// </summary>
        /// <param name="UserAccessRegister">The UserAccessRegister.</param>
        void AddUserAccessRegister(params tb_UserAccessRegister[] UserAccessRegister);

        /// <summary>
        /// Updates City items.
        /// </summary>
        /// <param name="UserAccessRegister">The UserAccessRegister.</param>
        void UpdateUserAccessRegister(string[] excludedProperties, params tb_UserAccessRegister[] UserAccessRegister);

        ///// <summary>
        ///// Removes City items.
        ///// </summary>
        ///// <param name="UserAccessRegister">The UserAccessRegister.</param>
        void RemoveUserAccessRegister(params tb_UserAccessRegister[] UserAccessRegister);
    }
}
