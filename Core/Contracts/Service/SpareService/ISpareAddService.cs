using Core.Dtos.SpareDto;

namespace Core.Contracts.Service.SpareService
{
    public interface ISpareAddService
    {   
        /// <summary>
        /// Adds a new Spare
        /// </summary>
        /// <param name="spareToAddDto"></param>
        /// <returns>Returns a Spare Dto</returns>
        Task<SpareToReturn> AddSpare(SpareToAdd spareToAddDto);
    }
}
