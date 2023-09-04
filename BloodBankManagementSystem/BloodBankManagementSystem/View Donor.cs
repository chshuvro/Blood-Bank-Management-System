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
    public partial class ViewDonor : Form
    {
        public ViewDonor()
        {
            InitializeComponent();
            populate();
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
        private void View_Donor_Load(object sender, EventArgs e)
        {

        }

        private void DonorDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Donor Db = new Donor();
            Db.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            DonateBlood Db = new DonateBlood();
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
