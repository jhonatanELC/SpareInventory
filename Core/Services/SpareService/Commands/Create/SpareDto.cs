namespace Core.Services.SpareService.Commands.Create
{
   public class SpareDto
   {
      public Guid SpareId { get; set; }
      public string? Sku { get; set; }
      public BrandDto Brand { get; set; }

   }
}
