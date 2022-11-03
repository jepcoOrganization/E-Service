using JepcoBackEndSystemProject.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JepcoBackEndSystemProject.Data.FazPowerCapacity
{
    //internal interface IFazPowerCapacityRepository
    //{
    //}
    public interface IFazPowerCapacityRepository : IRepositoryBase<tb_FazPowerCapacity>
    {

        Task<IEnumerable<tb_FazPowerCapacity>> GetAllFazPowerCapacity(params Expression<Func<tb_FazPowerCapacity, object>>[] navigationProperties);

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>List of type T.</returns>
        Task<IEnumerable<tb_FazPowerCapacity>> GetListOfFazPowerCapacity(Expression<Func<tb_FazPowerCapacity, bool>> where, params Expression<Func<tb_FazPowerCapacity, object>>[] navigationProperties);

        /// <summary>
        /// Gets the single.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>Generic of type T.</returns>
        Task<tb_FazPowerCapacity> GetSingleFazPowerCapacity(Expression<Func<tb_FazPowerCapacity, bool>> where, params Expression<Func<tb_FazPowerCapacity, object>>[] navigationProperties);
        /// <summary>
        /// Adds City items.
        /// </summary>
        /// <param name="cities">The cities.</param>
        void AddFazPowerCapacity(params tb_FazPowerCapacity[] District);

        /// <summary>
        /// Updates City items.
        /// </summary>
        /// <param name="cities">The cities.</param>
        void UpdateFazPowerCapacity(string[] excludedProperties, params tb_FazPowerCapacity[] District);

        ///// <summary>
        ///// Removes City items.
        ///// </summary>
        ///// <param name="cities">The cities.</param>
        void RemoveFazPowerCapacity(params tb_FazPowerCapacity[] District);
    }
}
