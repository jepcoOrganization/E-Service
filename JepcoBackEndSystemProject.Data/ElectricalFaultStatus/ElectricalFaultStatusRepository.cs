using JepcoBackEndSystemProject.Models.Models;
using JepcoBackEndSysytemProject.LoggerService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JepcoBackEndSystemProject.Data.ElectricalFaultStatus
{
    //internal class ElectricalFaultStatusRepository
    //{
    //}
    public class ElectricalFaultStatusRepository : RepositoryBase<tb_ElectricalFaultStatus>, IElectricalFaultStatusRepository
    {
        public ElectricalFaultStatusRepository(DBJEPCOBackEndContext repositoryContext, ILoggerManager logger)
            : base(repositoryContext, logger)
        {
        }
        #region GetData
        public async Task<IEnumerable<tb_ElectricalFaultStatus>> GetAllElectricalFaultStatus(params Expression<Func<tb_ElectricalFaultStatus, object>>[] navigationProperties)
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
        public async Task<IEnumerable<tb_ElectricalFaultStatus>> GetListOfElectricalFaultStatus(Expression<Func<tb_ElectricalFaultStatus, bool>> where, params Expression<Func<tb_ElectricalFaultStatus, object>>[] navigationProperties)
        {
            return await GetList(where, navigationProperties).ToListAsync();
        }
        public async Task<tb_ElectricalFaultStatus> GetSingleElectricalFaultStatus(Expression<Func<tb_ElectricalFaultStatus, bool>> where, params Expression<Func<tb_ElectricalFaultStatus, object>>[] navigationProperties)
        {
            return (tb_ElectricalFaultStatus)await GetList(where, navigationProperties).FirstOrDefaultAsync();
        }
        #endregion

        #region Add Branch
        /// <summary>
        /// Add Branch items.
        /// </summary>
        /// <param name="branch">The branch.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void AddElectricalFaultStatus(params tb_ElectricalFaultStatus[] ElectricalFaultStatus)
        {
            Add(ElectricalFaultStatus);
        }
        #endregion

        #region Edit Branch
        ///// <summary>
        ///// Updates Branch items.
        ///// </summary>
        ///// <param name="branch">The branch.</param>
        ///// <exception cref="System.NotImplementedException"></exception>
        public void UpdateElectricalFaultStatus(string[] excludedProperties, params tb_ElectricalFaultStatus[] ElectricalFaultStatus)
        {
            Update(excludedProperties, ElectricalFaultStatus);
        }
        #endregion

        #region Remove Branch
        /// <summary>
        /// Removes Branch items.
        /// </summary>
        /// <param name="branch">The branch.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void RemoveElectricalFaultStatus(params tb_ElectricalFaultStatus[] ElectricalFaultStatus)
        {
            Remove(ElectricalFaultStatus);
        }
        #endregion

    }
}
