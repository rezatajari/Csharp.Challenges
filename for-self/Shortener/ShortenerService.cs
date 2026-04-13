using System;
using System.Collections.Generic;
using System.Text;

namespace Shortener
{
    internal class ShortenerService
    {
        private readonly Dictionary<string, ShortLink> _store = new();
        public ShortLink Create(string url)
        {
            string code;

            do
            {
                code = GenerateCode();
            } while (_store.ContainsKey(code));

            var shortLink = ShortLink.Create(code, url);

            _store.Add(code, shortLink);

            return shortLink;
        }

        public string? Resolve(string code)
        {
            return _store.TryGetValue(code, out var link)
                ? link.Url
                : null;
        }

        private string GenerateCode()
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();

            var result = new char[6];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = chars[random.Next(chars.Length)];
            }

            return new string(result);
        }
    }
}
