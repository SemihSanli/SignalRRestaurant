using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.DTOs.AboutDTOs;
using SignalRWebUI.DTOs.TestimonialDTOs;

namespace SignalRWebUI.ViewComponents.DefaultComponents
{
    public class _DefaultTestimonialComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _DefaultTestimonialComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }



        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7205/api/Testimonial");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTestimonialDTOs>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
