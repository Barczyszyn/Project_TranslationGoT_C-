using RestSharp;
using System.Text.Json;

namespace FunTranslations
{
    public class TranslationService
    {
        private ApiClient _client;
        private string _urlBase;


        public TranslationService(string baseUrl)
        {
            this._client = new ApiClient(baseUrl);
            this._urlBase = baseUrl;
        }

        public async Task<string> Translate(string text)
        {
            var request = new RestRequest(_urlBase, Method.Get);
            request.AddQueryParameter("text", text);

            string response = await _client.ExecuteAsync(request);
            var translationResponse = JsonSerializer.Deserialize<TranslationServiceResponse>(response);

            return translationResponse.Contents.translated;
        }
    }
}
