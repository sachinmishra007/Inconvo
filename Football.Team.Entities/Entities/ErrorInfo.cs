using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Football.Team.Entities.Entities
{
    public class ErrorInfo
    {
        public ErrorInfo()
        {
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
