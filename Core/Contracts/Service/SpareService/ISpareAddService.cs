using Core.Services.SpareService.Commands.Create;

namespace Core.Contracts.Service.SpareService
{
    public interface ISpareAddService
   {
      /// <summary>
      /// Adds a new Spare
      /// </summary>
      /// <param name="spareToAddDto"></param>
      /// <returns>Returns a Spare Dto</returns>
      Task<SpareVmToReturn> AddSpare(SpareToAdd spareToAddDto);


      /// <summary>
      /// Adds a Spare with Brand and Price
      /// </summary>
      /// <param name="spareToAdd"></param>
      /// <returns></returns>
      Task<SpareVmToReturn> AddSpareWithBrand(SpareWithBrandToAdd spareToAdd);
   }
}
