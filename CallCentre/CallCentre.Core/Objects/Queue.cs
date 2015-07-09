namespace CallCentre.Core.Objects
{
    public class Queue
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int? Size { get; set; }
        public int? MaxSize { get; set; }
        public int? AverageWaitTime { get; set; }
    }
}
