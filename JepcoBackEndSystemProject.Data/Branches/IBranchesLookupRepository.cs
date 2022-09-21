using JepcoBackEndSystemProject.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JepcoBackEndSystemProject.Data.Branches
{
    public interface IBranchesLookupRepository : IRepositoryBase<TbBranchesLookup>
    {

        Task<IEnumerable<TbBranchesLookup>> GetAllBranchs(params Expression<Func<TbBranchesLookup, object>>[] navigationProperties);

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>List of type T.</returns>
        Task<IEnumerable<TbBranchesLookup>> GetListOfBranchs(Expression<Func<TbBranchesLookup, bool>> where, params Expression<Func<TbBranchesLookup, object>>[] navigationProperties);

        /// <summary>
        /// Gets the single.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>Generic of type T.</returns>
        Task<TbBranchesLookup> GetSingleBranch(Expression<Func<TbBranchesLookup, bool>> where, params Expression<Func<TbBranchesLookup, object>>[] navigationProperties);
        /// <summary>
        /// Adds Branch items.
        /// </summary>
        /// <param name="branch">The branch.</param>
        void AddBranch(params TbBranchesLookup[] branch);

        /// <summary>
        /// Updates Branch items.
        /// </summary>
        /// <param name="branch">The branch.</param>
        void UpdateBranch(string[] excludedProperties, params TbBranchesLookup[] branch);

        ///// <summary>
        ///// Removes Branch items.
        ///// </summary>
        ///// <param name="branch">The branch.</param>
        void RemoveBranch(params TbBranchesLookup[] branch);
    }
}
