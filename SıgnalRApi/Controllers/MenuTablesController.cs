using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.MenuTableDTO;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SıgnalRApi.DAL.Entities;

namespace SıgnalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MenuTablesController : ControllerBase
	{
		private readonly IMenuTableService _menuTableService;
        private readonly IMapper _mapper;

        public MenuTablesController(IMenuTableService menuTableService, IMapper mapper)
        {
            _menuTableService = menuTableService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult MenuTableList()
        {
            var value = _mapper.Map<List<ResultMenuTableDto>>(_menuTableService.GetListAllAsync());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateMenuTable(CreateMenuTableDto createMenuTableDto)
        {
            _menuTableService.AddAsync(new MenuTable()
            {
               Name = createMenuTableDto.Name,
               Status= false,
            });
            return Ok("Masa başarıyla eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteMenuTable(int id)
        {
            var value = _menuTableService.GetByIdAsync(id);
            _menuTableService.DeleteAsync(value);

            return Ok("Masa başarıyla silindi.");

        }
        [HttpGet("{id}")]
        public IActionResult GetMenuTable(int id)
        {
            var value = _menuTableService.GetByIdAsync(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateMenuTable(UpdateMenuTableDto updateMenuTableDto)
        {
            _menuTableService.UpdateAsync(new MenuTable()
            {
                MenuTableID = updateMenuTableDto.MenuTableID,
                Name = updateMenuTableDto.Name,
                Status = updateMenuTableDto.Status,
            });

            return Ok("Masa başarıyla güncellendi");
        }

        [HttpGet("MenuTableCount")]
		public IActionResult MenuTableCount()
		{
			return Ok(_menuTableService.MenuTableCountAsync());
		}
	}
}
