using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Amcrest.HttpApi.Models
{
    public class AudioEncodeInfo
    {
        public int Bitrate { get; set; }
        public List<int> Channels { get; set; }
        public string Compression { get; set; }
        public int Depth { get; set; }
        public int Frequency { get; set; }
        public string Pack { get; set; }
        public int Mode { get; set; }
    }

    public class VideoEncodeInfo
    {
        [JsonProperty("resolution")]
        public string Resolution { get; set; }
        public int BitRate { get; set; }
        public string BitRateControl { get; set; }
        public string Compression { get; set; }
        public string CustomResolutionName { get; set; }
        public int FPS { get; set; }
        public int GOP { get; set; }
        public int Height { get; set; }
        public string Pack { get; set; }
        public int Priority { get; set; }
        public string Profile { get; set; }
        public int Quality { get; set; }
        public int QualityRange { get; set; }
        public int SVCTLayer { get; set; }
        public int Width { get; set; }
    }

    public class MediaEncodeInfo
    {
        public AudioEncodeInfo Audio { get; set; }
        public bool AudioEnable { get; set; }
        public VideoEncodeInfo Video { get; set; }
        public bool VideoEnable { get; set; }
    }

    public class Encode
    {
        public List<MediaEncodeInfo> ExtraFormat { get; set; }
        public List<MediaEncodeInfo> MainFormat { get; set; }
        public List<MediaEncodeInfo> SnapFormat { get; set; }
    }
}
