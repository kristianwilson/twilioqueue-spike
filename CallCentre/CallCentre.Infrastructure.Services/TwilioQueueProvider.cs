using System.Collections.Generic;
using System.Linq;
using CallCentre.Core.Interfaces;
using Twilio;
using Call = CallCentre.Core.Objects.Call;
using Queue = CallCentre.Core.Objects.Queue;

namespace CallCentre.Infrastructure.Services
{
    public class TwilioQueueProvider : IQueueProvider
    {
        private readonly IAccountSettings _accountSettings;

        public TwilioQueueProvider(IAccountSettings accountSettings)
        {
            _accountSettings = accountSettings;
        }

        public Queue CreateQueue(Queue queue)
        {
            var twilioClient = new TwilioRestClient(_accountSettings.AccountSid, _accountSettings.AuthToken);
            var twilioQueue = twilioClient.CreateQueue(queue.Name, queue.MaxSize?? 0);

            return new Queue
            {
                Id = twilioQueue.Sid,
                Name = twilioQueue.FriendlyName,
                Size = twilioQueue.CurrentSize,
                MaxSize = twilioQueue.MaxSize,
                AverageWaitTime = twilioQueue.AverageWaitTime
            };
        }

        public Queue GetQueue(string id)
        {
            var twilioClient = new TwilioRestClient(_accountSettings.AccountSid, _accountSettings.AuthToken);
            var twilioQueue = twilioClient.GetQueue(id);

            return new Queue
            {
                Id = twilioQueue.Sid,
                Name = twilioQueue.FriendlyName,
                Size = twilioQueue.CurrentSize,
                MaxSize = twilioQueue.MaxSize,
                AverageWaitTime = twilioQueue.AverageWaitTime
            };
        }

        public bool DeleteQueue(Queue queue)
        {
            var twilioClient = new TwilioRestClient(_accountSettings.AccountSid, _accountSettings.AuthToken);
            var result = twilioClient.DeleteQueue(queue.Id);

            return result == DeleteStatus.Success;
        }

        public Call GetCallFromQueue(Queue queue, string callSid)
        {
            var twilioClient = new TwilioRestClient(_accountSettings.AccountSid, _accountSettings.AuthToken);
            var result = twilioClient.GetQueueMember(queue.Id, callSid);

            return new Call
            {
                Id = result.CallSid,
                WaitTime = result.WaitTime,
                DateEnqueued = result.DateEnqueued,
                Position = result.Position
            };
        }

        public bool DequeueCallFromQueue(Queue queue, string callSid, IRouteBuilder route)
        {
            var twilioClient = new TwilioRestClient(_accountSettings.AccountSid, _accountSettings.AuthToken);
            var result = twilioClient.DequeueQueueMember(queue.Id, callSid, route.Url, route.Method);

            return result == DequeueStatus.Success;
        }

        public Call GetFirstCallFromQueue(Queue queue)
        {
            var twilioClient = new TwilioRestClient(_accountSettings.AccountSid, _accountSettings.AuthToken);
            var result = twilioClient.GetFirstQueueMember(queue.Id);

            return new Call
            {
                Id = result.CallSid,
                WaitTime = result.WaitTime,
                DateEnqueued = result.DateEnqueued,
                Position = result.Position
            };
        }

        public bool DequeueFirstCallFromQueue(Queue queue, IRouteBuilder route)
        {
            var twilioClient = new TwilioRestClient(_accountSettings.AccountSid, _accountSettings.AuthToken);
            var result = twilioClient.DequeueFirstQueueMember(queue.Id, route.Url, route.Method);

            return result == DequeueStatus.Success;
        }

        public List<Queue> GetQueues()
        {
            var twilioClient = new TwilioRestClient(_accountSettings.AccountSid, _accountSettings.AuthToken);
            var twilioQueues = twilioClient.ListQueues();

            return twilioQueues.Queues.Select(queue => new Queue
            {
                Id = queue.Sid,
                Name = queue.FriendlyName,
                Size = queue.CurrentSize,
                MaxSize = queue.MaxSize,
                AverageWaitTime = queue.AverageWaitTime
            }).ToList();
        }
    }
}
