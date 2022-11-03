using JepcoBackEndSystemProject.Models.Models;
using JepcoBackEndSysytemProject.LoggerService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JepcoBackEndSystemProject.Data.Governate
{
    //    internal class GovernateRepository
    //    {
    //    }
    public class GovernateRepository : RepositoryBase<tb_Governate>, IGovernateRepository
    {
        public GovernateRepository(DBJEPCOBackEndContext repositoryContext, ILoggerManager logger)
            : base(repositoryContext, logger)
        {
        }
        #region GetData
        public async Task<IEnumerable<tb_Governate>> GetAllGovernate(params Expression<Func<tb_Governate, object>>[] navigationProperties)
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
        public async Task<IEnumerable<tb_Governate>> GetListOfGovernate(Expression<Func<tb_Governate, bool>> where, params Expression<Func<tb_Governate, object>>[] navigationProperties)
        {
            return await GetList(where, navigationProperties).ToListAsync();
        }
        public async Task<tb_Governate> GetSingleGovernate(Expression<Func<tb_Governate, bool>> where, params Expression<Func<tb_Governate, object>>[] navigationProperties)
        {
            return (tb_Governate)await GetList(where, navigationProperties).FirstOrDefaultAsync();
        }
        #endregion

        #region Add Branch
        /// <summary>
        /// Add Branch items.
        /// </summary>
        /// <param name="branch">The branch.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void AddGovernate(params tb_Governate[] Governate)
        {
            Add(Governate);
        }
        #endregion

        #region Edit Branch
        ///// <summary>
        ///// Updates Branch items.
        ///// </summary>
        ///// <param name="branch">The branch.</param>
        ///// <exception cref="System.NotImplementedException"></exception>
        public void UpdateGovernate(string[] excludedProperties, params tb_Governate[] Governate)
        {
            Update(excludedProperties, Governate);
        }
        #endregion

        #region Remove Branch
        /// <summary>
        /// Removes Branch items.
        /// </summary>
        /// <param name="branch">The branch.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void RemoveGovernate(params tb_Governate[] Governate)
        {
            Remove(Governate);
        }
        #endregion
    }
}
