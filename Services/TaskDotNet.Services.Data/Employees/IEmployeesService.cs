namespace TaskDotNet.Services.Data.Employees
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IEmployeesService
    {
        Task<int> CreateAsync(string firstName, string lastName, decimal salary, int vacationDays, int expirenceLevel, int companyId);

        T GetById<T>(int employeeId);

        IEnumerable<T> GetByCompanyId<T>(int companyId, int? take = null, int skip = 0);

        IEnumerable<T> GetAll<T>(int? count = null);

        Task Edit(int id, string firstName, string lastName, decimal salary, int vacationDays, int expirenceLevel);

        Task<int> Delete(int employeeId);

        Task DeleteAllByCompanyId(int companyId, int? count = null);

        int GetCountByCompanyId(int companyId);
    }
}
