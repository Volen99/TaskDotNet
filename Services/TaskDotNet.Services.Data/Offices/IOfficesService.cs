namespace TaskDotNet.Services.Data.Offices
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IOfficesService
    {
        Task CreateAsync(string country, string city, string street, int streetNumber, bool isHeadquarters, int companyId);

        T GetById<T>(int officeId);

        IEnumerable<T> GetAll<T>(int? count = null);

        IEnumerable<T> GetAllByCompanyId<T>(int companyId, int? take = null, int skip = 0);

        Task Edit(int id, string country, string city, string street, int streetNumber, bool isHeadquarters);

        Task Delete(int id);

        Task DeleteAllByCompanyId(int companyId, int? count = null);
    }
}
