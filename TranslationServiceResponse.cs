using System.Text.Json.Serialization;

namespace FunTranslations
{
    public class TranslationServiceResponse
    {
        [JsonPropertyName("success")]
        Success Success { get; set; }

        [JsonPropertyName("contents")]
        public Contents Contents { get; set; }
    }

    public class Success
    {
        public int total { get; set; }
    }

    public class Contents
    {
        public string translated { get; set; }
        public string text { get; set; }
        public string translation { get; set; }
    }
}
