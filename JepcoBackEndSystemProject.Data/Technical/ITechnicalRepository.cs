using JepcoBackEndSystemProject.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JepcoBackEndSystemProject.Data.Technical
{
    //internal interface ITechnicalRepository
    //{
    //}
    public interface ITechnicalRepository : IRepositoryBase<tb_Technical>
    {

        Task<IEnumerable<tb_Technical>> GetAllTechnical(params Expression<Func<tb_Technical, object>>[] navigationProperties);

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>List of type T.</returns>
        Task<IEnumerable<tb_Technical>> GetListOfTechnical(Expression<Func<tb_Technical, bool>> where, params Expression<Func<tb_Technical, object>>[] navigationProperties);

        /// <summary>
        /// Gets the single.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>Generic of type T.</returns>
        Task<tb_Technical> GetSingleTechnical(Expression<Func<tb_Technical, bool>> where, params Expression<Func<tb_Technical, object>>[] navigationProperties);
        /// <summary>
        /// Adds City items.
        /// </summary>
        /// <param name="UserAccessRegister">The UserAccessRegister.</param>
        void AddTechnical(params tb_Technical[] Technical);

        /// <summary>
        /// Updates City items.
        /// </summary>
        /// <param name="UserAccessRegister">The UserAccessRegister.</param>
        void UpdateTechnical(string[] excludedProperties, params tb_Technical[] Technical);

        ///// <summary>
        ///// Removes City items.
        ///// </summary>
        ///// <param name="UserAccessRegister">The UserAccessRegister.</param>
        void RemoveTechnical(params tb_Technical[] Technical);
    }
}
