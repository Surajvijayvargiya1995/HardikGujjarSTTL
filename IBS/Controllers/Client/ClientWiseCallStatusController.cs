﻿using IBS.DataAccess;
using IBS.Interfaces;
using IBS.Models;
using IBS.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Text.Json;

namespace IBS.Controllers.Client
{
    public class ClientWiseCallStatusController : BaseController
    {
        #region Variables
        private readonly IClientCallStatusRepository ClientCallStatusRepository;
        #endregion
        public ClientWiseCallStatusController(IClientCallStatusRepository _ClientCallStatusRepository)
        {
            ClientCallStatusRepository = _ClientCallStatusRepository;
        }
        public IActionResult ClientCallStatusReport()
        {
            string actionValue = HttpContext.Request.Query["Action"];
            ViewBag.Action = actionValue;
            return View();
        }
        [HttpPost]
        public IActionResult LoadTable([FromBody] DTParameters dtParameters)
        {
            var Action = dtParameters.AdditionalValues?.GetValueOrDefault("Action");
            DTResult<ClientCallRptModel> dTResult = new DTResult<ClientCallRptModel>();
            if (Action == "R")
            {
                 dTResult = ClientCallStatusRepository.GetCallStatusR(dtParameters);
            }
            else
            {
                 dTResult = ClientCallStatusRepository.GetCallStatusC(dtParameters);
            }

            return Json(dTResult);
        }

    }
}
