using Microsoft.AspNetCore.Http;

namespace Core.Contracts.Infrastructure.Upload
{
    public interface IUploadService
    {   
        /// <summary>
        /// Uploads inventory from csv file into database
        /// </summary>
        /// <param name="file">Csv File</param>
        /// <returns></returns>
        Task UploadFromCsvFile(IFormFile file );
    }
}
