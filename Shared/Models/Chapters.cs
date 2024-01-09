using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oqtane.Models;

namespace Fabletown.Module.Publisher.Shared.Models
{
    [Table("FabletownChapters")]
    public class Chapter : ModelBase
    {
        [Key]
        public int ChapterId { get; set; }
        public int ComicId { get; set; }
        public string Title { get; set; }
        public int ChapterNumber { get; set; }
        public DateTime PublicationDate { get; set; }
        public string ThumbnailImage { get; set; }
    }
}
