using JepcoBackEndSystemProject.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JepcoBackEndSystemProject.Data.RepairingStatus
{
    //public interface IRepairingStatusRepository
    //{
    //}
    public interface IRepairingStatusRepository : IRepositoryBase<tb_RepairingStatus>
    {

        Task<IEnumerable<tb_RepairingStatus>> GetAllStatus(params Expression<Func<tb_RepairingStatus, object>>[] navigationProperties);

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>List of type T.</returns>
        Task<IEnumerable<tb_RepairingStatus>> GetListOfStatus(Expression<Func<tb_RepairingStatus, bool>> where, params Expression<Func<tb_RepairingStatus, object>>[] navigationProperties);

        /// <summary>
        /// Gets the single.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>Generic of type T.</returns>
        Task<tb_RepairingStatus> GetSingleStatus(Expression<Func<tb_RepairingStatus, bool>> where, params Expression<Func<tb_RepairingStatus, object>>[] navigationProperties);
        /// <summary>
        /// Adds City items.
        /// </summary>
        /// <param name="cities">The cities.</param>
        void AddStatus(params tb_RepairingStatus[] Status);

        /// <summary>
        /// Updates City items.
        /// </summary>
        /// <param name="cities">The cities.</param>
        void UpdateStatus(string[] excludedProperties, params tb_RepairingStatus[] Status);

        ///// <summary>
        ///// Removes City items.
        ///// </summary>
        ///// <param name="cities">The cities.</param>
        void RemoveStatus(params tb_RepairingStatus[] Status);
    }
}
