using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Models
{
    public class Location
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy hh-mm}", ApplyFormatInEditMode = true)]
        public DateTime CreationDate { get; set; }

        public string AuthorId { get; set; }
        public virtual User Author { get; set; }
    }
}