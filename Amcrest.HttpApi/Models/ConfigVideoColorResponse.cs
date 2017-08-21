namespace Amcrest.HttpApi.Models
{
    using System.Collections.Generic;

    public class VideoColorItem
    {
        public int Brightness { get; set; }
        public int ChromaSuppress { get; set; }
        public int Contrast { get; set; }
        public int Gamma { get; set; }
        public int Hue { get; set; }
        public int Saturation { get; set; }
        public string Style { get; set; }
        public string TimeSection { get; set; }
    }

    public class VideoColor
    {
        public List<VideoColorItem> Items { get; set; }
    }
}
