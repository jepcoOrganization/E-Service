using JepcoBackEndSystemProject.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JepcoBackEndSystemProject.Data.EngineersAccessRegister
{
    

    public interface IEngineersAccessRegisterRepository : IRepositoryBase<tb_EngineersAccessRegister>
    {

        Task<IEnumerable<tb_EngineersAccessRegister>> GetAllEngineersAccessRegister(params Expression<Func<tb_EngineersAccessRegister, object>>[] navigationProperties);

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>List of type T.</returns>
        Task<IEnumerable<tb_EngineersAccessRegister>> GetListOfEngineersAccessRegister(Expression<Func<tb_EngineersAccessRegister, bool>> where, params Expression<Func<tb_EngineersAccessRegister, object>>[] navigationProperties);

        /// <summary>
        /// Gets the single.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>Generic of type T.</returns>
        Task<tb_EngineersAccessRegister> GetSingleEngineersAccessRegister(Expression<Func<tb_EngineersAccessRegister, bool>> where, params Expression<Func<tb_EngineersAccessRegister, object>>[] navigationProperties);
        /// <summary>
        /// Adds City items.
        /// </summary>
        /// <param name="UserAccessRegister">The UserAccessRegister.</param>
        void AddEngineersAccessRegister(params tb_EngineersAccessRegister[] UserAccessRegister);

        /// <summary>
        /// Updates City items.
        /// </summary>
        /// <param name="UserAccessRegister">The UserAccessRegister.</param>
        void UpdateEngineersAccessRegister(string[] excludedProperties, params tb_EngineersAccessRegister[] UserAccessRegister);

        ///// <summary>
        ///// Removes City items.
        ///// </summary>
        ///// <param name="UserAccessRegister">The UserAccessRegister.</param>
        void RemoveEngineersAccessRegister(params tb_EngineersAccessRegister[] UserAccessRegister);
    }
}
