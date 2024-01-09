using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oqtane.Models;

namespace Fabletown.Module.Publisher.Models
{
    [Table("FabletownPublisher")]
    public class Publisher : ModelBase
    {
        [Key]
        public int PublisherId { get; set; }
        public int ModuleId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Tagline { get; set; }
        public string Description { get; set; }
        public int? LogoFileId { get; set; }
        public int? BannerFileId { get; set; }

    }
}
