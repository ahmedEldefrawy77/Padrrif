using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Padrrif.Dto;
using Padrrif.Entities;
using Padrrif.UnitOfWork.Interface;

namespace Padrrif.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DamageReportController : ControllerBase
    {
        private readonly IDamageReportUnitOfWork _unitOfWork;
        private readonly IRepository<DamageReport>  _repository;
        private readonly IRepository<User> _userRepository;
        private readonly IHttpContextAccessor _contextAccessor;
     
        public DamageReportController(IDamageReportUnitOfWork unitOfWork, IRepository<DamageReport> repository,
            IRepository<User> userRepository, 
            IHttpContextAccessor conetextAccessor)
        {
            _unitOfWork = unitOfWork;   
            _repository = repository;
            _userRepository = userRepository;
            _contextAccessor = conetextAccessor;
        }

        [HttpPost]
        public async Task<IActionResult> AddDamageReport(string Name, string Description)
            => Ok(await _unitOfWork.AddDamageReport(Name, Description));

        [HttpPut]
        public async Task<IActionResult> UpdateReportSignature(Guid ReportId, IFormFileCollection Signature)
            => Ok( await _unitOfWork.UpdateDamageReport(ReportId, Signature));

        [HttpPut("update-Damage-Report-Statuse")]
        public async Task<IActionResult> UpdateReportStatuse([FromForm] DamageReportStatuseDto updateDto)
        {
            if (updateDto.id == Guid.Empty)
                return BadRequest("Damage report ID cannot be empty.");

            DamageReport? damageReport = await _repository.GetById(updateDto.id);
            if (damageReport == null)
                return NotFound("Damage report not found.");

            Guid Userid = _contextAccessor.GetUserId();
            if(Userid ==  Guid.Empty)
               throw new UnauthorizedAccessException("Wrong Credentials");

            User? User = await _userRepository.GetById(Userid);
            if (User == null)
                throw new Exception("User Cannot be found");

            List<User> users = await _userRepository.GetList(e => e.Where(e => e.ComiteeId == User.ComiteeId));
            if(damageReport.CurrentStage < users.Count)
                throw new InvalidOperationException("the Damage Report has not been signed from all Employees in the Committe, it should be signed first from all the Employee due to changing the Statuse of the Report");

            damageReport.Statuse = updateDto.statuse;
            await _repository.Update(damageReport);

            return Ok(damageReport);
        }
    }
}
