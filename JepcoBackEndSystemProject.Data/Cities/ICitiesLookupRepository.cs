using JepcoBackEndSystemProject.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace JepcoBackEndSystemProject.Data.Cities
{
   public interface ICitiesLookupRepository: IRepositoryBase<TbCitiesLookup>
    {

        Task<IEnumerable<TbCitiesLookup>> GetAllCities(params Expression<Func<TbCitiesLookup, object>>[] navigationProperties);

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>List of type T.</returns>
        Task<IEnumerable<TbCitiesLookup>> GetListOfCities(Expression<Func<TbCitiesLookup, bool>> where, params Expression<Func<TbCitiesLookup, object>>[] navigationProperties);

        /// <summary>
        /// Gets the single.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>Generic of type T.</returns>
        Task<TbCitiesLookup> GetSingleCity(Expression<Func<TbCitiesLookup, bool>> where, params Expression<Func<TbCitiesLookup, object>>[] navigationProperties);
        /// <summary>
        /// Adds City items.
        /// </summary>
        /// <param name="cities">The cities.</param>
        void AddCities(params TbCitiesLookup[] cities);

        /// <summary>
        /// Updates City items.
        /// </summary>
        /// <param name="cities">The cities.</param>
        void UpdateCities(string[] excludedProperties, params TbCitiesLookup[] cities);

        ///// <summary>
        ///// Removes City items.
        ///// </summary>
        ///// <param name="cities">The cities.</param>
        void RemoveCities(params TbCitiesLookup[] cities);
    }
}
