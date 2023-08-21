﻿using IBS.Interfaces;
using IBS.Interfaces.Reports;
using IBS.Models;
using IBS.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace IBS.Controllers.Reports
{
    public class ReportsController : BaseController
    {
        #region Variables
        private readonly IReportsRepository reportsRepository;
        private readonly IWebHostEnvironment env;
        private readonly IConfiguration _config;
        #endregion

        public ReportsController(IReportsRepository _reportsRepository, IWebHostEnvironment _environment, IConfiguration configuration)
        {
            reportsRepository = _reportsRepository;
            env = _environment;
            _config = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FromToDate()
        {
            var action = Request.Query["actiontype"];
            ViewBag.Action = action;
            var partialView = "../IC_Receipt/IC_Unbilled_Partial";
            if (action == "UNBILLEDIC")
            {
                partialView = "../IC_Receipt/IC_Unbilled_Partial";
            }
            else if (action == "ICISSUEDNSUB")
            {
                partialView = "../IC_Receipt/IC_Issued_Partial";
            }
            else if(action == "PJI")
            {
                partialView = "../Reports/Pending_JI_Cases_Partial";
            }
            ViewBag.PartialView = partialView;
            return View();
        }

        public IActionResult Get_Pending_JI_Cases([FromBody] DTParameters dtParameters)
        {
            DTResult<PendingJICasesReportModel> dtList = new();
            try
            {
                var region = GetUserInfo.Region;
                var username = GetUserInfo.UserName;
                var iecd = Convert.ToString(GetUserInfo.IeCd);
                dtList = reportsRepository.Get_Pending_JI_Cases(dtParameters, iecd);

                foreach (var row in dtList.data)
                {
                    var casetifpath = Path.Combine(env.WebRootPath, "/RBS/COMPLAINTS_CASES/" + row.CASE_NO + "-" + row.BK_NO + "-" + row.SET_NO + ".TIF");
                    var casepdfpath = Path.Combine(env.WebRootPath, "/RBS/COMPLAINTS_CASES/" + row.CASE_NO + "-" + row.BK_NO + "-" + row.SET_NO + ".PDF");

                    var reporttifpath = Path.Combine(env.WebRootPath, "/RBS/COMPLAINTS_REPORT/" + row.CASE_NO + "-" + row.BK_NO + "-" + row.SET_NO + ".TIF");
                    var reportpdfpath = Path.Combine(env.WebRootPath, "/RBS/COMPLAINTS_REPORT/" + row.CASE_NO + "-" + row.BK_NO + "-" + row.SET_NO + ".PDF");
                    row.IsCaseTIF = System.IO.File.Exists(casetifpath) == true ? true : false;
                    row.IsCasePDF = System.IO.File.Exists(casepdfpath) == true ? true : false;

                    row.IsReportTIF = System.IO.File.Exists(reporttifpath) == true ? true : false;
                    row.IsReportPDF = System.IO.File.Exists(reportpdfpath) == true ? true : false;
                }
            }
            catch (Exception ex)
            {
                Common.AddException(ex.ToString(), ex.Message.ToString(), "Reports", "Get_Pending_JI_Cases", 1, GetIPAddress());
            }
            return Json(dtList);
        }

        public IActionResult IEDairy()
        {
            var action = Convert.ToString(Request.Query["actiontype"]) == null ? "" : Convert.ToString(Request.Query["actiontype"]);
            ViewBag.Action = action;
            @ViewBag.Region = Convert.ToString(GetUserInfo.Region);
            return View();
        }

    }
}