﻿using System.ComponentModel.DataAnnotations;

namespace IBS.Models
{
    public class CentralQOIModel
    {
        [Required]
        public long? TotalQtyDispatched { get; set; }

        public long? NoOfIcIssued { get; set; }
        [Required]
        public string Client { get; set; } = null!;
        public string ClientName { get; set; } = null!;

        public string QtyDate { get; set; } = null!;
        [Required]
        public string Month { get; set; } = null!;
        [Required]
        public string Year { get; set; } = null!;

        public string? RegionCode { get; set; }

        public string? UserId { get; set; }

        public DateTime? Datetime { get; set; }

        public int? Createdby { get; set; }

        public DateTimeOffset? Createddate { get; set; }

        public int? Updatedby { get; set; }

        public DateTimeOffset? Updateddate { get; set; }

        public byte? Isdeleted { get; set; }
        public bool IsEdited { get; set; }
    }
}
