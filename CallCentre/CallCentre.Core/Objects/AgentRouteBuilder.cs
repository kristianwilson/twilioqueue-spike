using System;
using CallCentre.Core.Interfaces;

namespace CallCentre.Core.Objects
{
    public class AgentRouteBuilder : IRouteBuilder
    {
        private readonly Agent _agent;
        private readonly string _queuedId;
        private readonly string _url;

        public string Url { get { return string.Format(string.Concat(_url, "/{0}/{1}"), _agent.Identifier, _queuedId); } }
        public string Method { get { return "Post"; } }

        public AgentRouteBuilder(Agent agent, string queuedId, string url)
        {
            _agent = agent;
            _queuedId = queuedId;
            _url = url;
        }
    }
}
