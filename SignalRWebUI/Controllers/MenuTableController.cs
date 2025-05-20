using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.DTOs.AboutDTOs;
using SignalRWebUI.DTOs.MenuTableDTOs;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class MenuTableController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MenuTableController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7205/api/MenuTables");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMenuTableDTOs>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateMenuTable()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateMenuTable(CreateMenuTableDTOs createMenuTableDTOs)
        {
            createMenuTableDTOs.Status = false;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createMenuTableDTOs);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7205/api/MenuTables", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> DeleteMenuTable(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7205/api/MenuTables/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateMenuTable(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7205/api/MenuTables/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateMenuTableDTOs>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateMenuTable(UpdateMenuTableDTOs updateMenuTableDTOs)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateMenuTableDTOs);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7205/api/MenuTables/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> TableListByStatus()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7205/api/MenuTables");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMenuTableDTOs>>(jsonData);
                return View(values);
            }
            return View();
        }

    }
}
