using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oqtane.Models;

namespace Fabletown.Module.Publisher.Shared.Models
{
    /// <summary>
    /// Describes a User in Oqtane.
    /// </summary>
    /// 
    public class User : ModelBase
    {
        /// <summary>
        /// ID of this User.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Username used for login.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Name shown in menus / dialogs etc.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// User E-Mail address.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Reference to a <see cref="File"/> containing the users photo.
        /// </summary>
        public int? PhotoFileId { get; set; }

        /// <summary>
        /// Timestamp of last login.
        /// </summary>
    }
}
