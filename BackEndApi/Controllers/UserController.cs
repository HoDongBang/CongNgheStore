using BackEndApi.Repositories;
using CongNgheStore.Models;
using CongNgheStore.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Controllers
{

    
    [ApiController]
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        [Route("GetAllUsers")]     
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_userRepository.GetAll());
            }
            catch
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
        }

        [HttpGet]
        [Route("GetUser/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var data = _userRepository.GetById(id);
                if (data != null)
                    return Ok(data);
                return StatusCode(StatusCodes.Status404NotFound);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("CreateUser")]
        public IActionResult Create([FromBody] UserVM userVM)
        {
            try
            {
                if (userVM == null)
                    return StatusCode(StatusCodes.Status400BadRequest);

                _userRepository.Add(new User
                {
                    PhoneNumber = userVM.PhoneNumber,
                    FirstName = userVM.FirstName,
                    LastName = userVM.LastName,
                    PasswordHash = userVM.Password
                });
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("UpdateUser")]
        public IActionResult Update([FromBody] UserVM userVM)
        {
            try
            {
                if (userVM == null)
                    return StatusCode(StatusCodes.Status400BadRequest);

                var status = _userRepository.Update(new User
                {
                    Id = userVM.Id,
                    PhoneNumber = userVM.PhoneNumber,
                    FirstName = userVM.FirstName,
                    LastName = userVM.LastName,
                    PasswordHash = userVM.Password
                });
                if(status)
                    return Ok();
                else
                    return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        [Route("DeleteUser/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id == null)
                    return StatusCode(StatusCodes.Status400BadRequest);

                var status = _userRepository.Delete(id);
                if (status)
                    return Ok();
                else
                    return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
