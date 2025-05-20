using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.DTOs.AboutDTOs;
using SignalRWebUI.DTOs.NotificationDTOs;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class NotificationsController:Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public NotificationsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7205/api/Notification");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultNotificationDTOs>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateNotification()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateNotification(CreateNotificationDTOs createNotificationDTOs)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createNotificationDTOs);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7205/api/Notification", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> DeleteNotification(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7205/api/Notification/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateNotification(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7205/api/Notification/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateNotificationDTOs>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateNotification(UpdateNotificationDTOs updateNotificationDTOs)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateNotificationDTOs);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7205/api/Notification/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> NotificationStatusChangeToTrue(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.GetAsync($"https://localhost:7205/api/Notification/NotificationStatusChangeToTrue/{id}");
            
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> NotificationStatusChangeToFalse(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.GetAsync($"https://localhost:7205/api/Notification/NotificationStatusChangeToFalse/{id}");

            return RedirectToAction("Index");
        }
    }

}
