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
    public partial class Blood_Transfer : Form
    {
        public Blood_Transfer()
        {
            InitializeComponent();
            fillPatientCb();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-P3SC7NQ\SQLEXPRESS;Initial Catalog=BloodBankDB;Integrated Security=True");
        private void fillPatientCb()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select PNum from PatientTbl", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("PNum", typeof(int));
            dt.Load(rdr);
            PatientIdCb.ValueMember = "PNum";
            PatientIdCb.DataSource = dt;
            Con.Close();
        }
        
        private void GetData()
        {
            //Helps to get the BloodGroup and Name of the paitent
            Con.Open();
            string query = "select * from PatientTbl where PNum=" + PatientIdCb.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                PatNameTb.Text = dr["PName"].ToString();
                BloodGroup.Text = dr["PBGroup"].ToString();
            }
            Con.Close();
        }
        int stock;
        private void GetStock(string Bgroup)
        {
            //Helps to get the BloodGroup and Name of the paitent
            Con.Open();
            string query = "select * from BloodTbl where BGroup='" + Bgroup + "'";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                stock = Convert.ToInt32(dr["BStock"].ToString());
            }
            Con.Close();
        }
        private void Blood_Transfer_Load(object sender, EventArgs e)
        {

        }

        private void PatientIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetData();
            GetStock(BloodGroup.Text);
            if (stock > 0)
            {
                TransferBtn.Visible = true;
                AvailableLbl.Text = "Available Stock";
                AvailableLbl.Visible = true;
            }
            else
            {
                AvailableLbl.Text = "Stock not Available";
                AvailableLbl.Visible = true;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Patient Pat = new Patient();
            Pat.Show();
            this.Hide();
        }
        private void Reset()
        {
            PatNameTb.Text = "";
            BloodGroup.Text = "";
            //PatientIdCb.SelectedIndex = -1;
            AvailableLbl.Visible = false;
            TransferBtn.Visible = false;
        }

        
       
        private void underStock()
        {
            int newstock = stock - 1 ;
            try
            {
                string query = "update BloodTbl set BStock=" + newstock + " where BGroup='" + BloodGroup.Text + "';";
                Con.Open();
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Patient Successfully Updated");
                Con.Close();
                
                
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        private void TransferBtn_Click(object sender, EventArgs e)
        {
            if (PatNameTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    string query = "insert into TransferTbl values('" + PatNameTb.Text + "','" + BloodGroup.Text + "')";
                    Con.Open();
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully Transfered");
                    Con.Close();
                    GetStock(BloodGroup.Text);
                    underStock();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Blood_Stock Bstock = new Blood_Stock();
            Bstock.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Donor Db = new Donor();
            Db.Show();
            this.Hide();
        }

        private void label14_Click(object sender, EventArgs e)
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

        private void label4_Click(object sender, EventArgs e)
        {
            View_Patient Db = new View_Patient();
            Db.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            
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
