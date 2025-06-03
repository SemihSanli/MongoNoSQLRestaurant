using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Restaurant.DTO.ProductDTO;
using Restaurant.DTO.TeamDTO;
using System.Text;

namespace Restaurant.Consume.Controllers
{
    public class TeamsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TeamsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> TeamList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7101/api/Team");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTeamDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddTeam()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddTeam(CreateTeamDTO createTeamDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createTeamDTO);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7101/api/Team", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("TeamList");
            }
            return View();
        }
        public async Task<IActionResult> DeleteTeam(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7101/api/Team/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("TeamList");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateTeam(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7101/api/Team/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateTeamDTO>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTeam(UpdateTeamDTO updateTeamDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateTeamDTO);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7101/api/Team", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("TeamList");
            }
            return View();
        }
    }
}
