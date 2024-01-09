using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oqtane.Models;

namespace Fabletown.Module.Publisher.Shared.Models
{
    [Table("FabletownComicGenre")]
    public class ComicGenre : ModelBase
    {
        [Key]
        public int ComicGenreId { get; set; }
        public int ComicId { get; set; }
        public int GenreId { get; set; }
        public bool Enabled { get; set; }
    }
}
