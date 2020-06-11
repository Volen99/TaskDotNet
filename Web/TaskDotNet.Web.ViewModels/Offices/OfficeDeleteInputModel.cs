namespace TaskDotNet.Web.ViewModels.Offices
{
    using TaskDotNet.Data.Models;
    using TaskDotNet.Services.Mapping;

    public class OfficeDeleteInputModel : IMapFrom<Office>, IMapTo<Office>
    {
        public int Id { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public int StreetNumber { get; set; }

        public int CompanyId { get; set; }
    }
}
