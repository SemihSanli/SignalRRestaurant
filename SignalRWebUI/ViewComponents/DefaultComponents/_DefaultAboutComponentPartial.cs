using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.DTOs.AboutDTOs;
using SignalRWebUI.DTOs.ProductDTOs;
using System.Net.Http;

namespace SignalRWebUI.ViewComponents.DefaultComponents
{
    public class _DefaultAboutComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _DefaultAboutComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }



        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7205/api/About");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutDTOs>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
