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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                ServiceReference1.pisClient proxy = new ServiceReference1.pisClient();
                label1.Text = proxy.GetAuthorInfo();
            }
            catch
            {
                MessageBox.Show("Lỗi kết nối");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ServiceReference1.pisClient proxy = new ServiceReference1.pisClient();
            label2.Text = proxy.GetAuthorInfo();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
