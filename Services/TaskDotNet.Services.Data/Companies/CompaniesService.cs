namespace TaskDotNet.Services.Data.Companies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using TaskDotNet.Data.Common.Repositories;
    using TaskDotNet.Data.Models;
    using TaskDotNet.Services.Data.Employees;
    using TaskDotNet.Services.Data.Offices;
    using TaskDotNet.Services.Mapping;

    public class CompaniesService : ICompaniesService
    {
        private readonly IDeletableEntityRepository<Company> companiesRepository;
        private readonly IEmployeesService employeesService;
        private readonly IOfficesService officesService;

        public CompaniesService(
            IDeletableEntityRepository<Company> categoriesRepository,
            IEmployeesService employeesService,
            IOfficesService officesService)
        {
            this.companiesRepository = categoriesRepository;
            this.employeesService = employeesService;
            this.officesService = officesService;
        }

        public async Task<int> CreateAsync(string name, string imageUrl, string userId)
        {
            var company = new Company
            {
                Name = name,
                CreationDate = DateTime.UtcNow,
                ImageUrl = imageUrl,
                UserId = userId,
            };

            await this.companiesRepository.AddAsync(company);
            await this.companiesRepository.SaveChangesAsync();

            return company.Id;
        }

        public T GetById<T>(int id)
        {
            var companyCurrent = this.companiesRepository.All()
                .Where(c => c.Id == id)
                .To<T>()
                .FirstOrDefault();

            return companyCurrent;
        }

        public T GetByName<T>(string name)
        {
            var companyCurrent = this.companiesRepository.All()
                .Where(x => x.Name.Replace(" ", "-") == name.Replace(" ", "-"))
                .To<T>()
                .FirstOrDefault();

            return companyCurrent;
        }

        public IEnumerable<T> GetAll<T>(int? count = null)
        {
            var companies = this.companiesRepository.All();

            if (count.HasValue)
            {
                companies = companies.Take(count.Value);
            }

            return companies.To<T>()
                .ToList();
        }

        public async Task Edit(string name, string imageUrl, int companyId)
        {
            var companyCurrent = this.companiesRepository.All()
                .Where(i => i.Id == companyId)
                .FirstOrDefault();

            companyCurrent.Name = name;
            companyCurrent.ImageUrl = imageUrl;

            await this.companiesRepository.SaveChangesAsync();
        }

        public async Task Delete(int companyId)
        {
            var companyCurrent = this.companiesRepository.All()
                .FirstOrDefault(i => i.Id == companyId);

            await this.employeesService.DeleteAllByCompanyId(companyId);
            await this.officesService.DeleteAllByCompanyId(companyId);

            this.companiesRepository.Delete(companyCurrent);
            await this.companiesRepository.SaveChangesAsync();
        }
    }
}
