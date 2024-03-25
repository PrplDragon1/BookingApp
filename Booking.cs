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
    public partial class Booking : Form
    {
        public Booking()
        {
            InitializeComponent();
        }

        private void btn_book_Click(object sender, EventArgs e)
        {
            int userID = User.userID;
            string date = cal_dateSelect.SelectionRange.Start.ToShortDateString();
            int quantity = Convert.ToInt32(num_quantity.Value);

            SqlConnection con = new SqlConnection(@"CON FILE PATH");
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO bookings (Date, Quantity, CustomerID) VALUES (@date, @quantity, @userID)", con);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@quantity", quantity);
            cmd.Parameters.AddWithValue("@userID", userID);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            con.Close();
        }

        private void btn_viewBooking_Click(object sender, EventArgs e)
        {
            ViewBookings book = new ViewBookings();
            this.Hide();
            book.Show();
        }
    }
}
