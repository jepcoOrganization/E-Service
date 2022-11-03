
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






        private District.IDistrictRepository _districtRepository;
        private FazPowerCapacity.IFazPowerCapacityRepository _fazPowerCapacityRepository;
        private Governate.IGovernateRepository _governateRepository;
        private MaintenanceRequest.IMaintenanceRequestRepository _maintenanceRequestRepository;
        private MaintenanceRequestType.IMaintenanceRequestTypeRepository _maintenanceRequestTypeRepository;
 



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



















        public District.IDistrictRepository DistrictRepository
        {
            get
            {
                if (_districtRepository == null)
                {
                    _districtRepository = new District.DistrictRepository(_repoContext, _logger);
                }

                return _districtRepository;
            }
        }


        public FazPowerCapacity.IFazPowerCapacityRepository FazPowerCapacityRepository
        {
            get
            {
                if (_fazPowerCapacityRepository == null)
                {
                    _fazPowerCapacityRepository = new FazPowerCapacity.FazPowerCapacityRepository(_repoContext, _logger);
                }

                return _fazPowerCapacityRepository;
            }
        }

        public Governate.IGovernateRepository GovernateRepository
        {
            get
            {
                if (_governateRepository == null)
                {
                    _governateRepository = new Governate.GovernateRepository(_repoContext, _logger);
                }

                return _governateRepository;
            }
        }

        public MaintenanceRequest.IMaintenanceRequestRepository MaintenanceRequestRepository
        {
            get
            {
                if (_maintenanceRequestRepository == null)
                {
                    _maintenanceRequestRepository = new MaintenanceRequest.MaintenanceRequestRepository(_repoContext, _logger);
                }

                return _maintenanceRequestRepository;
            }
        }

        public MaintenanceRequestType.IMaintenanceRequestTypeRepository MaintenanceRequestTypeRepository
        {
            get
            {
                if (_maintenanceRequestTypeRepository == null)
                {
                    _maintenanceRequestTypeRepository = new MaintenanceRequestType.MaintenanceRequestTypeRepository(_repoContext, _logger);
                }

                return _maintenanceRequestTypeRepository;
            }
        }



    }
}

    

