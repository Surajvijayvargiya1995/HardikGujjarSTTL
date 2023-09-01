﻿using IBS.DataAccess;
using IBS.Interfaces;
using IBS.Models;
using Microsoft.AspNetCore.Mvc;

namespace IBS.Controllers
{
    public class BankMasterController : BaseController
    {
        private readonly IBankRepository bankRepository;

        public BankMasterController(IBankRepository _bankRepository)
        {
            bankRepository = _bankRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Manage(int id)
        {
            BankMasterModel model = new();
            if (id > 0)
            {
                model = bankRepository.FindByID(id);
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult LoadTable([FromBody] DTParameters dtParameters)
        {
            DTResult<BankMasterModel> dTResult = bankRepository.GetBankMasterList(dtParameters);
            return Json(dTResult);
        }

        [HttpPost]
        public IActionResult Manage(BankMasterModel model)
        {
            try
            {
                if (model.BankCd == 0)
                {
                    model.Createdby = UserId;
                    model.UserId = USER_ID.Substring(0, 8);
                    bankRepository.SaveDetails(model);
                    AlertAddSuccess("Record Added Successfully.");
                }
                else
                {
                    model.Updatedby = UserId;
                    model.UserId = USER_ID.Substring(0, 8);
                    bankRepository.SaveDetails(model);
                    AlertAddSuccess("Record Updated Successfully.");
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Common.AddException(ex.ToString(), ex.Message.ToString(), "BankMaster", "Manage", 1, GetIPAddress());
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            try
            {
                if (bankRepository.Remove(id, UserId))
                    AlertDeletedSuccess();
                else
                    AlertDanger();
            }
            catch (Exception ex)
            {
                Common.AddException(ex.ToString(), ex.Message.ToString(), "BankMaster", "Delete", 1, GetIPAddress());
                AlertDanger();
            }
            return RedirectToAction("Index");
        }


    }
}
