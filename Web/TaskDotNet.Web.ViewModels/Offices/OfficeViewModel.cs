namespace TaskDotNet.Web.ViewModels.Offices
{
    using System.Collections.Generic;

    using TaskDotNet.Data.Models;
    using TaskDotNet.Services.Mapping;

    public class OfficeViewModel : IMapFrom<Office>, IMapTo<Office>
    {
        public int Id { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public int StreetNumber { get; set; }

        public bool IsHeadquarters { get; set; }

        public int CompanyId { get; set; }

        public ICollection<EmployeeOffice> EmployeesOffices { get; set; }
    }
}
