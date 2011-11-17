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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                //DataSet myDs = new DataSet();
                //myDs = dataTTTV();
                //dataGridView1.DataSource = myDs.Tables[0].DefaultView;
            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void thôngTinNhómToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormNhom().ShowDialog();
        }

        private void thoátToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        // tao dataset
        public DataSet CreateData()
        {
            DataSet ds = new DataSet();
            ds.Tables.Add("tamtrutamvang");
            ds.Tables[0].Columns.Add("Id");
            ds.Tables[0].Columns.Add("FullName");
            ds.Tables[0].Columns.Add("PhoneNumber");
            ds.Tables[0].Columns.Add("Email");
            ds.Tables[0].Columns.Add("Birthday");
            ds.Tables[0].Columns.Add("Sex");
            ds.Tables[0].Columns.Add("OriginalAddress");
            ds.Tables[0].Columns.Add("IDNumber");
            ds.Tables[0].Columns.Add("Occupation");
            ds.Tables[0].Columns.Add("CurrentAddress");
            ds.Tables[0].Columns.Add("FromDate");
            ds.Tables[0].Columns.Add("ToDate");
            ds.Tables[0].Columns.Add("Reason");
            ds.Tables[0].Columns.Add("Description");
            ds.Tables[0].Columns.Add("Type");

            return ds;
        }

        public DataSet dataTTTV()
        {
            DataSet ds = new DataSet();
          
            ServiceReference1.pisClient proxy = new ServiceReference1.pisClient();
            TTTVService.TranferRecord[] result = proxy.LoadData();
            ds = CreateData();
            DataRow dr;
            for (int i = 0; i < result.Length; i++)
            {
                dr = ds.Tables["tamtrutamvang"].NewRow();
                dr["Id"] = result[i].Id;
                dr["FullName"] = result[i].FullName;
                dr["PhoneNumber"] = result[i].PhoneNumber;
                dr["Email"] = result[i].Email;
                dr["Birthday"] = result[i].Birthday.ToString("dd/MM/yyyy");
                dr["Sex"] = result[i].Sex;
                dr["OriginalAddress"] = result[i].OriginalAddress;
                dr["IDNumber"] = result[i].IDNumber;
                dr["Occupation"] = result[i].Occupation;
                dr["CurrentAddress"] = result[i].CurrentAddress;
                dr["FromDate"] = result[i].FromDate.ToString("dd/MM/yyyy");
                dr["ToDate"] = result[i].ToDate.ToString("dd/MM/yyyy");
                dr["Reason"] = result[i].Reason;
                dr["Description"] = result[i].Description;
                dr["Type"] = result[i].Type;                    

                // add row to table
                ds.Tables["tamtrutamvang"].Rows.Add(dr);
            }
            return ds;
        }

        private void tìmKiếmTheoTênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new TT_SearchByName().ShowDialog();
        }

        private void tìmKiếmTheoSốĐiệnThoạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new TT_SearchByPhone().ShowDialog();
        }

        private void tìmKiếmTheoCMNDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new TT_SearchByIdNumber().ShowDialog();
        }

        private void dsTạmTrúTheoĐịaChỉToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new TT_SearchByAddress().ShowDialog();
        }

        private void thốngKêGiớiTínhTheoĐịaChỉToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new TT_ReportSexByAddress().ShowDialog();
        }

        private void tìmKiếmDanhSáchTheoNgàyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new TT_ListByDate().ShowDialog();
        }

        private void thốngKêNghềNghiệpTheoĐịaChỉToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new TT_ReportOccupationByAddress().ShowDialog();
        }

        private void tìmKiếmTạmVắngTheoTênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new TV_SearchByName().ShowDialog();
        }

        private void tìmKiếmTạmVắngTheoSDTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new TV_SearchByPhone().ShowDialog();
        }

        private void tìmKiếmTạmVắngTheoCMNDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new TV_SearchByIdNumber().ShowDialog();
        }

        private void tìmKiếmTạmVắngTheoĐịaChỉToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new TV_SearchByAddress().ShowDialog();
        }

        private void timKiếmTạmVắngTheoNgàyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new TV_ListByDate().ShowDialog();
        }
    }
}
