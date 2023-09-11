﻿namespace IBS.Models
{
    public class CentralRegionBillingInformationModel
    {
        public string BillNo { get; set; } = null!;

        public DateTime? BillDt { get; set; }

        public string? Region { get; set; }

        public string? RlyNonrly { get; set; }

        public string? PoNo { get; set; }

        public DateTime? PoDt { get; set; }

        public string? Purchaser { get; set; }

        public string? Bpo { get; set; }

        public string? Consignee { get; set; }

        public string? RailDescID { get; set; }

        public string? RailDesc { get; set; }

        public string? IcNo { get; set; }

        public DateTime? IcDt { get; set; }

        public decimal? BasePrice { get; set; }

        public decimal? Qty { get; set; }

        public decimal? TotBaseValue { get; set; }

        public decimal? Laying { get; set; }

        public decimal? ExcisePer { get; set; }

        public decimal? Excise { get; set; }

        public decimal? SalesTaxPer { get; set; }

        public decimal? SalesTax { get; set; }

        public decimal? MaterialValue { get; set; }

        public decimal? FeeRate { get; set; }

        public decimal? InspFee { get; set; }

        public decimal? ServTaxRate { get; set; }

        public decimal? ServiceTax { get; set; }

        public decimal? EduCess { get; set; }

        public decimal? SheCess { get; set; }

        public decimal? BillAmount { get; set; }

        public string? Remarks { get; set; }

        public string? UserId { get; set; }

        public DateTime? Datetime { get; set; }

        public bool IsEdited { get; set; }
        public int? Createdby { get; set; }

        public DateTimeOffset? Createddate { get; set; }

        public int? Updatedby { get; set; }

        public DateTimeOffset? Updateddate { get; set; }

        public byte? Isdeleted { get; set; }
    }

    public class CentralRegionBillingInformationListModel
    {
        public string BILL_NO { get; set; }
        public string BILL_DT { get; set; }
        public string IC_NO { get; set; }
        public string IC_DT { get; set; }
        public string BPO { get; set; }
        public string INSP_FEE { get; set; }
        public string TAX { get; set; }
        public decimal BILL_AMOUNT { get; set; }
    }
}