using JepcoBackEndSystemProject.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JepcoBackEndSystemProject.Data.Governate
{
    //    internal interface IGovernateRepository
    //    {
    //    }
    public interface IGovernateRepository : IRepositoryBase<tb_Governate>
    {

        Task<IEnumerable<tb_Governate>> GetAllGovernate(params Expression<Func<tb_Governate, object>>[] navigationProperties);

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>List of type T.</returns>
        Task<IEnumerable<tb_Governate>> GetListOfGovernate(Expression<Func<tb_Governate, bool>> where, params Expression<Func<tb_Governate, object>>[] navigationProperties);

        /// <summary>
        /// Gets the single.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>Generic of type T.</returns>
        Task<tb_Governate> GetSingleGovernate(Expression<Func<tb_Governate, bool>> where, params Expression<Func<tb_Governate, object>>[] navigationProperties);
        /// <summary>
        /// Adds City items.
        /// </summary>
        /// <param name="cities">The cities.</param>
        void AddGovernate(params tb_Governate[] Governate);

        /// <summary>
        /// Updates City items.
        /// </summary>
        /// <param name="cities">The cities.</param>
        void UpdateGovernate(string[] excludedProperties, params tb_Governate[] Governate);

        ///// <summary>
        ///// Removes City items.
        ///// </summary>
        ///// <param name="cities">The cities.</param>
        void RemoveGovernate(params tb_Governate[] District);
    }
}
