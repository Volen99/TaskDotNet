namespace TaskDotNet.Web.ViewModels.Offices
{
    using System.ComponentModel.DataAnnotations;

    using TaskDotNet.Data.Models;
    using TaskDotNet.Services.Mapping;

    public class OfficeEditInputViewModel : IMapTo<Office>, IMapFrom<Office>
    {
        public int Id { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        [Display(Name = "Street Number")]
        public int StreetNumber { get; set; }

        public bool IsHeadquarters { get; set; }

        public int CompanyId { get; set; }
    }
}
