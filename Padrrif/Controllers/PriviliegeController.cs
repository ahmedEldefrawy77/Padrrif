using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Padrrif.Entities;
using Padrrif.UnitOfWork.Interface;

namespace Padrrif.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriviliegeController : ControllerBase
    {
        private readonly IPriviliegeUnitOfWork _unitOfWork;

        public PriviliegeController(IPriviliegeUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        [HttpPost]
        public async Task<IActionResult> CreatePriviliege(string priviliege)
        {
            if(priviliege == string.Empty)
            {
                return BadRequest("priviliege name connot be null or empty");

            }
            else
            {
                await _unitOfWork.AddPriviliege(priviliege);
                return Ok("Priviliege created successfully");
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetPrivileges()
        {
            return Ok(await _unitOfWork.getPrivilieges());
        }
    }
}
