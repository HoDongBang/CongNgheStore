using BackEndApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BackEndApi.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class BrandController : ControllerBase
    {
        private readonly IBrandRepository _brandRepository;

        public BrandController(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        [HttpGet]
        [Route("GetAllBrands")]
        public IActionResult GetAll()
        {
            try
            {
                var data = _brandRepository.GetAll();
                return Ok(data);
            }
            catch
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
        }

        [HttpGet]
        [Route("GetBrandByProductId/{productId}")]
        public IActionResult GetByProductId(Guid productId)
        {
            try
            {
                var data = _brandRepository.GetByProductId(productId);
                if (data != null)
                    return Ok(data);
                return StatusCode(StatusCodes.Status404NotFound);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("GetBrandByUrlHandle/{urlHandle}")]
        public IActionResult GetByUrlHandle(string urlHandle)
        {
            try
            {
                var data = _brandRepository.GetByUrlHandle(urlHandle);
                if (data != null)
                    return Ok(data);
                return StatusCode(StatusCodes.Status404NotFound);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
