﻿using IBS.Models;

namespace IBS.Interfaces
{
    public interface INCRRegisterRepository
    {
        DTResult<NCRRegister> GetDataList(DTParameters dtParameters);
        public NCRRegister FindByIDActionA(string CASE_NO, string BK_NO, string SET_NO,string NCNO);
        string SaveRemarks(string NCNO,string UserID, List<Remarks> model);
        string Saveupdate(NCRRegister model,bool isRadioChecked,string extractedText);
        bool SendEmail(NCRRegister nCRRegister);
        int ShouldRemarkDisable(string NCNO);
    }
}
