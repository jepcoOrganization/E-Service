using System;
using System.Collections.Generic;
using System.Text;

namespace JepcoBackEndSystemProject.Models
{
    public class CommonReturnResult
    {
        public string StatusCode { get; set; }
        public string Message { get; set; }
        public object Body { get; set; }



    }
}
