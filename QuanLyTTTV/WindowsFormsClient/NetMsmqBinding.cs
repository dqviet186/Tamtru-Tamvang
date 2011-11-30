using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// cau 2
using System.Messaging;

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
    public partial class NetMsmqBinding : Form
    {
        public NetMsmqBinding()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //// Get MSMQ queue name from app settings in configuration
            //string queueName = "kiemtra";
            //// Create the transacted MSMQ queue if necessary.
            //if (!MessageQueue.Exists(queueName))
            //{
            //    MessageQueue.Create(queueName, true);
            //}
            
            //// Get the base address that is used to listen for
            //// This is useful to generate a proxy for the client
            //string baseAddress = "net.msmq://localhost:8000/quanly/kiemtra/";

            ////Dung ChannelFactory cho phep tao nhieu doi tuong proxy voi cac endpoint khac nhau
            //EndpointAddress address1 = new EndpointAddress(baseAddress);
            //NetMsmqBinding binding1 = new NetMsmqBinding();
            //IService1 proxy1 = ChannelFactory<IService1>.CreateChannel(binding1, address1);
            //string str = proxy1.GetAuthor();

            //MessageBox.Show(str);
        }
    }
}
