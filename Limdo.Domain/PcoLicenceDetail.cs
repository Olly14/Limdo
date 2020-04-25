

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Limdo.Domain
{
    [Table("PcoDetails")]
    public class PcoLicenceDetail
    {
        [Key]
        [ForeignKey("AppUserId")]
        public string AppUserId { get; set; }
        public string PcoLicenceNumber { get; set; }
        public string ExprireDate { get; set; }

        public string IssueDate { get; set; }

        [NotMapped]
        public AppUser AppUser { get; set; }
    }
}
