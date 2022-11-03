using JepcoBackEndSystemProject.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JepcoBackEndSystemProject.Data.MaintenanceRequestType
{
    //internal interface IMaintenanceRequestTypeRepository
    //{
    //}
    public interface IMaintenanceRequestTypeRepository : IRepositoryBase<tb_MaintenanceRequestType>
    {

        Task<IEnumerable<tb_MaintenanceRequestType>> GetAllMaintenanceRequestType(params Expression<Func<tb_MaintenanceRequestType, object>>[] navigationProperties);

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>List of type T.</returns>
        Task<IEnumerable<tb_MaintenanceRequestType>> GetListOfMaintenanceRequestType(Expression<Func<tb_MaintenanceRequestType, bool>> where, params Expression<Func<tb_MaintenanceRequestType, object>>[] navigationProperties);

        /// <summary>
        /// Gets the single.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>Generic of type T.</returns>
        Task<tb_MaintenanceRequestType> GetSingleMaintenanceRequestType(Expression<Func<tb_MaintenanceRequestType, bool>> where, params Expression<Func<tb_MaintenanceRequestType, object>>[] navigationProperties);
        /// <summary>
        /// Adds City items.
        /// </summary>
        /// <param name="cities">The cities.</param>
        void AddMaintenanceRequestType(params tb_MaintenanceRequestType[] MaintenanceRequestType);

        /// <summary>
        /// Updates City items.
        /// </summary>
        /// <param name="cities">The cities.</param>
        void UpdateMaintenanceRequestType(string[] excludedProperties, params tb_MaintenanceRequestType[] MaintenanceRequestType);

        ///// <summary>
        ///// Removes City items.
        ///// </summary>
        ///// <param name="cities">The cities.</param>
        void RemoveMaintenanceRequestType(params tb_MaintenanceRequestType[] MaintenanceRequestType);
    }
}
