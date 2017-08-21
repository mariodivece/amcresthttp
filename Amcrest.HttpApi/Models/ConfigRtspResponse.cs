namespace Amcrest.HttpApi.Models
{
    using Newtonsoft.Json;

    public class PortRange
    {
        public int EndPort { get; set; }
        public int StartPort { get; set; }
    }

    public class RtspConfig
    {
        public bool Enable { get; set; }
        public int Port { get; set; }
        public PortRange RTP { get; set; }
    }
}
