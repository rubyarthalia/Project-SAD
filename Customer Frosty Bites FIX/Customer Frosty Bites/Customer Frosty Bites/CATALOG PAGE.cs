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
    public partial class Catalog_Page : Form
    {
        MySqlConnection sqlConnection;
        MySqlCommand sqlCommand;
        MySqlDataAdapter sqlDataAdapter;
        string sqlQuery;
        DataTable dt_catalog;
        string cust_name;
        int index = 0;
        public Catalog_Page(string customer_name)
        {
            InitializeComponent();
            cust_name = customer_name;
            sqlConnection = new MySqlConnection("server=sub4.sift-uc.id; user=subsift5_user_b1; pwd=e0PFR9[Z+pj@; database=subsift5_db_b1;");

            lb_namaC_catalogpage.Text = cust_name;
            tampilan();
        }
        private void tampilan()
        {
            dt_catalog = new DataTable();
            sqlQuery = "select*from catalog"; //VIEW catalog//
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnection);
            sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dt_catalog);

            lb_namaP1_catalogpage.Text = dt_catalog.Rows[index]["Nama"].ToString();
            lb_hargaP1_catalogpage.Text = "Rp." + dt_catalog.Rows[index]["Harga"].ToString();
            lb_detailsP1_catalogpage.Text = dt_catalog.Rows[index]["Deskripsi"].ToString();
            pb_produk1_catalogpage.Image = Image.FromFile(dt_catalog.Rows[index]["Path"].ToString());

            lb_namaP2_catalogpage.Text = dt_catalog.Rows[index + 1]["Nama"].ToString();
            lb_hargaP2_catalogpage.Text = "Rp." + dt_catalog.Rows[index + 1]["Harga"].ToString();
            lb_detailsP2_catalogpage.Text = dt_catalog.Rows[index + 1]["Deskripsi"].ToString();
            pb_produk2_catalogpage.Image = Image.FromFile(dt_catalog.Rows[index + 1]["Path"].ToString());

            lb_namaP3_catalogpage.Text = dt_catalog.Rows[index + 2]["Nama"].ToString();
            lb_hargaP3_catalogpage.Text = "Rp." + dt_catalog.Rows[index + 2]["Harga"].ToString();
            lb_detailsP3_catalogpage.Text = dt_catalog.Rows[index + 2]["Deskripsi"].ToString();
            pb_produk3_catalogpage.Image = Image.FromFile(dt_catalog.Rows[index + 2]["Path"].ToString());
        }

        private void pb_previous_catalogpage_Click(object sender, EventArgs e)
        {
            if (index > 0)
            {
                index--;
                tampilan();
            }
            else
            {
                MessageBox.Show("You are at the beginning of the catalog.");
            }
        }

        private void pb_next_catalogpage_Click(object sender, EventArgs e)
        {
            if (index + 1 < dt_catalog.Rows.Count - 2)
            {
                index++;
                tampilan();
            }
            else
            {
                MessageBox.Show("You have reached the end of the catalog.");
            }
        }

        private void pb_orderbutton_Click(object sender, EventArgs e)
        {
            Order_Page orderpage = new Order_Page(cust_name);
            orderpage.Show();
            this.Hide();
        }

        private void lb_orderlabel_Click(object sender, EventArgs e)
        {
            Order_Page orderpage = new Order_Page(cust_name);
            orderpage.Show();
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

        private void lb_historylabel_Click(object sender, EventArgs e)
        {
            History_Page catalogpage = new History_Page(cust_name);
            catalogpage.Show();
            this.Hide();
        }

        private void pb_historybutton_Click(object sender, EventArgs e)
        {
            History_Page catalogpage = new History_Page(cust_name);
            catalogpage.Show();
            this.Hide();
        }

        private void Catalog_Page_Load(object sender, EventArgs e)
        {

        }
    }
}
