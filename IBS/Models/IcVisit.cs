﻿using System;
using System.Collections.Generic;

namespace IBS.Models;

public partial class IcVisit
{
    public string? CaseNo { get; set; }

    public short? CallSno { get; set; }

    public DateTime? CallRecvDt { get; set; }

    public string? VisitsDates { get; set; }
}
