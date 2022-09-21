
using JepcoBackEndSystemProject.Data.CommonReturn;
using JepcoBackEndSystemProject.Models.Models;
using JepcoBackEndSysytemProject.LoggerService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JepcoBackEndSystemProject.Data
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly DBJEPCOBackEndContext _repoContext;
        private readonly ILoggerManager _logger;
       
        private Branches.IBranchesLookupRepository _branch;
        private Cities.ICitiesLookupRepository _city;

      
        
       

        public RepositoryWrapper(DBJEPCOBackEndContext repositoryContext, ILoggerManager logger)
        {
            _repoContext = repositoryContext;
            _logger = logger;
        }

        public async Task SaveAsync()
        {
            try
            {
                await _repoContext.SaveChangesAsync();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException e)
            {
                foreach (var eve in e.Entries)
                {
                    _logger.LogError(string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:", eve.Entity.GetType().Name, eve.State));

                }
                throw;
            }
            catch (Exception e)
            {
                _logger.LogError(string.Format(" The error in Add Method has a Massege \"{0}\" , the StackTrace is \"{1}\", and the Inner Exception is \"{2}\" ", e.Message, e.StackTrace, e.InnerException));

                throw;
            }

        }


      

        public Branches.IBranchesLookupRepository Branch
        {
            get
            {
                if (_branch == null)
                {
                    _branch = new Branches.BranchesLookupRepository(_repoContext, _logger);
                }

                return _branch;
            }
        }
        public Cities.ICitiesLookupRepository City
        {
            get
            {
                if (_city == null)
                {
                    _city = new Cities.CitiesLookupRepository(_repoContext, _logger );
                }

                return _city;
            }
        }
      
      

       





    }
}
