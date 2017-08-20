namespace Amcrest.HttpApi.Models
{
    public enum ErrorCode
    {
        None = -1,
        InvalidAuthority = 0,
        RequestParseErrror = 1,
        InvalidRequest = 2,
        MethodNotFound = 3,
        InvalidParameter = 4,
        InternalServerError = 5,
        RequestTimeout = 6,
        KeepAliveFailed = 7,
    }
    public enum PtzControlAction
    {
        Start,
        Stop
    }

    public enum PtzControlCommand
    {
        Up,
        Down,
        Left,
        Right,
        ZoomWide,
        ZoomTele,
        FocusNear,
        FocusFar,
        IrisLarge,
        IrisSmall,
        GotoPreset,
        SetPreset,
        ClearPreset,
        StartTour,
        StopTour,
        LeftUp,
        RightUp,
        LeftDown,
        RightDown,
        AddTour,
        DelTour,
        ClearTour,
        AutoPanOn,
        AutoPanOff,
        SetLeftLimit,
        SetRightLimit,
        AutoScanOn,
        AutoScanOff,
        SetPatternBegin,
        SetPatternEnd,
        StartPattern,
        StopPattern,
        ClearPattern,
        AlarmSearch,
        Position,
        AuxOn,
        AuxOff,
        Menu,
        Exit,
        Enter,
        MenuUp,
        MenuDown,
        MenuLeft,
        MenuRight,
        Reset,
        LightController,
        PositionABS,
        PositionReset,
        Continuously
    }
}
