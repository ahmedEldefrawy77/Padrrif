using Padrrif.Entities;
using Padrrif.Services.PicServices;
using Padrrif.UnitOfWork.Interface;
using System.Security.Cryptography.Xml;

namespace Padrrif.UnitOfWork
{
    public class DamageReportUnitOfWork : UnitOfWork<DamageReport>, IDamageReportUnitOfWork
    {
        private readonly IRepository<DamageReport> _repository;
        private readonly IImageService _imageService;
        public DamageReportUnitOfWork(IRepository<DamageReport> repository, IImageService imageService) :base(repository)
        {
            _repository = repository;
            _imageService = imageService;
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
            if (id == Guid.Empty || SignatureImage == null)
                throw new ArgumentNullException("id or Signature for Damage Report cannot be empty");


            DamageReport? damageReportFromDb = await _repository.GetById(id);

            if (damageReportFromDb != null && damageReportFromDb.CurrentStage < 5)
            {
                ImageRecord imagerecord = await _imageService.SaveImage(SignatureImage, damageReportFromDb.Id, "DamageReport");
                damageReportFromDb.StageSignaturePath = imagerecord.imagePaths;
                if(imagerecord.imagePaths != null)
                {
                    damageReportFromDb.CurrentStage += 1;
                    await _repository.Update(damageReportFromDb);
                }
                else
                {
                    throw new Exception("something went wronge saving the Signature pic Pasth");
                }
            }
            else
            {
                throw new ArgumentNullException("eaither Id or Signature is Null");
            }
            return damageReportFromDb;
        }
    }
}
