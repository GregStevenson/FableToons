using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oqtane.Models;

namespace Fabletown.Module.Publisher.Shared.Models
{
    [Table("FabletownComicHashtag")]
    public class ComicHashtag : ModelBase
    {
        [Key]
        public int ComicHashtagId { get; set; }
        public int ComicId { get; set; }
        public int HashtagId { get; set; }
        public bool Enabled { get; set; }
    }
}
