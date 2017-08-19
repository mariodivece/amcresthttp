namespace Armcrest.HttpApi.Sample.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class PtzStatus
    {
        public string MoveStatus { get; set; }
        public int PTS { get; set; }
        public List<string> Postion { get; set; }
        public int PresetID { get; set; }
        public int Sequence { get; set; }
        public int UTC { get; set; }
        public string ZoomStatus { get; set; }

        public decimal PositionX { get { return decimal.Parse(Postion[0]); } }
        public decimal PositionY { get { return decimal.Parse(Postion[1]); } }
        public decimal Zoom { get { return decimal.Parse(Postion[2]); } }
    }

    public class PtzStatusResponse
    {
        [JsonProperty("status")]
        public PtzStatus Status { get; set; }
    }
}
