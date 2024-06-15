using Core.Responses;

namespace Core.Features.Spares.Commands.CreateSpare
{
   public class SpareVmToReturn : BaseResponse
   {
      public SpareDto spare { get; set; }

   }

   public class SpareDto
   {
      public Guid SpareId { get; set; }
      public BrandDto Brand { get; set; }

   }

   public class BrandDto
   {
      public Guid BrandId { get; set; }
      public string Name { get; set; } = string.Empty;
   }
}
