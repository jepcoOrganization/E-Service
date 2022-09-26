using JepcoBackEndSystemProject.Models.Models;
using JepcoBackEndSysytemProject.LoggerService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JepcoBackEndSystemProject.Data.EngineersAccessRegister
{
    //internal class EngineersAccessRegisterRepository
    //{
    //}
    public class EngineersAccessRegisterRepository : RepositoryBase<tb_EngineersAccessRegister>, IEngineersAccessRegisterRepository
    {
        public EngineersAccessRegisterRepository(DBJEPCOBackEndContext repositoryContext, ILoggerManager logger)
            : base(repositoryContext, logger)
        {
        }


        #region GetData
        public async Task<IEnumerable<tb_EngineersAccessRegister>> GetAllEngineersAccessRegister(params Expression<Func<tb_EngineersAccessRegister, object>>[] navigationProperties)
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
        public async Task<IEnumerable<tb_EngineersAccessRegister>> GetListOfEngineersAccessRegister(Expression<Func<tb_EngineersAccessRegister, bool>> where, params Expression<Func<tb_EngineersAccessRegister, object>>[] navigationProperties)
        {
            return await GetList(where, navigationProperties).ToListAsync();
        }
        public async Task<tb_EngineersAccessRegister> GetSingleEngineersAccessRegister(Expression<Func<tb_EngineersAccessRegister, bool>> where, params Expression<Func<tb_EngineersAccessRegister, object>>[] navigationProperties)
        {
            return (tb_EngineersAccessRegister)await GetList(where, navigationProperties).FirstOrDefaultAsync();
        }
        #endregion

        #region Add UserAccessRegister
        /// <summary>
        /// Add City items.
        /// </summary>
        /// <param name="UserAccessRegister">The UserAccessRegister.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void AddEngineersAccessRegister(params tb_EngineersAccessRegister[] EngineersAccessRegister)
        {
            Add(EngineersAccessRegister);
        }
        #endregion

        #region Edit UserAccessRegister
        ///// <summary>
        ///// Updates City items.
        ///// </summary>
        ///// <param name="UserAccessRegister">The UserAccessRegister.</param>
        ///// <exception cref="System.NotImplementedException"></exception>
        public void UpdateEngineersAccessRegister(string[] excludedProperties, params tb_EngineersAccessRegister[] EngineersAccessRegister)
        {
            Update(excludedProperties, EngineersAccessRegister);
        }
        #endregion

        #region Remove UserAccessRegister
        /// <summary>
        /// Removes City items.
        /// </summary>
        /// <param name="UserAccessRegister">The UserAccessRegister.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void RemoveEngineersAccessRegister(params tb_EngineersAccessRegister[] EngineersAccessRegister)
        {
            Remove(EngineersAccessRegister);
        }
        #endregion

    }
}
