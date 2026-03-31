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
using System.Windows.Forms.DataVisualization.Charting;


namespace Team_Frosty_Bites
{
    public partial class Home_Page : Form
    {
        MySqlConnection sqlConnection;
        MySqlCommand sqlCommand;
        MySqlDataAdapter sqlDataAdapter;
        string sqlQuery;
        DataTable dt_homepage;
        DataTable dt_recap;

        bool ismanager;
        string employee;

        string transaksi_id;
        string Sbayar;
        string Sproduksi;
        string Skirim;

        DialogResult result;
        public Home_Page(bool is_manager, string karyawan)
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

        private void lb_teamManagement_Click(object sender, EventArgs e)
        {
            Add_Team_Management form = new Add_Team_Management(ismanager, employee);
            form.Show();
            this.Hide();
        }

        private void dgv_homepage_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            transaksi_id = dgv_homepage.Rows[e.RowIndex].Cells["T_id"].Value.ToString();
            Sbayar = dgv_homepage.Rows[e.RowIndex].Cells["Payment Status"].Value.ToString();
            if (Sbayar == "False")
            {
                Sbayar = "0";
            }
            else
            {
                Sbayar = "1";
            }

            Sproduksi = dgv_homepage.Rows[e.RowIndex].Cells["Production Status"].Value.ToString();
            if (Sproduksi == "False")
            {
                Sproduksi = "0";
            }
            else
            {
                Sproduksi = "1";
            }

            Skirim = dgv_homepage.Rows[e.RowIndex].Cells["Delivery Status"].Value.ToString();
            if (Skirim == "False")
            {
                Skirim = "0";
            }
            else
            {
                Skirim = "1";
            }
            update_true_false();

            int rowIndex = e.RowIndex;
            if (rowIndex >= 0) // Ensure a valid row is clicked  
            {
                // Get the clicked column name  
                string columnName = dgv_homepage.Columns[e.ColumnIndex].Name;
                //MessageBox.Show(columnName);

                transaksi_id = dgv_homepage.Rows[e.RowIndex].Cells["T_id"].Value.ToString();

                // Handle Payment Status column  
                if (columnName == "Payment Status")
                {
                    Sbayar = dgv_homepage.Rows[e.RowIndex].Cells["Payment Status"].Value.ToString();

                    if (Sbayar == "False")
                    {
                        Sbayar = "0";
                    }
                    else
                    {
                        Sbayar = "1";
                    }

                    // Show confirmation messagebox only for Payment Status  
                    result = MessageBox.Show("Are you sure you want to change the Payment Status?", "Disclaimer",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }

                // Handle Production Status column  
                if (columnName == "Production Status")
                {
                    Sproduksi = dgv_homepage.Rows[e.RowIndex].Cells["Production Status"].Value.ToString();

                    if (Sproduksi == "False")
                    {
                        Sproduksi = "0";
                    }
                    else
                    {
                        Sproduksi = "1";
                    }

                    // Show confirmation messagebox only for Production Status  
                    result = MessageBox.Show("Are you sure you want to change the Production Status?", "Disclaimer",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }

                // Handle Delivery Status column  
                if (columnName == "Delivery Status")
                {
                    Skirim = dgv_homepage.Rows[e.RowIndex].Cells["Delivery Status"].Value.ToString();

                    if (Skirim == "False")
                    {
                        Skirim = "0";
                    }
                    else
                    {
                        Skirim = "1";
                    }

                    // Show confirmation messagebox only for Delivery Status  
                    result = MessageBox.Show("Are you sure you want to change the Delivery Status?", "Disclaimer",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }

                if (result == DialogResult.Yes)
                {
                    //MessageBox.Show("Update kok");
                    update_true_false();
                }
            }
        }

        private void update_true_false()
        {
            sqlConnection.Open();

            sqlQuery = "CALL update_bool_transaksi(@id, @status_bayar, @status_produksi, @status_kirim)";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id", transaksi_id);
            sqlCommand.Parameters.AddWithValue("@status_bayar", Sbayar);
            sqlCommand.Parameters.AddWithValue("@status_produksi", Sproduksi);
            sqlCommand.Parameters.AddWithValue("@status_kirim", Skirim);
            sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }
        private void tampilan()
        {
            //
            dt_homepage = new DataTable();
            sqlQuery = "select*from homepage"; //VIEW homepage//
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnection);
            sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dt_homepage);
            dgv_homepage.DataSource = dt_homepage;

            dgv_homepage.Columns["T_id"].Visible = false;

            dt_recap = new DataTable();
            sqlQuery = "select*from recap"; //VIEW recap//
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnection);
            sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dt_recap);
            dgv_recap.DataSource = dt_recap;

            //LOAD PIE CHART

            Series series = new Series
            {
                ChartType = SeriesChartType.Pie,
                XValueMember = "PRODUK_NAMA",
                YValueMembers = "Total",
                IsValueShownAsLabel = true,
            };

            pie_chart.Series.Add(series);

            // Bind Data
            pie_chart.DataSource = dt_recap;

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

        private void lb_preorder_Click(object sender, EventArgs e)
        {
            Add_Preorder form = new Add_Preorder(ismanager, employee);
            form.Show();
            this.Hide();
        }

        private void pb_teamManagement_Click(object sender, EventArgs e)
        {
            Add_Team_Management form = new Add_Team_Management(ismanager, employee);
            form.Show();
            this.Hide();
        }

        private void pb_preorder_Click(object sender, EventArgs e)
        {
            Add_Preorder form = new Add_Preorder(ismanager, employee);
            form.Show();
            this.Hide();
        }
    }
}
