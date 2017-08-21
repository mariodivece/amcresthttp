namespace Amcrest.HttpApi.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class ConfigTable
    {
        public RtspConfig RTSP { get; set; }
        public List<SnapConfig> Snap { get; set; }
        public List<VideoColor> VideoColor { get; set; }
        public List<Encode> Encode { get; set; }
        public List<VideoEncodeROI> VideoEncodeROI { get; set; }
        public List<ChannelTitle> ChannelTitle { get; set; }
        public string VideoStandard { get; set; }
        public List<VideoWidget> VideoWidget { get; set; }
        public List<VideoInOption> VideoInOptions { get; set; }
    }

    public class ConfigTableResponse
    {
        [JsonProperty("table")]
        public ConfigTable Table { get; set; }
    }

    public class NestedArray
    {
        public List<string> Items { get; set; }

        public string this[int index]
        {
            get { return Items[index]; }
        }
    }
}
