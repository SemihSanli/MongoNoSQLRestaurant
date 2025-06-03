using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Restaurant.DTO.AboutDTO;
using Restaurant.DTO.GalleryDTO;
using Restaurant.EntityLayer.Entities;
using System.Text;

namespace Restaurant.Consume.Controllers
{
    public class GalleriesController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public GalleriesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> GalleryList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7101/api/Gallery");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultGalleryDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddGallery()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddGallery(CreateGalleryDTO createGalleryDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createGalleryDTO);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7101/api/Gallery", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("GalleryList");
            }
            return View();
        }
        public async Task<IActionResult> DeleteGallery(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7101/api/Gallery/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("GalleryList");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateGallery(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7101/api/Gallery/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateGalleryDTO>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateGallery(UpdateGalleryDTO updateGalleryDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateGalleryDTO);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7101/api/Gallery", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("GalleryList");
            }
            return View();
        }
    }
}
