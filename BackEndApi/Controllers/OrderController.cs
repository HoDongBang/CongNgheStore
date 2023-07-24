using BackEndApi.Repositories;
using BackEndApi.Service;
using CongNgheStore.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;

namespace BackEndApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOptions<CongNgheStoreSetting> _congNgheStoreSetting;

        public OrderController(IOrderRepository orderRepository, IOptions<CongNgheStoreSetting> congNgheStoreSetting)
        {
            _orderRepository = orderRepository;
            _congNgheStoreSetting = congNgheStoreSetting;
        }

        [HttpGet]
        [Route("GetOrderById/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var url = _congNgheStoreSetting.Value.Url + "Images/Product/";
                var data = _orderRepository.GetById(id);
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

        [HttpPost]
        [Route("AddOrder")]
        public IActionResult Add(OrderVM order)
        {
            try
            {
                var id = _orderRepository.Add(order);
                return Ok(id);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
