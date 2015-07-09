using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Twilio.Mvc;

namespace CallCentre.WebAPI.Controllers
{
    public class CallStatusController : ApiController
    {
        public void UpdateStatus(StatusCallbackRequest request)
        {
            // do something with this request
        }
    }
}
