using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Footboll.Team.WebApi.CommonUtils
{
    public class CommonUtils
    {
        public CommonUtils()
        {

        }

        public static Info GetV1ApiSwaggerInfo()
        {
            return new  Info()
            {
                Version = "V1.0",
                Title = "Football Web Api",
                Description = "This documnent will bascially provide the Information about the Api Version and Documentation",
                TermsOfService = "None",
                Contact = new Swashbuckle.AspNetCore.Swagger.Contact()
                {
                    Name = "Sachin Mishra",
                    Email = "sachinmishra609@gmail.com",
                    Url = "https://github.com/sachinmishra007"
                }
                
            };
        }       
    }
}
