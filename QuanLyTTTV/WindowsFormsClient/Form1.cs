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

//using TTTVService;
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
                ServiceReference1.pisClient proxy = new ServiceReference1.pisClient();

                string sql = "Select Id,FullName,PhoneNumber,Email,BirthDay,OriginalAddress,IDNumber from tamtrutamvang";
                proxy.LoadData(sql);

                DataSet myDataSet = new DataSet();
                dataGridView1.DataSource = myDataSet.Tables[0].DefaultView;
            }
            catch
            {
                MessageBox.Show("Lỗi kết nối");
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
    }
}
