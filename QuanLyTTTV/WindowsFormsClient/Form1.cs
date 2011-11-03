using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
            //Dung ChannelFactory cho phep tao nhieu doi tuong proxy voi cac endpoint khac nhau
            //EndpointAddress address = new EndpointAddress("http://localhost:8000/quanly/tamtrutamvang");
            //BasicHttpBinding binding = new BasicHttpBinding();
            //IService1 proxy = ChannelFactory<IService1>.CreateChannel(binding, address);

            //string thongtinnhom = proxy.GetThongTinNhom();
            //label1.Text = thongtinnhom;
            //Console.WriteLine(thongtinnhom);
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
