using System;
using System.Collections.Generic;

namespace PolicySubmission.DatabaseEntity
{
    public partial class Policy
    {
        public int PolicyId { get; set; }
        public string PolicyStatus { get; set; } = null!;
        public string PolicyType { get; set; } = null!;
        public string PremiumAmount { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public int MemberId { get; set; }

        public virtual MemberRegistration Member { get; set; } = null!;
    }
}
