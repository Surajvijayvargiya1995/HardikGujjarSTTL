﻿namespace IBS.Models
{
    public class MasterItemsListFormModel
    {
        public string ItemCd { get; set; } = null!;

        public string? ItemDesc { get; set; }

        public string? Department { get; set; }

        public byte? TimeForInsp { get; set; }

        public string? Checksheet { get; set; }

        public string? UserId { get; set; }

        public DateTime? Datetime { get; set; }
        public byte? Ie { get; set; }

        public byte? Cm { get; set; }

        public byte? Isdeleted { get; set; }

        public int? Createdby { get; set; }

        public int? Updatedby { get; set; }

        public DateTime? Createddate { get; set; }

        public DateTime? Updateddate { get; set; }

        public DateTime? CreationRevDt { get; set; }
        

    }
}