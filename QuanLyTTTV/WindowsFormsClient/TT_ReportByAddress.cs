using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// require class database
using System.Data.Sql;
using System.Data.SqlClient;

// require classes service
using System.ServiceModel;
using System.ServiceModel.Description;

using TTTVService;
using WindowsFormsHostingWS;
using WindowsFormsClient.ServiceReference1;

namespace WindowsFormsClient
{
    public partial class TT_ReportSexByAddress : Form
    {
        public TT_ReportSexByAddress()
        {
            InitializeComponent();
        }

        // tao dataset
        public DataSet CreateData()
        {
            DataSet ds = new DataSet();
            ds.Tables.Add("tamtrutamvang");
            ds.Tables[0].Columns.Add("Sex");
            ds.Tables[0].Columns.Add("Total");

            return ds;
        }

        public DataSet dataTTTV(string Address, string type)
        {
            DataSet ds = new DataSet();

            ServiceReference1.pisClient proxy = new ServiceReference1.pisClient();
            TTTVService.TranferRecord[] result = proxy.CountSexByAddress(Address, type);
            ds = CreateData();
            DataRow dr;
            for (int i = 0; i < result.Length; i++)
            {
                dr = ds.Tables["tamtrutamvang"].NewRow();
                dr["Sex"] = result[i].Sex;
                dr["Total"] = result[i].Total;

                // add row to table
                ds.Tables["tamtrutamvang"].Rows.Add(dr);
            }
            return ds;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string txtSearch = textBox1.Text.Trim();
                DataSet myDs = new DataSet();
                if (txtSearch == "")
                {
                    MessageBox.Show("Vui lòng nhập thông tin cần tìm kiếm");
                    textBox1.Focus();
                }
                else
                {
                    myDs = dataTTTV(txtSearch, "TT");
                    dataGridView1.DataSource = myDs.Tables[0].DefaultView;
                }
            }
            catch (FaultException exp)
            {
                MessageBox.Show(exp.Code.Name + ": " + exp.Message.ToString(), exp.GetType().ToString());
            }
            catch (Exception exp)//bat loi o code rieng phia client
            {
                MessageBox.Show(exp.Message.ToString(), exp.GetType().ToString());
            }
        }
    }
}
