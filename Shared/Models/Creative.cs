using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oqtane.Models;

namespace Fabletown.Module.Publisher.Shared.Models
{
    [Table("FabletownCreative")]
    public class Creative : ModelBase
    {
        [Key]
        public int CreativeId { get; set; }
        public int UserId { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public int? AvatarFileId { get; set; }
        public string Bio { get; set; }
    }
}
