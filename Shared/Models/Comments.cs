using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oqtane.Models;

namespace Fabletown.Module.Publisher.Shared.Models
{
    [Table("FabletownComments")]
    public class Comment : ModelBase
    {
        [Key]
        public int CommentId { get; set; }
        public int ReaderId { get; set; }
        public int ComicId { get; set; }
        public int ChapterId { get; set; }
        public int PageId { get; set; }
        public int PanelId { get; set; }
        public int? ParentCommentId { get; set; }
        public int? PriorCommentId { get; set; }
        public bool Superceded { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentDate { get; set; }
    }
}
