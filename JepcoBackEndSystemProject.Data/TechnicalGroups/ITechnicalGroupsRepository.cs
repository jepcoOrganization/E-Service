using JepcoBackEndSystemProject.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JepcoBackEndSystemProject.Data.TechnicalGroups
{
    //internal interface ITechnicalGroupsRepository
    //{
    //}
    public interface ITechnicalGroupsRepository : IRepositoryBase<tb_TechnicalGroups>
    {

        Task<IEnumerable<tb_TechnicalGroups>> GetAllTechnicalGroups(params Expression<Func<tb_TechnicalGroups, object>>[] navigationProperties);

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>List of type T.</returns>
        Task<IEnumerable<tb_TechnicalGroups>> GetListOfTechnicalGroups(Expression<Func<tb_TechnicalGroups, bool>> where, params Expression<Func<tb_TechnicalGroups, object>>[] navigationProperties);

        /// <summary>
        /// Gets the single.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>Generic of type T.</returns>
        Task<tb_TechnicalGroups> GetSingleTechnicalGroups(Expression<Func<tb_TechnicalGroups, bool>> where, params Expression<Func<tb_TechnicalGroups, object>>[] navigationProperties);
        /// <summary>
        /// Adds City items.
        /// </summary>
        /// <param name="UserAccessRegister">The UserAccessRegister.</param>
        void AddTechnicalGroups(params tb_TechnicalGroups[] TechnicalGroups);

        /// <summary>
        /// Updates City items.
        /// </summary>
        /// <param name="UserAccessRegister">The UserAccessRegister.</param>
        void UpdateTechnicalGroups(string[] excludedProperties, params tb_TechnicalGroups[] TechnicalGroups);

        ///// <summary>
        ///// Removes City items.
        ///// </summary>
        ///// <param name="UserAccessRegister">The UserAccessRegister.</param>
        void RemoveTechnicalGroups(params tb_TechnicalGroups[] TechnicalGroups);
    }
}
