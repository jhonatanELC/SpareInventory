using Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Services
{
    public class AllDataToUpload
    {
        // Spare
        [Required]
        [MaxLength(100)]
        public string Description { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? Comments { get; set; }

        [MaxLength(20)]
        public string? Keyword { get; set; }

        [MaxLength(20)]
        public string OemCode { get; set; } = string.Empty;

        public Group Group { get; set; }

        // Brand
        [Required]
        [MaxLength(20)]
        public string Name { get; set; } = string.Empty;

        // SpareBrand
        [Range(0, int.MaxValue, ErrorMessage = "Solo se permite numeros mayores o igual a 0")]
        public int Quantity { get; set; }
        public string Unit { get; set; } = "Unit";
        public string? CodeByBrand { get; set; }



        // Vehicle
        [Required]
        [MaxLength(50)]
        public string Brand { get; set; } = string.Empty;
        public string? Model { get; set; } = string.Empty;
        public int? Year { get; set; }


        // Price
        public decimal UnitPrice { get; set; } = 0;
        public Currency Currency { get; set; }
    }
}
