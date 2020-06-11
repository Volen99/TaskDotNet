namespace TaskDotNet.Web.ViewModels.Companies
{
    using System.ComponentModel.DataAnnotations;

    using TaskDotNet.Data.Models;
    using TaskDotNet.Services.Mapping;

    public class CompanyCreateInputModel : IMapTo<Company>, IMapFrom<Company>
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Display(Name = "Image Url")]
        public string ImageUrl { get; set; }

        [Display(Name = "Office Country")]
        public string OfficeCountry { get; set; }

        [Display(Name = "Office City")]
        public string OfficeCity { get; set; }

        [Display(Name = "Office Street")]
        public string OfficeStreet { get; set; }

        [Display(Name = "Office Street Number")]
        public int OfficeStreetNumber { get; set; }

        [Display(Name = "Is Office Headquarters?")]
        public bool OfficeIsHeadquarters { get; set; }
    }
}
