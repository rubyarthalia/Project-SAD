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
    public partial class Add_Catalog : Form
    {
        MySqlConnection sqlConnection;
        MySqlCommand sqlCommand;
        MySqlDataAdapter sqlDataAdapter;
        string sqlQuery;

        int index = 0;
        bool ismanager;
        string employee;
        public Add_Catalog(bool is_manager, string karyawan)
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
        }

        

        private void pb_addButton_Click(object sender, EventArgs e)
        {
            if (tb_namaP.Text == "" || tb_price.Text == "" || tb_desc.Text == "")
            {
                MessageBox.Show("ISI SEMUA DULU");
            }
            else
            {
                try
                {
                    sqlConnection.Open();


                    // Buat query dengan parameter
                    sqlQuery = "CALL add_product(@nama, @harga, @deskripsi, @path)"; //PROCEDURE add_product
                    sqlCommand = new MySqlCommand(sqlQuery, sqlConnection);

                    sqlCommand.Parameters.AddWithValue("@nama", tb_namaP.Text);
                    sqlCommand.Parameters.AddWithValue("@harga", tb_price.Text);
                    sqlCommand.Parameters.AddWithValue("@deskripsi", tb_desc.Text);
                    sqlCommand.Parameters.AddWithValue("@path", tb_filepath.Text);

                    // Eksekusi perintah
                    int rowsAffected = sqlCommand.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Data Updated!");
                    }

                    // ADD_DELETE_CATALOG
                    DataTable dt_id_produk = new DataTable();

                    sqlQuery =
                        "SELECT MAX(PRODUK_ID) as id " +
                        "FROM PRODUK ";
                    sqlCommand = new MySqlCommand(sqlQuery, sqlConnection);
                    sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
                    sqlDataAdapter.Fill(dt_id_produk);

                    DataTable dt_user_id = new DataTable();

                    sqlQuery =
                        "SELECT USER_ID as id " +
                        "FROM `USER` " +
                        $"WHERE USER_NAMA LIKE '{employee}'";
                    sqlCommand = new MySqlCommand(sqlQuery, sqlConnection);
                    sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
                    sqlDataAdapter.Fill(dt_user_id);

                    sqlQuery = "CALL pAddDeleteCatalog(@user_id, @produk_id)"; //PROCEDURE pAddDeleteCatalog
                    sqlCommand = new MySqlCommand(sqlQuery, sqlConnection);

                    sqlCommand.Parameters.AddWithValue("@user_id", dt_user_id.Rows[0]["id"].ToString());
                    sqlCommand.Parameters.AddWithValue("@produk_id", dt_id_produk.Rows[0]["id"].ToString());

                    // Eksekusi perintah
                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sqlConnection.Close();

                    tb_namaP.Clear();
                    tb_price.Clear();
                    tb_desc.Clear();
                }
            }
        }

        private void pb_backButton_Click(object sender, EventArgs e)
        {
            Menu_Catalog form = new Menu_Catalog(ismanager, employee);
            form.Show();
            this.Hide();
        }

        private void tb_price_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
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

        private void lb_catalog_Click(object sender, EventArgs e)
        {
            Menu_Catalog form = new Menu_Catalog(ismanager, employee);
            form.Show();
            this.Hide();
        }

        private void pb_catalog_Click(object sender, EventArgs e)
        {
            Menu_Catalog form = new Menu_Catalog(ismanager, employee);
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

        private void pb_uploadbutton_Click(object sender, EventArgs e)
        {
            pb_product.Image = Image.FromFile(tb_filepath.Text);
        }

        private void p_Sidebar_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
