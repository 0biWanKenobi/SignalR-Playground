using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SignalR.WebApp.Controllers
{
    public class MessageController : ApiController
    {
        private static readonly ServerHub Hub = new ServerHub();
        // GET api/<controller>
        [HttpPost]
        public HttpResponseMessage Send(object content)
        {
            dynamic cnt = content;
            Hub.Send(cnt.name.Value, cnt.message.Value, cnt.group.Value);
            return new HttpResponseMessage();
        }
    }
}