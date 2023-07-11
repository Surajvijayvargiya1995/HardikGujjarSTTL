﻿using System;
using System.Collections.Generic;

namespace IBS.Models;

public partial class InspectionTstPlndimension
{
    public string? DimCd { get; set; }

    public string? Parameter { get; set; }

    public string? Specified { get; set; }

    public string? ItemCd { get; set; }

    public string? HeaderCode { get; set; }

    public decimal? RowHeight { get; set; }
}
