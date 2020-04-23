using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Limdo.Domain
{
    [Table("dbo_Users")]
    public class User
    {
        public User()
        {
            Claims = new List<UserClaim>();
            Logins = new List<UserLogin>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key] 
        [MaxLength(50)] 
        public string SubjectId { get; set; }

        [MaxLength(50)]
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        [Required]
        public bool IsActive { get; set; }
        [Required]
        public bool IsBlocked { get; set; }

        public ICollection<UserClaim> Claims { get; set; }
        public ICollection<UserLogin> Logins { get; set; }
        public string Email { get; set; }

        [NotMapped]
        public AppUser AppUser { get; set; }
    }
}
