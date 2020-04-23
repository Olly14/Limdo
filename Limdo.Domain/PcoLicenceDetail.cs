

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Limdo.Domain
{
    public class PcoLicenceDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string PcoId { get; set; }

        public string ExprireDate { get; set; }

        public string IssueDate { get; set; }
    }
}
