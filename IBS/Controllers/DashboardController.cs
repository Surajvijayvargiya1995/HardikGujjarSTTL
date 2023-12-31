﻿using IBS.Interfaces;
using IBS.Models;
using IBS.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace IBS.Controllers
{
    //[Authorize]
    public class DashboardController : BaseController
    {
        #region Variables
        private readonly IIEMessageRepository userRepository;
        #endregion
        public DashboardController(IIEMessageRepository _userRepository)
        {
            userRepository = _userRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IE_Instructions()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoadTable([FromBody] DTParameters dtParameters)
        {
            DTResult<IEMessagesModel> dTResult = userRepository.GetUserList(dtParameters,GetRegionCode);
            return Json(dTResult);
        }
    }
}
