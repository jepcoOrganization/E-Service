using System;
using System.Collections.Generic;

namespace JepcoBackEndSystemProject.Models.Models
{
    public partial class TbCitiesLookup
    {
        public TbCitiesLookup()
        {
            this.tb_BranchesLookup = new HashSet<TbBranchesLookup>();
        }

        public int ID { get; set; }
        public string CityName { get; set; }

        public virtual ICollection<TbBranchesLookup> tb_BranchesLookup { get; set; }
    }
}
