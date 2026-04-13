namespace URLShortener.Entities
{
    public class ShortLink
    {
        public string Code { get;private set; }
        public string Url { get; set; }

        public string GenerateCode() {
            while (true) {

                Code = CreateRandomCode();

                if (!Exists(Code))
                    return Code;
            }
        }

        public string CreateRandomCode()
        {

        }

        public bool Exists(string code) { 
        }


        public void CreateShortLink(string Url) { }
    }
}
