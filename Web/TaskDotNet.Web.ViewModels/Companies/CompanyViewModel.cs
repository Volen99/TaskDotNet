namespace TaskDotNet.Web.ViewModels.Companies
{
    using System.Collections.Generic;

    using TaskDotNet.Data.Models;
    using TaskDotNet.Services.Mapping;
    using TaskDotNet.Web.ViewModels.Employees;
    using TaskDotNet.Web.ViewModels.Offices;

    public class CompanyViewModel : IMapFrom<Company>, IMapTo<Company>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public int CurrentPage { get; set; }

        public int PagesCount { get; set; }

        public string UserId { get; set; }

        public bool HasCurrentUserRights { get; set; }

        public IEnumerable<EmployeeViewModel> Employees { get; set; }

        public IEnumerable<OfficeViewModel> Offices { get; set; }
    }
}
