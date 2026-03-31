using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Customer_Frosty_Bites
{
    public partial class Login_Page : Form
    {
        MySqlConnection sqlConnection;
        MySqlCommand sqlCommand;
        MySqlDataAdapter sqlDataAdapter;
        string sqlQuery;
        public Login_Page()
        {
            InitializeComponent(); 
            sqlConnection = new MySqlConnection("server=sub4.sift-uc.id; user=subsift5_user_b1; pwd=e0PFR9[Z+pj@; database=subsift5_db_b1;");
        }

        private void lb_signup_loginpage_Click(object sender, EventArgs e)
        {
            Signup_Page loginpage = new Signup_Page();
            loginpage.Show();
            this.Hide();
        }

        private void pb_loginbutton_loginpage_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                sqlQuery = $"CALL cust_login('{tb_email_loginpage.Text}', '{tb_pass_loginpage.Text}')"; //PROCEDURE cust_login//
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnection);
                sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    MessageBox.Show("Login Succeed");
                    Catalog_Page catalogpage = new Catalog_Page(dt.Rows[0]["nama"].ToString());
                    catalogpage.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Login Failed. Try again");
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("ERROR",ex.Message);
            }
            
        }

        private void Login_Page_Load(object sender, EventArgs e)
        {
            //tb_email_loginpage.Text = "citra.maharani@gmail.com";
            //tb_pass_loginpage.Text = "CitraM45";
        }
    }
}
