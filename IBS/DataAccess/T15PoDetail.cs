﻿using System;
using System.Collections.Generic;

namespace IBS.DataAccess;

public partial class T15PoDetail
{
    public string CaseNo { get; set; } = null!;

    public byte ItemSrno { get; set; }

    public string? ItemDesc { get; set; }

    public int? ConsigneeCd { get; set; }

    public decimal? Qty { get; set; }

    public decimal? Rate { get; set; }

    public byte? UomCd { get; set; }

    public decimal? BasicValue { get; set; }

    public decimal? SalesTaxPer { get; set; }

    public decimal? SalesTax { get; set; }

    public string? ExciseType { get; set; }

    public decimal? ExcisePer { get; set; }

    public decimal? Excise { get; set; }

    public string? DiscountType { get; set; }

    public decimal? DiscountPer { get; set; }

    public decimal? Discount { get; set; }

    public decimal? OtherCharges { get; set; }

    public decimal? Value { get; set; }

    public DateTime? DelvDt { get; set; }

    public DateTime? ExtDelvDt { get; set; }

    public string? UserId { get; set; }

    public DateTime? Datetime { get; set; }

    public string? OtChargeType { get; set; }

    public decimal? OtChargePer { get; set; }

    public string? ItemCd { get; set; }

    public string? PlNo { get; set; }

    public string? Createdby { get; set; }

    public DateTimeOffset? Createddate { get; set; }

    public string? Updatedby { get; set; }

    public DateTimeOffset? Updateddate { get; set; }

    public decimal? Isdeleted { get; set; }

    public virtual T14PoBpo? C { get; set; }

    public virtual T13PoMaster CaseNoNavigation { get; set; } = null!;

    public virtual T04Uom? UomCdNavigation { get; set; }
}
