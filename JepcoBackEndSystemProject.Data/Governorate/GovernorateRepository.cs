using JepcoBackEndSystemProject.Models.Models;
using JepcoBackEndSysytemProject.LoggerService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JepcoBackEndSystemProject.Data.Governorate
{
    //internal class GovernorateRepository
    //{
    //}
    public class GovernorateRepository : RepositoryBase<tb_Governorate>, IGovernorateRepository
    {
        public GovernorateRepository(DBJEPCOBackEndContext repositoryContext, ILoggerManager logger)
            : base(repositoryContext, logger)
        {
        }
        #region GetData
        public async Task<IEnumerable<tb_Governorate>> GetAllGovernorate(params Expression<Func<tb_Governorate, object>>[] navigationProperties)
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
        public async Task<IEnumerable<tb_Governorate>> GetListOfGovernorate(Expression<Func<tb_Governorate, bool>> where, params Expression<Func<tb_Governorate, object>>[] navigationProperties)
        {
            return await GetList(where, navigationProperties).ToListAsync();
        }
        public async Task<tb_Governorate> GetSingleGovernorate(Expression<Func<tb_Governorate, bool>> where, params Expression<Func<tb_Governorate, object>>[] navigationProperties)
        {
            return (tb_Governorate)await GetList(where, navigationProperties).FirstOrDefaultAsync();
        }
        #endregion

        #region Add Branch
        /// <summary>
        /// Add Branch items.
        /// </summary>
        /// <param name="branch">The branch.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void AddGovernorate(params tb_Governorate[] Governorate)
        {
            Add(Governorate);
        }
        #endregion

        #region Edit Branch
        ///// <summary>
        ///// Updates Branch items.
        ///// </summary>
        ///// <param name="branch">The branch.</param>
        ///// <exception cref="System.NotImplementedException"></exception>
        public void UpdateGovernorate(string[] excludedProperties, params tb_Governorate[] Governorate)
        {
            Update(excludedProperties, Governorate);
        }
        #endregion

        #region Remove Branch
        /// <summary>
        /// Removes Branch items.
        /// </summary>
        /// <param name="branch">The branch.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void RemoveGovernorate(params tb_Governorate[] Governorate)
        {
            Remove(Governorate);
        }
        #endregion

    }
}
