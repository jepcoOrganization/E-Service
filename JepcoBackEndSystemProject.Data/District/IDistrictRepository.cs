using JepcoBackEndSystemProject.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JepcoBackEndSystemProject.Data.District
{
    //internal interface IDistrictRepository
    //{
    //}

    public interface IDistrictRepository : IRepositoryBase<tb_District>
    {

        Task<IEnumerable<tb_District>> GetAllDistrict(params Expression<Func<tb_District, object>>[] navigationProperties);

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>List of type T.</returns>
        Task<IEnumerable<tb_District>> GetListOfDistrict(Expression<Func<tb_District, bool>> where, params Expression<Func<tb_District, object>>[] navigationProperties);

        /// <summary>
        /// Gets the single.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>Generic of type T.</returns>
        Task<tb_District> GetSingleDistrict(Expression<Func<tb_District, bool>> where, params Expression<Func<tb_District, object>>[] navigationProperties);
        /// <summary>
        /// Adds City items.
        /// </summary>
        /// <param name="cities">The cities.</param>
        void AddDistrict(params tb_District[] District);

        /// <summary>
        /// Updates City items.
        /// </summary>
        /// <param name="cities">The cities.</param>
        void UpdateDistrict(string[] excludedProperties, params tb_District[] District);

        ///// <summary>
        ///// Removes City items.
        ///// </summary>
        ///// <param name="cities">The cities.</param>
        void RemoveDistrict(params tb_District[] District);
    }
}
