﻿using IBS.Filters;
using IBS.Helper;
using IBS.Interfaces;
using IBS.Models;
using IBS.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

namespace IBS.Controllers
{
    public class ComplaintApprovalController : BaseController
    {
        #region Variables
        private readonly IComplaintApprovalRepository complaintApprovalRepository ;
        #endregion

        private readonly IDocument iDocument;
        private readonly IWebHostEnvironment env;
        public ComplaintApprovalController(IDocument _iDocumentRepository, IWebHostEnvironment _environment, IComplaintApprovalRepository _complaintApprovalRepository)
        {
            iDocument = _iDocumentRepository;
            env = _environment;
            complaintApprovalRepository = _complaintApprovalRepository;
        }
        [Authorization("ComplaintApproval", "Index", "view")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoadTable([FromBody] DTParameters dtParameters)
        {
            DTResult<OnlineComplaints> dTResult = complaintApprovalRepository.GetRejComplaints(dtParameters);
            return Json(dTResult);
        }

        [Authorization("ComplaintApproval", "Index", "view")]
        public IActionResult Manage(string TEMP_COMPLAINT_ID,string SetNo,string BKNo,string CaseNo)
        {
            OnlineComplaints model = new();

            try
            {
                model = complaintApprovalRepository.FindByID(TEMP_COMPLAINT_ID, SetNo, BKNo, CaseNo);
                List<IBS_DocumentDTO> lstDocumentUpload_Memo = iDocument.GetRecordsList((int)Enums.DocumentCategory.OnlineComplaints, Convert.ToString(TEMP_COMPLAINT_ID));
                FileUploaderDTO FileUploaderUpload_Memo = new FileUploaderDTO();
                FileUploaderUpload_Memo.Mode = (int)Enums.FileUploaderMode.Add_Edit;
                FileUploaderUpload_Memo.IBS_DocumentList = lstDocumentUpload_Memo.Where(m => m.ID == (int)Enums.DocumentCategory_CANRegisrtation.Upload_Rejection_Memo).ToList();
                FileUploaderUpload_Memo.OthersSection = false;
                FileUploaderUpload_Memo.MaxUploaderinOthers = 5;
                FileUploaderUpload_Memo.FilUploadMode = (int)Enums.FilUploadMode.Single;
                ViewBag.Upload_Rejection_Memo = FileUploaderUpload_Memo;
            }
            catch (Exception ex)
            {
                Common.AddException(ex.ToString(), ex.Message.ToString(), "OnlineComplaints", "ComplaintsSave", 1, GetIPAddress());
            }
            return View(model);
        }

        [HttpPost]
        [Authorization("ComplaintApproval", "Index", "edit")]
        public ActionResult RejectComplaint(OnlineComplaints model)
        {
            string msg = "";
            try
            {
                 msg = complaintApprovalRepository.RejectComp(model);
            }
            catch (Exception ex)
            {
                Common.AddException(ex.ToString(), ex.Message.ToString(), "OnlineComplaints", "ComplaintsSave", 1, GetIPAddress());
            }
            return Json(new { status = true, responseText = msg, redirectToIndex = true, alertMessage = msg });
        }

        public ActionResult GetItems(string InspRegionDropdown)
        {
            var json = complaintApprovalRepository.GetItems(InspRegionDropdown);

            return Json(json);
        }

        [HttpPost]
        [Authorization("ComplaintApproval", "Index", "edit")]
        public ActionResult AcceptComplaint(OnlineComplaints model)
        {
            string msg = complaintApprovalRepository.AcceptComplaint(model);
            return Json(new { status = true, responseText = msg });
        }

        [HttpPost]
        [Authorization("ComplaintApproval", "Index", "edit")]
        public ActionResult Submit(OnlineComplaints model)
        {
            string msg = complaintApprovalRepository.SubmitAcceptRecord(model);
            return Json(new { status = true, responseText = msg, redirectToIndex = true, alertMessage = msg });
        }
    }
}
