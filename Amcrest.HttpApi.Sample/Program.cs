namespace Amcrest.HttpApi.Sample
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Unosquare.Swan;
    using Amcrest.HttpApi.Models;
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            var exitRequested = new ManualResetEvent(false);
            var cam = new AmcrestConnection();
            cam.Connect(new Uri("http://192.168.137.183/"), "admin", "pass.word1");
            var audioBytesReceived = 0;

            var rtspConfig = cam.GetConfigRtsp().Result;
            var rtspMonUri = cam.GetRtspMonitorUri().Result;
            return;
            var audioReceiveTask = Task.Run(async () =>
            {
                var audioStream = await cam.ReceiveAudioStream();
                var lastBytesReceived = 0;
                var payload = new byte[4096];
                using (var fileStream = new FileStream(@"C:\users\unosp\desktop\audio.aac", FileMode.OpenOrCreate, FileAccess.Write))
                {
                    while (exitRequested.WaitOne(0) == false)
                    {
                        lastBytesReceived = await audioStream.Stream.ReadAsync(payload, 0, payload.Length);
                        audioBytesReceived += lastBytesReceived;
                        await fileStream.WriteAsync(payload, 0, lastBytesReceived);
                    }
                }

                audioStream.Stream.Close();
            });

            var ptzStatusTask = Task.Run(async () =>
            {
                while (exitRequested.WaitOne(100) == false)
                {
                    try
                    {
                        var status = (await cam.GetPtzStatus()).Status;
                        var pos = new Tuple<int, int>(Console.CursorLeft, Console.CursorTop);
                        Console.SetCursorPosition(0, 1);
                        Console.WriteLine($"X: {status.PositionX,6}    Z: {status.PositionY,6}    Z: {status.PositionZ,6}    AIn: {audioBytesReceived}");
                        Console.SetCursorPosition(pos.Item1, pos.Item2);
                    }
                    catch (Exception ex)
                    {
                        Console.SetCursorPosition(0, 1);
                        Console.WriteLine(ex.Message);
                    }
                }
            });

            var inputTask = Task.Run(async () =>
            {

                //var resp = await cam.GetResponseText("/cgi-bin/ptz.cgi?action=start&channel=0&code=Up&arg1=0&arg2=1&arg3=0");
                const int speed = 1;

                while (true)
                {
                    Console.Clear();
                    Console.SetCursorPosition(0, 2);
                    var prompt = Terminal.ReadPrompt("PTZ", new Dictionary<ConsoleKey, string>
                    {
                        { ConsoleKey.LeftArrow, "LEFT" },
                        { ConsoleKey.RightArrow, "RIGHT" },
                        { ConsoleKey.R, "RESET" },
                    }, "Exit");

                    if (prompt.Key == ConsoleKey.LeftArrow)
                    {
                        var move = cam.PtzControl(PtzControlCommand.Left, PtzControlAction.Start, 0, speed);
                    }
                    else if (prompt.Key == ConsoleKey.RightArrow)
                    {
                        var move = cam.PtzControl(PtzControlCommand.Right, PtzControlAction.Start, 0, speed);
                    }
                    else if (prompt.Key == ConsoleKey.UpArrow)
                    {
                        var move = cam.PtzControl(PtzControlCommand.Up, PtzControlAction.Start, 0, speed);
                    }
                    else if (prompt.Key == ConsoleKey.DownArrow)
                    {
                        var move = cam.PtzControl(PtzControlCommand.Down, PtzControlAction.Start, 0, speed);
                    }
                    else if (prompt.Key == ConsoleKey.S)
                    {
                        var move = await cam.PtzControl(PtzControlCommand.Up, PtzControlAction.Stop);
                    }
                    else if (prompt.Key == ConsoleKey.Escape)
                    {
                        exitRequested.Set();
                        break;
                    }
                }

                cam.Dispose();
            });


            while (exitRequested.WaitOne(100) == false)
            {
                // placeholder
            }
        }
    }





}
