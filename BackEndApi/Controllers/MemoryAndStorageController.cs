using BackEndApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BackEndApi.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class MemoryAndStorageController : ControllerBase
    {
        private readonly IMemoryAndStorageRepository _memoryAndStorageRepository;

        public MemoryAndStorageController(IMemoryAndStorageRepository memoryAndStorageRepository)
        {
            _memoryAndStorageRepository = memoryAndStorageRepository;
        }

        [HttpGet]
        [Route("GetMemoryAndStoragesByProductId/{productId}")]
        public IActionResult GetByProductId(Guid productId, int quantity = 0)
        {
            try
            {
                return Ok(_memoryAndStorageRepository.GetByProductId(productId, quantity));
            }
            catch
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
        }
    }
}
