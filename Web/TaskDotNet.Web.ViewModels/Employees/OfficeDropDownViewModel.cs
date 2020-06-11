namespace TaskDotNet.Web.ViewModels.Employees
{
    using TaskDotNet.Data.Models;
    using TaskDotNet.Services.Mapping;

    public class OfficeDropDownViewModel : IMapFrom<Office>, IMapTo<Office>
    {
        public int Id { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Street { get; set; }
    }
}
