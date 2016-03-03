using System.ComponentModel.DataAnnotations;

namespace Repository.Models
{
    public class Location
    {
        [Required]
        public string Id { get; set; }

        [Display(ResourceType = typeof(Resources.Location), Name = "Name")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Display(ResourceType = typeof(Resources.Location), Name = "Description")]
        [MaxLength(255)]
        public string Description { get; set; }

        [Display(ResourceType = typeof(Resources.Location), Name = "District")]
        [MaxLength(100)]
        public string District { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resources.Location), Name = "City")]
        [MaxLength(100)]
        public string City { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resources.Location), Name = "Country")]
        [MaxLength(100)]
        public string Country { get; set; }

        [Display(ResourceType = typeof(Resources.Location), Name = "Latitude")]
        [MaxLength(16)]
        public string Latitude { get; set; }

        [Display(ResourceType = typeof(Resources.Location), Name = "Longtitude")]
        [MaxLength(16)]
        public string Longtitude { get; set; }

    }
}