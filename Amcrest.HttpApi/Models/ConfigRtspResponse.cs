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

    public class ConfigTable
    {
        public RtspConfig RTSP { get; set; }
    }

    public class ConfigTableResponse
    {
        [JsonProperty("table")]
        public ConfigTable Table { get; set; }
    }
}
