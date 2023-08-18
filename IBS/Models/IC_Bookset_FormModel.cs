﻿using IBS.DataAccess;

namespace IBS.Models
{
    public class IC_Bookset_FormModel
    {
        public string? BkNo { get; set; }

        public string? SetNoFr { get; set; }

        public string? SetNoTo { get; set; }

        public DateTime? IssueDt { get; set; }

        public int? IssueToIecd { get; set; }

        public string? BkSubmitted { get; set; }

        public DateTime? BkSubmitDt { get; set; }

        public string? Region { get; set; }

        public string? UserId { get; set; }

        public DateTime? Datetime { get; set; }

        public DateTime? CutOffDt { get; set; }

        public string? CutOffSet { get; set; }

        public byte? Isdeleted { get; set; }

        public int? Createdby { get; set; }

        public int? Updatedby { get; set; }

        public DateTime? Createddate { get; set; }

        public DateTime? Updateddate { get; set; }
        public virtual T09Ie? IssueToIecdNavigation { get; set; }
    }
}