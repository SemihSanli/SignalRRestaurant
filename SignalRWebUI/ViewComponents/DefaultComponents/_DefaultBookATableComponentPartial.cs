using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.DTOs.AboutDTOs;

namespace SignalRWebUI.ViewComponents.DefaultComponents
{
    public class _DefaultBookATableComponentPartial:ViewComponent
    {
          public IViewComponentResult Invoke()
        {
            return View();
        }
        
    }
}
