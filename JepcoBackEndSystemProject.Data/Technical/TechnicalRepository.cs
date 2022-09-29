using JepcoBackEndSystemProject.Models.Models;
using JepcoBackEndSysytemProject.LoggerService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JepcoBackEndSystemProject.Data.Technical
{
    //internal class TechnicalRepository
    //{
    //}
    public class TechnicalRepository : RepositoryBase<tb_Technical>, ITechnicalRepository
    {
        public TechnicalRepository(DBJEPCOBackEndContext repositoryContext, ILoggerManager logger)
            : base(repositoryContext, logger)
        {
        }


        #region GetData
        public async Task<IEnumerable<tb_Technical>> GetAllTechnical(params Expression<Func<tb_Technical, object>>[] navigationProperties)
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
        public async Task<IEnumerable<tb_Technical>> GetListOfTechnical(Expression<Func<tb_Technical, bool>> where, params Expression<Func<tb_Technical, object>>[] navigationProperties)
        {
            return await GetList(where, navigationProperties).ToListAsync();
        }
        public async Task<tb_Technical> GetSingleTechnical(Expression<Func<tb_Technical, bool>> where, params Expression<Func<tb_Technical, object>>[] navigationProperties)
        {
            return (tb_Technical)await GetList(where, navigationProperties).FirstOrDefaultAsync();
        }

        #endregion

        #region Add UserAccessRegister
        /// <summary>
        /// Add City items.
        /// </summary>
        /// <param name="UserAccessRegister">The UserAccessRegister.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void AddTechnical(params tb_Technical[] Technical)
        {
            Add(Technical);
        }
        #endregion

        #region Edit UserAccessRegister
        ///// <summary>
        ///// Updates City items.
        ///// </summary>
        ///// <param name="UserAccessRegister">The UserAccessRegister.</param>
        ///// <exception cref="System.NotImplementedException"></exception>
        public void UpdateTechnical(string[] excludedProperties, params tb_Technical[] Technical)
        {
            Update(excludedProperties, Technical);
        }
        #endregion

        #region Remove UserAccessRegister
        /// <summary>
        /// Removes City items.
        /// </summary>
        /// <param name="UserAccessRegister">The UserAccessRegister.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void RemoveTechnical(params tb_Technical[] Technical)
        {
            Remove(Technical);
        }
        #endregion

    }
}
