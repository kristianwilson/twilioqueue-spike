using System;

namespace CallCentre.Core.Objects
{
    public class Call
    {
        public string Id { get; set; }
        public DateTime DateEnqueued { get; set; }
        public int? WaitTime { get; set; }
        public int? Position { get; set; }
    }
}
