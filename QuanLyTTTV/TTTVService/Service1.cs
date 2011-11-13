using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// require class database
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace TTTVService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class Service1 : IService1
    {
        TranferRecord[] data;

        public string GetAuthor()
        {
            string nhom = "Nhóm: 10";
            string hoten = "Họ tên: Dương Quốc Việt";
            string mssv = "MSSV: 09263L";
            string kq = nhom + "\n" + hoten + "\n" + mssv;
            return kq;
        }

        public TranferRecord[] GetInfoByName(string Name, string type)
        {
            try
            {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = "Data Source=mavi-PC;Initial Catalog=cnweb;Integrated Security=True";
                cn.Open();

                string query = "SELECT * FROM tamtrutamvang WHERE FullName like '%" + Name + "%' and Type = '" + type + "'";
                SqlCommand sql = new SqlCommand(query, cn);
                SqlDataAdapter adt = new SqlDataAdapter(sql);
                DataSet ds = new DataSet();
                adt.Fill(ds);
                int rows = ds.Tables[0].Rows.Count;
                data = new TranferRecord[rows];

                for (int i = 0; i < rows; i++)
                {
                    data[i] = new TranferRecord();
                    data[i].Id = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[0].ToString());
                    data[i].FullName = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                    data[i].PhoneNumber = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                    data[i].Email = ds.Tables[0].Rows[i].ItemArray[3].ToString();
                    data[i].Birthday = Convert.ToDateTime(ds.Tables[0].Rows[i].ItemArray[4]);
                    data[i].Sex = ds.Tables[0].Rows[i].ItemArray[5].ToString();
                    data[i].OriginalAddress = ds.Tables[0].Rows[i].ItemArray[6].ToString();
                    data[i].IDNumber = ds.Tables[0].Rows[i].ItemArray[7].ToString();
                    data[i].Occupation = ds.Tables[0].Rows[i].ItemArray[8].ToString();
                    data[i].CurrentAddress = ds.Tables[0].Rows[i].ItemArray[9].ToString();
                    //data[i].FromDate = Convert.ToDateTime(ds.Tables[0].Rows[i].ItemArray[10]);
                    //data[i].ToDate = Convert.ToDateTime(ds.Tables[0].Rows[i].ItemArray[11]);
                    data[i].Reason = ds.Tables[0].Rows[i].ItemArray[12].ToString();
                    data[i].Description = ds.Tables[0].Rows[i].ItemArray[13].ToString();
                    data[i].Type = ds.Tables[0].Rows[i].ItemArray[14].ToString();
                }

                cn.Close();

                return data;
            }
            catch (PisNotFoundException exp)
            {
                TrackedFault tf = new TrackedFault(
                    Guid.NewGuid(),
                    exp.Message,
                    DateTime.Now);

                throw new FaultException<TrackedFault>(
                    tf,
                    new FaultReason("PisNotFoundException"),
                    FaultCode.CreateReceiverFaultCode(new FaultCode("GetInfoByName")));
            }
            catch (Exception exp)
            {
                FaultReasonText reason = new FaultReasonText(exp.Message);
                throw new FaultException(new FaultReason(reason), FaultCode.CreateReceiverFaultCode(new FaultCode("GetInfoByName")));
            }
        }

        public TranferRecord[] GetInfoByPhone(string Phone, string type)
        {
            try
            {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = "Data Source=mavi-PC;Initial Catalog=cnweb;Integrated Security=True";
                cn.Open();

                string query = "SELECT * FROM tamtrutamvang WHERE PhoneNumber = '" + Phone + "' and Type = '" + type + "'";
                SqlCommand sql = new SqlCommand(query, cn);
                SqlDataAdapter adt = new SqlDataAdapter(sql);
                DataSet ds = new DataSet();
                adt.Fill(ds);
                int rows = ds.Tables[0].Rows.Count;
                data = new TranferRecord[rows];

                for (int i = 0; i < rows; i++)
                {
                    data[i] = new TranferRecord();
                    data[i].Id = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[0].ToString());
                    data[i].FullName = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                    data[i].PhoneNumber = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                    data[i].Email = ds.Tables[0].Rows[i].ItemArray[3].ToString();
                    data[i].Birthday = Convert.ToDateTime(ds.Tables[0].Rows[i].ItemArray[4]);
                    data[i].Sex = ds.Tables[0].Rows[i].ItemArray[5].ToString();
                    data[i].OriginalAddress = ds.Tables[0].Rows[i].ItemArray[6].ToString();
                    data[i].IDNumber = ds.Tables[0].Rows[i].ItemArray[7].ToString();
                    data[i].Occupation = ds.Tables[0].Rows[i].ItemArray[8].ToString();
                    data[i].CurrentAddress = ds.Tables[0].Rows[i].ItemArray[9].ToString();
                    //data[i].FromDate = Convert.ToDateTime(ds.Tables[0].Rows[i].ItemArray[10]);
                    //data[i].ToDate = Convert.ToDateTime(ds.Tables[0].Rows[i].ItemArray[11]);
                    data[i].Reason = ds.Tables[0].Rows[i].ItemArray[12].ToString();
                    data[i].Description = ds.Tables[0].Rows[i].ItemArray[13].ToString();
                    data[i].Type = ds.Tables[0].Rows[i].ItemArray[14].ToString();
                }

                cn.Close();

                return data;
            }
            catch (PisNotFoundException exp)
            {
                TrackedFault tf = new TrackedFault(
                    Guid.NewGuid(),
                    exp.Message,
                    DateTime.Now);

                throw new FaultException<TrackedFault>(
                    tf,
                    new FaultReason("PisNotFoundException"),
                    FaultCode.CreateReceiverFaultCode(new FaultCode("GetInfoByPhone")));
            }
            catch (Exception exp)
            {
                FaultReasonText reason = new FaultReasonText(exp.Message);
                throw new FaultException(new FaultReason(reason), FaultCode.CreateReceiverFaultCode(new FaultCode("GetInfoByPhone")));
            }
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

        public void InsertData()
        {

        }

        public void UpdateData(int Id)
        {
            
        }

        public void DeleteData(int Id)
        {

        }

        public TranferRecord[] GetData()
        {
            try
            {
                string query = "SELECT * FROM tamtrutamvang";

                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = "Data Source=mavi-PC;Initial Catalog=cnweb;Integrated Security=True";
                cn.Open();

                SqlCommand sql = new SqlCommand(query, cn);
                SqlDataAdapter adt = new SqlDataAdapter(sql);
                DataSet ds = new DataSet();
                adt.Fill(ds);
                int rows = ds.Tables[0].Rows.Count;
                data = new TranferRecord[rows];

                for (int i = 0; i < rows; i++)
                {
                    data[i] = new TranferRecord();
                    data[i].Id = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[0].ToString());
                    data[i].FullName = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                    data[i].PhoneNumber = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                    data[i].Email = ds.Tables[0].Rows[i].ItemArray[3].ToString();
                    data[i].Birthday = Convert.ToDateTime(ds.Tables[0].Rows[i].ItemArray[4]);
                    data[i].Sex = ds.Tables[0].Rows[i].ItemArray[5].ToString();
                    data[i].OriginalAddress = ds.Tables[0].Rows[i].ItemArray[6].ToString();
                    data[i].IDNumber = ds.Tables[0].Rows[i].ItemArray[7].ToString();
                    data[i].Occupation = ds.Tables[0].Rows[i].ItemArray[8].ToString();
                    data[i].CurrentAddress = ds.Tables[0].Rows[i].ItemArray[9].ToString();
                    //data[i].FromDate = Convert.ToDateTime(ds.Tables[0].Rows[i].ItemArray[10]);
                    //data[i].ToDate = Convert.ToDateTime(ds.Tables[0].Rows[i].ItemArray[11]);
                    data[i].Reason = ds.Tables[0].Rows[i].ItemArray[12].ToString();
                    data[i].Description = ds.Tables[0].Rows[i].ItemArray[13].ToString();
                    data[i].Type = ds.Tables[0].Rows[i].ItemArray[14].ToString();
                }

                cn.Close();

                return data;
            }
            catch (PisNotFoundException exp)
            {
                TrackedFault tf = new TrackedFault(
                    Guid.NewGuid(),
                    exp.Message,
                    DateTime.Now);

                throw new FaultException<TrackedFault>(
                    tf,
                    new FaultReason("PisNotFoundException"),
                    FaultCode.CreateReceiverFaultCode(new FaultCode("GetData")));
            }
            catch (Exception exp)
            {
                FaultReasonText reason = new FaultReasonText(exp.Message);
                throw new FaultException(new FaultReason(reason), FaultCode.CreateReceiverFaultCode(new FaultCode("GetData")));
            }
        }
    }

    public class PisNotFoundException : Exception
    {
        public PisNotFoundException() { }
        public PisNotFoundException(string message) : base(message) { }
        public PisNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected PisNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
