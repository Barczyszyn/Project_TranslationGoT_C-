using RestSharp;

namespace FunTranslations
{
    public class ApiClient
    {
        private RestClient _client;

        public ApiClient(string baseUrl)
        {
            _client = new RestClient(baseUrl);
        }

        public async Task<string> ExecuteAsync(RestRequest request)
        {
            RestResponse response = await _client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                return response.Content;
            }
            else
            {
                throw new Exception($"Falha em executar a requisição: {response.ErrorMessage}");
            }
        }
    }
}
