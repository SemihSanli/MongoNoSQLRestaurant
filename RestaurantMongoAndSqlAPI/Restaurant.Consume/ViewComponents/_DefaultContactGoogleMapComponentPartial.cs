using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Restaurant.DTO.ContactDetailDTO;

namespace Restaurant.Consume.ViewComponents
{
    public class _DefaultContactGoogleMapComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultContactGoogleMapComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7101/api/ContactDetail");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultContactDetailDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
