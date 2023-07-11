﻿using System;
using System.Collections.Generic;

namespace IBS.Models;

public partial class T84OutsLy
{
    public string LyPer { get; set; } = null!;

    public decimal? LyOuts { get; set; }

    public string RegionCode { get; set; } = null!;

    public string? UserId { get; set; }

    public DateTime? Datetime { get; set; }
}
