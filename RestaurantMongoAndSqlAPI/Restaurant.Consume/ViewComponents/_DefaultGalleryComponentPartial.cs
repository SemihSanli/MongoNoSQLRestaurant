using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Restaurant.DTO.GalleryDTO;

namespace Restaurant.Consume.ViewComponents
{
    public class _DefaultGalleryComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultGalleryComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7101/api/Gallery");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultGalleryDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
