using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Padrrif.UnitOfWork.Interface;

namespace Padrrif.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DamageReportController : ControllerBase
    {
        private readonly IDamageReportUnitOfWork _unitOfWork;
        public DamageReportController(IDamageReportUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;   
        }

        [HttpPost]
        public async Task<IActionResult> AddDamageReport(string Name, string Description)
            => Ok(await _unitOfWork.AddDamageReport(Name, Description));

        [HttpPut]
        public async Task<IActionResult> UpdateReportSignature(Guid ReportId, IFormFileCollection Signature)
            => Ok( await _unitOfWork.UpdateDamageReport(ReportId, Signature));
    }
}
