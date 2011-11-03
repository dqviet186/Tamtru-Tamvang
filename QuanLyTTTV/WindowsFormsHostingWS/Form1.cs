using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// add Service + library
using TTTVService;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace WindowsFormsHostingWS
{
    public partial class Form1 : Form
    {
        // all params here
        string ShowMex = "No";
        Object selectedItem = "";
        string str = "";
        string relativeAddress = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnstop_Click(object sender, EventArgs e)
        {
            label5.Text = "Servie just stoped!!";
            Uri baseAddress = new Uri(baselocation.Text);
            Type contractType = typeof(TTTVService.IService1);
            Type instanceType = typeof(TTTVService.Service1);
            ServiceHost host = new ServiceHost(instanceType, baseAddress);
            using (host)
            {
                host.Close();
            }
        }

        private void btnstart_Click(object sender, EventArgs e)
        {
            if (showmex.Checked)
            {
                ShowMex = "Yes";
            }

            str = selectedItem.ToString();

            if(str == "")
            {
                str = "BasicHttpBinding";
            }

            Uri baseAddress = new Uri(baselocation.Text);
            Type contractType = typeof(TTTVService.IService1); // interface 
            Type instanceType = typeof(TTTVService.Service1); // implement interface
            ServiceHost host = new ServiceHost(instanceType, baseAddress);
            using (host)
            {
                
                if (str == "BasicHttpBinding")
                {
                    relativeAddress = txt1.Text;
                    host.AddServiceEndpoint(contractType, new BasicHttpBinding(), relativeAddress);
                }
                else if (str == "WSHttpBinding")
                {
                    host.AddServiceEndpoint(contractType, new WSHttpBinding(), "http://localhost:8000/quanly/"+txt2.Text);
                }
                else if (str == "NetTcpBinding")
                {
                    NetTcpBinding A = new NetTcpBinding(SecurityMode.Transport);
                    host.AddServiceEndpoint(contractType, new NetTcpBinding(), "net.tcp://localhost:8000/quanly/"+txt3.Text);
                    //host.AddServiceEndpoint(contractType, A, "net.tcp://localhost:8000/quanly/");
                }

                if (ShowMex == "Yes")
                {
                    // Add behavior for our MEX endpoint
                    // Add Mex endpoint can dung de khi client discovery thay duoc service
                    // neu khong add thi khi khong add duoc service refference
                    // Neu khong add Mex endpoint, de tao duoc doi tuong proxy (client dung)
                    // thi phai dung tool svcutil.exe

                    ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();
                    behavior.HttpGetEnabled = true;
                    host.Description.Behaviors.Add(behavior);

                    host.AddServiceEndpoint(typeof(IMetadataExchange), new BasicHttpBinding(), "MEX");
                }
                
                host.Open();
                label5.Text = "Service is ready";
                MessageBox.Show("Service is ready");
                host.Close();
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txt1.Enabled = true;
                endpoints.Items.Add(checkBox1.Text);
            }
            else
            {
                txt1.Text = "";
                txt1.Enabled = false;
                endpoints.Items.Remove(checkBox1.Text);
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                txt2.Enabled = true;
                endpoints.Items.Add(checkBox2.Text);
            }
            else
            {
                txt2.Text = "";
                txt2.Enabled = false;
                endpoints.Items.Remove(checkBox2.Text);
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void endpoints_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.selectedItem = endpoints.SelectedItem;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                txt3.Enabled = true;
                endpoints.Items.Add(checkBox3.Text);
            }
            else
            {
                txt3.Text = "";
                txt3.Enabled = false;
                endpoints.Items.Remove(checkBox3.Text);
            }
        }

    }
}
