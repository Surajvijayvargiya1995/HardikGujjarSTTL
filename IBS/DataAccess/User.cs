﻿using System;
using System.Collections.Generic;

namespace IBS.DataAccess;

public partial class User
{
    public decimal Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime? EmailVerifiedAt { get; set; }

    public string Password { get; set; } = null!;

    public string? RememberToken { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
