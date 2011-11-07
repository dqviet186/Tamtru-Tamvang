using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// require class database
using System.Data.Sql;
using System.Data.SqlClient;

namespace TTTVService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class Service1 : IService1
    {
        private System.Data.SqlClient.SqlConnection myConnection;
        private System.Data.DataSet myDataSet;
        private System.Data.SqlClient.SqlCommand myCommand;
        private System.Data.SqlClient.SqlDataAdapter DataAdapter;

        private int currentRowId = 0;
        private string baseSql = "Select Id,FullName,PhoneNumber,Email,BirthDay,OriginalAddress,IDNumber from tamtrutamvang";

        public string GetAuthor()
        {
            string nhom = "Nhóm: 10";
            string hoten = "Họ tên: Dương Quốc Việt";
            string mssv = "MSSV: 09263L";
            string kq = nhom + "\n" + hoten + "\n" + mssv;
            return kq;
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

        public void InsertData()
        {

        }

        public void UpdateData(int Id)
        {
            
        }

        public void DeleteData(int Id)
        {

        }

        public void BindingData(string sql)
        {
            try
            {
                string connectionString = "Data Source=mavi-PC;Initial Catalog=cnweb;Integrated Security=True";
                myConnection = new SqlConnection(connectionString);

                // Open connection
                myConnection.Open();

                // create dataset to retrieve data
                myDataSet = new System.Data.DataSet();

                // create command to run query
                myCommand = new SqlCommand();
                myCommand.Connection = myConnection;
                myCommand.CommandText = sql;

                // create dataadapter to fill data to dataset
                DataAdapter = new SqlDataAdapter();
                DataAdapter.SelectCommand = myCommand;
                DataAdapter.TableMappings.Add("Table", "users");
                DataAdapter.Fill(myDataSet);

                // close connection
                myConnection.Close();
            }
            catch (SqlException)
            {
                System.Console.WriteLine("To run this example, replace the value of the " +
                "connectionString variable with a connection string that is " +
                "valid for your system.");
            }
        }
    }
}
