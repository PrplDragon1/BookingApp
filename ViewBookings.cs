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
    public partial class ViewBookings : Form
    {
        public ViewBookings()
        {
            InitializeComponent();
        }

        private void ViewBookings_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        void LoadData()
        {
            int userID = User.userID;
            SqlConnection con = new SqlConnection(@"CON FILE PATH");
            con.Open();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Date,Quantity FROM bookings WHERE customerID ='"+userID+"'", con);
                DataSet ds = new DataSet();
                da.Fill(ds, "bookings");
                dataGridView1.DataSource = ds.Tables["bookings"].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }
    }
}
