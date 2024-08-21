using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using Newtonsoft.Json;


using System.Threading.Tasks;

namespace ECommerce.Application.Exceptions
{
    public  class ExceptionModel : ErrorStatusCode
    {
        public IEnumerable<string> Errors { get; set; }

        public override string ToString() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
    }

    public class ErrorStatusCode
    {
        public int StatusCode { get; set; }
    }
}
