using Core.Contracts.Infrastructure.Upload;
using Core.Dtos;
using CsvHelper;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Formats.Asn1;
using System.Globalization;

namespace Infrastructure.Services
{
    public class UploadService : IUploadService
    {
        public UploadService()
        {
            
        }

        public Task UploadFromCsvFile(IFormFile file)
        {
            using var reader = new StreamReader(file.OpenReadStream());
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);


            IEnumerable<AllDataToUpload> records = csv.GetRecords<AllDataToUpload>();

            foreach (var record in records)
            {
                // Validate model
                var context = new ValidationContext(record);
                var results = new List<ValidationResult>();

                if (!Validator.TryValidateObject(record, context, results, true))
                {
                    // Handle validation errors (e.g., log them or return a bad request response)
                    var errorMessages = new List<string>();
                    foreach (var result in results)
                    {
                        errorMessages.Add(result.ErrorMessage);

                    }
                    //return BadRequest(new { message = "Validation failed", errors = errorMessages });
                }
            }

            throw new NotImplementedException();
        }

   
    }
}
