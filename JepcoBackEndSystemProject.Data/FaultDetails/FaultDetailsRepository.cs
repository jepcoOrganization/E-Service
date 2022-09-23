using JepcoBackEndSystemProject.Models.Models;
using JepcoBackEndSysytemProject.LoggerService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JepcoBackEndSystemProject.Data.FaultDetails
{
    //internal class FaultDetailsRepository
    //{
    //}

    public class FaultDetailsRepository : RepositoryBase<tb_FaultDetails>, IFaultDetailsRepository
    {
        public FaultDetailsRepository(DBJEPCOBackEndContext repositoryContext, ILoggerManager logger)
            : base(repositoryContext, logger)
        {
        }
        #region GetData
        public async Task<IEnumerable<tb_FaultDetails>> GetAllFaultDetails(params Expression<Func<tb_FaultDetails, object>>[] navigationProperties)
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
        public async Task<IEnumerable<tb_FaultDetails>> GetListOfFaultDetails(Expression<Func<tb_FaultDetails, bool>> where, params Expression<Func<tb_FaultDetails, object>>[] navigationProperties)
        {
            return await GetList(where, navigationProperties).ToListAsync();
        }
        public async Task<tb_FaultDetails> GetSingleFaultDetails(Expression<Func<tb_FaultDetails, bool>> where, params Expression<Func<tb_FaultDetails, object>>[] navigationProperties)
        {
            return (tb_FaultDetails)await GetList(where, navigationProperties).FirstOrDefaultAsync();
        }
        #endregion

        #region Add Branch
        /// <summary>
        /// Add Branch items.
        /// </summary>
        /// <param name="branch">The branch.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void AddFaultDetails(params tb_FaultDetails[] FaultDetails)
        {
            Add(FaultDetails);
        }
        #endregion

        #region Edit Branch
        ///// <summary>
        ///// Updates Branch items.
        ///// </summary>
        ///// <param name="branch">The branch.</param>
        ///// <exception cref="System.NotImplementedException"></exception>
        public void UpdateFaultDetails(string[] excludedProperties, params tb_FaultDetails[] FaultDetails)
        {
            Update(excludedProperties, FaultDetails);
        }
        #endregion

        #region Remove Branch
        /// <summary>
        /// Removes Branch items.
        /// </summary>
        /// <param name="branch">The branch.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void RemoveFaultDetails(params tb_FaultDetails[] FaultDetails)
        {
            Remove(FaultDetails);
        }
        #endregion

    }
}

