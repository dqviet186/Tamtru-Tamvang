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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            //ServiceReference1.pisClient proxy = new ServiceReference1.pisClient();
            //int result = proxy.Login(username, password);

            ServiceReference2.WSLoginClient proxy = new ServiceReference2.WSLoginClient();
            int result = proxy.Login(username, password);
            
            if (result == 1)
            {
                new Thongtintamtru().ShowDialog();
            }
            else
            {
                label4.Text = "Sai tên đăng nhập/ mật khẩu. Vui lòng thử lại lần nữa!!";
            }
        }
    }
}
