using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Restaurant.DTO.AboutDTO;
using Restaurant.DTO.ContactUsDTO;
using System.Text;

namespace Restaurant.Consume.Controllers
{
    public class ContactUsesController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactUsesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> ContactUsList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7101/api/ContactUs");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultContactUsDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> DeleteContactUs(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7101/api/ContactUs/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ContactUsList");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> SeeContactUsDetail(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7101/api/ContactUs/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetContactUsDTO>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult SendMessage()
        {
          
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateContactUsDTO createContactUsDTO)
        {
            if (!ModelState.IsValid)
            {
                return View(createContactUsDTO);
            }
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createContactUsDTO);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7101/api/ContactUs", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                ViewBag.Success = "Gönderim işlemi başarılı!";
                return View("~/Views/Default/Index.cshtml");

            }
            ModelState.AddModelError("", "Mesaj gönderilirken bir hata oluştu.");
           
            return View(createContactUsDTO);
        }
    }
}
