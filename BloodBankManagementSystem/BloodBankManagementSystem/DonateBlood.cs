using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BloodBankManagementSystem
{
    public partial class DonateBlood : Form
    {
        public DonateBlood()
        {
            InitializeComponent();
            populate();
            bloodStock();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-P3SC7NQ\SQLEXPRESS;Initial Catalog=BloodBankDB;Integrated Security=True");
        private void populate()
        {
            Con.Open();
            string Query = "select * from DonorTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            DonorDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void bloodStock()
        {
            Con.Open();
            string Query = "select * from BloodTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BloodStockDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void DonateBlood_Load(object sender, EventArgs e)
        {

        }
        int oldStock;
        private void GetStock(String Bgroup)
        {
            //Helps to get actual Stock of Blood based on particular Blood Group
            Con.Open();
            string query = "select* from BloodTbl where BGroup = '" + Bgroup + "'";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                oldStock = Convert.ToInt32(dr["BStock"].ToString());
            }
            Con.Close();
        }
        private void DonorDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DNameTb.Text = DonorDGV.SelectedRows[0].Cells[1].Value.ToString();
            DBGroupCb.Text = DonorDGV.SelectedRows[0].Cells[6].Value.ToString();
            GetStock(DBGroupCb.Text);
        }
        private void Reset()
        {
            DNameTb.Text = "";
            DBGroupCb.SelectedIndex = -1;
        }
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if(DNameTb.Text == "")
            {
                MessageBox.Show("Select a donor");
            }
            else
            {
                try
                {
                    int Stock = oldStock+1;
                    string query = "update BloodTbl set BStock=" + Stock +"  where BGroup='" + DBGroupCb.SelectedItem.ToString() + "';";
                    Con.Open();
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Donation Successful");
                    Con.Close();
                    Reset();
                    populate();
                    bloodStock();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Donor Db = new Donor();
            Db.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            ViewDonor Db = new ViewDonor();
            Db.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Patient Db = new Patient();
            Db.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            View_Patient Db = new View_Patient();
            Db.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Blood_Stock Db = new Blood_Stock();
            Db.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Blood_Transfer Db = new Blood_Transfer();
            Db.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Dashboard Db = new Dashboard();
            Db.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }
    }
}
