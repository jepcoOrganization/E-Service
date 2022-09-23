using JepcoBackEndSystemProject.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JepcoBackEndSystemProject.Data.ElectricalFaultStatus
{
    //internal interface IElectricalFaultStatusRepository
    //{
    //}

    public interface IElectricalFaultStatusRepository : IRepositoryBase<tb_ElectricalFaultStatus>
    {

        Task<IEnumerable<tb_ElectricalFaultStatus>> GetAllElectricalFaultStatus(params Expression<Func<tb_ElectricalFaultStatus, object>>[] navigationProperties);

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>List of type T.</returns>
        Task<IEnumerable<tb_ElectricalFaultStatus>> GetListOfElectricalFaultStatus(Expression<Func<tb_ElectricalFaultStatus, bool>> where, params Expression<Func<tb_ElectricalFaultStatus, object>>[] navigationProperties);

        /// <summary>
        /// Gets the single.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>Generic of type T.</returns>
        Task<tb_ElectricalFaultStatus> GetSingleElectricalFaultStatus(Expression<Func<tb_ElectricalFaultStatus, bool>> where, params Expression<Func<tb_ElectricalFaultStatus, object>>[] navigationProperties);
        /// <summary>
        /// Adds City items.
        /// </summary>
        /// <param name="cities">The cities.</param>
        void AddElectricalFaultStatus(params tb_ElectricalFaultStatus[] ElectricalFaultStatus);

        /// <summary>
        /// Updates City items.
        /// </summary>
        /// <param name="cities">The cities.</param>
        void UpdateElectricalFaultStatus(string[] excludedProperties, params tb_ElectricalFaultStatus[] ElectricalFaultStatus);

        ///// <summary>
        ///// Removes City items.
        ///// </summary>
        ///// <param name="cities">The cities.</param>
        void RemoveElectricalFaultStatus(params tb_ElectricalFaultStatus[] ElectricalFaultStatus);
    }
}
