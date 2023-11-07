using MathLearner.Domain.Entities;
using MathLearner.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MathLearner.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllRoles()
        {
            var result = await _unitOfWork.RoleRepository.GetAll();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetRole(int id)
        {
            var result = await _unitOfWork.RoleRepository.Get(x => x.Id == id);

            if (result == null)
            {
                return NotFound("Role not found.");
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Role>>> AddRole(Role role)
        {
            await _unitOfWork.RoleRepository.Add(role);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Role>>> UpdateRole(Role role)
        {
            await _unitOfWork.RoleRepository.Update(role);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Role>>> DeleteRole(Role role)
        {
            await _unitOfWork.RoleRepository.Remove(role);
            return Ok();
        }
    }
}
