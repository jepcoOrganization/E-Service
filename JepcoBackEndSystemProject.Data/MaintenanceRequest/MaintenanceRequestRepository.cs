using JepcoBackEndSystemProject.Models.Models;
using JepcoBackEndSysytemProject.LoggerService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JepcoBackEndSystemProject.Data.MaintenanceRequest
{
    //internal class MaintenanceRequestRepository
    //{
    //}
    public class MaintenanceRequestRepository : RepositoryBase<tb_MaintenanceRequest>, IMaintenanceRequestRepository
    {
        public MaintenanceRequestRepository(DBJEPCOBackEndContext repositoryContext, ILoggerManager logger)
            : base(repositoryContext, logger)
        {
        }
        #region GetData
        public async Task<IEnumerable<tb_MaintenanceRequest>> GetAllMaintenanceRequest(params Expression<Func<tb_MaintenanceRequest, object>>[] navigationProperties)
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
        public async Task<IEnumerable<tb_MaintenanceRequest>> GetListOfMaintenanceRequest(Expression<Func<tb_MaintenanceRequest, bool>> where, params Expression<Func<tb_MaintenanceRequest, object>>[] navigationProperties)
        {
            return await GetList(where, navigationProperties).ToListAsync();
        }
        public async Task<tb_MaintenanceRequest> GetSingleMaintenanceRequest(Expression<Func<tb_MaintenanceRequest, bool>> where, params Expression<Func<tb_MaintenanceRequest, object>>[] navigationProperties)
        {
            return (tb_MaintenanceRequest)await GetList(where, navigationProperties).FirstOrDefaultAsync();
        }
        #endregion

        #region Add Branch
        /// <summary>
        /// Add Branch items.
        /// </summary>
        /// <param name="branch">The branch.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void AddMaintenanceRequest(params tb_MaintenanceRequest[] MaintenanceRequest)
        {
            Add(MaintenanceRequest);
        }
        #endregion

        #region Edit Branch
        ///// <summary>
        ///// Updates Branch items.
        ///// </summary>
        ///// <param name="branch">The branch.</param>
        ///// <exception cref="System.NotImplementedException"></exception>
        public void UpdateMaintenanceRequest(string[] excludedProperties, params tb_MaintenanceRequest[] MaintenanceRequest)
        {
            Update(excludedProperties, MaintenanceRequest);
        }
        #endregion

        #region Remove Branch
        /// <summary>
        /// Removes Branch items.
        /// </summary>
        /// <param name="branch">The branch.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void RemoveMaintenanceRequest(params tb_MaintenanceRequest[] MaintenanceRequest)
        {
            Remove(MaintenanceRequest);
        }
        #endregion
    }
}
