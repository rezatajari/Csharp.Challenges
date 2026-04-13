namespace URLShortener.Entities
{
    public class ShortLink
    {

        private static readonly char[] Alphabet=
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();

        private static readonly Random Random = new Random();

        private readonly List<string> Codes = new List<string>();

        public string Code { get;private set; }
        public string Url { get; set; }

        public string GenerateCode() {
            while (true) {

                Code = CreateRandomCode();

                Codes.Add(Code);

                if (!Codes.Any(c => c == Code))
                    return Code;
            }
        }

         string CreateRandomCode(int length=6)
        {
            var result=new char[length];

            for(int i = 0; i < length; i++)
            {
                result[i] = Alphabet[Random.Next(Alphabet.Length)];
            }

            return new string(result);
        }

        public void CreateShortLink(string Url) { }
    }
}
