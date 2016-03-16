﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Repository.Models
{
    public class EventType
    {
        public string Id { get; set; }

        [Display(ResourceType = typeof(Resources.Event), Name = "TypeName")]
        [Required]
        public string Name{ get; set; }

        [Display(ResourceType = typeof(Resources.Event), Name = "TypeDescription")]
        public string Description { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy hh-mm}", ApplyFormatInEditMode = true)]
        public DateTime CreationDate { get; set; }

        public string AuthorId { get; set; }
        public virtual User Author { get; set; }
    }
}
