using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CallCentre.Core.Interfaces;

namespace CallCentre.Infrastructure
{
    public class QueueSettings : IQueueSettings
    {
        public string Url { get; private set; }
    }
}
