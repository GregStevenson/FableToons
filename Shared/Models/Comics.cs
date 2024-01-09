using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oqtane.Models;

namespace Fabletown.Module.Publisher.Shared.Models
{
    [Table("FabletownComics")]
    public class Comics : ModelBase
    {
        [Key]
        public int ComicId { get; set; }
        public int PublisherId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? ThumbnailFileId { get; set; }
        public int? BannerFileId { get; set; }
    }
}
