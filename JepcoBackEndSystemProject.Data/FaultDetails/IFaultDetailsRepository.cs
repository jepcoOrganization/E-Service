
using JepcoBackEndSystemProject.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JepcoBackEndSystemProject.Data.FaultDetails
{
    //internal interface IFaultDetailsRepository
    //{
    //}
    public interface IFaultDetailsRepository : IRepositoryBase<tb_FaultDetails>
    {

        Task<IEnumerable<tb_FaultDetails>> GetAllFaultDetails(params Expression<Func<tb_FaultDetails, object>>[] navigationProperties);

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>List of type T.</returns>
        Task<IEnumerable<tb_FaultDetails>> GetListOfFaultDetails(Expression<Func<tb_FaultDetails, bool>> where, params Expression<Func<tb_FaultDetails, object>>[] navigationProperties);

        /// <summary>
        /// Gets the single.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>Generic of type T.</returns>
        Task<tb_FaultDetails> GetSingleFaultDetails(Expression<Func<tb_FaultDetails, bool>> where, params Expression<Func<tb_FaultDetails, object>>[] navigationProperties);
        /// <summary>
        /// Adds City items.
        /// </summary>
        /// <param name="cities">The cities.</param>
        void AddFaultDetails(params tb_FaultDetails[] FaultDetails);

        /// <summary>
        /// Updates City items.
        /// </summary>
        /// <param name="cities">The cities.</param>
        void UpdateFaultDetails(string[] excludedProperties, params tb_FaultDetails[] FaultDetails);

        ///// <summary>
        ///// Removes City items.
        ///// </summary>
        ///// <param name="cities">The cities.</param>
        void RemoveFaultDetails(params tb_FaultDetails[] FaultDetails);

        Task<IEnumerable<tb_FaultDetails>> GetListOfFaultDetailsWithoutImages(long FaultComplaintID);
    }
}
