using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Restaurant.DTO.AboutDTO;
using Restaurant.DTO.ContactDetailDTO;
using System.Text;

namespace Restaurant.Consume.Controllers
{
    public class ContactDetailsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactDetailsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> ContactDetailList()
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
        [HttpGet]
        public IActionResult AddContactDetail()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddContactDetail(CreateContactDetailDTO createContactDetailDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createContactDetailDTO);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7101/api/ContactDetail", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ContactDetailList");
            }
            return View();
        }
        public async Task<IActionResult> DeleteContactDetail(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7101/api/ContactDetail/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ContactDetailList");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateContactDetail(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7101/api/ContactDetail/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateContactDetailDTO>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateContactDetail(UpdateContactDetailDTO updateContactDetailDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateContactDetailDTO);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7101/api/ContactDetail", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ContactDetailList");
            }
            return View();
        }
    }
}
