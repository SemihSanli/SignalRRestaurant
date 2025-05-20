using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.DTOs.ProductDTOs;
using SignalRWebUI.DTOs.SliderDTOs;

namespace SignalRWebUI.ViewComponents.DefaultComponents
{
    public class _DefaultOurMenuComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultOurMenuComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }



        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7205/api/Product");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDTOs>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
