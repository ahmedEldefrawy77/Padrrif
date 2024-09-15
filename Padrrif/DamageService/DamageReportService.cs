
using Padrrif.Migrations;
using Padrrif.Services.PicServices;

namespace Padrrif.DamageService
{
    public class DamageReportService : IDamageReportService
    {
        private readonly IRepository<Damage> _repository;
        private readonly IRepository<User> _userRepository;
        private readonly IImageService _imageService;
        private readonly IHttpContextAccessor _contextAccessor;
        public async Task<Damage> UpdateDamageReportStatuse(Guid damageReportId, IFormFileCollection SignatureImage)
        {
            if (damageReportId == Guid.Empty)
                throw new ArgumentNullException(nameof(damageReportId), "id or Signature for Damage Report cannot be empty");

            if (SignatureImage == null)
                throw new ArgumentNullException(nameof(SignatureImage), "SignatureImage Cannot be null");

            Damage? damageReportFromDb = await _repository.GetById(damageReportId);

            Guid Employeeid = _contextAccessor.GetUserId();

            User? userFromDb = await _userRepository.GetById(Employeeid);

            if (userFromDb == null)
                throw new UnauthorizedAccessException("invalid Credentials");

            List<User> users = await _userRepository.GetList(e => e.Where(e => e.ComiteeId == userFromDb.ComiteeId));

            if (damageReportFromDb != null && damageReportFromDb.CurrentStage < users.Count)
            {
                ImageRecord imagerecord = await _imageService.SaveImage(SignatureImage, damageReportFromDb.Id, "DamageReport");

                if (imagerecord.imagePaths != null)
                {
                    damageReportFromDb.StageSignaturePath = imagerecord.imagePaths;

                    damageReportFromDb.CurrentStage += 1;
                    if (damageReportFromDb.CurrentStage >= users.Count)
                    {
                        damageReportFromDb.IsSignedDamageReport = true;
                        await _repository.Update(damageReportFromDb);
                    }
                    else
                    {
                        await _repository.Update(damageReportFromDb);
                    }


                }
                else
                {
                    throw new ArgumentNullException(nameof(SignatureImage), "Signature image can not be null");
                }
            }
            else
            {
                throw new InvalidOperationException("Failed to save the signature image, Signatures Exceeds the Number of Employees related to this Damage Report. Check if all Employees related to this This Damage Report have assigned a Signature");
            }
            return damageReportFromDb;
        }

        public async Task<Damage> UpdateDamageReportStatuseFirstCheck(Guid damageReportId, FirstCheckWait statuse)
        {
            if(damageReportId == Guid.Empty)
                throw new ArgumentNullException(nameof(damageReportId), "Damage Id cannot be null, invalid operation Exception");

            Damage? damageFromDb = await _repository.GetById(damageReportId);

            if(damageFromDb== null)
                throw new ArgumentNullException(nameof(damageFromDb),"there is no damage recorded with such an Id");

            if (damageFromDb.IsSignedDamageReport == false)
                throw new InvalidOperationException("damage cannot be checked because its not signed from all employees relating to Damage Report, please sign it out first in order to proceed with this operation");

            damageFromDb.FirstCheck = statuse;

            await _repository.Update(damageFromDb);

            return damageFromDb;
        }
    }
    
}
