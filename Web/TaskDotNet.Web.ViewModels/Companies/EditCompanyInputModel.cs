namespace TaskDotNet.Web.ViewModels.Companies
{
    using TaskDotNet.Data.Models;
    using TaskDotNet.Services.Mapping;

    public class EditCompanyInputModel : IMapFrom<Company>, IMapTo<Company>
    {
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public int CompanyId { get; set; }
    }
}
