using BackEndApi.Repositories;
using BackEndApi.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace BackEndApi.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class SlideController : ControllerBase
    {
        private readonly ISlideRepository _slideRepository;
        private readonly IOptions<CongNgheStoreSetting> _congNgheStoreSetting;
        public SlideController(ISlideRepository slideRepository, IOptions<CongNgheStoreSetting> congNgheStoreSetting)
        {
            _slideRepository = slideRepository;
            _congNgheStoreSetting = congNgheStoreSetting;
        }
        [HttpGet]
        [Route("GetAllSlides")]
        public IActionResult GetAll()
        {
            try
            {
                var slides = _slideRepository.GetAll();
                var url = _congNgheStoreSetting.Value.Url + "Images/Slide/";
                if(slides != null)
                {
                    return Ok(new
                    {
                        Url = url,
                        slides
                    });
                }    
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
