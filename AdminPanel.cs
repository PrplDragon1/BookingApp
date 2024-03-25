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
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        void LoadData()
        {
            SqlConnection con = new SqlConnection(@"CON FILE PATH");
            con.Open();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT B.BookingID,B.Date,B.Quantity, A.username FROM users AS A INNER JOIN bookings AS B ON A.userID = B.CustomerID",con);
                DataSet ds = new DataSet();
                da.Fill(ds, "bookings");
                dataGridView1.DataSource = ds.Tables["bookings"].DefaultView;
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }
    }
}
