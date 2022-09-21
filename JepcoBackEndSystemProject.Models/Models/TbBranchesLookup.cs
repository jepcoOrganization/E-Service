using System;
using System.Collections.Generic;

namespace JepcoBackEndSystemProject.Models.Models
{
    public partial class TbBranchesLookup
    {


        public int BranchID { get; set; }
        public string BranchName { get; set; }
        public int CityID { get; set; }

      
        public virtual TbCitiesLookup Tb_CitiesLookup { get; set; }

    }
}
