using Core.Domain.Entities;

namespace Infrastructure.ToDelete
{
    public interface ISpareRepository : IGenericRepository<Spare>
    {
        //Here, you need to define the operations which are specific to Employee Entity
        //This method returns all the Employee entities along with Department data
        Task<IEnumerable<Spare>> GetAllSparesAsync();
        //This method returns one the Employee along with Department data based on the Employee Id
        Task<Spare?> GetSpareByIdAsync(int EmployeeID);
        //This method will return Employees by Departmentid
        Task<IEnumerable<Spare>> GetSpareByBrandAsync(int Departmentid);
    }
}
