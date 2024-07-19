    namespace Padrrif.Services.PicServices
{
    public interface IImageService
    {
        Task<ImageRecord> SaveImage(IFormFileCollection fileCollection, Guid DamageReportId, string objectName);
        List<string> GetImage(string hostUrl, Guid DamageReportId, string objectName);
        void DeleteImage(Guid DamageReport , string objectName);
    }
}
        