using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Models
{
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        [Display(ResourceType = typeof(Resources.Event), Name="Name")]
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Display(ResourceType = typeof(Resources.Event), Name = "Description")]
        [MaxLength(500)]
        public string Description { get; set; }

        [Display(ResourceType = typeof(Resources.Event), Name = "StartDate")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Display(ResourceType = typeof(Resources.Event), Name = "StartTime")]
        [Required]
        [DataType(DataType.Time)] //"{0:hh:mm:ss}"
        [DisplayFormat(DataFormatString = "{0:hh:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; }

        [Display(ResourceType = typeof(Resources.Event), Name = "EndDate")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        [Display(ResourceType = typeof(Resources.Event), Name = "EndTime")]
        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime EndTime { get; set; }

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
        
        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public virtual ICollection<EventUser> EventUsers{ get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DataType(DataType.DateTime)]
        public DateTime CreationDate { get; set; }

        public Event()
        {
            EventUsers = new HashSet<EventUser>();
        }
    }
}