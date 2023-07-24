using BackEndApi.Model;
using BackEndApi.Repositories;
using BackEndApi.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;

namespace BackEndApi.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IOptions<CongNgheStoreSetting> _congNgheStoreSetting;

        public ProductController(IProductRepository productRepository, IOptions<CongNgheStoreSetting> congNgheStoreSetting)
        {
            _productRepository = productRepository;
            _congNgheStoreSetting = congNgheStoreSetting;
        }

        [HttpGet]
        [Route("GetAllProducts")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_productRepository.GetAll());
            }
            catch
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
        }

        [HttpGet]
        [Route("GetProductsByBrandCategoty")]
        public IActionResult GetByBrandCategoty(string? brandUrlHandle, string? categoryUrlHandle, string? price, string? sort, int quantity = 0)
        {
            try
            {
                var url = _congNgheStoreSetting.Value.Url + "Images/Product/";
                var data = _productRepository.GetByBrandCategoty(brandUrlHandle, categoryUrlHandle, price, sort, quantity);
                if (data.Count > 0)
                    return Ok(new 
                    {
                        Url = url,
                        data
                    });

                return StatusCode(StatusCodes.Status404NotFound);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("GetProductById/{id}")]
        public IActionResult GetByUrlHandle(Guid id)
        {
            try
            {
                var url = _congNgheStoreSetting.Value.Url + "Images/Product/";
                var data = _productRepository.GetById(id);
                if (data != null)
                    return Ok(new
                    {
                        Url = url,
                        data
                    });
                return StatusCode(StatusCodes.Status404NotFound);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("GetProductsBySearch")]
        public IActionResult GetBySearch(string? value, int quantity = 0)
        {
            try
            {
                var url = _congNgheStoreSetting.Value.Url + "Images/Product/";
                var data = _productRepository.GetBySearch(value, quantity);
                if (data != null)
                    return Ok(new
                    {
                        Url = url,
                        data
                    });

                return StatusCode(StatusCodes.Status404NotFound);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
