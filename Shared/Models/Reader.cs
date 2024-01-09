using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oqtane.Models;

namespace Fabletown.Module.Publisher.Shared.Models
{
    [Table("FabletownReader")]
    public class Reader : ModelBase
    {
        [Key]
        public int ReaderId { get; set; }
        public int ModuleId { get; set; }
        public int UserId { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public int? AvatarFileId { get; set; }
        public string Bio { get; set; }
    }
}
