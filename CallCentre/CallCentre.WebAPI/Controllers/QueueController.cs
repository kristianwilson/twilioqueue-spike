using System.Web.Http;
using Twilio.TwiML;

namespace CallCentre.WebAPI.Controllers
{
    public class QueueController : ApiController
    {
        public TwilioResponse DequeueToAgent(string agent, string queueId)
        {
            return new TwilioResponse();
        }
    }
}
