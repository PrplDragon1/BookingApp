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

namespace BookingSys_X_Login
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void Login()
        {
            SqlConnection con = new SqlConnection(@"CON FILE PATH");
            string password = txt_password.Text;
            string username = txt_username.Text;
            bool isExist = false;

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM users WHERE username='" + username + "'",con);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                string corPass = sdr.GetString(2);
                int userID =sdr.GetInt32(0);
                
                User.token(userID);
                isExist = true;
            }
            con.Close();

            if (isExist)
            {
                //Show Dash
                Booking book = new Booking();
                book.Show();
                this.Hide();
            }
        }

        private void btn_admin_Click(object sender, EventArgs e)
        {
            AdminPanel admin = new AdminPanel();
            this.Hide();
            admin.Show();
        }
    }
}
