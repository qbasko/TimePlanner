using System;
using System.ComponentModel.DataAnnotations;

namespace Repository.Models
{
    public class Event
    {
        public string Id { get; set; }

        [Display(ResourceType = typeof(Resources.Event), Name="Name")]
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Display(ResourceType = typeof(Resources.Event), Name = "Description")]
        [MaxLength(500)]
        public string Description { get; set; }

        [Display(ResourceType = typeof(Resources.Event), Name = "StartDateTime")]
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy hh-mm}", ApplyFormatInEditMode = true)]
        public DateTime StartDateTime { get; set; }

        [Display(ResourceType = typeof(Resources.Event), Name = "EndDateTime")]
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy hh-mm}", ApplyFormatInEditMode = true)]
        public DateTime EndDateTime { get; set; }

        [Display(ResourceType = typeof(Resources.Event), Name = "Location")]
        public string LocationId { get; set; }

        public virtual Location Location { get; set; }

        [Display(ResourceType = typeof(Resources.Event), Name = "Type")]
        public string TypeId{ get; set; }

        public virtual EventType Type { get; set; }

        [Display(ResourceType = typeof(Resources.Event), Name = "Objective")]
        [MaxLength(255)]
        public string Objective { get; set; }

        [Display(ResourceType = typeof(Resources.Event), Name = "NumberOfAttendees")]
        public int? NumberOfAttendees { get; set; }
        
        public string UserId { get; set; }

        public virtual User User { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreationDate { get; set; }
    }
}