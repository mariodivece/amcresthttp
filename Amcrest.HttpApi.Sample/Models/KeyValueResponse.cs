namespace Amcrest.HttpApi.Models
{
    using System;

    public class KeyValueResponse
    {
        public KeyValueResponse(string responseText)
        {
            var parts = responseText.Split('=', StringSplitOptions.RemoveEmptyEntries);
            Key = (parts.Length >= 1) ? parts[0]?.Trim() : string.Empty;
            Value = parts.Length >= 2 ? parts[1]?.Trim() : string.Empty;
        }

        public string Key { get; }
        public string Value { get; }
    }
}
