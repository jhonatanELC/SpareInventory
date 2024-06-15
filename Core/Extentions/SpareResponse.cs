using Core.Domain.Entities;
using Core.Models;

namespace Core.Extentions
{
   public static class SpareResponse
   {
      public static SpareToReturn ToSpareResponse(this Spare spare)
      {     

         return new SpareToReturn()
         {
            SpareId = spare.SpareId,
            Description = spare.Description,
            OemCode = spare.OemCode,
            Group = spare.Group,
            Brands = spare.SpareBrands.Select(s => s.ToSpareBrandResponse()).ToList()
         };
      }

   }
}
