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
    public partial class TestFault : Form
    {
        public TestFault()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Test Client bat loi Typed Fault OutOfMemory");

            }
            catch (FaultOutOfMemory exp)
            {
                MessageBox.Show(exp.Message.ToString());
            }
            catch (Exception exp)//bat loi o code rieng phia client
            {
                MessageBox.Show(exp.Message.ToString(), exp.GetType().ToString());
            }
        }
    }
}
