namespace Amcrest.HttpApi
{
    using Amcrest.HttpApi.Models;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class AmcrestConnection : IDisposable
    {
        private const int DefaultChannel = 1;
        private const int DefaultStreamType = 0;

        private bool IsDisposed = false;

        #region Properties

        public Uri BaseAddress { get; private set; }

        public string Username { get; private set; }
        public string Password { get; private set; }

        public bool IsConnected
        {
            get
            {
                try
                {
                    if (Client == null || ClientHandler == null) return false;
                    var currentTime = GetCurrentTime().Result;
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public HttpClient Client { get; private set; }

        public HttpClientHandler ClientHandler { get; private set; }

        #endregion

        #region Constructor

        public AmcrestConnection()
        {
            // placeholder
        }

        public bool Connect(Uri baseAddress, string username, string password)
        {
            BaseAddress = baseAddress;
            Username = username;
            Password = password;
            InitializeClient();
            return IsConnected;
        }

        #endregion

        public async Task<Uri> GetRtspMonitorUri(int channel = DefaultChannel, int subType = DefaultStreamType)
        {
            var rtspConfig = await GetConfigRtsp();
            return new Uri(
                $"rtsp://{Username}:{Password}@{BaseAddress.Host}:{rtspConfig.Port}/cam/realmonitor?channel={channel}&subtype={subType}");
        }

        public async Task<RtspConfig> GetConfigRtsp()
        {
            var httpResponse = await Client.GetAsync(BuildTargetUri(
                $"/cgi-bin/configManager.cgi?action=getConfig&name=RTSP"));
            var config = await Response.CreateAsync<ConfigTableResponse>(httpResponse);
            return config.Table.RTSP;
        }

        public async Task<List<SnapConfig>> GetConfigSnap()
        {
            var httpResponse = await Client.GetAsync(BuildTargetUri(
                $"/cgi-bin/configManager.cgi?action=getConfig&name=Snap"));
            var config = await Response.CreateAsync<ConfigTableResponse>(httpResponse);
            return config.Table.Snap;
        }

        public async Task<List<VideoColor>> GetConfigVideoColor()
        {
            var httpResponse = await Client.GetAsync(BuildTargetUri(
                $"/cgi-bin/configManager.cgi?action=getConfig&name=VideoColor"));

            var config = await Response.CreateAsync<ConfigTableResponse>(httpResponse);
            return config.Table.VideoColor;
        }

        public async Task<List<Encode>> GetConfigEncode()
        {
            var httpResponse = await Client.GetAsync(BuildTargetUri(
                $"/cgi-bin/configManager.cgi?action=getConfig&name=Encode"));

            var config = await Response.CreateAsync<ConfigTableResponse>(httpResponse);
            return config.Table.Encode;
        }

        public async Task<List<VideoEncodeROI>> GetConfigVideoEncodeROI()
        {
            var httpResponse = await Client.GetAsync(BuildTargetUri(
                $"/cgi-bin/configManager.cgi?action=getConfig&name=VideoEncodeROI"));

            var config = await Response.CreateAsync<ConfigTableResponse>(httpResponse);
            return config.Table.VideoEncodeROI;
        }

        public async Task<List<ChannelTitle>> GetConfigChannelTitle()
        {
            var httpResponse = await Client.GetAsync(BuildTargetUri(
                $"/cgi-bin/configManager.cgi?action=getConfig&name=ChannelTitle"));

            var config = await Response.CreateAsync<ConfigTableResponse>(httpResponse);
            return config.Table.ChannelTitle;
        }

        public async Task<string> GetConfigVideoStandard()
        {
            var httpResponse = await Client.GetAsync(BuildTargetUri(
                $"/cgi-bin/configManager.cgi?action=getConfig&name=VideoStandard"));

            var config = await Response.CreateAsync<ConfigTableResponse>(httpResponse);
            return config.Table.VideoStandard;
        }

        public async Task<List<VideoWidget>> GetConfigVideoWidget()
        {
            var httpResponse = await Client.GetAsync(BuildTargetUri(
                $"/cgi-bin/configManager.cgi?action=getConfig&name=VideoWidget"));

            var config = await Response.CreateAsync<ConfigTableResponse>(httpResponse);
            return config.Table.VideoWidget;
        }

        public async Task<List<VideoInOption>> GetConfigVideoInOptions()
        {
            var httpResponse = await Client.GetAsync(BuildTargetUri(
                $"/cgi-bin/configManager.cgi?action=getConfig&name=VideoInOptions"));

            var config = await Response.CreateAsync<ConfigTableResponse>(httpResponse);
            return config.Table.VideoInOptions;
        }

        public async Task<string> GetConfigJson(string tableName)
        {
            var httpResponse = await Client.GetAsync(BuildTargetUri(
                $"/cgi-bin/configManager.cgi?action=getConfig&name={tableName}"));

            return await GetResponseJson(httpResponse);
        }

        public async Task<DateTime> GetCurrentTime()
        {
            var httpResponse = await Client.GetAsync(BuildTargetUri(
                $"/cgi-bin/global.cgi?action=getCurrentTime"));
            var response = await Response.CreateAsync<KeyValueResponse>(httpResponse);
            return DateTime.Parse(response.Value);
        }

        public async Task<ConfigEncodeCapsResponse> GetConfigEncodeCaps(int channel = DefaultChannel)
        {
            var httpResponse = await Client.GetAsync(BuildTargetUri(
                $"/cgi-bin/encode.cgi?action=getConfigCaps&channel={channel}"));
            return await Response.CreateAsync<ConfigEncodeCapsResponse>(httpResponse);
        }

        public async Task<PtzStatusResponse> GetPtzStatus(int channel = DefaultChannel)
        {
            var httpResponse = await Client.GetAsync(BuildTargetUri(
                $"/cgi-bin/ptz.cgi?action=getStatus&channel={channel}"));
            return await Response.CreateAsync<PtzStatusResponse>(httpResponse);
        }

        public async Task<bool> PtzControl(
            PtzControlCommand command, PtzControlAction action, decimal arg1 = 0, decimal arg2 = 0, decimal arg3 = 0, decimal arg4 = 0, int channel = DefaultChannel)
        {
            var httpResponse = await Client.GetAsync(BuildTargetUri(
                $"cgi-bin/ptz.cgi?action={action.ToString().ToLowerInvariant()}" +
                $"&channel={channel}&code={command}&arg1={arg1}&arg2={arg2}&arg3={arg3}&arg4={arg4}"));
            return await Response.CreateAsync<bool>(httpResponse);
        }

        public async Task<AudioStream> ReceiveAudioStream(int channel = DefaultChannel)
        {
            var httpResponse = await Client.GetAsync(BuildTargetUri(
                $"cgi-bin/audio.cgi?action=getAudio&httptype=singlepart&channel={channel}"), 
                HttpCompletionOption.ResponseHeadersRead);

            var contentType = httpResponse.Content.Headers.ContentType.MediaType;
            var stream = await httpResponse.Content.ReadAsStreamAsync();
            return new AudioStream(stream, contentType);
        }

        #region Helper Methods

        private Uri BuildTargetUri(string relativePath)
        {
            return new Uri(BaseAddress, relativePath);
        }

        internal async Task<string> GetResponseText(HttpResponseMessage httpResponse)
        {
            return await httpResponse.Content.ReadAsStringAsync();
        }

        internal async Task<string> GetResponseText(string path)
        {
            var httpResponse = await Client.GetAsync(BuildTargetUri(path));
            return await GetResponseText(httpResponse);
        }

        internal async Task<string> GetResponseJson(HttpResponseMessage httpResponse)
        {
            var text = await GetResponseText(httpResponse);
            return Node.FromFormData(text).ToJson();
        }

        internal async Task<string> GetResponseJson(string path)
        {
            var text = await GetResponseText(path);
            return Node.FromFormData(text).ToJson();
        }

        private void InitializeClient()
        {
            DestroyClient();
            ClientHandler = new HttpClientHandler { Credentials = new NetworkCredential(Username, Password) };
            Client = new HttpClient(ClientHandler);
            Client.DefaultRequestHeaders.Add("Connection", "keep-alive");
            Client.DefaultRequestHeaders.Add("Keep-Alive", "600");
        }

        private void DestroyClient()
        {
            Client?.CancelPendingRequests();
            Client?.Dispose();
            Client = null;

            ClientHandler?.Dispose();
            ClientHandler = null;
        }

        #endregion

        #region IDisposable Support

        protected virtual void Dispose(bool alsoManaged)
        {
            if (!IsDisposed)
            {
                if (alsoManaged)
                {
                    DestroyClient();
                }

                IsDisposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        #endregion

    }

}
