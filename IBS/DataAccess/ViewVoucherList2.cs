﻿using System;
using System.Collections.Generic;

namespace IBS.DataAccess;

public partial class ViewVoucherList2
{
    public string? VchrNo { get; set; }

    public byte? Sno { get; set; }

    public string? AccDesc { get; set; }

    public decimal? Amount { get; set; }

    public string? BpoName { get; set; }

    public string ChqNo { get; set; } = null!;

    public string? ChqDt { get; set; }

    public string? Narration { get; set; }

    public string? CaseNo { get; set; }

    public int BankCd { get; set; }

    public string? BankName { get; set; }
}
