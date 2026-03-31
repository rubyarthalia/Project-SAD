using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team_Frosty_Bites
{
    public partial class Menu_Catalog : Form
    {
        MySqlConnection sqlConnection;
        MySqlCommand sqlCommand;
        MySqlDataAdapter sqlDataAdapter;
        string sqlQuery;
        DataTable dt_catalog;

        int index = 0;
        bool ismanager;
        string employee;
        public Menu_Catalog(bool is_manager, string karyawan)
        {
            InitializeComponent();
            ismanager = is_manager;
            employee = karyawan;
            if (ismanager == true)
            {
                lb_teamManagement.Enabled = true;
                lb_teamManagement.Visible = true;
                pb_teamManagement.Enabled = true;
                pb_teamManagement.Visible = true;
            }
            sqlConnection = new MySqlConnection("server=sub4.sift-uc.id; user=subsift5_user_b1; pwd=e0PFR9[Z+pj@; database=subsift5_db_b1;");
            lb_namaC.Text = employee;

            tampilan();
        }
        private void tampilan()
        {
            dt_catalog = new DataTable();
            sqlQuery = "select*from all_catalog"; //VIEW catalog//
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnection);
            sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dt_catalog);

            lb_namaP1_catalogpage.Text = dt_catalog.Rows[index]["Nama"].ToString();
            lb_hargaP1_catalogpage.Text = "Rp." + dt_catalog.Rows[index]["Harga"].ToString();
            lb_detailsP1_catalogpage.Text = dt_catalog.Rows[index]["Deskripsi"].ToString();
            pb_product1.Image = Image.FromFile(dt_catalog.Rows[index]["Path"].ToString());

            lb_namaP2_catalogpage.Text = dt_catalog.Rows[index + 1]["Nama"].ToString();
            lb_hargaP2_catalogpage.Text = "Rp." + dt_catalog.Rows[index + 1]["Harga"].ToString();
            lb_detailsP2_catalogpage.Text = dt_catalog.Rows[index + 1]["Deskripsi"].ToString();
            pb_product2.Image = Image.FromFile(dt_catalog.Rows[index + 1]["Path"].ToString());

            lb_namaP3_catalogpage.Text = dt_catalog.Rows[index + 2]["Nama"].ToString();
            lb_hargaP3_catalogpage.Text = "Rp." + dt_catalog.Rows[index + 2]["Harga"].ToString();
            lb_detailsP3_catalogpage.Text = dt_catalog.Rows[index + 2]["Deskripsi"].ToString();
            pb_product3.Image = Image.FromFile(dt_catalog.Rows[index + 2]["Path"].ToString());
        }

        private void lb_homepage_Click(object sender, EventArgs e)
        {
            Home_Page form = new Home_Page(ismanager, employee);
            form.Show();
            this.Hide();
        }

        private void pb_homepage_Click(object sender, EventArgs e)
        {
            Home_Page form = new Home_Page(ismanager, employee);
            form.Show();
            this.Hide();
        }

        private void pb_editbutton_Click(object sender, EventArgs e)
        {
            Edit_Catalog form = new Edit_Catalog(ismanager, employee);
            form.Show();
            this.Hide();
        }

        private void pb_prev_Click(object sender, EventArgs e)
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

        private void pb_next_Click(object sender, EventArgs e)
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

        private void pb_addbutton_Click(object sender, EventArgs e)
        {
            Add_Catalog form = new Add_Catalog(ismanager, employee);
            form.Show();
            this.Hide();
        }

        private void lb_logout_Click(object sender, EventArgs e)
        {
            Login_Page form = new Login_Page();
            form.Show();
            this.Hide();
        }

        private void pb_logout_Click(object sender, EventArgs e)
        {
            Login_Page form = new Login_Page();
            form.Show();
            this.Hide();
        }

        private void lb_customer_Click(object sender, EventArgs e)
        {
            Customer form = new Customer(ismanager, employee);
            form.Show();
            this.Hide();
        }

        private void pb_customer_Click(object sender, EventArgs e)
        {
            Customer form = new Customer(ismanager, employee);
            form.Show();
            this.Hide();
        }

        private void lb_batch_Click(object sender, EventArgs e)
        {
            Report_Batch_Page form = new Report_Batch_Page(ismanager, employee);
            form.Show();
            this.Hide();
        }

        private void lb_month_Click(object sender, EventArgs e)
        {
            Report_Month_Page form = new Report_Month_Page(ismanager, employee);
            form.Show();
            this.Hide();
        }

        private void lb_year_Click(object sender, EventArgs e)
        {
            Report_Year_Page form = new Report_Year_Page(ismanager, employee);
            form.Show();
            this.Hide();
        }

        private void lb_teamManagement_Click(object sender, EventArgs e)
        {
            Add_Team_Management form = new Add_Team_Management(ismanager, employee);
            form.Show();
            this.Hide();
        }

        private void pb_teamManagement_Click(object sender, EventArgs e)
        {
            Add_Team_Management form = new Add_Team_Management(ismanager, employee);
            form.Show();
            this.Hide();
        }

        private void lb_preorder_Click(object sender, EventArgs e)
        {
            Add_Preorder form = new Add_Preorder(ismanager, employee);
            form.Show();
            this.Hide();
        }

        private void pb_preorder_Click(object sender, EventArgs e)
        {
            Add_Preorder form = new Add_Preorder(ismanager, employee);
            form.Show();
            this.Hide();
        }

        private void Menu_Catalog_Load(object sender, EventArgs e)
        {

        }
    }
}
