using Padrrif.Entities;
using Padrrif.Services.PicServices;
using Padrrif.UnitOfWork.Interface;
using System.Security.Cryptography.Xml;

namespace Padrrif.UnitOfWork
{
    public class DamageReportUnitOfWork : UnitOfWork<DamageReport>, IDamageReportUnitOfWork
    {
        private readonly IRepository<DamageReport> _repository;
        private readonly IRepository<User> _userRepository;
        private readonly IImageService _imageService;
        private readonly IHttpContextAccessor _contextAccessor;
        public DamageReportUnitOfWork(IRepository<DamageReport> repository, IImageService imageService, IHttpContextAccessor contextAccessor, IRepository<User> userRepository) : base(repository)
        {
            _repository = repository;
            _imageService = imageService;
            _contextAccessor = contextAccessor;
            _userRepository =  userRepository;
        }
        public async Task<string> AddDamageReport(string name, string description)
        {
            DamageReport damagereport = new DamageReport();
            if(name == string.Empty || description == string.Empty)
                throw new ArgumentNullException("name or description for Damage Report cannot be empty");

            damagereport.Name = name;
            damagereport.Description = description;
           await _repository.Add(damagereport);
            return ("Damage Report has been successfully created  and awaiting for Employee´s Signature");

        }
        public async Task<DamageReport> UpdateDamageReport(Guid id, IFormFileCollection SignatureImage)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException(nameof(id),"id or Signature for Damage Report cannot be empty");

            if(SignatureImage == null)
                throw new ArgumentNullException(nameof(SignatureImage), "SignatureImage Cannot be null");

            DamageReport? damageReportFromDb = await _repository.GetById(id);

            Guid Employeeid = _contextAccessor.GetUserId();

            User? userFromDb = await _userRepository.GetById(Employeeid);

            if (userFromDb == null)
                throw new UnauthorizedAccessException("invalid Credentials");
           
            List<User> users = await _userRepository.GetList(e => e.Where(e => e.ComiteeId == userFromDb.ComiteeId));

            if (damageReportFromDb != null && damageReportFromDb.CurrentStage < users.Count )
            {
                ImageRecord imagerecord = await _imageService.SaveImage(SignatureImage, damageReportFromDb.Id, "DamageReport");

                if(imagerecord.imagePaths != null)
                {
                    damageReportFromDb.StageSignaturePath = imagerecord.imagePaths;

                    damageReportFromDb.CurrentStage += 1;
                    if(damageReportFromDb.CurrentStage  >= users.Count)
                    {
                        damageReportFromDb.IsSignedReport = true;
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
    }
}
