using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Restaurant.DTO.AboutDTO;
using Restaurant.DTO.OurSpecialDTO;
using System.Text;

namespace Restaurant.Consume.Controllers
{
    public class OurSpecialsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public OurSpecialsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> OurSpecialList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7101/api/OurSpecial");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultOurSpecialDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddOurSpecial()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddOurSpecial(CreateOurSpecialDTO createOurSpecialDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createOurSpecialDTO);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7101/api/OurSpecial", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("OurSpecialList");
            }
            return View();
        }
        public async Task<IActionResult> DeleteOurSpecial(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7101/api/OurSpecial/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("OurSpecialList");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateOurSpecial(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7101/api/OurSpecial/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateOurSpecialDTO>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateOurSpecial(UpdateOurSpecialDTO updateOurSpecialDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateOurSpecialDTO);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7101/api/OurSpecial", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("OurSpecialList");
            }
            return View();
        }
    }
}
