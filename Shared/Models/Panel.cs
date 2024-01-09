using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oqtane.Models;

namespace Fabletown.Module.Publisher.Shared.Models
{
    [Table("FabletownPanel")]
    public class Panel : ModelBase
    {
        [Key]
        public int PanelId { get; set; }
        public int PageId { get; set; }
          public int PageSequence { get; set; }
        public int ImageFileId { get; set; }
        public string Caption { get; set; }
    }
}
