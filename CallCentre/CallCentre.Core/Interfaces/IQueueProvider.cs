using System.Collections.Generic;
using CallCentre.Core.Objects;

namespace CallCentre.Core.Interfaces
{
    public interface IQueueProvider
    {
        Queue CreateQueue(Queue queue);
        Queue GetQueue(string id);
        bool DeleteQueue(Queue queue);
        Call GetCallFromQueue(Queue queue, string callSid);
        bool DequeueCallFromQueue(Queue queue, string callSid, IRouteBuilder routeBuilder);
        Call GetFirstCallFromQueue(Queue queue);
        bool DequeueFirstCallFromQueue(Queue queue, IRouteBuilder routeBuilder);
        List<Queue> GetQueues();
    }
}
