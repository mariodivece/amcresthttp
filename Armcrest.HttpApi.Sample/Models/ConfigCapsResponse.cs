namespace Armcrest.HttpApi.Sample.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class MediaFormatItem
    {
        [JsonProperty("resolution")]
        public string Resolution { get; set; }
        public string BitRateOptions { get; set; }
        public string CompressionTypes { get; set; }
        public int FPSMax { get; set; }
        public List<string> H264Profile { get; set; }
        public int MaxROICount { get; set; }
        public string ResolutionTypes { get; set; }
    }

    public class MediaFormat
    {
        public MediaFormatItem Audio { get; set; }
        public MediaFormatItem Video { get; set; }
        public bool SupportIndividualResolution { get; set; }
    }

    public class Cap
    {
        public List<MediaFormat> ExtraFormat { get; set; }
        public List<MediaFormat> MainFormat { get; set; }
        public List<MediaFormat> SnapFormat { get; set; }
    }

    public class ConfigCapsResponse
    {
        [JsonProperty("caps")]
        public List<Cap> Caps { get; set; }
    }
}
