using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Teme.Shared.Data.Context
{
    public class AuthUser : BaseEntity
    {
        [Required]
        public string UserName { get; set; }

        public string Bin { get; set; }

        public bool? HasIin { get; set; }

        public string Iin { get; set; }

        public string Pwdhash { get; set; }

        public string CompanyName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required]
        public string Email { get; set; }

        public string UserType { get; set; }

        [Required]
        public virtual IEnumerable<AuthUserScopes> Scopes { get; set; }
    }

    public class AuthUserScopes : BaseEntity
    {
        public string Scope { get; set; }
    }
}