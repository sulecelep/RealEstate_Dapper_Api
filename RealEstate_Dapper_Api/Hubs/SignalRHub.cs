using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace RealEstate_Dapper_Api.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SignalRHub(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task SendCategoryCount() //Kanal gibi düşünelim abone olucaz 
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage6 = await client.GetAsync("https://localhost:44352/api/Statistics/CategoryCount");
            var value = await responseMessage6.Content.ReadAsStringAsync();
            await Clients.All.SendAsync("ReceiveCategoryCount", value);
        }
    }
}
