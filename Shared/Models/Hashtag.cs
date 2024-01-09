using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oqtane.Models;

namespace Fabletown.Module.Publisher.Shared.Models
{
    [Table("FabletownHashtag")]
    public class Hashtag : ModelBase
    {
        [Key]
        public int HashtagId { get; set; }
        public string HashtagName { get; set; }
        public string Description { get; set; }
    }
}
