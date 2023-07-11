﻿using System;
using System.Collections.Generic;

namespace IBS.Models;

public partial class T18CallDetail
{
    public string CaseNo { get; set; } = null!;

    public DateTime CallRecvDt { get; set; }

    public short CallSno { get; set; }

    public byte ItemSrnoPo { get; set; }

    public string? ItemDescPo { get; set; }

    public int? ConsigneeCd { get; set; }

    public decimal? QtyOrdered { get; set; }

    public decimal? CumQtyPrevOffered { get; set; }

    public decimal? CumQtyPrevPassed { get; set; }

    public decimal? QtyToInsp { get; set; }

    public decimal? QtyPassed { get; set; }

    public decimal? QtyRejected { get; set; }

    public decimal? QtyDue { get; set; }

    public string? UserId { get; set; }

    public DateTime? Datetime { get; set; }

    public virtual T06Consignee? ConsigneeCdNavigation { get; set; }
}
