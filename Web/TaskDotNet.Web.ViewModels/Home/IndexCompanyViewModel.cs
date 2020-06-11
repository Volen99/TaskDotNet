namespace TaskDotNet.Web.ViewModels.Home
{
    using System;

    using TaskDotNet.Data.Models;
    using TaskDotNet.Services.Mapping;

    public class IndexCompanyViewModel : IMapFrom<Company>, IMapTo<Company>
    {
        public string Name { get; set; }

        public DateTime CreationDate { get; set; }

        public string ImageUrl { get; set; }

        public int EmployeesCount { get; set; }

        public string Url => $"/f/{this.Name.Replace(' ', '-')}";
    }
}
