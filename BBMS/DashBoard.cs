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

namespace BBMS
{
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
            GetData();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Omkar\Documents\BloodBankDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void GetData()

        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select count(*) from DonorTb1", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DonorLb1.Text = dt.Rows[0][0].ToString();
            SqlDataAdapter sda1 = new SqlDataAdapter("Select count(*) from TransferTb1", Con);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            TransferLb1.Text = dt1.Rows[0][0].ToString();
            SqlDataAdapter sda2 = new SqlDataAdapter("Select count(*) from EmployeeTb1", Con);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            EmployeeLb1.Text = dt2.Rows[0][0].ToString();
            SqlDataAdapter sda3 = new SqlDataAdapter("Select Sum(BStock) from BloodTb1", Con);
            DataTable dt3 = new DataTable();
            sda3.Fill(dt3);
            int BStock = Convert.ToInt32(dt3.Rows[0][0].ToString());
            TotalLb1.Text = "" + BStock;
            
            //O+ percentage
            SqlDataAdapter sda4 = new SqlDataAdapter("Select BStock from BloodTb1 where BGroup = '"+"O+"+"'", Con);
            DataTable dt4 = new DataTable();
            sda4.Fill(dt4);
            OPlusNumLb1.Text = dt4.Rows[0][0].ToString();
            double OplusPercentage = (Convert.ToDouble(dt4.Rows[0][0].ToString()) / BStock) * 100;
            OPlusProgress.Value = Convert.ToInt32(OplusPercentage);

            //AB+ percentage
            SqlDataAdapter sda5 = new SqlDataAdapter("Select BStock from BloodTb1 where BGroup = '"+"AB+"+"'", Con);
            DataTable dt5 = new DataTable();
            sda5.Fill(dt5);
            ABplusLabel.Text = dt5.Rows[0][0].ToString();
            double ABPlusPercentage = (Convert.ToDouble(dt5.Rows[0][0].ToString()) / BStock) * 100;
            ABplusProgress.Value = Convert.ToInt32(ABPlusPercentage);

            //O- percentage
            SqlDataAdapter sda6 = new SqlDataAdapter("Select BStock from BloodTb1 where BGroup = '"+"O-"+"'", Con);
            DataTable dt6 = new DataTable();
            sda6.Fill(dt6);
            OminusLabel.Text = dt6.Rows[0][0].ToString();
            double OminusPercentage = (Convert.ToDouble(dt6.Rows[0][0].ToString()) / BStock) * 100;
            OminusProgress.Value = Convert.ToInt32(OminusPercentage);

            //AB- percentage
            SqlDataAdapter sda7 = new SqlDataAdapter("Select BStock from BloodTb1 where BGroup = '"+"AB-"+"'", Con);
            DataTable dt7 = new DataTable();
            sda7.Fill(dt7);
            ABminusLabel.Text = dt7.Rows[0][0].ToString();
            double ABminusPercentage = (Convert.ToDouble(dt7.Rows[0][0].ToString()) / BStock) * 100;
            ABminusProgress.Value = Convert.ToInt32(ABminusPercentage);
            Con.Close();
        }
        private void label1_Click(object sender, EventArgs e)
        {
            ViewPatients Ob = new ViewPatients();
            Ob.Show();
            this.Hide();
        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Donor Ob = new Donor();
            Ob.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            ViewDonors Ob = new ViewDonors();
            Ob.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            DonateBlood Ob = new DonateBlood();
            Ob.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Patient Ob = new Patient();
            Ob.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            BloodStock Ob = new BloodStock();
            Ob.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            BloodTransfert Ob = new BloodTransfert();
            Ob.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            DashBoard Ob = new DashBoard();
            Ob.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Login Ob = new Login();
            Ob.Show();
            this.Hide();
        }
    }
}
