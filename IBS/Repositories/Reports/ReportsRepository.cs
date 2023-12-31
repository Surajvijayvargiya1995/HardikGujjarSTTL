﻿using IBS.Helper;
using IBS.Interfaces.Reports;
using IBS.Models;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Drawing;

namespace IBS.Repositories.Reports
{
    public class ReportsRepository : IReportsRepository
    {
        public DTResult<PendingJICasesReportModel> Get_Pending_JI_Cases(DTParameters dtParameters, string iecd)
        {
            DTResult<PendingJICasesReportModel> dTResult = new() { draw = 0 };
            IQueryable<PendingJICasesReportModel>? query = null;

            var searchBy = dtParameters.Search?.Value;
            var orderCriteria = string.Empty;
            var orderAscendingDirection = true;


            if (dtParameters.Order != null)
            {
                // in this example we just default sort on the 1st column
                orderCriteria = dtParameters.Columns[dtParameters.Order[0].Column].Data;

                if (orderCriteria == "")
                {
                    orderCriteria = "BK_NO";
                }
                orderAscendingDirection = dtParameters.Order[0].Dir.ToString().ToLower() == "desc";
            }
            else
            {
                orderCriteria = "BK_NO";
                orderAscendingDirection = true;
            }

            string FromDate = "", ToDate = "", IE_CD = "";
            if (!string.IsNullOrEmpty(dtParameters.AdditionalValues["FromDate"]))
            {
                FromDate = Convert.ToString(dtParameters.AdditionalValues["FromDate"]);
                FromDate = Common.DateConcate(FromDate);
            }
            if (!string.IsNullOrEmpty(dtParameters.AdditionalValues["ToDate"]))
            {
                ToDate = Convert.ToString(dtParameters.AdditionalValues["ToDate"]);
                ToDate = Common.DateConcate(ToDate);
            }
            if (!string.IsNullOrEmpty(iecd))
            {
                IE_CD = iecd;
            }


            FromDate = FromDate.ToString() == "" ? string.Empty : FromDate.ToString();
            ToDate = ToDate.ToString() == "" ? string.Empty : ToDate.ToString();

            OracleParameter[] par = new OracleParameter[4];
            par[0] = new OracleParameter("P_FROMDATE", OracleDbType.Varchar2, FromDate, ParameterDirection.Input);
            par[1] = new OracleParameter("P_TODATE", OracleDbType.Varchar2, ToDate, ParameterDirection.Input);
            par[2] = new OracleParameter("P_IECD", OracleDbType.Varchar2, IE_CD, ParameterDirection.Input);
            par[3] = new OracleParameter("P_RESULT_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);

            var ds = DataAccessDB.GetDataSet("SP_GET_PENDING_JI_CASES", par, 1);
            DataTable dt = ds.Tables[0];


            List<PendingJICasesReportModel> list = dt.AsEnumerable().Select(row => new PendingJICasesReportModel
            {
                COMPLAINT_ID = Convert.ToString(row["COMPLAINT_ID"]),
                COMPLAINT_DATE = Convert.ToString(row["COMPLAINT_DATE"]),
                REJ_MEMO = Convert.ToString(row["REJ_MEMO"]),
                CASE_NO = Convert.ToString(row["CASE_NO"]),
                BK_NO = Convert.ToString(row["BK_NO"]),
                SET_NO = Convert.ToString(row["SET_NO"]),
                IE_NAME = Convert.ToString(row["IE_NAME"]),
                IE_CO_NAME = Convert.ToString(row["IE_CO_NAME"]),
                COMP_RECV_REGION = Convert.ToString(row["COMP_RECV_REGION"]),
                CONSIGNEE = Convert.ToString(row["CONSIGNEE"]),
                VENDOR = Convert.ToString(row["VENDOR"]),
                ITEM_DESC = Convert.ToString(row["ITEM_DESC"]),
                QTY_OFF = Convert.ToString(row["QTY_OFF"]),
                QTY_REJECTED = Convert.ToString(row["QTY_REJECTED"]),
                REJECTION_VALUE = Convert.ToString(row["REJECTION_VALUE"]),
                REJECTION_REASON = Convert.ToString(row["REJECTION_REASON"]),
                STATUS = Convert.ToString(row["STATUS"]),
                JI_REQUIRED = Convert.ToString(row["JI_REQUIRED"]),
                JI_SNO = Convert.ToString(row["JI_SNO"]),
                JI_DATE = Convert.ToString(row["JI_DATE"]),
                DEFECT_DESC = Convert.ToString(row["DEFECT_DESC"]),
                JI_STATUS_DESC = Convert.ToString(row["JI_STATUS_DESC"]),
                ACTION = Convert.ToString(row["ACTION"]),
                PO_NO = Convert.ToString(row["PO_NO"]),
                PO_DATE = Convert.ToString(row["PO_DATE"]),
                IC_DATE = Convert.ToString(row["IC_DATE"]),
                JI_IE_NAME = Convert.ToString(row["JI_IE_NAME"]),
                ACTION_PROPOSED = Convert.ToString(row["ACTION_PROPOSED"]),
                ACTION_PROPOSED_DATE = Convert.ToString(row["ACTION_PROPOSED_DATE"]),
                CO_NAME = Convert.ToString(row["CO_NAME"])
            }).ToList();

            query = list.AsQueryable();

            dTResult.recordsTotal = ds.Tables[0].Rows.Count;
            dTResult.recordsFiltered = ds.Tables[0].Rows.Count;
            dTResult.data = DbContextHelper.OrderByDynamic(query, orderCriteria, orderAscendingDirection).Skip(dtParameters.Start).Take(dtParameters.Length).Select(p => p).ToList();
            dTResult.draw = dtParameters.Draw;
            return dTResult;
        }

        public DTResult<IEDairyModel> Get_IE_Dairy(DTParameters dtParameters, UserSessionModel userModel)
        {
            DTResult<IEDairyModel> dTResult = new() { draw = 0 };
            IQueryable<IEDairyModel>? query = null;
            
            var searchBy = dtParameters.Search?.Value;
            var orderCriteria = string.Empty;
            var orderAscendingDirection = true;


            if (dtParameters.Order != null)
            {
                // in this example we just default sort on the 1st column
                orderCriteria = dtParameters.Columns[dtParameters.Order[0].Column].Data;

                if (orderCriteria == "")
                {
                    orderCriteria = "IE_NAME";
                }
                orderAscendingDirection = dtParameters.Order[0].Dir.ToString().ToLower() == "desc";
            }
            else
            {
                orderCriteria = "IE_NAME";
                orderAscendingDirection = true;
            }

            string FromDate = "", ToDate = "", Region = "", IECD = null;
            int sorByVisitDate = 0;
            var IsAll = true;
            if (!string.IsNullOrEmpty(dtParameters.AdditionalValues["FromDate"]))
            {
                FromDate = Convert.ToString(dtParameters.AdditionalValues["FromDate"]);
                FromDate = Common.DateConcate(FromDate);
            }
            if (!string.IsNullOrEmpty(dtParameters.AdditionalValues["ToDate"]))
            {
                ToDate = Convert.ToString(dtParameters.AdditionalValues["ToDate"]);
                ToDate = Common.DateConcate(ToDate);
            }
            if (!string.IsNullOrEmpty(dtParameters.AdditionalValues["DpIE"]))
            {
                IECD = Convert.ToString(dtParameters.AdditionalValues["DpIE"]);                
            }
            if (!string.IsNullOrEmpty(dtParameters.AdditionalValues["OrderByVisit"]))
            {
                sorByVisitDate = Convert.ToInt16(dtParameters.AdditionalValues["OrderByVisit"]);
            }
            if (!string.IsNullOrEmpty(dtParameters.AdditionalValues["IsAllIE"]))
            {
                IsAll = Convert.ToBoolean(dtParameters.AdditionalValues["IsAllIE"]);
            }


            if (userModel.RoleName == "Inspection Engineer (IE)")
            {
                IECD = Convert.ToString(userModel.IeCd);
            }
            else
            {                
                if(IsAll == true)
                {
                    IECD = null;
                }                
            }

            FromDate = FromDate.ToString() == "" ? string.Empty : FromDate.ToString();
            ToDate = ToDate.ToString() == "" ? string.Empty : ToDate.ToString();

            OracleParameter[] par = new OracleParameter[6];
            par[0] = new OracleParameter("P_FROMDATE", OracleDbType.Varchar2, FromDate, ParameterDirection.Input);
            par[1] = new OracleParameter("P_TODATE", OracleDbType.Varchar2, ToDate, ParameterDirection.Input);
            par[2] = new OracleParameter("P_IECD", OracleDbType.Varchar2, IECD, ParameterDirection.Input);
            par[3] = new OracleParameter("P_REGION", OracleDbType.Varchar2, userModel.Region, ParameterDirection.Input);
            par[4] = new OracleParameter("P_SORTVISTDATE", OracleDbType.Int16, sorByVisitDate, ParameterDirection.Input);
            par[5] = new OracleParameter("P_RESULT_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);

            var ds = DataAccessDB.GetDataSet("SP_GET_IE_DAIRY_REPORT", par, 1);
            DataTable dt = ds.Tables[0];


            List<IEDairyModel> list = dt.AsEnumerable().Select(row => new IEDairyModel
            {
                IE_NAME = Convert.ToString(row["IE_NAME"]),
                PO = Convert.ToString(row["PO"]),
                CASE_NO = Convert.ToString(row["CASE_NO"]),
                CALL = Convert.ToString(row["CALL"]),
                VEND = Convert.ToString(row["VEND"]),
                DT_OF_VISIT = Convert.ToString(row["DT_OF_VISIT"]),
                ITEM_DESC_PO = Convert.ToString(row["ITEM_DESC_PO"]),
                QTY_TO_INSP = Convert.ToString(row["QTY_TO_INSP"]),
                CALL_INSTALL_NO = Convert.ToString(row["CALL_INSTALL_NO"]),
                BK_NO = Convert.ToString(row["BK_NO"]),
                IC_ISSUE_DT = Convert.ToString(row["IC_ISSUE_DT"]),
                CONSIGNEE = Convert.ToString(row["CONSIGNEE"]),
                MATERIAL_VALUE = Convert.ToString(row["MATERIAL_VALUE"]),
                SUBMIT_DT = Convert.ToString(row["SUBMIT_DT"]),
                INSP_FEE = Convert.ToString(row["INSP_FEE"])
            }).ToList();
           
            query = list.AsQueryable();

            dTResult.recordsTotal = ds.Tables[0].Rows.Count;
            dTResult.recordsFiltered = ds.Tables[0].Rows.Count;
            dTResult.data = DbContextHelper.OrderByDynamic(query, orderCriteria, orderAscendingDirection).Skip(dtParameters.Start).Take(dtParameters.Length).Select(p => p).ToList();
            dTResult.draw = dtParameters.Draw;
            return dTResult;
        }
    }
}
