using System;
using System.Collections.Generic;
using System.Text;

namespace Shortener
{
    public class ShortLink
    {
        public string Code { get; private set; }
        public string Url { get; private set; }

        private ShortLink(string code, string url)
        {
            Code = code;
            Url = url;
        }

        public static ShortLink Create(string code, string url)
        {
            if (string.IsNullOrWhiteSpace(code))
                throw new ArgumentException("Code is required");

            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException("Url is required");

            return new ShortLink(code, url);
        }
    }
}
