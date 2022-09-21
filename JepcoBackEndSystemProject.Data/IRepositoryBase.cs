using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace JepcoBackEndSystemProject.Data
{
    /// <summary>
    /// Interface for generic data repository.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepositoryBase<T> where T : class
    {/// <summary>
     /// Gets all.
     /// </summary>
     /// <param name="navigationProperties">The navigation properties.</param>
     /// <returns>List of type T.</returns>
        IQueryable<T> GetAll(params Expression<Func<T, object>>[] navigationProperties);

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>List of type T.</returns>
        IQueryable<T> GetList(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties);

        /// <summary>
        /// Gets the single.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>Generic of type T.</returns>
        //T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);

        /// <summary>
        /// Adds the specified items.
        /// </summary>
        /// <param name="items">The items.</param>
        void Add(params T[] items);

        /// <summary>
        /// Updates the specified items.
        /// </summary>
        /// <param name="items">The items.</param>
        void Update( string[] excludedProperties,params T[] items);

        /// <summary>
        /// Removes the specified items.
        /// </summary>
        /// <param name="items">The items.</param>
        void Remove(params T[] items);
    }
}