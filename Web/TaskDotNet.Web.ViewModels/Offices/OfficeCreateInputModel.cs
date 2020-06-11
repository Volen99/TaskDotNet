namespace TaskDotNet.Web.ViewModels.Offices
{
    using System.ComponentModel.DataAnnotations;

    public class OfficeCreateInputModel
    {
        public string Country { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        [Display(Name = "Street Number")]
        public int StreetNumber { get; set; }

        [Display(Name = "Is Office Headquarters?")]
        public bool IsHeadquarters { get; set; }

        public int CompanyId { get; set; }
    }
}
