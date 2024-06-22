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
        private readonly IUserPrivilegeUnitOfWork _userPrivilegeUnitOfWork;

        public PriviliegeController(IPriviliegeUnitOfWork unitOfWork, IUserPrivilegeUnitOfWork userPrivilegeUOW) {
            _unitOfWork = unitOfWork; 
            _userPrivilegeUnitOfWork = userPrivilegeUOW;
        }

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
        [HttpPost("Add_Privilege")]
        public async Task<IActionResult> AddPrivilegeToUser(Guid PrivilegeId, Guid UserId)
        {
            try
            {
                await _userPrivilegeUnitOfWork.AddPrivilegeToUser(PrivilegeId, UserId);
                return Ok("Privilege Created Add to the User Successfuly");
            }
            catch(Exception ex) 
            {
                return BadRequest($"Something went wronge while adding the Privlege to the User : {ex.Message}");
            }
           
        }
        [HttpGet]
        public async Task<IActionResult> GetPrivileges()
        {
            return Ok(await _unitOfWork.getPrivilieges());
        }
    }
}
