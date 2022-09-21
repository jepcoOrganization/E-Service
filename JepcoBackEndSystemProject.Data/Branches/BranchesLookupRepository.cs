using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using JepcoBackEndSystemProject.Models.Models;
using JepcoBackEndSysytemProject.LoggerService;
using Microsoft.EntityFrameworkCore;

namespace JepcoBackEndSystemProject.Data.Branches
{
    public class BranchesLookupRepository : RepositoryBase<TbBranchesLookup>, IBranchesLookupRepository
    {        
        public BranchesLookupRepository(DBJEPCOBackEndContext repositoryContext, ILoggerManager logger)
            : base(repositoryContext, logger)
        {            
        }

        #region GetData
        public async Task<IEnumerable<TbBranchesLookup>> GetAllBranchs(params Expression<Func<TbBranchesLookup, object>>[] navigationProperties)
        {
            try
            {
                return  await GetAll(navigationProperties).ToListAsync();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return null; 
                
            }
            
        }
        public async Task<IEnumerable<TbBranchesLookup>> GetListOfBranchs(Expression<Func<TbBranchesLookup, bool>> where, params Expression<Func<TbBranchesLookup, object>>[] navigationProperties)
        {
            return  await GetList(where, navigationProperties).ToListAsync();
        }
        public async Task<TbBranchesLookup> GetSingleBranch(Expression<Func<TbBranchesLookup, bool>> where, params Expression<Func<TbBranchesLookup, object>>[] navigationProperties)
        {
            return (TbBranchesLookup)await GetList(where, navigationProperties).FirstOrDefaultAsync();
        }
        #endregion

        #region Add Branch
        /// <summary>
        /// Add Branch items.
        /// </summary>
        /// <param name="branch">The branch.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void AddBranch(params TbBranchesLookup[] branchs)
        {
            Add(branchs);
        }
        #endregion

        #region Edit Branch
        ///// <summary>
        ///// Updates Branch items.
        ///// </summary>
        ///// <param name="branch">The branch.</param>
        ///// <exception cref="System.NotImplementedException"></exception>
        public void UpdateBranch(string[] excludedProperties, params TbBranchesLookup[] branchs)
        {
            Update(excludedProperties, branchs);
        }
        #endregion

        #region Remove Branch
        /// <summary>
        /// Removes Branch items.
        /// </summary>
        /// <param name="branch">The branch.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void RemoveBranch(params TbBranchesLookup[] branchs)
        {
            Remove(branchs);
        }
        #endregion

    }
}
