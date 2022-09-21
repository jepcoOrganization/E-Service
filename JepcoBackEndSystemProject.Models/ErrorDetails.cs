using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JepcoBackEndSystemProject.Models
{
    public class ErrorDetails
    {
        public string ErrorType { get; set; }
        public string Title { get; set; }
        public long Status { get; set; }
        public string TraceId { get; set; }
        public object Errors { get; set; }


        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
