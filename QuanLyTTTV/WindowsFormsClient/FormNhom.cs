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
    public partial class FormNhom : Form
    {
        public FormNhom()
        {
            InitializeComponent();
        }

        private void Thongtinnhom_Load(object sender, EventArgs e)
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
    }
}
