using System;
using System.Collections.Generic;
using System.Text;

namespace Amcrest.HttpApi.Models
{
    public class VideoWidgetChannelTitle
    {
        public List<int> BackColor { get; set; }
        public bool EncodeBlend { get; set; }
        public List<int> FrontColor { get; set; }
        public bool PreviewBlend { get; set; }
        public List<int> Rect { get; set; }
    }

    public class VideoWidgetCover
    {
        public List<int> BackColor { get; set; }
        public bool EncodeBlend { get; set; }
        public List<int> FrontColor { get; set; }
        public bool PreviewBlend { get; set; }
        public List<int> Rect { get; set; }
    }

    public class VideoWidgetCustomTitle
    {
        public List<int> BackColor { get; set; }
        public bool EncodeBlend { get; set; }
        public List<int> FrontColor { get; set; }
        public bool PreviewBlend { get; set; }
        public List<int> Rect { get; set; }
        public string Text { get; set; }
    }

    public class VideoWidgetOSDMobileState
    {
        public List<int> BackColor { get; set; }
        public bool EncodeBlend { get; set; }
        public List<int> FrontColor { get; set; }
        public bool PreviewBlend { get; set; }
        public List<int> Rect { get; set; }
    }

    public class VideoWidgetPTZCoordinates
    {
        public List<int> BackColor { get; set; }
        public int DisplayTime { get; set; }
        public bool EncodeBlend { get; set; }
        public List<int> FrontColor { get; set; }
        public bool PreviewBlend { get; set; }
        public List<int> Rect { get; set; }
    }

    public class VideoWidgetPTZDirection
    {
        public List<int> BackColor { get; set; }
        public int DisplayTime { get; set; }
        public bool EncodeBlend { get; set; }
        public List<int> FrontColor { get; set; }
        public bool PreviewBlend { get; set; }
        public List<int> Rect { get; set; }
    }

    public class VideoWidgetPTZOSDMenu
    {
        public List<int> BackColor { get; set; }
        public int DisplayTime { get; set; }
        public bool EncodeBlend { get; set; }
        public List<int> FrontColor { get; set; }
        public bool PreviewBlend { get; set; }
        public List<int> Rect { get; set; }
    }

    public class VideoWidgetPTZOSDMenuViaApp
    {
        public List<int> BackColor { get; set; }
        public int DisplayTime { get; set; }
        public bool EncodeBlend { get; set; }
        public bool EncodeBlendExtra1 { get; set; }
        public bool EncodeBlendExtra2 { get; set; }
        public List<int> FrontColor { get; set; }
        public bool PreviewBlend { get; set; }
        public List<int> Rect { get; set; }
    }

    public class VideoWidgetPTZPreset
    {
        public List<int> BackColor { get; set; }
        public int DisplayTime { get; set; }
        public bool EncodeBlend { get; set; }
        public List<int> FrontColor { get; set; }
        public bool PreviewBlend { get; set; }
        public List<int> Rect { get; set; }
    }

    public class VideoWidgetPTZZoom
    {
        public List<int> BackColor { get; set; }
        public int DisplayTime { get; set; }
        public bool EncodeBlend { get; set; }
        public List<int> FrontColor { get; set; }
        public bool PreviewBlend { get; set; }
        public List<int> Rect { get; set; }
    }

    public class VideoWidgetPictureTitle
    {
        public List<int> BackColor { get; set; }
        public bool EncodeBlend { get; set; }
        public List<int> FrontColor { get; set; }
        public int Height { get; set; }
        public string Name { get; set; }
        public bool PreviewBlend { get; set; }
        public List<int> Rect { get; set; }
        public int Width { get; set; }
    }

    public class VideoWidgetPtzPattern
    {
        public List<int> BackColor { get; set; }
        public int DisplayTime { get; set; }
        public bool EncodeBlend { get; set; }
        public List<int> FrontColor { get; set; }
        public bool PreviewBlend { get; set; }
        public List<int> Rect { get; set; }
    }

    public class VideoWidgetPtzRS485Detect
    {
        public List<int> BackColor { get; set; }
        public int DisplayTime { get; set; }
        public bool EncodeBlend { get; set; }
        public List<int> FrontColor { get; set; }
        public bool PreviewBlend { get; set; }
        public List<int> Rect { get; set; }
    }

    public class VideoWidgetTemperature
    {
        public List<int> BackColor { get; set; }
        public int DisplayTime { get; set; }
        public bool EncodeBlend { get; set; }
        public List<int> FrontColor { get; set; }
        public bool PreviewBlend { get; set; }
        public List<int> Rect { get; set; }
        public string TemperatureUnit { get; set; }
    }

    public class VideoWidgetTimeTitle
    {
        public List<int> BackColor { get; set; }
        public bool EncodeBlend { get; set; }
        public List<int> FrontColor { get; set; }
        public bool PreviewBlend { get; set; }
        public List<int> Rect { get; set; }
        public bool ShowWeek { get; set; }
        public string WeekPosition { get; set; }
    }

    public class VideoWidgetVoltageStatus
    {
        public List<int> BackColor { get; set; }
        public int DisplayTime { get; set; }
        public bool EncodeBlend { get; set; }
        public List<int> FrontColor { get; set; }
        public bool PreviewBlend { get; set; }
        public List<int> Rect { get; set; }
    }

    public class VideoWidget
    {
        public VideoWidgetChannelTitle ChannelTitle { get; set; }
        public List<VideoWidgetCover> Covers { get; set; }
        public List<VideoWidgetCustomTitle> CustomTitle { get; set; }
        public int FontSize { get; set; }
        public int FontSizeExtra1 { get; set; }
        public int FontSizeExtra2 { get; set; }
        public int FontSizeExtra3 { get; set; }
        public int FontSizeScale { get; set; }
        public int FontSizeSnapshot { get; set; }
        public VideoWidgetOSDMobileState OSDMobileState { get; set; }
        public VideoWidgetPTZCoordinates PTZCoordinates { get; set; }
        public VideoWidgetPTZDirection PTZDirection { get; set; }
        public VideoWidgetPTZOSDMenu PTZOSDMenu { get; set; }
        public VideoWidgetPTZOSDMenuViaApp PTZOSDMenuViaApp { get; set; }
        public VideoWidgetPTZPreset PTZPreset { get; set; }
        public VideoWidgetPTZZoom PTZZoom { get; set; }
        public VideoWidgetPictureTitle PictureTitle { get; set; }
        public VideoWidgetPtzPattern PtzPattern { get; set; }
        public VideoWidgetPtzRS485Detect PtzRS485Detect { get; set; }
        public VideoWidgetTemperature Temperature { get; set; }
        public VideoWidgetTimeTitle TimeTitle { get; set; }
        public VideoWidgetVoltageStatus VoltageStatus { get; set; }
        public int WideHeightRatio { get; set; }
    }
}
