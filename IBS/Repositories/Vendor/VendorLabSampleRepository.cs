﻿using IBS.DataAccess;
using IBS.Helper;
using IBS.Interfaces;
using IBS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Configuration;
using System.Data;
using System.Reflection.Emit;
using static IBS.Helper.Enums;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace IBS.Repositories
{
    public class VendorLabSampleRepository : IVendorLabSampleInfoRepository
    {
        private readonly ModelContext context;

        public VendorLabSampleRepository(ModelContext context)
        {
            this.context = context;
        }
        public List<LabSampleInfoModel> LapSampleIndex(string CaseNo, string CallRdt,string CallSno, string VenCod)
        {

            using (var dbContext = context.Database.GetDbConnection())
            {
                OracleParameter[] par = new OracleParameter[5];
                par[0] = new OracleParameter("p_VEND_CD", OracleDbType.NVarchar2, VenCod, ParameterDirection.Input);
                par[1] = new OracleParameter("p_CaseNo", OracleDbType.NVarchar2, CaseNo, ParameterDirection.Input);
                par[2] = new OracleParameter("p_CSNO", OracleDbType.NVarchar2, CallSno, ParameterDirection.Input);
                par[3] = new OracleParameter("p_Rdt", OracleDbType.NVarchar2, CallRdt, ParameterDirection.Input);
                par[4] = new OracleParameter("p_Result", OracleDbType.RefCursor, ParameterDirection.Output);

                var ds = DataAccessDB.GetDataSet("Vendor_GetSampleInfoIndex", par, 4);

                List<LabSampleInfoModel> modelList = new List<LabSampleInfoModel>();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        LabSampleInfoModel model = new LabSampleInfoModel
                        {
                            CaseNo = Convert.ToString(row["case_no"]),
                            CallRecDt = Convert.ToString(row["call_recv_dt"]),
                            CallSNO = Convert.ToString(row["call_sno"]),
                            IEName = Convert.ToString(row["ie_name"]),
                            
                        };

                        modelList.Add(model);
                    }
                }

                return modelList;
            }

            //return dTResult;
        }
        public LabSampleInfoModel SampleDtlData(string CaseNo, string CallRdt, string CallSno, string Regin)
        {
           var file = ShowFile(CallRdt, CaseNo, CallSno);
           
            using (var dbContext = context.Database.GetDbConnection())
            {
                OracleParameter[] par = new OracleParameter[4];
                par[0] = new OracleParameter("p_Case_No", OracleDbType.NVarchar2, CaseNo, ParameterDirection.Input);
                par[1] = new OracleParameter("p_Call_Recv_DT", OracleDbType.NVarchar2, CallRdt, ParameterDirection.Input);
                par[2] = new OracleParameter("p_Call_SNO", OracleDbType.NVarchar2, CallSno, ParameterDirection.Input);
                par[3] = new OracleParameter("p_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);

                var ds = DataAccessDB.GetDataSet("Vendor_GetLabSampleDtl", par, 3);

                LabSampleInfoModel model = new();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {

                    DataRow row = ds.Tables[0].Rows[0];
                    model = new LabSampleInfoModel
                    {
                        IEName = row["ie_name"] as string, // Replace "Property1" with the actual column name in the table
                        VendorName = Convert.ToString(row["vendor"]),
                        Vendor = Convert.ToString(row["vend_cd"]),
                        IE = Convert.ToString(row["ie_cd"]),
                        CaseNo = CaseNo,
                        CallRecDt = CallRdt,
                        CallSNO = CallSno,
                        NetTesting = Convert.ToString(row["testing_charges"]),
                        TDS = Convert.ToString(row["tds"]),
                        UTRNO = Convert.ToString(row["utr_no"]),
                        UTRDT = Convert.ToString(row["utr_dt"]),
                        PaymentStatus = Convert.ToString(row["status"]),
                        File = Convert.ToString(file),
                    };
                }
                
                return model;
            }
        }
        public bool ShowFile(string lblCallDT, string lblCaseNo, string lblCSNO)
        {
            
            string mdtEx = dateconcate(lblCallDT.Trim());
            string myFileEx = $"{lblCaseNo.Trim()}_{lblCSNO.Trim()}_{mdtEx}";

            string fpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Payment", $"{myFileEx}.PDF");
            
            return File.Exists(fpath);
        }
        public static string GetDateString(string sqlQuery)
        {
            ModelContext context = new ModelContext(DbContextHelper.GetDbContextOptions());
            string dateResult = null;
            try
            {
                var conn = (OracleConnection)context.Database.GetDbConnection();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sqlQuery;

                    context.Database.OpenConnection();

                    // Execute the SQL query and fetch the date result
                    var result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        dateResult = result.ToString();
                    }

                    context.Database.CloseConnection();
                }
            }
            catch (Exception)
            {
                context.Database.CloseConnection();
            }

            return dateResult;
        }
        public bool SaveDataDetails(LabSampleInfoModel LabSampleInfoModel)
        {
            
            string ss;
            string sqlQuery = "Select to_char(sysdate,'mm/dd/yyyy') from dual";

            ss = GetDateString(sqlQuery);
            try
            {

                OracleParameter[] par = new OracleParameter[9];
                par[0] = new OracleParameter("p_CaseNo", OracleDbType.Varchar2, LabSampleInfoModel.CaseNo, ParameterDirection.Input);
                par[1] = new OracleParameter("p_CallRecvDT", OracleDbType.Date, LabSampleInfoModel.CallRecDt, ParameterDirection.Input);
                par[2] = new OracleParameter("p_CallSno", OracleDbType.Varchar2, LabSampleInfoModel.CallSNO, ParameterDirection.Input);
                par[3] = new OracleParameter("p_TestingCharges", OracleDbType.Varchar2, LabSampleInfoModel.NetTesting, ParameterDirection.Input);
                par[4] = new OracleParameter("p_DocInitDateTime", OracleDbType.Date, ss, ParameterDirection.Input);
                par[5] = new OracleParameter("p_TDS", OracleDbType.Varchar2, LabSampleInfoModel.TDS, ParameterDirection.Input);
                par[6] = new OracleParameter("p_UTRNo", OracleDbType.Varchar2, LabSampleInfoModel.UTRNO, ParameterDirection.Input);
                par[7] = new OracleParameter("p_UTRDate", OracleDbType.Date, LabSampleInfoModel.UTRDT, ParameterDirection.Input);               
                par[8] = new OracleParameter("p_VEND_CD", OracleDbType.Varchar2, LabSampleInfoModel.UName, ParameterDirection.Input);

                var ds = DataAccessDB.ExecuteNonQuery("Vendor_InsertLabSampleInfo", par, 1);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        string dateconcate(string dt)
        {
            string myYear, myMonth, myDay;

            myYear = dt.Substring(6, 4);
            myMonth = dt.Substring(3, 2);
            myDay = dt.Substring(0, 2);
            string dt1 = myYear + myMonth + myDay;
            return (dt1);
        }
        
        public bool UpdateDetails(LabSampleInfoModel LabSampleInfoModel)
        {
            
            //if (LabSampleInfoModel.UploadLab != null && LabSampleInfoModel.UploadLab.Length > 0)
            //{
                
            //    List<string> savedFilePaths = new List<string>();
            //    string fn = "", MyFile = "", fx = "", fl = "";
            //    string mdt = dateconcate(LabSampleInfoModel.CallRecDt);
            //    MyFile = LabSampleInfoModel.CaseNo + '_' + LabSampleInfoModel.CallSNO + '_' + mdt;
            //    fn = System.IO.Path.GetFileName(LabSampleInfoModel.UploadLab.FileName);
            //    fx = System.IO.Path.GetExtension(LabSampleInfoModel.UploadLab.FileName).ToUpper().Substring(1);
            //    string saveLocation = null;
            //    if (fx == "PDF")
            //    {
            //        saveLocation = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "LAB", MyFile + ".PDF");
            //        using (var stream = new FileStream(saveLocation, FileMode.Create))
            //        {
            //            LabSampleInfoModel.UploadLab.CopyTo(stream);
            //        }
            //        savedFilePaths.Add(saveLocation);
            //    }
                
            //}
                string ss;
            string sqlQuery = "Select to_char(sysdate,'mm/dd/yyyy') from dual";

            ss = GetDateString(sqlQuery);
            try
            {

                OracleParameter[] par = new OracleParameter[9];
                par[0] = new OracleParameter("p_TestingCharges", OracleDbType.Varchar2, LabSampleInfoModel.NetTesting, ParameterDirection.Input);
                par[1] = new OracleParameter("p_DocInitDateTime", OracleDbType.Date, ss, ParameterDirection.Input);
                par[2] = new OracleParameter("p_TDS", OracleDbType.Varchar2, LabSampleInfoModel.TDS, ParameterDirection.Input);
                par[3] = new OracleParameter("p_UTRNo", OracleDbType.Varchar2, LabSampleInfoModel.UTRNO, ParameterDirection.Input);
                par[4] = new OracleParameter("p_UTRDate", OracleDbType.Date, LabSampleInfoModel.UTRDT, ParameterDirection.Input);
                par[5] = new OracleParameter("p_CaseNo", OracleDbType.Varchar2, LabSampleInfoModel.CaseNo, ParameterDirection.Input);
                par[6] = new OracleParameter("p_CallRecvDT", OracleDbType.Date, LabSampleInfoModel.CallRecDt, ParameterDirection.Input);
                par[7] = new OracleParameter("p_CallSno", OracleDbType.Varchar2, LabSampleInfoModel.CallSNO, ParameterDirection.Input);
                par[8] = new OracleParameter("p_VEND_CD", OracleDbType.Varchar2, LabSampleInfoModel.UName, ParameterDirection.Input);
                

                var ds = DataAccessDB.ExecuteNonQuery("Vendor_UPDATE_SAMPLE_INFO", par, 1);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public string CheckExist(string CaseNo, string CallRdt, string CallSno,string Regin)
        {

            string query = "SELECT COUNT(*) FROM T110_LAB_DOC T110 " +
                  "WHERE TO_CHAR(T110.CALL_RECV_DT, 'dd/mm/yyyy') = '"+CallRdt+"' " +
                  "AND T110.case_no = '"+CaseNo+"' AND T110.call_sno = '"+CallSno+"'";


            string count = GetDateString(query);

            
            //string nextSerialNumber = (count + 1).ToString();

            return count;
        }


    }
}
