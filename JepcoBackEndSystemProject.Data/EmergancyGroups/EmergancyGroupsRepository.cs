using JepcoBackEndSystemProject.Models.Models;
using JepcoBackEndSysytemProject.LoggerService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JepcoBackEndSystemProject.Data.EmergancyGroups
{
    //internal class EmergancyGroupsRepository
    //{
    //}
    public class EmergancyGroupsRepository : RepositoryBase<tb_EmergancyGroups>, IEmergancyGroupsRepository
    {
        public EmergancyGroupsRepository(DBJEPCOBackEndContext repositoryContext, ILoggerManager logger)
            : base(repositoryContext, logger)
        {
        }
        #region GetData
        public async Task<IEnumerable<tb_EmergancyGroups>> GetAllEmergancyGroups(params Expression<Func<tb_EmergancyGroups, object>>[] navigationProperties)
        {
            try
            {
                return await GetAll(navigationProperties).ToListAsync();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return null;

            }

        }
        public async Task<IEnumerable<tb_EmergancyGroups>> GetListOfEmergancyGroups(Expression<Func<tb_EmergancyGroups, bool>> where, params Expression<Func<tb_EmergancyGroups, object>>[] navigationProperties)
        {
            return await GetList(where, navigationProperties).ToListAsync();
        }
        public async Task<tb_EmergancyGroups> GetSingleEmergancyGroups(Expression<Func<tb_EmergancyGroups, bool>> where, params Expression<Func<tb_EmergancyGroups, object>>[] navigationProperties)
        {
            return (tb_EmergancyGroups)await GetList(where, navigationProperties).FirstOrDefaultAsync();
        }
        #endregion

        #region Add Branch
        /// <summary>
        /// Add Branch items.
        /// </summary>
        /// <param name="branch">The branch.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void AddEmergancyGroups(params tb_EmergancyGroups[] EmergancyGroups)
        {
            Add(EmergancyGroups);
        }
        #endregion

        #region Edit Branch
        ///// <summary>
        ///// Updates Branch items.
        ///// </summary>
        ///// <param name="branch">The branch.</param>
        ///// <exception cref="System.NotImplementedException"></exception>
        public void UpdateEmergancyGroups(string[] excludedProperties, params tb_EmergancyGroups[] EmergancyGroups)
        {
            Update(excludedProperties, EmergancyGroups);
        }
        #endregion

        #region Remove Branch
        /// <summary>
        /// Removes Branch items.
        /// </summary>
        /// <param name="branch">The branch.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void RemoveEmergancyGroups(params tb_EmergancyGroups[] EmergancyGroups)
        {
            Remove(EmergancyGroups);
        }
        #endregion

    }
}
