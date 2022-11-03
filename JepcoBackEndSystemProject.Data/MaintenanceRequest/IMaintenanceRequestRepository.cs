using JepcoBackEndSystemProject.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JepcoBackEndSystemProject.Data.MaintenanceRequest
{
    //internal interface IMaintenanceRequestRepository
    //{
    //}
    public interface IMaintenanceRequestRepository : IRepositoryBase<tb_MaintenanceRequest>
    {

        Task<IEnumerable<tb_MaintenanceRequest>> GetAllMaintenanceRequest(params Expression<Func<tb_MaintenanceRequest, object>>[] navigationProperties);

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>List of type T.</returns>
        Task<IEnumerable<tb_MaintenanceRequest>> GetListOfMaintenanceRequest(Expression<Func<tb_MaintenanceRequest, bool>> where, params Expression<Func<tb_MaintenanceRequest, object>>[] navigationProperties);

        /// <summary>
        /// Gets the single.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>Generic of type T.</returns>
        Task<tb_MaintenanceRequest> GetSingleMaintenanceRequest(Expression<Func<tb_MaintenanceRequest, bool>> where, params Expression<Func<tb_MaintenanceRequest, object>>[] navigationProperties);
        /// <summary>
        /// Adds City items.
        /// </summary>
        /// <param name="cities">The cities.</param>
        void AddMaintenanceRequest(params tb_MaintenanceRequest[] MaintenanceRequest);

        /// <summary>
        /// Updates City items.
        /// </summary>
        /// <param name="cities">The cities.</param>
        void UpdateMaintenanceRequest(string[] excludedProperties, params tb_MaintenanceRequest[] MaintenanceRequest);

        ///// <summary>
        ///// Removes City items.
        ///// </summary>
        ///// <param name="cities">The cities.</param>
        void RemoveMaintenanceRequest(params tb_MaintenanceRequest[] MaintenanceRequest);
    }
}
