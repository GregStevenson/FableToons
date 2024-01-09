using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oqtane.Models;

namespace Fabletown.Module.Publisher.Shared.Models
{
    [Table("FabletownCreativeRole")]
    public class CreativeRole : ModelBase
    {
        [Key]
        public int CreativeRoleId { get; set; }
        public string Role { get; set; }
        public string Description { get; set; }
    }
}
