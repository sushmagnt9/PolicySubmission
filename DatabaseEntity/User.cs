﻿using System;
using System.Collections.Generic;

namespace PolicySubmission.DatabaseEntity
{
    public partial class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
