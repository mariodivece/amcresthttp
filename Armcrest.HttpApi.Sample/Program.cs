namespace Armcrest.HttpApi.Sample
{
    using Armcrest.HttpApi.Sample.Models;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Unosquare.Swan;


    class Program
    {
        static void Main(string[] args)
        {

            var task = Task.Run(async () =>
            {
                var cam = new AmcrestCamera();
                cam.Connect(new Uri("http://192.168.137.183/"), "admin", "pass.word1");
                var config = await cam.GetEncodeConfig();
                config.Dump(nameof(Program));

                const int delay = 150;
                const int speed = 8;

                while (true)
                {
                    PtzStatus ptzStatus = null;

                    var prompt = Terminal.ReadPrompt("PTZ", new Dictionary<ConsoleKey, string>
                    {
                        { ConsoleKey.LeftArrow, "LEFT" },
                        { ConsoleKey.RightArrow, "RIGHT" },
                        { ConsoleKey.R, "RESET" },
                    }, "Exit");

                    if (prompt.Key == ConsoleKey.LeftArrow)
                    {
                        ptzStatus = await cam.PtzControlMove(PtzControlCommand.Left, delay, speed);
                    }
                    else if (prompt.Key == ConsoleKey.RightArrow)
                    {
                        ptzStatus = await cam.PtzControlMove(PtzControlCommand.Right, delay, speed);
                    }
                    else if (prompt.Key == ConsoleKey.UpArrow)
                    {
                        ptzStatus = await cam.PtzControlMove(PtzControlCommand.Up, delay, speed);
                    }
                    else if (prompt.Key == ConsoleKey.DownArrow)
                    {
                        ptzStatus = await cam.PtzControlMove(PtzControlCommand.Down, delay, speed);
                    }
                    else if (prompt.Key == ConsoleKey.Escape)
                    {
                        break;
                    }

                    if (ptzStatus != null)
                    $"Camera Position - X: {ptzStatus.PositionX,6}   Y: {ptzStatus.PositionY,6}    Z: {ptzStatus.Zoom,6}".Info();
                }

            });

            var mre = new ManualResetEvent(false);
            while (mre.WaitOne(100) == false)
            {
                // placeholder
            }
        }
    }


    public class AmcrestCamera
    {
        private const int DefaultChannel = 1;
        public Uri BaseAddress { get; private set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public void Connect(Uri baseAddress, string username, string password)
        {
            BaseAddress = baseAddress;
            Username = username;
            Password = password;
        }

        public async Task<ConfigCapsResponse> GetEncodeConfig(int channel = DefaultChannel)
        {
            var endpoint = $"/cgi-bin/encode.cgi?action=getConfigCaps&channel={channel}";
            var responseText = await GetResponseText(endpoint);
            return Node.FromFormData<ConfigCapsResponse>(responseText);
        }

        public async Task<PtzStatusResponse> GetPtzStatus(int channel = DefaultChannel)
        {
            var endpoint = $"/cgi-bin/ptz.cgi?action=getStatus&channel={channel}";
            var responseText = await GetResponseText(endpoint);
            return Node.FromFormData<PtzStatusResponse>(responseText);
        }

        public async Task<PtzStatus> PtzControlMove(PtzControlCommand command, int delay, int speed = 4)
        {
            await PtzControl(command, PtzControlAction.Start, 0, speed);
            await Task.Delay(delay);
            await PtzControl(PtzControlCommand.Left, PtzControlAction.Stop);
            //var ptz = await GetPtzStatus();
            return null;
        }

        public async Task<string> PtzControl(
            PtzControlCommand command, PtzControlAction action, decimal arg1 = 0, decimal arg2 = 0, decimal arg3 = 0, decimal arg4 = 0, int channel = DefaultChannel)
        {
            var endpoint = $"cgi-bin/ptz.cgi?action={action.ToString().ToLowerInvariant()}" + 
                $"&channel={channel}&code={command}&arg1={arg1}&arg2={arg2}&arg3={arg3}&arg4={arg4}";
            var responseText = await GetResponseText(endpoint);
            return responseText;
        }

        #region Helper Methods

        internal async Task<string> GetResponseText(string path)
        {
            using (var handler = CreateHandler())
            using (var client = new HttpClient(handler))
            {
                var targetUri = new Uri(BaseAddress, path);
                var httpResponse = await client.GetAsync(targetUri);
                return await httpResponse.Content.ReadAsStringAsync();
            }
        }

        internal async Task<string> GetResponseJson(string path)
        {
            var text = await GetResponseText(path);
            return Node.FromFormData(text).ToJson();
        }

        private HttpClientHandler CreateHandler()
        {
            return new HttpClientHandler
            {
                Credentials = new NetworkCredential(Username, Password)
            };
        }


        #endregion

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
