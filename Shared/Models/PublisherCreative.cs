using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oqtane.Models;

namespace Fabletown.Module.Publisher.Shared.Models
{
    [Table("FabletownPublisherCreative")]
    public class PublisherCreative : ModelBase
    {
        [Key]
        public int PublisherCreativeId { get; set; }
        public int PublisherId { get; set; }
        public int CreativeId { get; set; }
        public int CreativeRoleId { get; set; }
    }
}
