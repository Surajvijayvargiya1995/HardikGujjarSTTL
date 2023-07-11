﻿using System;
using System.Collections.Generic;

namespace IBS.Models;

public partial class T32ClientLogin
{
    public string? UserName { get; set; }

    public string? Organisation { get; set; }

    public string? Designation { get; set; }

    public string Mobile { get; set; } = null!;

    public string? Email { get; set; }

    public string? Pwd { get; set; }

    public string? Status { get; set; }

    public string? OrgnType { get; set; }

    public string? Unit { get; set; }
}
