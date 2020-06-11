namespace TaskDotNet.Services.Data.Offices
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using TaskDotNet.Data.Common.Repositories;
    using TaskDotNet.Data.Models;
    using TaskDotNet.Services.Mapping;

    public class OfficesService : IOfficesService
    {
        private readonly IDeletableEntityRepository<Office> officesRepository;

        public OfficesService(IDeletableEntityRepository<Office> officesRepository)
        {
            this.officesRepository = officesRepository;
        }

        public async Task CreateAsync(string country, string city, string street, int streetNumber, bool isHeadquarters, int companyId)
        {
            var officeNew = new Office
            {
                Country = country,
                City = city,
                Street = street,
                StreetNumber = streetNumber,
                IsHeadquarters = isHeadquarters,
                CompanyId = companyId,
            };

            await this.officesRepository.AddAsync(officeNew);
            await this.officesRepository.SaveChangesAsync();
        }

        public T GetById<T>(int id)
        {
            var officeCurrent = this.officesRepository.All()
                .Where(i => i.Id == id)
                .To<T>()
                .FirstOrDefault();

            return officeCurrent;
        }

        public IEnumerable<T> GetAll<T>(int? count = null)
        {
            var offices = this.officesRepository.All();

            if (count.HasValue)
            {
                offices = offices.Take(count.Value);
            }

            return offices.To<T>()
                .ToList();
        }

        public IEnumerable<T> GetAllByCompanyId<T>(int companyId, int? take = null, int skip = 0)
        {
            var offices = this.officesRepository.All()
                .Where(x => x.CompanyId == companyId)
                .Skip(skip);

            if (take.HasValue)
            {
                offices = offices.Take(take.Value);
            }

            return offices.To<T>()
                .ToList();
        }

        public async Task Edit(int id, string country, string city, string street, int streetNumber, bool isHeadquarters)
        {
            var officeCurrent = this.officesRepository.All()
                .FirstOrDefault(o => o.Id == id);

            officeCurrent.Country = country;
            officeCurrent.City = city;
            officeCurrent.Street = street;
            officeCurrent.StreetNumber = streetNumber;
            officeCurrent.IsHeadquarters = isHeadquarters;

            await this.officesRepository.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var officeCurrent = this.officesRepository.All()
                .FirstOrDefault(e => e.Id == id);

            this.officesRepository.Delete(officeCurrent);

            await this.officesRepository.SaveChangesAsync();
        }

        public async Task DeleteAllByCompanyId(int companyId, int? count = null)
        {
            var companyOffices = this.officesRepository.All()
                .Where(o => o.CompanyId == companyId);

            foreach (var office in companyOffices)
            {
                 this.officesRepository.Delete(office);
            }

            await this.officesRepository.SaveChangesAsync();
        }
    }
}
