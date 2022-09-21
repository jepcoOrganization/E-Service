using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JepcoBackEndSystemProject.EMRCServices.DataTransferObject
{
    public class CommontRetrunDto
    {
        public string StatusCode { get; set; }
        public string Message { get; set; }
        public object Body { get; set; }
    }
}
