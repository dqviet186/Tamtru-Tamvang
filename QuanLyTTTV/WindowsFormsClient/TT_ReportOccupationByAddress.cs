﻿using System;
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
    public partial class TT_ReportOccupationByAddress : Form
    {
        public TT_ReportOccupationByAddress()
        {
            InitializeComponent();
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

        // tao dataset
        public DataSet CreateData()
        {
            DataSet ds = new DataSet();
            ds.Tables.Add("tamtrutamvang");
            //ds.Tables[0].Columns.Add("Id");
            //ds.Tables[0].Columns.Add("FullName");
            //ds.Tables[0].Columns.Add("PhoneNumber");
            //ds.Tables[0].Columns.Add("Email");
            //ds.Tables[0].Columns.Add("Birthday");
            //ds.Tables[0].Columns.Add("Sex");
            //ds.Tables[0].Columns.Add("OriginalAddress");
            //ds.Tables[0].Columns.Add("IDNumber");
            ds.Tables[0].Columns.Add("Occupation");
            ds.Tables[0].Columns.Add("CurrentAddress");
            //ds.Tables[0].Columns.Add("FromDate");
            //ds.Tables[0].Columns.Add("ToDate");
            //ds.Tables[0].Columns.Add("Reason");
            //ds.Tables[0].Columns.Add("Description");
            //ds.Tables[0].Columns.Add("Type");

            return ds;
        }

        public DataSet dataTTTV(string Address, string type)
        {
            DataSet ds = new DataSet();

            ServiceReference1.pisClient proxy = new ServiceReference1.pisClient();
            TTTVService.TranferRecord[] result = proxy.ListOccupationByAddress(Address, type);
            ds = CreateData();
            DataRow dr;
            for (int i = 0; i < result.Length; i++)
            {
                dr = ds.Tables["tamtrutamvang"].NewRow();
                //dr["Id"] = result[i].Id;
                //dr["FullName"] = result[i].FullName;
                //dr["PhoneNumber"] = result[i].PhoneNumber;
                //dr["Email"] = result[i].Email;
                //dr["Birthday"] = result[i].Birthday;
                //dr["Sex"] = result[i].Sex;
                //dr["OriginalAddress"] = result[i].OriginalAddress;
                //dr["IDNumber"] = result[i].IDNumber;
                dr["Occupation"] = result[i].Occupation;
                dr["CurrentAddress"] = result[i].CurrentAddress;
                //dr["FromDate"] = result[i].FromDate.ToString("dd/MM/yyyy");
                //dr["ToDate"] = result[i].ToDate.ToString("dd/MM/yyyy");
                //dr["Reason"] = result[i].Reason;
                //dr["Description"] = result[i].Description;
                //dr["Type"] = result[i].Type;

                // add row to table
                ds.Tables["tamtrutamvang"].Rows.Add(dr);
            }
            return ds;
        }
    }
}
