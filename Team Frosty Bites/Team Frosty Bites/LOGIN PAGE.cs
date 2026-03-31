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
using MySql.Data.MySqlClient;

namespace Team_Frosty_Bites
{
    public partial class Login_Page : Form
    {
        MySqlConnection sqlConnection;
        MySqlCommand sqlCommand;
        MySqlDataAdapter sqlDataAdapter;
        string sqlQuery;
        DataTable dt_USER;
        public Login_Page()
        {
            InitializeComponent();
            sqlConnection = new MySqlConnection("server=sub4.sift-uc.id; user=subsift5_user_b1; pwd=e0PFR9[Z+pj@; database=subsift5_db_b1;");

            tb_userid_loginpage.Text = "CEO001";
            tb_pass_loginpage.Text = "FLIX2153";
        }

        private void pb_login_Click(object sender, EventArgs e)
        {
            try
            {
                dt_USER = new DataTable();
                sqlQuery = $"CALL user_login('{tb_userid_loginpage.Text}', '{tb_pass_loginpage.Text}')"; //PROCEDURE user_login//
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnection);
                sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dt_USER);

                if (dt_USER.Rows[0]["USER_ID"].ToString().StartsWith("CEO"))
                {
                    bool ismanager = true;
                    Home_Page form2 = new Home_Page(ismanager, dt_USER.Rows[0]["USER_NAMA"].ToString());
                    form2.Show();
                    this.Hide();
                }
                else
                {
                    bool ismanager = false;
                    Home_Page form2 = new Home_Page(ismanager, dt_USER.Rows[0]["USER_NAMA"].ToString());
                    form2.Show();
                    this.Hide();
                }

            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Incorrect Username or Password");
            }
        }
    }
}
