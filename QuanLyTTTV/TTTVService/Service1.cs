using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Transactions;
using System.ServiceModel;
using System.Text;

// require class database
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace TTTVService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    //[ServiceBehavior(IncludeExceptionDetailInFaults = true, InstanceContextMode = InstanceContextMode.PerCall)]
    [ServiceBehavior(IncludeExceptionDetailInFaults = true, InstanceContextMode = InstanceContextMode.PerSession)]
    public class Service1 : IService1
    {
        TranferRecord[] data;

        private System.Data.SqlClient.SqlConnection myConnection;
        private System.Data.DataSet myDataSet;
        private System.Data.SqlClient.SqlCommand myCommand;
        private System.Data.SqlClient.SqlDataAdapter DataAdapter;
        private DataTable dataTable;

        public string GetAuthor()
        {
            try
            {
                string nhom = "Nhóm: 10";
                string hoten = "Họ tên: Dương Quốc Việt";
                string mssv = "MSSV: 09263L";
                string kq = nhom + "\n" + hoten + "\n" + mssv;
                return kq;
            }
            catch (FaultOutOfMemory exp)
            {
                throw new FaultException("Out of memory!!",
                    FaultCode.CreateReceiverFaultCode(new FaultCode("GetAuthor")));
            }
            catch (Exception exp)
            {
                FaultReasonText reason = new FaultReasonText(exp.Message);
                throw new FaultException(new FaultReason(reason), FaultCode.CreateReceiverFaultCode(new FaultCode("GetAuthor")));
            }
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
                    data[i].FromDate = Convert.ToDateTime(ds.Tables[0].Rows[i].ItemArray[10]);
                    data[i].ToDate = Convert.ToDateTime(ds.Tables[0].Rows[i].ItemArray[11]);
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

        public TranferRecord[] GetInfoByEmail(string Email, string type)
        {
            try
            {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = "Data Source=mavi-PC;Initial Catalog=cnweb;Integrated Security=True";
                cn.Open();

                string query = "SELECT * FROM tamtrutamvang WHERE Email = '" + Email + "' and Type = '" + type + "'";
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
                    data[i].FromDate = Convert.ToDateTime(ds.Tables[0].Rows[i].ItemArray[10]);
                    data[i].ToDate = Convert.ToDateTime(ds.Tables[0].Rows[i].ItemArray[11]);
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
                    data[i].FromDate = Convert.ToDateTime(ds.Tables[0].Rows[i].ItemArray[10]);
                    data[i].ToDate = Convert.ToDateTime(ds.Tables[0].Rows[i].ItemArray[11]);
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

        public TranferRecord[] GetInfoByIdNumber(string IdNumber, string type)
        {
            try
            {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = "Data Source=mavi-PC;Initial Catalog=cnweb;Integrated Security=True";
                cn.Open();

                string query = "SELECT * FROM tamtrutamvang WHERE IDNumber = '" + IdNumber + "' and Type = '" + type + "'";
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
                    data[i].FromDate = Convert.ToDateTime(ds.Tables[0].Rows[i].ItemArray[10]);
                    data[i].ToDate = Convert.ToDateTime(ds.Tables[0].Rows[i].ItemArray[11]);
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
                    FaultCode.CreateReceiverFaultCode(new FaultCode("GetInfoByIdNumber")));
            }
            catch (Exception exp)
            {
                FaultReasonText reason = new FaultReasonText(exp.Message);
                throw new FaultException(new FaultReason(reason), FaultCode.CreateReceiverFaultCode(new FaultCode("GetInfoByIdNumber")));
            }
        }

        public TranferRecord[] GetInfoBySex(string Address, string Sex, string type)
        {
            try
            {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = "Data Source=mavi-PC;Initial Catalog=cnweb;Integrated Security=True";
                cn.Open();

                string query = "SELECT * FROM tamtrutamvang WHERE CurrentAddress like '%" + Address + "%' and Sex = '"+ Sex +"' and Type = '" + type + "'";
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
                    data[i].FromDate = Convert.ToDateTime(ds.Tables[0].Rows[i].ItemArray[10]);
                    data[i].ToDate = Convert.ToDateTime(ds.Tables[0].Rows[i].ItemArray[11]);
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
                    FaultCode.CreateReceiverFaultCode(new FaultCode("GetInfoBySex")));
            }
            catch (Exception exp)
            {
                FaultReasonText reason = new FaultReasonText(exp.Message);
                throw new FaultException(new FaultReason(reason), FaultCode.CreateReceiverFaultCode(new FaultCode("GetInfoBySex")));
            }
        }

        public TranferRecord[] GetListByAddress(string Address, string type)
        {
            try
            {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = "Data Source=mavi-PC;Initial Catalog=cnweb;Integrated Security=True";
                cn.Open();

                string query = "SELECT * FROM tamtrutamvang WHERE CurrentAddress like '%" + Address + "%' and Type = '" + type + "'";
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
                    data[i].FromDate = Convert.ToDateTime(ds.Tables[0].Rows[i].ItemArray[10]);
                    data[i].ToDate = Convert.ToDateTime(ds.Tables[0].Rows[i].ItemArray[11]);
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
                    FaultCode.CreateReceiverFaultCode(new FaultCode("GetListByAddress")));
            }
            catch (Exception exp)
            {
                FaultReasonText reason = new FaultReasonText(exp.Message);
                throw new FaultException(new FaultReason(reason), FaultCode.CreateReceiverFaultCode(new FaultCode("GetListByAddress")));
            }
        }

        public TranferRecord[] GetListByDate(string Address, DateTime FromDate, DateTime ToDate, string type)
        {
            try
            {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = "Data Source=mavi-PC;Initial Catalog=cnweb;Integrated Security=True";
                cn.Open();

                string str1 = FromDate.ToString("yyyy-MM-dd");
                string str2 = ToDate.ToString("yyyy-MM-dd");

                string query = "SELECT * FROM tamtrutamvang WHERE CurrentAddress like '%" + Address + "%' and FromDate >= '" + str1 + "' or ToDate <= '" + str2 + "' and Type = '" + type + "'";
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
                    data[i].FromDate = Convert.ToDateTime(ds.Tables[0].Rows[i].ItemArray[10]);
                    data[i].ToDate = Convert.ToDateTime(ds.Tables[0].Rows[i].ItemArray[11]);
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
                    FaultCode.CreateReceiverFaultCode(new FaultCode("GetListByDate")));
            }
            catch (Exception exp)
            {
                FaultReasonText reason = new FaultReasonText(exp.Message);
                throw new FaultException(new FaultReason(reason), FaultCode.CreateReceiverFaultCode(new FaultCode("GetListByDate")));
            }
        }

        public TranferRecord[] GetListOccupationByAddress(string Address, string type)
        {
            try
            {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = "Data Source=mavi-PC;Initial Catalog=cnweb;Integrated Security=True";
                cn.Open();

                string query = "SELECT DISTINCT(Occupation),CurrentAddress,OriginalAddress FROM tamtrutamvang WHERE CurrentAddress like '%" + Address + "%' and Type = '" + type + "'";
                SqlCommand sql = new SqlCommand(query, cn);
                SqlDataAdapter adt = new SqlDataAdapter(sql);
                DataSet ds = new DataSet();
                adt.Fill(ds);
                int rows = ds.Tables[0].Rows.Count;
                data = new TranferRecord[rows];

                for (int i = 0; i < rows; i++)
                {
                    data[i] = new TranferRecord();
                    data[i].Occupation = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                    data[i].CurrentAddress = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                    data[i].OriginalAddress = ds.Tables[0].Rows[i].ItemArray[2].ToString();
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
                    FaultCode.CreateReceiverFaultCode(new FaultCode("GetListOccupationByAddress")));
            }
            catch (Exception exp)
            {
                FaultReasonText reason = new FaultReasonText(exp.Message);
                throw new FaultException(new FaultReason(reason), FaultCode.CreateReceiverFaultCode(new FaultCode("GetListOccupationByAddress")));
            }
        }

        public TranferRecord[] CountSexByAddress(string Address, string type)
        {
            try
            {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = "Data Source=mavi-PC;Initial Catalog=cnweb;Integrated Security=True";
                cn.Open();

                string query = "SELECT Sex, COUNT(Sex) AS Total"; 
                       query += " FROM tamtrutamvang";
                       query += " WHERE CurrentAddress LIKE '%" + Address + "%' and type = '" + type + "'";
                       query += " GROUP BY Sex";
                SqlCommand sql = new SqlCommand(query, cn);
                SqlDataAdapter adt = new SqlDataAdapter(sql);
                DataSet ds = new DataSet();
                adt.Fill(ds);
                int rows = ds.Tables[0].Rows.Count;
                data = new TranferRecord[rows];

                for (int i = 0; i < rows; i++)
                {
                    data[i] = new TranferRecord();
                    data[i].Sex = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                    data[i].Total = int.Parse(ds.Tables[0].Rows[i].ItemArray[1].ToString());
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
                    FaultCode.CreateReceiverFaultCode(new FaultCode("GetListOccupationByAddress")));
            }
            catch (Exception exp)
            {
                FaultReasonText reason = new FaultReasonText(exp.Message);
                throw new FaultException(new FaultReason(reason), FaultCode.CreateReceiverFaultCode(new FaultCode("GetListOccupationByAddress")));
            }
        }

        //public int Login(string username, string password)
        //{
        //    try
        //    {
        //        if (username == "" || password == "")
        //        {
        //            return 0;
        //        }

        //        string query = "SELECT * FROM users WHERE username = '" + username + "' AND password = '" + password + "'";


        //        SqlConnection cn = new SqlConnection();
        //        cn.ConnectionString = "Data Source=mavi-PC;Initial Catalog=cnweb;Integrated Security=True";
        //        cn.Open();

        //        SqlCommand sql = new SqlCommand(query, cn);
        //        SqlDataAdapter adt = new SqlDataAdapter(sql);
        //        DataSet ds = new DataSet();
        //        adt.Fill(ds);
        //        int rows = ds.Tables[0].Rows.Count;              

        //        cn.Close();

        //        if (rows > 0)
        //        {
        //            return 1;
        //        }
        //        else
        //        {
        //            return 0;
        //        }
        //    }
        //    catch (PisNotFoundException exp)
        //    {
        //        TrackedFault tf = new TrackedFault(
        //            Guid.NewGuid(),
        //            exp.Message,
        //            DateTime.Now);

        //        throw new FaultException<TrackedFault>(
        //            tf,
        //            new FaultReason("PisNotFoundException"),
        //            FaultCode.CreateReceiverFaultCode(new FaultCode("Login")));
        //    }
        //    catch (Exception exp)
        //    {
        //        FaultReasonText reason = new FaultReasonText(exp.Message);
        //        throw new FaultException(new FaultReason(reason), FaultCode.CreateReceiverFaultCode(new FaultCode("Login")));
        //    }
        //}

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = false)]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        public void InsertData(TranferRecord data)
        {
            try
            {
                string connectionString = "Data Source=mavi-PC;Initial Catalog=cnweb;Integrated Security=True";
                myConnection = new SqlConnection(connectionString);

                // Open connection
                myConnection.Open();

                string updateCement = "INSERT INTO tamtrutamvang (FullName,PhoneNumber,Email,Birthday,Sex,OriginalAddress,IDNumber,Occupation,CurrentAddress,FromDate,ToDate,Reason,Description,Type) VALUES (@FullName,@PhoneNumber,@Email,@Birthday,@Sex,@OriginalAddress,@IDNumber,@Occupation,@CurrentAddress,@FromDate,@ToDate,@Reason,@Description,@Type)";
                SqlCommand cmd = new SqlCommand(updateCement, myConnection);
                cmd.Parameters.AddWithValue("@FullName", data.FullName);
                cmd.Parameters.AddWithValue("@PhoneNumber", data.PhoneNumber);
                cmd.Parameters.AddWithValue("@Email", data.Email);
                cmd.Parameters.AddWithValue("@Birthday", data.Birthday.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@Sex", data.Sex);
                cmd.Parameters.AddWithValue("@OriginalAddress", data.OriginalAddress);
                cmd.Parameters.AddWithValue("@IDNumber", data.IDNumber);
                cmd.Parameters.AddWithValue("@Occupation", data.Occupation);
                cmd.Parameters.AddWithValue("@CurrentAddress", data.CurrentAddress);
                cmd.Parameters.AddWithValue("@FromDate", data.FromDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@ToDate", data.ToDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@Reason", data.Reason);
                cmd.Parameters.AddWithValue("@Description", data.Description);
                cmd.Parameters.AddWithValue("@Type", data.Type);
                cmd.ExecuteNonQuery();

                // close connection
                myConnection.Close();
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
                    FaultCode.CreateReceiverFaultCode(new FaultCode("InsertInfomation")));
            }
            catch (Exception exp)
            {
                FaultReasonText reason = new FaultReasonText(exp.Message);
                throw new FaultException(new FaultReason(reason), FaultCode.CreateReceiverFaultCode(new FaultCode("InsertInfomation")));
            }
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        public void UpdateData(int Id, TranferRecord data)
        {
            try
            {
                string connectionString = "Data Source=mavi-PC;Initial Catalog=cnweb;Integrated Security=True";
                myConnection = new SqlConnection(connectionString);

                // Open connection
                myConnection.Open();

                string updateCement = "UPDATE tamtrutamvang SET FullName=@FullName,PhoneNumber=@PhoneNumber,Email=@Email,Birthday=@Birthday,Sex=@Sex,OriginalAddress=@OriginalAddress,IDNumber=@IDNumber,Occupation=@Occupation,CurrentAddress=@CurrentAddress,FromDate=@FromDate,ToDate=@ToDate,Reason=@Reason,Description=@Description,Type=@Type WHERE Id = " + Id;
                SqlCommand cmd = new SqlCommand(updateCement, myConnection);
                cmd.Parameters.AddWithValue("@FullName", data.FullName);
                cmd.Parameters.AddWithValue("@PhoneNumber", data.PhoneNumber);
                cmd.Parameters.AddWithValue("@Email", data.Email);
                cmd.Parameters.AddWithValue("@Birthday", data.Birthday.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@Sex", data.Sex);
                cmd.Parameters.AddWithValue("@OriginalAddress", data.OriginalAddress);
                cmd.Parameters.AddWithValue("@IDNumber", data.IDNumber);
                cmd.Parameters.AddWithValue("@Occupation", data.Occupation);
                cmd.Parameters.AddWithValue("@CurrentAddress", data.CurrentAddress);
                cmd.Parameters.AddWithValue("@FromDate", data.FromDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@ToDate", data.ToDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@Reason", data.Reason);
                cmd.Parameters.AddWithValue("@Description", data.Description);
                cmd.Parameters.AddWithValue("@Type", data.Type);
                cmd.ExecuteNonQuery();

                // close connection
                myConnection.Close();
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
                    FaultCode.CreateReceiverFaultCode(new FaultCode("UpdatInformation")));
            }
            catch (Exception exp)
            {
                FaultReasonText reason = new FaultReasonText(exp.Message);
                throw new FaultException(new FaultReason(reason), FaultCode.CreateReceiverFaultCode(new FaultCode("UpdatInformation")));
            }
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        public void DeleteData(int Id)
        {
            try
            {
                string connectionString = "Data Source=mavi-PC;Initial Catalog=cnweb;Integrated Security=True";
                myConnection = new SqlConnection(connectionString);

                // Open connection
                myConnection.Open();

                string updateCement = "DELETE tamtrutamvang WHERE Id = " + Id;
                SqlCommand cmd = new SqlCommand(updateCement, myConnection);
                cmd.ExecuteNonQuery();

                // close connection
                myConnection.Close();
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
                    FaultCode.CreateReceiverFaultCode(new FaultCode("DeleteInformation")));
            }
            catch (Exception exp)
            {
                FaultReasonText reason = new FaultReasonText(exp.Message);
                throw new FaultException(new FaultReason(reason), FaultCode.CreateReceiverFaultCode(new FaultCode("DeleteInformation")));
            }
        }

        public void ImportData(string[] file)
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
                    data[i].FromDate = Convert.ToDateTime(ds.Tables[0].Rows[i].ItemArray[10]);
                    data[i].ToDate = Convert.ToDateTime(ds.Tables[0].Rows[i].ItemArray[11]);
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

    public class FaultOutOfMemory : Exception
    {
        public FaultOutOfMemory(
             System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
