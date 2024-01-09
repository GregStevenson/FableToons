using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oqtane.Models;

namespace Fabletown.Module.Publisher.Shared.Models
{
    [Table("FabletownPages")]
    public class Page : ModelBase
    {
        [Key]
        public int PageId { get; set; }
        public int ChapterId { get; set; }
        public int PageNumber { get; set; }
        public string ImageURL { get; set; }
        public string Caption { get; set; }
    }
}
