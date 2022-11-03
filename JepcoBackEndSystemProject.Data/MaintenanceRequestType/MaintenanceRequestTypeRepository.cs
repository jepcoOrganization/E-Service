using JepcoBackEndSystemProject.Models.Models;
using JepcoBackEndSysytemProject.LoggerService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JepcoBackEndSystemProject.Data.MaintenanceRequestType
{
    //internal class MaintenanceRequestTypeRepository
    //{
    //}
    public class MaintenanceRequestTypeRepository : RepositoryBase<tb_MaintenanceRequestType>, IMaintenanceRequestTypeRepository
    {
        public MaintenanceRequestTypeRepository(DBJEPCOBackEndContext repositoryContext, ILoggerManager logger)
            : base(repositoryContext, logger)
        {
        }
        #region GetData
        public async Task<IEnumerable<tb_MaintenanceRequestType>> GetAllMaintenanceRequestType(params Expression<Func<tb_MaintenanceRequestType, object>>[] navigationProperties)
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
        public async Task<IEnumerable<tb_MaintenanceRequestType>> GetListOfMaintenanceRequestType(Expression<Func<tb_MaintenanceRequestType, bool>> where, params Expression<Func<tb_MaintenanceRequestType, object>>[] navigationProperties)
        {
            return await GetList(where, navigationProperties).ToListAsync();
        }
        public async Task<tb_MaintenanceRequestType> GetSingleMaintenanceRequestType(Expression<Func<tb_MaintenanceRequestType, bool>> where, params Expression<Func<tb_MaintenanceRequestType, object>>[] navigationProperties)
        {
            return (tb_MaintenanceRequestType)await GetList(where, navigationProperties).FirstOrDefaultAsync();
        }
        #endregion

        #region Add Branch
        /// <summary>
        /// Add Branch items.
        /// </summary>
        /// <param name="branch">The branch.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void AddMaintenanceRequestType(params tb_MaintenanceRequestType[] MaintenanceRequestType)
        {
            Add(MaintenanceRequestType);
        }
        #endregion

        #region Edit Branch
        ///// <summary>
        ///// Updates Branch items.
        ///// </summary>
        ///// <param name="branch">The branch.</param>
        ///// <exception cref="System.NotImplementedException"></exception>
        public void UpdateMaintenanceRequestType(string[] excludedProperties, params tb_MaintenanceRequestType[] MaintenanceRequestType)
        {
            Update(excludedProperties, MaintenanceRequestType);
        }
        #endregion

        #region Remove Branch
        /// <summary>
        /// Removes Branch items.
        /// </summary>
        /// <param name="branch">The branch.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void RemoveMaintenanceRequestType(params tb_MaintenanceRequestType[] MaintenanceRequestType)
        {
            Remove(MaintenanceRequestType);
        }
        #endregion
    }
}
