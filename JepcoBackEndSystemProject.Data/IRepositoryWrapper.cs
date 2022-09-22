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



        Task SaveAsync();
    }
}
