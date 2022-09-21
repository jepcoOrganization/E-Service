using JepcoBackEndSystemProject.Data.CommonReturn;
using JepcoBackEndSystemProject.Models.Models;
using JepcoBackEndSysytemProject.LoggerService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JepcoBackEndSystemProject.Data.Cities
{
   public class CitiesLookupRepository: RepositoryBase<TbCitiesLookup>, ICitiesLookupRepository
    {
        public CitiesLookupRepository(DBJEPCOBackEndContext repositoryContext, ILoggerManager logger )
            : base(repositoryContext, logger)
        {
        }


        #region GetData
        public async Task<IEnumerable<TbCitiesLookup>> GetAllCities(params Expression<Func<TbCitiesLookup, object>>[] navigationProperties)
        {
            try
            {
                return await GetAll(navigationProperties).ToListAsync();
            }
            catch (Exception )
            {
                throw;

            }

        }
        public async Task<IEnumerable<TbCitiesLookup>> GetListOfCities(Expression<Func<TbCitiesLookup, bool>> where, params Expression<Func<TbCitiesLookup, object>>[] navigationProperties)
        {
            return await GetList(where, navigationProperties).ToListAsync();
        }
        public async Task<TbCitiesLookup> GetSingleCity(Expression<Func<TbCitiesLookup, bool>> where, params Expression<Func<TbCitiesLookup, object>>[] navigationProperties)
        {
            return (TbCitiesLookup)await GetList(where, navigationProperties).FirstOrDefaultAsync();
        }
        #endregion

        #region Add Cities
        /// <summary>
        /// Add City items.
        /// </summary>
        /// <param name="cities">The cities.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void AddCities(params TbCitiesLookup[] cities)
        {
            Add(cities);
        }
        #endregion

        #region Edit Cities
        ///// <summary>
        ///// Updates City items.
        ///// </summary>
        ///// <param name="cities">The cities.</param>
        ///// <exception cref="System.NotImplementedException"></exception>
        public void UpdateCities(string[] excludedProperties, params TbCitiesLookup[] cities)
        {
            Update(excludedProperties, cities);
        }
        #endregion

        #region Remove Cities
        /// <summary>
        /// Removes City items.
        /// </summary>
        /// <param name="cities">The cities.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void RemoveCities(params TbCitiesLookup[] cities)
        {
            Remove(cities);
        }
        #endregion

    }
}
