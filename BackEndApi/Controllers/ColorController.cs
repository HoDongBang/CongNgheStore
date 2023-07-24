using BackEndApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BackEndApi.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class ColorController : ControllerBase
    {
        private readonly IColorRepository _colorRepository;

        public ColorController(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }

        [HttpGet]
        [Route("GetColorsByProductId/{productId}")]
        public IActionResult GetByProductId(Guid productId, int quantity = 0)
        {
            try
            {
                return Ok(_colorRepository.GetByProductId(productId, quantity));
            }
            catch
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
        }
    }
}
