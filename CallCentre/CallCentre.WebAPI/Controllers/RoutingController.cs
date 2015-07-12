using System.Web.Http;
using Twilio.Mvc;
using Twilio.TwiML;

namespace CallCentre.WebAPI.Controllers
{
    public class RoutingController : ApiController
    {
        public TwilioResponse InboundAction(TwilioRequest request)
        {
            return new TwilioResponse();
        }
    }
}
