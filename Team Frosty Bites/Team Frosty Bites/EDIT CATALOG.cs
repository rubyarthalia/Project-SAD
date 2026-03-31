using MySql.Data.MySqlClient;
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

namespace Team_Frosty_Bites
{
    public partial class Edit_Catalog : Form
    {
        MySqlConnection sqlConnection;
        MySqlCommand sqlCommand;
        MySqlDataAdapter sqlDataAdapter;
        string sqlQuery;
        DataTable dt_product;
        DataTable dt_produkID;

        int index = 0;
        bool ismanager;
        string employee;
        public Edit_Catalog(bool is_manager, string karyawan)
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

            dt_produkID = new DataTable();
            sqlQuery =
                "select ID from all_catalog"; //VIEW catalog//
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnection);
            sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dt_produkID);

            tampilan();
        }
        private void tampilan()
        {
            dt_product = new DataTable();
            sqlQuery =
                "select Nama, Deskripsi, Harga, Status, Path " +
                "from all_catalog"; //VIEW catalog//
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnection);
            sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dt_product);

            tb_namaP.Text = dt_product.Rows[index]["Nama"].ToString();
            tb_price.Text = dt_product.Rows[index]["Harga"].ToString();
            tb_desc.Text = dt_product.Rows[index]["Deskripsi"].ToString();
            cb_status.Text = dt_product.Rows[index]["Status"].ToString();
            if(cb_status.Text == "0")
            {
                cb_status.Text = "Available";
            }
            else
            {
                cb_status.Text = "Not Available";
            }
            pb_product.Image = Image.FromFile(dt_product.Rows[index]["Path"].ToString());
            tb_filepath.Text = dt_product.Rows[index]["Path"].ToString();
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

        private void pb_backbutton_Click(object sender, EventArgs e)
        {
            Menu_Catalog form = new Menu_Catalog(ismanager, employee);
            form.Show();
            this.Hide();
        }

        private void pb_donebutton_Click(object sender, EventArgs e)
        {
            try
            {
                sqlConnection.Open();

                // Buat query dengan parameter
                sqlQuery = "CALL edit_product(@id, @nama, @harga, @deskripsi, @status, @path)";  //PROCEDURE edit_product
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnection);

                sqlCommand.Parameters.AddWithValue("@id", dt_produkID.Rows[index]["ID"].ToString());
                sqlCommand.Parameters.AddWithValue("@nama", tb_namaP.Text);
                sqlCommand.Parameters.AddWithValue("@harga", tb_price.Text);
                sqlCommand.Parameters.AddWithValue("@deskripsi", tb_desc.Text);
                if (cb_status.SelectedIndex == 0)
                {
                    cb_status.Text = "0";
                }
                else { cb_status.Text = "1";}
                sqlCommand.Parameters.AddWithValue("@status", cb_status.Text);
                sqlCommand.Parameters.AddWithValue("@path", tb_filepath.Text);

                //// ADD DELETE CATALOG
                //if (cb_status.Text == "1") //APE INI WE
                //{
                //    DataTable dt_id_produk = new DataTable();

                //    sqlQuery =
                //        "SELECT MAX(PRODUK_ID) as id " +
                //        "FROM PRODUK ";
                //    sqlCommand = new MySqlCommand(sqlQuery, sqlConnection);
                //    sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
                //    sqlDataAdapter.Fill(dt_id_produk);

                //    DataTable dt_user_id = new DataTable();

                //    sqlQuery =
                //        "SELECT USER_ID as id " +
                //        "FROM `USER` " +
                //        $"WHERE USER_NAMA LIKE '{employee}'";
                //    sqlCommand = new MySqlCommand(sqlQuery, sqlConnection);
                //    sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
                //    sqlDataAdapter.Fill(dt_user_id);

                //    //sqlQuery = "CALL pAddDeleteCatalog(@user_id, @produk_id)"; //PROCEDURE pAddDeleteCatalog
                //    //sqlCommand = new MySqlCommand(sqlQuery, sqlConnection);

                //    //sqlCommand.Parameters.AddWithValue("@user_id", dt_user_id.Rows[0]["id"].ToString());
                //    //sqlCommand.Parameters.AddWithValue("@produk_id", dt_id_produk.Rows[0]["id"].ToString());
                //}
                // Eksekusi perintah
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
            }
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
                MessageBox.Show("You are at the beginning of the product.");
            }
        }

        private void pb_next_Click(object sender, EventArgs e)
        {
            if (index < dt_product.Rows.Count - 1)
            {
                index++;
                tampilan();
            }
            else
            {
                MessageBox.Show("You have reached the end of the product.");
            }
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

        private void pb_uploadbutton_Click(object sender, EventArgs e)
        {
            pb_product.Image = Image.FromFile(tb_filepath.Text);
        }
    }
}
