using System;
using System.Collections.Generic;
using System.Text;

namespace Amcrest.HttpApi.Models
{
    public class VideoInDuskOptions
    {
        public int ExternalSyncPhase { get; set; }
    }

    public class VideoInFishEye
    {
        public string CalibrateMode { get; set; }
        public List<int> Center { get; set; }
        public string Direction { get; set; }
        public int PlaceHolder { get; set; }
        public int Radius { get; set; }
    }

    public class VideoInFlashControl
    {
        public int DutyCycle { get; set; }
        public int FrequencyMultiple { get; set; }
        public int Mode { get; set; }
        public int Pole { get; set; }
        public int PreValue { get; set; }
        public int Value { get; set; }
    }

    public class VideoInTemporaryConfigs
    {
        public int AntiFlicker { get; set; }
        public int ExposureMode { get; set; }
        public string ExposureValue1 { get; set; }
        public int ExposureValue2 { get; set; }
        public int GainMax { get; set; }
        public int GainMin { get; set; }
    }

    public class VideoInOptionParams
    {
        public int AlarmDayNightColorMode { get; set; }
        public int AntiFlicker { get; set; }
        public int Backlight { get; set; }
        public List<int> BacklightRegion { get; set; }
        public int BrightnessThreshold { get; set; }
        public int ColorTemperatureLevel { get; set; }
        public int DayNightColor { get; set; }
        public int DayNightSensitivity { get; set; }
        public int DayNightSwitchDelay { get; set; }
        public int DoubleExposure { get; set; }
        public int ExposureCompensation { get; set; }
        public int ExposureIris { get; set; }
        public int ExposureMode { get; set; }
        public int ExposureSpeed { get; set; }
        public int ExposureValue1 { get; set; }
        public int ExposureValue2 { get; set; }
        public string ExternalSyncPhase { get; set; }
        public bool Flip { get; set; }
        public int FocusMode { get; set; }
        public int Gain { get; set; }
        public bool GainAuto { get; set; }
        public int GainBlue { get; set; }
        public int GainGreen { get; set; }
        public int GainMax { get; set; }
        public int GainMin { get; set; }
        public int GainRed { get; set; }
        public int GlareInhibition { get; set; }
        public bool InfraRed { get; set; }
        public int InfraRedLevel { get; set; }
        public bool IrisAuto { get; set; }
        public int IrisAutoSensitivity { get; set; }
        public bool Mirror { get; set; }
        public int Profile { get; set; }
        public int ReferenceLevel { get; set; }
        public int Rotate90 { get; set; }
        public int SunriseHour { get; set; }
        public int SunriseMinute { get; set; }
        public int SunriseSecond { get; set; }
        public int SunsetHour { get; set; }
        public int SunsetMinute { get; set; }
        public int SunsetSecond { get; set; }
        public int SwitchMode { get; set; }
        public VideoInTemporaryConfigs TemporaryConfigs { get; set; }
        public string WhiteBalance { get; set; }
        public List<int> WhiteBalanceDatumRect { get; set; }
        public int WideDynamicRange { get; set; }
        public int WideDynamicRangeMode { get; set; }
    }

    public class VideoInSnapshot
    {
        public int ColorTemperatureLevel { get; set; }
        public int ExposureSpeed { get; set; }
        public string ExposureValue1 { get; set; }
        public string ExposureValue2 { get; set; }
        public int Gain { get; set; }
        public bool GainAuto { get; set; }
        public int GainBlue { get; set; }
        public int GainGreen { get; set; }
        public int GainRed { get; set; }
        public string WhiteBalance { get; set; }
    }

    public class VideoInOption
    {
        public int AlarmDayNightColorMode { get; set; }
        public int AntiFlicker { get; set; }
        public bool AutoSyncPhase { get; set; }
        public int Backlight { get; set; }
        public List<int> BacklightRegion { get; set; }
        public int ColorTemperatureLevel { get; set; }
        public int DayNightColor { get; set; }
        public int DayNightSensitivity { get; set; }
        public int DayNightSwitchDelay { get; set; }
        public int DoubleExposure { get; set; }
        public VideoInDuskOptions DuskOptions { get; set; }
        public int ExposureCompensation { get; set; }
        public int ExposureIris { get; set; }
        public int ExposureMode { get; set; }
        public int ExposureSpeed { get; set; }
        public int ExposureValue1 { get; set; }
        public int ExposureValue2 { get; set; }
        public int ExternalSync { get; set; }
        public string ExternalSyncPhase { get; set; }
        public VideoInFishEye FishEye { get; set; }
        public VideoInFlashControl FlashControl { get; set; }
        public bool Flip { get; set; }
        public int FocusMode { get; set; }
        public List<int> FocusRect { get; set; }
        public int Gain { get; set; }
        public bool GainAuto { get; set; }
        public int GainBlue { get; set; }
        public int GainGreen { get; set; }
        public int GainMax { get; set; }
        public int GainMin { get; set; }
        public int GainRed { get; set; }
        public int GlareInhibition { get; set; }
        public bool InfraRed { get; set; }
        public int InfraRedLevel { get; set; }
        public bool IrisAuto { get; set; }
        public int IrisAutoSensitivity { get; set; }
        public bool Mirror { get; set; }
        public VideoInOptionParams NightOptions { get; set; }
        public VideoInOptionParams NormalOptions { get; set; }
        public int ReferenceLevel { get; set; }
        public bool ReferenceLevelEnable { get; set; }
        public int Rotate90 { get; set; }
        public string SignalFormat { get; set; }
        public VideoInSnapshot Snapshot { get; set; }
        public VideoInTemporaryConfigs TemporaryConfigs { get; set; }
        public string WhiteBalance { get; set; }
        public List<int> WhiteBalanceDatumRect { get; set; }
        public int WideDynamicRange { get; set; }
        public int WideDynamicRangeMode { get; set; }
    }
}
