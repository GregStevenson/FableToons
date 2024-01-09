using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oqtane.Models;

namespace Fabletown.Module.Publisher.Shared.Models
{
    [Table("FabletownGenre")]
    public class Genre : ModelBase
    {
        [Key]
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public string Description { get; set; }
    }
}
