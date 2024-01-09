using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oqtane.Models;

namespace Fabletown.Module.Publisher.Shared.Models
{
    [Table("FabletownComicCreative")]
    public class ComicCreative : ModelBase
    {
        [Key]
        public int ComicCreativeId { get; set; }
        public int ComicId { get; set; }
        public int CreativeId { get; set; }
        public int CreativeRoleId { get; set; }
    }
}
