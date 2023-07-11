﻿using System;
using System.Collections.Generic;

namespace IBS.Models;

public partial class ErpProblem
{
    public int ErpProbId { get; set; }

    public string? Name { get; set; }

    public string? ProbDesc { get; set; }

    public DateTime? Datetime { get; set; }

    public string? Resolution { get; set; }
}
