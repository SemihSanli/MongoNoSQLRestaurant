using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Restaurant.DTO.ProductDTO;
using Restaurant.DTO.WhyUsDTO;
using System.Text;

namespace Restaurant.Consume.Controllers
{
    public class WhyUsesController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public WhyUsesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> WhyUsList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7101/api/WhyUs");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultWhyUsDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddWhyUs()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddWhyUs(CreateWhyUsDTO createWhyUsDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createWhyUsDTO);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7101/api/WhyUs", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("WhyUsList");
            }
            return View();
        }
        public async Task<IActionResult> DeleteWhyUs(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7101/api/WhyUs/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("WhyUsList");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateWhyUs(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7101/api/WhyUs/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateWhyUsDTO>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateWhyUs(UpdateWhyUsDTO updateWhyUsDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateWhyUsDTO);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7101/api/WhyUs", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("WhyUsList");
            }
            return View();
        }
    }
}
