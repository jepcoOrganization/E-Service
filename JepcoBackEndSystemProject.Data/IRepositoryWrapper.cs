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
    
        District.IDistrictRepository DistrictRepository { get; }
        FazPowerCapacity.IFazPowerCapacityRepository FazPowerCapacityRepository { get; }
        Governate.IGovernateRepository GovernateRepository { get; }
        MaintenanceRequest.IMaintenanceRequestRepository MaintenanceRequestRepository { get; }

        MaintenanceRequestType.IMaintenanceRequestTypeRepository MaintenanceRequestTypeRepository { get; }
            


        Task SaveAsync();
    }
}
