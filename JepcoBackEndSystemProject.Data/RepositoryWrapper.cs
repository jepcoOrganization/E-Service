﻿
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
       
     
        private RepairingStatus.IRepairingStatusRepository _status;
        private FaultCompliants.IFaultCompliantsLookupRepository _FaultCompliantsLookupRepository;
        private UserAccessRegister.IUserAccessRegisterLookupRepository _UserAccessRegisterLookupRepository;
        private FaultDetails.IFaultDetailsRepository _faultDetailsRepository;
        private ElectricalFaultStatus.IElectricalFaultStatusRepository _electricalFaultStatusRepository;
        private EngineersAccessRegister.IEngineersAccessRegisterRepository _engineersAccessRegisterRepository;
        private Technical.ITechnicalRepository _technicalRepository;
        private Governorate.IGovernorateRepository _governorateRepository;
        private EmergancyGroups.IEmergancyGroupsRepository _emergancyGroupsRepository;

 



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


      

        
     
        public RepairingStatus.IRepairingStatusRepository Status
        {
            get
            {
                if (_status == null)
                {
                    _status = new RepairingStatus.RepairingStatusRepository(_repoContext, _logger);
                }

                return _status;
            }
        }



        public FaultCompliants.IFaultCompliantsLookupRepository FaultCompliantsLookupRepository
        {
            get
            {
                if (_FaultCompliantsLookupRepository == null)
                {
                    _FaultCompliantsLookupRepository = new FaultCompliants.FaultCompliantsLookupRepository(_repoContext, _logger);
                }

                return _FaultCompliantsLookupRepository;
            }
        }


        public UserAccessRegister .IUserAccessRegisterLookupRepository  UserAccessRegisterLookupRepository
        {
            get
            {
                if (_UserAccessRegisterLookupRepository == null)
                {
                    _UserAccessRegisterLookupRepository = new UserAccessRegister.UserAccessRegisterLookupRepository (_repoContext, _logger);
                }

                return _UserAccessRegisterLookupRepository;
            }
        }


        public FaultDetails.IFaultDetailsRepository FaultDetailsRepository
        {
            get
            {
                if (_faultDetailsRepository == null)
                {
                    _faultDetailsRepository = new FaultDetails.FaultDetailsRepository(_repoContext, _logger);
                }

                return _faultDetailsRepository;
            }
        }


        public ElectricalFaultStatus.IElectricalFaultStatusRepository ElectricalFaultStatusRepository
        {
            get
            {
                if (_electricalFaultStatusRepository == null)
                {
                    _electricalFaultStatusRepository = new ElectricalFaultStatus.ElectricalFaultStatusRepository(_repoContext, _logger);
                }

                return _electricalFaultStatusRepository;
            }
        }

       

        public EngineersAccessRegister.IEngineersAccessRegisterRepository EngineersAccessRegisterRepository
        {
            get
            {
                if (_engineersAccessRegisterRepository == null)
                {
                    _engineersAccessRegisterRepository = new EngineersAccessRegister.EngineersAccessRegisterRepository(_repoContext, _logger);
                }

                return _engineersAccessRegisterRepository;
            }
        }


        public Technical.ITechnicalRepository TechnicalRepository
        {
            get
            {
                if (_technicalRepository == null)
                {
                    _technicalRepository = new Technical.TechnicalRepository(_repoContext, _logger);
                }

                return _technicalRepository;
            }
        }




        public Governorate.IGovernorateRepository GovernorateRepository
        {
            get
            {
                if (_governorateRepository == null)
                {
                    _governorateRepository = new Governorate.GovernorateRepository(_repoContext, _logger);
                }

                return _governorateRepository;
            }
        }




        public EmergancyGroups.IEmergancyGroupsRepository EmergancyGroupsRepository
        {
            get
            {
                if (_emergancyGroupsRepository == null)
                {
                    _emergancyGroupsRepository = new EmergancyGroups.EmergancyGroupsRepository(_repoContext, _logger);
                }

                return _emergancyGroupsRepository;
            }
        }
















    }
}
