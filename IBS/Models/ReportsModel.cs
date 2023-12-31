﻿namespace IBS.Models
{
    public class ReportsModel
    {
    }

    public class PendingJICasesReportModel
    {
        public string COMPLAINT_ID { get; set; }
        public string COMPLAINT_DATE { get; set; }
        public string REJ_MEMO { get; set; }
        public string CASE_NO { get; set; }
        public string BK_NO { get; set; }
        public string SET_NO { get; set; }
        public string IE_NAME { get; set; }
        public string IE_CO_NAME { get; set; }
        public string COMP_RECV_REGION { get; set; }
        public string CONSIGNEE { get; set; }
        public string VENDOR { get; set; }
        public string ITEM_DESC { get; set; }
        public string QTY_OFF { get; set; }
        public string QTY_REJECTED { get; set; }
        public string REJECTION_VALUE { get; set; }
        public string REJECTION_REASON { get; set; }
        public string STATUS { get; set; }
        public string JI_REQUIRED { get; set; }
        public string JI_SNO { get; set; }
        public string JI_DATE { get; set; }
        public string DEFECT_DESC { get; set; }
        public string JI_STATUS_DESC { get; set; }
        public string ACTION { get; set; }
        public string PO_NO { get; set; }
        public string PO_DATE { get; set; }
        public string IC_DATE { get; set; }
        public string JI_IE_NAME { get; set; }
        public string ACTION_PROPOSED { get; set; }
        public string ACTION_PROPOSED_DATE { get; set; }
        public string CO_NAME { get; set; }

        public bool IsCaseTIF { get; set;}
        public bool IsCasePDF { get; set; }
        public bool IsReportTIF { get; set; }
        public bool IsReportPDF { get; set; }
        //public string CASE_NO { get; set; }
        //public string BK_NO { get; set; }
        //public string SET_NO { get; set; }
    }

    public class IEDairyModel
    {
        public string IE_NAME { get; set; }
        public string PO { get; set; }
        public string CASE_NO { get; set; }
        public string CALL { get; set; }
        public string VEND { get; set; }
        public string DT_OF_VISIT { get; set; }
        public string ITEM_DESC_PO { get; set; }
        public string QTY_TO_INSP { get; set; }
        public string CALL_INSTALL_NO { get; set; }
        public string BK_NO { get; set; }
        public string IC_ISSUE_DT { get; set; }
        public string CONSIGNEE { get; set; }
        public string MATERIAL_VALUE { get; set; }
        public string SUBMIT_DT { get; set; }
        public string INSP_FEE { get; set; }
        //public string MyProperty { get; set; }
    }
}
