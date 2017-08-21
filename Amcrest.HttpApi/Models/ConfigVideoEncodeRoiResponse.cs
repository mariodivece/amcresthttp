namespace Amcrest.HttpApi.Models
{
    public class VideoEncodeROI
    {
        public bool DynamicTrack { get; set; }
        public bool Extra1 { get; set; }
        public bool Extra2 { get; set; }
        public bool Extra3 { get; set; }
        public bool Main { get; set; }
        public int Quality { get; set; }
        public bool Snapshot { get; set; }
    }
}
