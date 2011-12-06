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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service2" in both code and config file together.
    //[ServiceBehavior(IncludeExceptionDetailInFaults = true, InstanceContextMode = InstanceContextMode.PerSession)]
    //[ServiceBehavior(IncludeExceptionDetailInFaults = true, InstanceContextMode = InstanceContextMode.PerCall)]
    [ServiceBehavior(IncludeExceptionDetailInFaults = true, InstanceContextMode = InstanceContextMode.Single)]
    public class Service2 : IService2
    {
        public int Login(string username, string password)
        {
            try
            {
                if (username == "" || password == "")
                {
                    return 0;
                }

                string query = "SELECT * FROM users WHERE username = '" + username + "' AND password = '" + password + "'";


                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = "Data Source=mavi-PC;Initial Catalog=cnweb;Integrated Security=True";
                cn.Open();

                SqlCommand sql = new SqlCommand(query, cn);
                SqlDataAdapter adt = new SqlDataAdapter(sql);
                DataSet ds = new DataSet();
                adt.Fill(ds);
                int rows = ds.Tables[0].Rows.Count;

                cn.Close();

                if (rows > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
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
                    FaultCode.CreateReceiverFaultCode(new FaultCode("Login")));
            }
            catch (Exception exp)
            {
                FaultReasonText reason = new FaultReasonText(exp.Message);
                throw new FaultException(new FaultReason(reason), FaultCode.CreateReceiverFaultCode(new FaultCode("Login")));
            }
        }
    }
}
