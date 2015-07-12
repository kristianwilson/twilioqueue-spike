using CallCentre.Core.Interfaces;

namespace CallCentre.Core.Objects
{
    public class AgentRouteBuilder : IRouteBuilder
    {
        private readonly Agent _agent;
        private readonly string _url;

        public string Url { get { return string.Format(_url, _agent.Identifier); } }
        public string Method { get { return "Post"; } }

        public AgentRouteBuilder(Agent agent, string url)
        {
            _agent = agent;
            _url = url;
        }
    }
}
