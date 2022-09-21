using JepcoBackEndSystemProject.Models.Models;
using JepcoBackEndSysytemProject.LoggerService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace JepcoBackEndSystemProject.Data
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ILoggerManager Logger { get; set; }
        protected DBJEPCOBackEndContext RepositoryContext { get; set; }
        public RepositoryBase(DBJEPCOBackEndContext repositoryContext, ILoggerManager logger, CommonReturn.ICommonReturn common)
        {
            Logger = logger;
            this.RepositoryContext = repositoryContext;
        }

        protected RepositoryBase(DBJEPCOBackEndContext repositoryContext, ILoggerManager logger)
        {
            RepositoryContext = repositoryContext;
            Logger = logger;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>
        /// List of type T.
        /// </returns>
        public IQueryable<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            
            IQueryable<T> dbQuery = RepositoryContext.Set<T>().AsNoTracking();

            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<T, object>(navigationProperty);


            return dbQuery;//.AsNoTracking();//.ToList<T>();
            
        }

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>
        /// List of type T.
        /// </returns>
        public IQueryable<T> GetList(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {

            IQueryable<T> dbQuery = (IQueryable<T>)RepositoryContext.Set<T>().Where(where).AsNoTracking();

            //Apply eager loading
            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<T, object>(navigationProperty);


            return dbQuery;//.AsNoTracking();

                    
           
        }

        /// <summary>
        /// Gets the single.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>
        /// Generic of type T.
        /// </returns>
        //public  T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
        //{
        //    T item = null;
        //    IQueryable<T> dbQuery = RepositoryContext.Set<T>();

        //    //Apply eager loading
        //    foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
        //    {
        //        dbQuery = dbQuery.Include<T, object>(navigationProperty);
        //    }

        //    item = dbQuery
        //                .AsNoTracking() //Don't track any changes for the selected item
        //                .FirstOrDefault(where); //Apply where clause
        //    return item;
        //    //using (var context = new DBJEPCOBackEndContext())
        //    //{
        //    //    IQueryable<T> dbQuery = context.Set<T>();

        //    //    //Apply eager loading
        //    //    foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
        //    //    {
        //    //        dbQuery = dbQuery.Include<T, object>(navigationProperty);
        //    //    }

        //    //    item = dbQuery
        //    //                .AsNoTracking() //Don't track any changes for the selected item
        //    //                .FirstOrDefault(where); //Apply where clause
        //    //}
        //    //return item;
        //}

        /// <summary>
        /// Adds the specified items.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Add(params T[] items)
        {

            try
            {
                foreach (T item in items)
                {
                    RepositoryContext.Set<T>().Add(item);

                }
                
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException e)
            {
                foreach (var eve in e.Entries)
                {
                    Logger.LogError(string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:", eve.Entity.GetType().Name, eve.State));

                }
                throw;
            }
            catch (Exception e)
            {

                Logger.LogError(string.Format(" The error in Add Method has a Massege \"{0}\" , the StackTrace is \"{1}\", and the Inner Exception is \"{2}\" ", e.Message, e.StackTrace, e.InnerException));


                throw;
            }



             
        }

        /// <summary>
        /// Updates the specified items.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Update(string[] excludedProperties, params T[] items)
        {
             

            try
            {
                 
                foreach (T item in items)
                {
                    var entry = RepositoryContext.Entry(item);
                    entry.State = EntityState.Modified;

                    if (excludedProperties != null)
                    {
                        foreach (string excludedProperty in excludedProperties)
                        {
                            try
                            {
                                entry.Property(excludedProperty).IsModified = false;
                            }
                            catch (Exception e)
                            {
                                Logger.LogError(string.Format(" The error in Update Method has a Massege \"{0}\" , the StackTrace is \"{1}\", and the Inner Exception is \"{2}\" ", e.Message, e.StackTrace, e.InnerException));

                                //do nothing, excludedProperty not exist in the entry.
                            }
                        }
                    }
                }

               
            }
            catch (Exception e)
            {
                Logger.LogError(string.Format(" The error in Add Method has a Massege \"{0}\" , the StackTrace is \"{1}\", and the Inner Exception is \"{2}\" ", e.Message, e.StackTrace, e.InnerException));

                throw;
            }



        }


        /// <summary>
        /// Removes the specified items.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Remove(params T[] items)
        {
            foreach (T item in items)
            {
                RepositoryContext.Set<T>().Remove(item);
            }
             
        }
    }
}




