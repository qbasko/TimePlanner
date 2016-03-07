using System.ComponentModel.DataAnnotations;

namespace Repository.Models
{
    public class EventType
    {
        [Required]
        public string Id { get; set; }

        [Display(ResourceType = typeof(Resources.Event), Name = "TypeName")]
        [Required]
        public string Name{ get; set; }

        [Display(ResourceType = typeof(Resources.Event), Name = "TypeDescription")]
        public string Description { get; set; }
    }
}
