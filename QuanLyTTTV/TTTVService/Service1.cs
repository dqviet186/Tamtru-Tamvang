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
        public string GetThongTinNhom()
        {
            string nhom = "10";
            string dstv = "Duong Quoc Viet (MSSV: 09263L)";
            string tt = "Nhóm: " + nhom + " - Thành viên nhóm: " + dstv;
            return tt;
        }
    }
}
