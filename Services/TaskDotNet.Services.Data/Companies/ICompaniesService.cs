namespace TaskDotNet.Services.Data.Companies
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICompaniesService
    {
        Task<int> CreateAsync(string name, string imageUrl, string userId);

        T GetById<T>(int id);

        T GetByName<T>(string name);

        IEnumerable<T> GetAll<T>(int? count = null);

        Task Edit(string name, string imageUrl, int companyId);

        Task Delete(int companyId);
    }
}
