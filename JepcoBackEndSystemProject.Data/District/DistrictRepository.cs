using JepcoBackEndSystemProject.Models.Models;
using JepcoBackEndSysytemProject.LoggerService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JepcoBackEndSystemProject.Data.District
{
    //internal class DistrictRepository
    //{
    //}
    public class DistrictRepository : RepositoryBase<tb_District>, IDistrictRepository
    {
        public DistrictRepository(DBJEPCOBackEndContext repositoryContext, ILoggerManager logger)
            : base(repositoryContext, logger)
        {
        }
        #region GetData
        public async Task<IEnumerable<tb_District>> GetAllDistrict(params Expression<Func<tb_District, object>>[] navigationProperties)
        {
            try
            {
                return await GetAll(navigationProperties).ToListAsync();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return null;

            }

        }
        public async Task<IEnumerable<tb_District>> GetListOfDistrict(Expression<Func<tb_District, bool>> where, params Expression<Func<tb_District, object>>[] navigationProperties)
        {
            return await GetList(where, navigationProperties).ToListAsync();
        }
        public async Task<tb_District> GetSingleDistrict(Expression<Func<tb_District, bool>> where, params Expression<Func<tb_District, object>>[] navigationProperties)
        {
            return (tb_District)await GetList(where, navigationProperties).FirstOrDefaultAsync();
        }
        #endregion

        #region Add Branch
        /// <summary>
        /// Add Branch items.
        /// </summary>
        /// <param name="branch">The branch.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void AddDistrict(params tb_District[] District)
        {
            Add(District);
        }
        #endregion

        #region Edit Branch
        ///// <summary>
        ///// Updates Branch items.
        ///// </summary>
        ///// <param name="branch">The branch.</param>
        ///// <exception cref="System.NotImplementedException"></exception>
        public void UpdateDistrict(string[] excludedProperties, params tb_District[] District)
        {
            Update(excludedProperties, District);
        }
        #endregion

        #region Remove Branch
        /// <summary>
        /// Removes Branch items.
        /// </summary>
        /// <param name="branch">The branch.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void RemoveDistrict(params tb_District[] District)
        {
            Remove(District);
        }
        #endregion
    }
}
