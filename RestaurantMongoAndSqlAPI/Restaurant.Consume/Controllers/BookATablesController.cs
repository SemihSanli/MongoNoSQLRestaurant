using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Newtonsoft.Json;
using Restaurant.DTO.AboutDTO;
using Restaurant.DTO.BookATableDTO;
using Restaurant.DTO.ContactUsDTO;
using System.Text;

namespace Restaurant.Consume.Controllers
{
    public class BookATablesController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookATablesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> BookList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7101/api/BookATable");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultATableDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> DeleteBook(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7101/api/BookATable/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("BookList");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Booking()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Booking(CreateBookATableDTO createBookATableDTO)
        {
            if (!ModelState.IsValid)
            {
                return View(createBookATableDTO);
            }
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBookATableDTO);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7101/api/BookATable", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                await SendConfirmationEmail(createBookATableDTO);

                ViewBag.Success = "Rezervasyon işlemi başarılı!";
                return View("~/Views/Default/Index.cshtml");

            }
            ModelState.AddModelError("", "Rezervasyon oluşturulurken bir hata oluştu.");

            return View(createBookATableDTO);
        }
        private async Task SendConfirmationEmail(CreateBookATableDTO booking)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Mongo Restaurant", "sanlisemh@gmail.com"));
            message.To.Add(new MailboxAddress(booking.BookFullName, booking.BookEmail)); 
            message.Subject = "Rezervasyon Onayı";

            message.Body = new TextPart("plain")
            {
                Text = $"Sayın {booking.BookFullName},\n\nRezervasyonunuz başarıyla alınmıştır. Tarih: {booking.BookDate.ToShortDateString()} Saat ve masa bilgisi için tarafımızdan aranacaksınız.Teşekkürler."
            };

            using var client = new SmtpClient();
            await client.ConnectAsync("smtp.gmail.com", 587, false);
            await client.AuthenticateAsync("sanlisemh@gmail.com", "xjsz xhmb krxx yjif");
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }

    }
}
