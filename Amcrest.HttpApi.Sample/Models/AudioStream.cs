using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Amcrest.HttpApi.Models
{
    public class AudioStream
    {
        public AudioStream(Stream stream, string mediaType)
        {
            Stream = stream;
            MediaType = mediaType;
        }

        public Stream Stream { get; }
        public string MediaType { get; }
    }
}
