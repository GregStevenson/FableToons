using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oqtane.Models;

namespace Fabletown.Module.Publisher.Shared.Models
{
    [Table("FabletownLikes")]
    public class Like : ModelBase
    {
        [Key]
        public int LikeId { get; set; }
        public int ReaderId { get; set; }
        public int ComicId { get; set; }
        public int ChapterId { get; set; }
        public int PageId { get; set; }
        public int PanelId { get; set; }
        public bool Enabled { get; set; }
    }
}
