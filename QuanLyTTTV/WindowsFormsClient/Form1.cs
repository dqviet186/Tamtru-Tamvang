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

        }

        private void thôngTinNhómToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormNhom().ShowDialog();
        }

        private void thoátToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
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

        private void quảnLýThôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Login().ShowDialog();
        }
    }
}
