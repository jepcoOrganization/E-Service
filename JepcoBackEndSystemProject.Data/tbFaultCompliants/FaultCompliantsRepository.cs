using JepcoBackEndSystemProject.Data.CommonReturn;
using JepcoBackEndSystemProject.Models.Models;
using JepcoBackEndSysytemProject.LoggerService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JepcoBackEndSystemProject.Data.FaultCompliants
{
    public class FaultCompliantsLookupRepository : RepositoryBase<tb_Fault_Compliants>, IFaultCompliantsLookupRepository
    {
        public FaultCompliantsLookupRepository(DBJEPCOBackEndContext repositoryContext, ILoggerManager logger)
            : base(repositoryContext, logger)
        {
        }


        #region GetData
        public async Task<IEnumerable<tb_Fault_Compliants>> GetAllFaultCompliants(params Expression<Func<tb_Fault_Compliants, object>>[] navigationProperties)
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
        public async Task<IEnumerable<tb_Fault_Compliants>> GetListOfFaultCompliants(Expression<Func<tb_Fault_Compliants, bool>> where, params Expression<Func<tb_Fault_Compliants, object>>[] navigationProperties)
        {
            return await GetList(where, navigationProperties).ToListAsync();
        }
        public async Task<tb_Fault_Compliants> GetSingleFaultCompliant(Expression<Func<tb_Fault_Compliants, bool>> where, params Expression<Func<tb_Fault_Compliants, object>>[] navigationProperties)
        {
            return (tb_Fault_Compliants)await GetList(where, navigationProperties).FirstOrDefaultAsync();
        }
        #endregion

        #region Add FaultCompliants
        /// <summary>
        /// Add City items.
        /// </summary>
        /// <param name="FaultCompliants">The FaultCompliants.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void AddFaultCompliants(params tb_Fault_Compliants[] FaultCompliants)
        {
            Add(FaultCompliants);
        }
        #endregion

        #region Edit FaultCompliants
        ///// <summary>
        ///// Updates City items.
        ///// </summary>
        ///// <param name="FaultCompliants">The FaultCompliants.</param>
        ///// <exception cref="System.NotImplementedException"></exception>
        public void UpdateFaultCompliants(string[] excludedProperties, params tb_Fault_Compliants[] FaultCompliants)
        {
            Update(excludedProperties, FaultCompliants);
        }
        #endregion

        #region Remove FaultCompliants
        /// <summary>
        /// Removes City items.
        /// </summary>
        /// <param name="FaultCompliants">The FaultCompliants.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void RemoveFaultCompliants(params tb_Fault_Compliants[] FaultCompliants)
        {
            Remove(FaultCompliants);
        }
        #endregion

    }
}
