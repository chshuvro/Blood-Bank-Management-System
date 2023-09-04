using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodBankManagementSystem
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            GetData();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-P3SC7NQ\SQLEXPRESS;Initial Catalog=BloodBankDB;Integrated Security=True");
        private void GetData()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select count(*) from DonorTbl", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DonorLbl.Text = dt.Rows[0][0].ToString();
            SqlDataAdapter sda1 = new SqlDataAdapter("Select count (*)from TransferTbl", Con);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            TransferLbl.Text = dt.Rows[0][0].ToString();
            SqlDataAdapter sda2 = new SqlDataAdapter("Select count (*)from EmployeeTbl", Con);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            UsersLbl.Text = dt2.Rows[0][0].ToString();
            SqlDataAdapter sda3 = new SqlDataAdapter("Select count (*)from BloodTbl", Con);
            DataTable dt3 = new DataTable();
            sda3.Fill(dt3);
            int BStock = Convert.ToInt32(dt3.Rows[0][0].ToString());
            TotalLbl.Text = "" + BStock;

            //O+ Group

            SqlDataAdapter sda4 = new SqlDataAdapter("Select count (*)from BloodTbl where BGroup='" + "O+" + "'", Con);
            DataTable dt4 = new DataTable();
            sda4.Fill(dt4);
            OPlusNumLbl.Text = dt4.Rows[0][0].ToString();
            double OplusPercentage = (Convert.ToDouble(dt4.Rows[0][0].ToString()) / BStock) * 100;
            OPlusProgress.Value = Convert.ToInt32( OplusPercentage);

            //AB+ Group

            SqlDataAdapter sda5 = new SqlDataAdapter("Select count (*)from BloodTbl where BGroup='" + "AB+" + "'", Con);
            DataTable dt5 = new DataTable();
            sda5.Fill(dt5);
            ABPlusNumLbl.Text = dt5.Rows[0][0].ToString();
            double ABplusPercentage = (Convert.ToDouble(dt5.Rows[0][0].ToString()) / BStock) * 100;
            ABPlusProgress.Value = Convert.ToInt32(ABplusPercentage);

            //O- Group

            SqlDataAdapter sda6 = new SqlDataAdapter("Select count (*)from BloodTbl where BGroup='" + "O-" + "'", Con);
            DataTable dt6 = new DataTable();
            sda6.Fill(dt6);
            OMinusNumLbl.Text = dt6.Rows[0][0].ToString();
            double OMinusPercentage = (Convert.ToDouble(dt6.Rows[0][0].ToString()) / BStock) * 100;
            OMinusProgress.Value = Convert.ToInt32(OMinusPercentage);

            //AB- Group

            SqlDataAdapter sda7 = new SqlDataAdapter("Select count (*)from BloodTbl where BGroup='" + "O-" + "'", Con);
            DataTable dt7 = new DataTable();
            sda7.Fill(dt7);
            ABMinusNumLbl.Text = dt7.Rows[0][0].ToString();
            double ABMinusPercentage = (Convert.ToDouble(dt7.Rows[0][0].ToString()) / BStock) * 100;
            ABMinusProgress.Value = Convert.ToInt32(ABMinusPercentage);

            Con.Close();
        }
        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Donor Db = new Donor();
            Db.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            DonateBlood Db = new DonateBlood();
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

        private void label9_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }
    }
}
