using BasicWebServer.Server.Common;
using BasicWebServer.Server.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebServer.Server.Responses
{
    public class BadRequestResponse : Response
    {
        public BadRequestResponse(string content, string contentType)
            :base(StatusCode.BadRequest)
        {
            
        }
    }
}
