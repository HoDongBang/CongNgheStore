using BackEndApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        [Route("GetAllCategories")]
        public IActionResult GetAll()
        {
            try
            {
                var data = _categoryRepository.GetAll();
                return Ok(data);
            }
            catch
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
        }
        
        [HttpGet]
        [Route("GetCategoryByUrlHandle/{urlHandle}")]
        public IActionResult GetByUrlHandle(string urlHandle)
        {
            try
            {
                var data = _categoryRepository.GetByUrlHandle(urlHandle);
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
