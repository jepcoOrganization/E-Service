using JepcoBackEndSystemProject.Models.Models;
using JepcoBackEndSysytemProject.LoggerService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JepcoBackEndSystemProject.Data.TechnicalGroups
{
    //internal class TechnicalGroupsRepository
    //{
    //}
    public class TechnicalRepository : RepositoryBase<tb_TechnicalGroups>, ITechnicalGroupsRepository
    {
        public TechnicalRepository(DBJEPCOBackEndContext repositoryContext, ILoggerManager logger)
            : base(repositoryContext, logger)
        {
        }


        #region GetData
        public async Task<IEnumerable<tb_TechnicalGroups>> GetAllTechnicalGroups(params Expression<Func<tb_TechnicalGroups, object>>[] navigationProperties)
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
        public async Task<IEnumerable<tb_TechnicalGroups>> GetListOfTechnicalGroups(Expression<Func<tb_TechnicalGroups, bool>> where, params Expression<Func<tb_TechnicalGroups, object>>[] navigationProperties)
        {
            return await GetList(where, navigationProperties).ToListAsync();
        }
        public async Task<tb_TechnicalGroups> GetSingleTechnicalGroups(Expression<Func<tb_TechnicalGroups, bool>> where, params Expression<Func<tb_TechnicalGroups, object>>[] navigationProperties)
        {
            return (tb_TechnicalGroups)await GetList(where, navigationProperties).FirstOrDefaultAsync();
        }

        #endregion

        #region Add UserAccessRegister
        /// <summary>
        /// Add City items.
        /// </summary>
        /// <param name="UserAccessRegister">The UserAccessRegister.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void AddTechnicalGroups(params tb_TechnicalGroups[] TechnicalGroups)
        {
            Add(TechnicalGroups);
        }
        #endregion

        #region Edit UserAccessRegister
        ///// <summary>
        ///// Updates City items.
        ///// </summary>
        ///// <param name="UserAccessRegister">The UserAccessRegister.</param>
        ///// <exception cref="System.NotImplementedException"></exception>
        public void UpdateTechnicalGroups(string[] excludedProperties, params tb_TechnicalGroups[] TechnicalGroups)
        {
            Update(excludedProperties, TechnicalGroups);
        }
        #endregion

        #region Remove UserAccessRegister
        /// <summary>
        /// Removes City items.
        /// </summary>
        /// <param name="UserAccessRegister">The UserAccessRegister.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void RemoveTechnicalGroups(params tb_TechnicalGroups[] TechnicalGroups)
        {
            Remove(TechnicalGroups);
        }
        #endregion
    }
}
