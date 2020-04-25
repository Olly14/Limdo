

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Limdo.Domain
{
    [Table("PcoDetails")]
    public class PcoLicenceDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string PcoId { get; set; }

        public string PcoLicenceId { get; set; }

        public string ExprireDate { get; set; }

        public string IssueDate { get; set; }


        [ForeignKey("AppUserId")]
        public string AppUserId { get; set; }

        public AppUser AppUser { get; set; }
    }
}
