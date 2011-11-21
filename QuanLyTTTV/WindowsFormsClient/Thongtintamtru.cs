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
    public partial class Thongtintamtru : Form
    {
        private int currentRowId = 0;
        public Thongtintamtru()
        {
            InitializeComponent();
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

        private void Thongtintamtru_Load(object sender, EventArgs e)
        {
            try
            {
                DataSet myDs = new DataSet();
                myDs = dataTTTV();
                dataGridView1.DataSource = myDs.Tables[0].DefaultView;
            }
            catch (FaultException exp)
            {
                MessageBox.Show(exp.Reason.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceReference1.pisClient proxy = new ServiceReference1.pisClient();
                TTTVService.TranferRecord param = new TTTVService.TranferRecord();
                param.FullName = textBox1.Text.Trim();
                param.PhoneNumber = textBox2.Text.Trim();
                param.Email = textBox3.Text.Trim();
                param.Birthday = dateTimePicker1.Value;
                param.Sex = textBox5.Text.Trim();
                param.OriginalAddress = textBox4.Text.Trim();
                param.IDNumber = textBox6.Text.Trim();
                param.Occupation = textBox7.Text.Trim();
                param.CurrentAddress = textBox8.Text.Trim();
                param.FromDate = dateTimePicker2.Value;
                param.ToDate = dateTimePicker3.Value;
                param.Reason = textBox9.Text.Trim();
                param.Description = textBox10.Text;
                param.Type = textBox11.Text.Trim();

                // insert infromation
                proxy.InsertInfomation(param);

                MessageBox.Show("Thêm dữ liệu thành công!!");

                // xoa du lieu textbox
                clearData();

                // load data again
                DataSet myDs = new DataSet();
                myDs = dataTTTV();
                dataGridView1.DataSource = myDs.Tables[0].DefaultView;
            }
            catch (FaultException exp)
            {
                MessageBox.Show(exp.Reason.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceReference1.pisClient proxy = new ServiceReference1.pisClient();
                TTTVService.TranferRecord param = new TTTVService.TranferRecord();
                param.FullName = textBox1.Text.Trim();
                param.PhoneNumber = textBox2.Text.Trim();
                param.Email = textBox3.Text.Trim();
                param.Birthday = dateTimePicker1.Value;
                param.Sex = textBox5.Text.Trim();
                param.OriginalAddress = textBox4.Text.Trim();
                param.IDNumber = textBox6.Text.Trim();
                param.Occupation = textBox7.Text.Trim();
                param.CurrentAddress = textBox8.Text.Trim();
                param.FromDate = dateTimePicker2.Value;
                param.ToDate = dateTimePicker3.Value;
                param.Reason = textBox9.Text.Trim();
                param.Description = textBox10.Text;
                param.Type = textBox11.Text.Trim();
                param.Id = int.Parse(textBox12.Text.Trim());

                // update infromation
                proxy.UpdatInformation(param.Id, param);

                MessageBox.Show("Cập nhật dữ liệu thành công!!");

                // xoa du lieu textbox
                clearData();

                // load data again
                DataSet myDs = new DataSet();
                myDs = dataTTTV();
                dataGridView1.DataSource = myDs.Tables[0].DefaultView;
            }
            catch (FaultException exp)
            {
                MessageBox.Show(exp.Reason.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceReference1.pisClient proxy = new ServiceReference1.pisClient();
                TTTVService.TranferRecord param = new TTTVService.TranferRecord();
                param.Id = int.Parse(textBox12.Text.Trim());

                // delete infromation
                proxy.DeleteInformation(param.Id);

                MessageBox.Show("Xóa dữ liệu thành công!!");

                // xoa du lieu textbox
                clearData();

                // load data again
                DataSet myDs = new DataSet();
                myDs = dataTTTV();
                dataGridView1.DataSource = myDs.Tables[0].DefaultView;
            }
            catch (FaultException exp)
            {
                MessageBox.Show(exp.Reason.ToString());
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // set index value in every cell click event
            int Id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["FullName"].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["PhoneNumber"].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["Email"].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["OriginalAddress"].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["Sex"].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells["IDNumber"].Value.ToString();
            textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells["Occupation"].Value.ToString();
            textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells["CurrentAddress"].Value.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["Birthday"].Value.ToString());
            dateTimePicker2.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["FromDate"].Value.ToString());
            dateTimePicker3.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["ToDate"].Value.ToString());
            textBox9.Text = dataGridView1.Rows[e.RowIndex].Cells["Reason"].Value.ToString();
            textBox10.Text = dataGridView1.Rows[e.RowIndex].Cells["Description"].Value.ToString();
            textBox11.Text = dataGridView1.Rows[e.RowIndex].Cells["Type"].Value.ToString();
            textBox12.Text = dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString();
            currentRowId = Id;
        }

        public void clearData()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
        }
    }
}
