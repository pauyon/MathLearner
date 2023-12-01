using MathLearner.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using MathLearner.Domain.Repositories;
using MathLearner.Domain.Models;
using System.Net;
using AutoMapper;

namespace MathLearner.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        protected ApiResponse _response;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _response = new ApiResponse();
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var result = await _unitOfWork.UserRepository.GetAll();

            return Ok(result);
        }

        [HttpGet("getWithCustomResponse")]
        public async Task<ActionResult<ApiResponse>> GetAllUsers2()
        {
            try
            {
                var result = await _unitOfWork.UserRepository.GetAll();
                _response.Result = _mapper.Map<IEnumerable<User>>(result);
                _response.StatusCode = HttpStatusCode.OK;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Errors = new List<string>() { ex.ToString() };
            }

            return _response;

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var result = await _unitOfWork.UserRepository.Get(x => x.Id == id);

            if (result == null)
            {
                return NotFound("User not found.");
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<User>>> AddUser(User user)
        {
            await _unitOfWork.UserRepository.Add(user);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<User>>> UpdateUser(User user)
        {
            await _unitOfWork.UserRepository.Update(user);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<User>>> DeleteUser(int id)
        {
            await _unitOfWork.UserRepository.Delete(id);
            return Ok();
        }
    }
}
