using Google.Cloud.Storage.V1;
using InternManagementCommon;
using InternManagementData.DTO;
using Microsoft.AspNetCore.Http;
using DataObject = Google.Apis.Storage.v1.Data;
namespace InternManagementBusiness.Category
{
    public class MediaBusiness
    {
        private readonly StorageClient storageClient;
        private readonly string bucketName;

        public MediaBusiness(StorageClient storageClient) {
            this.storageClient = storageClient;
            this.bucketName = AppConfig.GoogleSetting.StorageBucket;
        }
        public async Task<IInternManagementResult> UploadFile(IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                Guid id = Guid.NewGuid();
                string extension = Path.GetExtension(file.FileName);
                string objectName = $"{id}{extension}";
                DataObject.Object result = null!;
                try
                {
                    result = await storageClient.UploadObjectAsync(bucketName, objectName, null, memoryStream);
                }
                catch (Exception e)
                {
                    return new BaseResult(Const.ERROR_EXCEPTION, e.Message);
                }
                return new BaseResult(Const.SUCCESS_GET, "Upload successfully", new FileDTO
                {
                    Name = result.Name,
                    MediaLink = result.MediaLink,
                    SelfLink = result.SelfLink,
                    PublicLink = $"https://storage.cloud.google.com/{bucketName}/{objectName}",
                    Size = result.Size ?? 0,
                    Metadata = result.Metadata,
                    ContentType = result.ContentType
                });
            }
        }
        public async Task<IInternManagementResult> DownloadFile(string fileName)
        {
            var memoryStream = new MemoryStream();
            DataObject.Object result = null!;
            try
            {
                result = await storageClient.DownloadObjectAsync(bucketName, fileName, memoryStream);
                memoryStream.Position = 0;
                return new BaseResult(Const.SUCCESS_GET, "Download successfully", new FileDTO
                {
                    Name = result.Name,
                    MediaLink = result.MediaLink,
                    SelfLink = result.SelfLink,
                    Size = result.Size ?? 0,
                    Metadata = result.Metadata,
                    ContentType = result.ContentType,
                    memoryStream = memoryStream
                });
            }
            catch (Exception e)
            {
                return new BaseResult(Const.ERROR_EXCEPTION, e.Message);
            }
        }
    }
}
