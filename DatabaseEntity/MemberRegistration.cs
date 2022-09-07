using System;
using System.Collections.Generic;

namespace PolicySubmission.DatabaseEntity
{
    public partial class MemberRegistration
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime Dob { get; set; }
        public string Address { get; set; } = null!;
        public string State { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
