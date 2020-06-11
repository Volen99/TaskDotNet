namespace TaskDotNet.Web.ViewModels.Companies
{
    using System;

    using TaskDotNet.Data.Models;
    using TaskDotNet.Services.Mapping;

    public class DeleteCompanyViewModel : IMapFrom<Company>, IMapTo<Company>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
