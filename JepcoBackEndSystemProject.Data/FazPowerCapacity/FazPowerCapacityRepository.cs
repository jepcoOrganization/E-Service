using JepcoBackEndSystemProject.Models.Models;
using JepcoBackEndSysytemProject.LoggerService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JepcoBackEndSystemProject.Data.FazPowerCapacity
{
    //internal class FazPowerCapacityRepository
    //{
    //}

    public class FazPowerCapacityRepository : RepositoryBase<tb_FazPowerCapacity>, IFazPowerCapacityRepository
    {
        public FazPowerCapacityRepository(DBJEPCOBackEndContext repositoryContext, ILoggerManager logger)
            : base(repositoryContext, logger)
        {
        }
        #region GetData
        public async Task<IEnumerable<tb_FazPowerCapacity>> GetAllFazPowerCapacity(params Expression<Func<tb_FazPowerCapacity, object>>[] navigationProperties)
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
        public async Task<IEnumerable<tb_FazPowerCapacity>> GetListOfFazPowerCapacity(Expression<Func<tb_FazPowerCapacity, bool>> where, params Expression<Func<tb_FazPowerCapacity, object>>[] navigationProperties)
        {
            return await GetList(where, navigationProperties).ToListAsync();
        }
        public async Task<tb_FazPowerCapacity> GetSingleFazPowerCapacity(Expression<Func<tb_FazPowerCapacity, bool>> where, params Expression<Func<tb_FazPowerCapacity, object>>[] navigationProperties)
        {
            return (tb_FazPowerCapacity)await GetList(where, navigationProperties).FirstOrDefaultAsync();
        }
        #endregion

        #region Add Branch
        /// <summary>
        /// Add Branch items.
        /// </summary>
        /// <param name="branch">The branch.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void AddFazPowerCapacity(params tb_FazPowerCapacity[] FazPowerCapacity)
        {
            Add(FazPowerCapacity);
        }
        #endregion

        #region Edit Branch
        ///// <summary>
        ///// Updates Branch items.
        ///// </summary>
        ///// <param name="branch">The branch.</param>
        ///// <exception cref="System.NotImplementedException"></exception>
        public void UpdateFazPowerCapacity(string[] excludedProperties, params tb_FazPowerCapacity[] FazPowerCapacity)
        {
            Update(excludedProperties, FazPowerCapacity);
        }
        #endregion

        #region Remove Branch
        /// <summary>
        /// Removes Branch items.
        /// </summary>
        /// <param name="branch">The branch.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void RemoveFazPowerCapacity(params tb_FazPowerCapacity[] FazPowerCapacity)
        {
            Remove(FazPowerCapacity);
        }
        #endregion
    }
}
