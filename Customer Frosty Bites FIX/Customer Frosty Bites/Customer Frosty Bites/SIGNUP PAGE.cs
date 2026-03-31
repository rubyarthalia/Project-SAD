using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Customer_Frosty_Bites
{
    public partial class Signup_Page : Form
    {
        MySqlConnection sqlConnection;
        MySqlCommand sqlCommand;
        MySqlDataAdapter sqlDataAdapter;
        string sqlQuery;
        public Signup_Page()
        {
            InitializeComponent();
            sqlConnection = new MySqlConnection("server=sub4.sift-uc.id; user=subsift5_user_b1; pwd=e0PFR9[Z+pj@; database=subsift5_db_b1;");
        }

        private void lb_login_signuppage_Click(object sender, EventArgs e)
        {
            Login_Page signuppage = new Login_Page();
            signuppage.Show();
            this.Hide();
        }

        private void pb_signupbutton_signuppage_Click(object sender, EventArgs e)
        {
            if (tb_pass_signuppage.Text == tb_confirm_signuppage.Text)
            {
                try
                {
                    sqlConnection.Open();
                    sqlQuery = "CALL add_cust(@nama, @email, @notelp, @pass, @address)";
                    sqlCommand = new MySqlCommand(sqlQuery, sqlConnection);

                    sqlCommand.Parameters.AddWithValue("@nama", tb_name_signuppage.Text);
                    sqlCommand.Parameters.AddWithValue("@email", tb_email_signuppage.Text);
                    sqlCommand.Parameters.AddWithValue("@notelp", tb_phone_signuppage.Text);
                    sqlCommand.Parameters.AddWithValue("@pass", tb_pass_signuppage.Text);
                    sqlCommand.Parameters.AddWithValue("@address", tb_address_signuppage.Text);

                    int rowsAffected = sqlCommand.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Data Updated!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sqlConnection.Close();

                    Login_Page loginpage = new Login_Page();
                    loginpage.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Confirm Password is different from the Password");
            }
        }

        private void tb_phone_signuppage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
    }
}
