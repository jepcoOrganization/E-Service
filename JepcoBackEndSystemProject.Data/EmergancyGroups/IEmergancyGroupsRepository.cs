using JepcoBackEndSystemProject.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JepcoBackEndSystemProject.Data.EmergancyGroups
{
    //internal interface IEmergancyGroupsRepository
    //{
    //}

    public interface IEmergancyGroupsRepository : IRepositoryBase<tb_EmergancyGroups>
    {

        Task<IEnumerable<tb_EmergancyGroups>> GetAllEmergancyGroups(params Expression<Func<tb_EmergancyGroups, object>>[] navigationProperties);

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>List of type T.</returns>
        Task<IEnumerable<tb_EmergancyGroups>> GetListOfEmergancyGroups(Expression<Func<tb_EmergancyGroups, bool>> where, params Expression<Func<tb_EmergancyGroups, object>>[] navigationProperties);

        /// <summary>
        /// Gets the single.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>Generic of type T.</returns>
        Task<tb_EmergancyGroups> GetSingleEmergancyGroups(Expression<Func<tb_EmergancyGroups, bool>> where, params Expression<Func<tb_EmergancyGroups, object>>[] navigationProperties);
        /// <summary>
        /// Adds City items.
        /// </summary>
        /// <param name="cities">The cities.</param>
        void AddEmergancyGroups(params tb_EmergancyGroups[] EmergancyGroups);

        /// <summary>
        /// Updates City items.
        /// </summary>
        /// <param name="cities">The cities.</param>
        void UpdateEmergancyGroups(string[] excludedProperties, params tb_EmergancyGroups[] EmergancyGroups);

        ///// <summary>
        ///// Removes City items.
        ///// </summary>
        ///// <param name="cities">The cities.</param>
        void RemoveEmergancyGroups(params tb_EmergancyGroups[] EmergancyGroups);
    }
}
