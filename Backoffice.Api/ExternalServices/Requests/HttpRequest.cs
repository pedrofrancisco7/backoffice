using System;
namespace ExternalServices.Requests
{
	public class HttpRequest
	{
        public async Task<HttpResponseMessage> GetCep(string cep)
        {
            try
            {
                using (var http = GetHttpClient("https://viacep.com.br/ws/"))
                {                    
                    return await http.GetAsync($"{cep}/json/");
                }
            }
            catch (Exception)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            }

        }


        private static HttpClient GetHttpClient(string baseref)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseref);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            return httpClient;
        }
    }
}

