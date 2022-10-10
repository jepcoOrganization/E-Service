using JepcoBackEndSystemProject.Data;
using JepcoBackEndSystemProject.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JepcoBackEndSystemProject.Data
{
    public interface IRepositoryWrapper
    {
   
RepairingStatus.IRepairingStatusRepository Status { get; }
FaultCompliants.IFaultCompliantsLookupRepository FaultCompliantsLookupRepository { get; }
UserAccessRegister.IUserAccessRegisterLookupRepository UserAccessRegisterLookupRepository { get; }
FaultDetails.IFaultDetailsRepository FaultDetailsRepository { get; }
ElectricalFaultStatus.IElectricalFaultStatusRepository ElectricalFaultStatusRepository { get; }
EngineersAccessRegister.IEngineersAccessRegisterRepository EngineersAccessRegisterRepository { get; }
Technical.ITechnicalRepository TechnicalRepository { get; }
 Governorate.IGovernorateRepository GovernorateRepository { get; }
        EmergancyGroups.IEmergancyGroupsRepository EmergancyGroupsRepository { get; }
        Smsverifications.ISmsverificationRepository SmsVerification { get; }


TechnicalGroups.ITechnicalGroupsRepository TechnicalGroupsRepository { get; }



        Task SaveAsync();
    }
}
