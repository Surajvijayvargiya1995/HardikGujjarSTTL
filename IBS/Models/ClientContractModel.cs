﻿using System.Composition;

namespace IBS.Models
{
    public class ClientContractModel
    {
        public int Id { get; set; }
        public DateTime VisitDt { get; set; }

        public string? ClientOfficerName { get; set; }

        public string? Designation { get; set; }

        public string? ClientType { get; set; }

        public string Client { get; set; } = null!;

        public byte RitesOfficerCd { get; set; }

        public string? Highlights { get; set; }

        public string? OverallOutcome { get; set; }

        public string? RegionCd { get; set; }

        public string? UserId { get; set; }

        public DateTime? Datetime { get; set; }

        public string TypeCb { get; set; } = null!;

        public decimal? OutAmt { get; set; }

        public byte? Isdeleted { get; set; }

        public DateTime? Createddate { get; set; }

        public int? Createdby { get; set; }

        public DateTime? Updateddate { get; set; }

        public int? Updatedby { get; set; }

    }
}
