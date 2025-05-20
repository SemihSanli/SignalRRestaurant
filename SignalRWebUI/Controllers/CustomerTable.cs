using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.DTOLayer.MenuTableDTO;
using SignalRWebUI.DTOs.MenuTableDTOs;

namespace SignalRWebUI.Controllers
{
    public class CustomerTable : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CustomerTable(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> CustomerTableList()
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
