using CallCentre.Core.Interfaces;

namespace CallCentre.Core.Objects
{
    public class AgentQueueRouteBuilder : IRouteBuilder
    {
        private readonly Agent _agent;
        private readonly Queue _queue;
        private readonly string _url;

        public string Url { get { return string.Format(string.Concat(_url, "/{0}/{1}"), _agent.Identifier, _queue.Id); } }
        public string Method { get { return "POST"; } }

        public AgentQueueRouteBuilder(Agent agent, Queue queue, string url)
        {
            _agent = agent;
            _queue = queue;
            _url = url;
        }
    }
}
