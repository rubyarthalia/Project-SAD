using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Customer_Frosty_Bites
{
    public partial class History_Page : Form
    {
        MySqlConnection sqlConnection;
        MySqlCommand sqlCommand;
        MySqlDataAdapter sqlDataAdapter;
        string sqlQuery;
        string cust_name;
        public History_Page(string customer)
        {
            InitializeComponent();
            cust_name = customer;
            sqlConnection = new MySqlConnection("server=sub4.sift-uc.id; user=subsift5_user_b1; pwd=e0PFR9[Z+pj@; database=subsift5_db_b1;");

            lb_namaC_catalogpage.Text = cust_name;
            tampilan();
        }
        private void tampilan()
        {
            DataTable dt_history = new DataTable();
            sqlQuery = $"CALL POINT_CUST('{cust_name}')";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnection);
            sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dt_history);
            dgv_history.DataSource = dt_history;
            dgv_history.Columns["id"].Visible = false;

            int count = 0 ;
            foreach (DataRow dr in dt_history.Rows)
            {
                if (dr["Point"].ToString() == "+1")
                {
                    count++;
                }
                if(count >= 10)
                {
                    count = count%10 ;
                }
            }
            lb_pointtotal.Text = count.ToString();
        }

        private void lb_cataloglabel_Click(object sender, EventArgs e)
        {
            Catalog_Page catalogpage = new Catalog_Page(cust_name);
            catalogpage.Show();
            this.Hide();
        }

        private void pb_catalogbutton_Click(object sender, EventArgs e)
        {
            Catalog_Page catalogpage = new Catalog_Page(cust_name);
            catalogpage.Show();
            this.Hide();
        }

        private void pb_orderbutton_Click(object sender, EventArgs e)
        {
            Order_Page catalogpage = new Order_Page(cust_name);
            catalogpage.Show();
            this.Hide();
        }

        private void lb_orderlabel_Click(object sender, EventArgs e)
        {
            Order_Page catalogpage = new Order_Page(cust_name);
            catalogpage.Show();
            this.Hide();
        }

        private void lb_logoutlabel_Click(object sender, EventArgs e)
        {
            Login_Page signuppage = new Login_Page();
            signuppage.Show();
            this.Hide();
        }

        private void pb_logoutbutton_Click(object sender, EventArgs e)
        {
            Login_Page signuppage = new Login_Page();
            signuppage.Show();
            this.Hide();
        }
    }
}
