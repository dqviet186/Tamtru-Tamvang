using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TTTVService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class Service1 : IService1
    {
        public string GetAuthor()
        {
            string nhom = "10";
            string dstv = "Duong Quoc Viet (MSSV: 09263L)";
            string tt = "Nhóm: " + nhom + " - Thành viên nhóm: " + dstv;
            return tt;
        }

        public string GetInfoByName(string Name)
        {
            return Name;
        }

        public string GetInfoByPhone(string Phone)
        {
            return "";
        }

        public string GetInfoByIdNumber(string IdNumber)
        {
            return "";
        }

        public int GetInfoBySex(string Address, string Sex)
        {
            return 0;
        }

        public string GetListByAddress(string Address)
        {
            return "";
        }

        public string GetListByDate(string Address, DateTime FromDate, DateTime ToDate)
        {
            return "";
        }

        public string GetListOccupationByAddress(string Address)
        {
            return "";
        }

        public int CountSexByAddress(string Address)
        {
            return 0;
        }
    }
}
