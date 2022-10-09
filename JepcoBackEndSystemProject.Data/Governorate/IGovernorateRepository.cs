using JepcoBackEndSystemProject.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JepcoBackEndSystemProject.Data.Governorate
{
    //internal interface IGovernorateRepository
    //{
    //}
    public interface IGovernorateRepository : IRepositoryBase<tb_Governorate>
    {

        Task<IEnumerable<tb_Governorate>> GetAllGovernorate(params Expression<Func<tb_Governorate, object>>[] navigationProperties);

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>List of type T.</returns>
        Task<IEnumerable<tb_Governorate>> GetListOfGovernorate(Expression<Func<tb_Governorate, bool>> where, params Expression<Func<tb_Governorate, object>>[] navigationProperties);

        /// <summary>
        /// Gets the single.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>Generic of type T.</returns>
        Task<tb_Governorate> GetSingleGovernorate(Expression<Func<tb_Governorate, bool>> where, params Expression<Func<tb_Governorate, object>>[] navigationProperties);
        /// <summary>
        /// Adds City items.
        /// </summary>
        /// <param name="cities">The cities.</param>
        void AddGovernorate(params tb_Governorate[] FaultDetails);

        /// <summary>
        /// Updates City items.
        /// </summary>
        /// <param name="cities">The cities.</param>
        void UpdateGovernorate(string[] excludedProperties, params tb_Governorate[] Governorate);

        ///// <summary>
        ///// Removes City items.
        ///// </summary>
        ///// <param name="cities">The cities.</param>
        void RemoveGovernorate(params tb_Governorate[] Governorate);
    }
}
