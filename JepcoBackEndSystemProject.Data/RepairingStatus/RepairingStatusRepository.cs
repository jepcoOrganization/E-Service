using JepcoBackEndSystemProject.Models.Models;
using JepcoBackEndSysytemProject.LoggerService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JepcoBackEndSystemProject.Data.RepairingStatus
{
    //internal class RepairingStatusRepository
    //{
    //}
    public class RepairingStatusRepository : RepositoryBase<tb_RepairingStatus>, IRepairingStatusRepository
    {
        public RepairingStatusRepository(DBJEPCOBackEndContext repositoryContext, ILoggerManager logger)
            : base(repositoryContext, logger)
        {
        }
           #region GetData
        public async Task<IEnumerable<tb_RepairingStatus>> GetAllStatus(params Expression<Func<tb_RepairingStatus, object>>[] navigationProperties)
        {
            try
            {
                return  await GetAll(navigationProperties).ToListAsync();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return null; 
                
            }
            
        }
        public async Task<IEnumerable<tb_RepairingStatus>> GetListOfStatus(Expression<Func<tb_RepairingStatus, bool>> where, params Expression<Func<tb_RepairingStatus, object>>[] navigationProperties)
        {
            return  await GetList(where, navigationProperties).ToListAsync();
        }
        public async Task<tb_RepairingStatus> GetSingleStatus(Expression<Func<tb_RepairingStatus, bool>> where, params Expression<Func<tb_RepairingStatus, object>>[] navigationProperties)
        {
            return (tb_RepairingStatus)await GetList(where, navigationProperties).FirstOrDefaultAsync();
        }
        #endregion

        #region Add Branch
        /// <summary>
        /// Add Branch items.
        /// </summary>
        /// <param name="branch">The branch.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void AddStatus(params tb_RepairingStatus[] Status)
        {
            Add(Status);
        }
        #endregion

        #region Edit Branch
        ///// <summary>
        ///// Updates Branch items.
        ///// </summary>
        ///// <param name="branch">The branch.</param>
        ///// <exception cref="System.NotImplementedException"></exception>
        public void UpdateStatus(string[] excludedProperties, params tb_RepairingStatus[] Status)
        {
            Update(excludedProperties, Status);
        }
        #endregion

        #region Remove Branch
        /// <summary>
        /// Removes Branch items.
        /// </summary>
        /// <param name="branch">The branch.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void RemoveStatus(params tb_RepairingStatus[] Status)
        {
            Remove(Status);
        }
        #endregion

    }
}