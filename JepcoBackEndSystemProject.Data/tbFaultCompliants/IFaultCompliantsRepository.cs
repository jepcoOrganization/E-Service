using JepcoBackEndSystemProject.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace JepcoBackEndSystemProject.Data.FaultCompliants
{
    public interface IFaultCompliantsLookupRepository : IRepositoryBase<tb_Fault_Compliants>
    {

        Task<IEnumerable<tb_Fault_Compliants>> GetAllFaultCompliants(params Expression<Func<tb_Fault_Compliants, object>>[] navigationProperties);

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>List of type T.</returns>
        Task<IEnumerable<tb_Fault_Compliants>> GetListOfFaultCompliants(Expression<Func<tb_Fault_Compliants, bool>> where, params Expression<Func<tb_Fault_Compliants, object>>[] navigationProperties);

        /// <summary>
        /// Gets the single.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>Generic of type T.</returns>
        Task<tb_Fault_Compliants> GetSingleFaultCompliant(Expression<Func<tb_Fault_Compliants, bool>> where, params Expression<Func<tb_Fault_Compliants, object>>[] navigationProperties);
        /// <summary>
        /// Adds City items.
        /// </summary>
        /// <param name="FaultCompliants">The FaultCompliants.</param>
        void AddFaultCompliants(params tb_Fault_Compliants[] FaultCompliants);

        /// <summary>
        /// Updates City items.
        /// </summary>
        /// <param name="FaultCompliants">The FaultCompliants.</param>
        void UpdateFaultCompliants(string[] excludedProperties, params tb_Fault_Compliants[] FaultCompliants);

        ///// <summary>
        ///// Removes City items.
        ///// </summary>
        ///// <param name="FaultCompliants">The FaultCompliants.</param>
        void RemoveFaultCompliants(params tb_Fault_Compliants[] FaultCompliants);
    }
}
