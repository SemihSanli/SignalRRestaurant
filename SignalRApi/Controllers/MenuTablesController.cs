using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DTOLayer.AboutDTO;
using SignalR.DTOLayer.MenuTableDTO;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuTablesController : ControllerBase
    {
        private readonly IMenuTableService _menuTableService;

        public MenuTablesController(IMenuTableService menuTableService)
        {
            _menuTableService = menuTableService;
        }

        [HttpGet("MenuTableCount")]
        public IActionResult MenuTableCount()
        {
            return Ok(_menuTableService.TMenuTableCount());
        }
        [HttpGet]
        public IActionResult MenuTableList()
        {
            var values = _menuTableService.TGetListAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateMenuTable(CreateMenuTableDTO createMenuTableDTO)
        {
            MenuTable menuTable = new MenuTable()
            {
                Name = createMenuTableDTO.Name,
                Status = false,
            };
            _menuTableService.TAdd(menuTable);
            return Ok("Masa Oluşturuldu");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteMenuTable(int id)
        {
            var value = _menuTableService.TGetByID(id);
            _menuTableService.TDelete(value);
            return Ok("Masa  Silindi");
        }
        [HttpPut]
        public IActionResult UpdateMenuTable(UpdateMenuTableDTO updateMenuTableDTO)
        {
            MenuTable menuTable = new MenuTable()
            {
                MenuTableID = updateMenuTableDTO.MenuTableID,
                Name = updateMenuTableDTO.Name,
                Status = false,
            };
            _menuTableService.TUpdate(menuTable);
            return Ok("Masa Güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetMenuTable(int id)
        {
            var value = _menuTableService.TGetByID(id);
            return Ok(value);
        }
        [HttpGet("ChangeMenuTableStatusToTrue")]
        public IActionResult ChangeMenuTableStatusToTrue(int id)
        {
            _menuTableService.TChangeMenuTableStatusToTrue(id);
            return Ok("İşlem Başarılı");
        }
        [HttpGet("ChangeMenuTableStatusToFalse")]
        public IActionResult ChangeMenuTableStatusToFalse(int id)
        {
            _menuTableService.TChangeMenuTableStatusToFalse(id);
            return Ok("İşlem Başarılı");
        }
    }
}
