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
    public partial class Report_Year_Page : Form
    {
        MySqlConnection sqlConnection;
        MySqlCommand sqlCommand;
        MySqlDataAdapter sqlDataAdapter;
        string sqlQuery;
        DataTable dt_report;

        string str_year;
        bool ismanager;
        string employee;
        public Report_Year_Page(bool is_manager, string karyawan)
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

            fill_cb_year();
        }
        private void fill_cb_year()
        {
            DataTable dt_batch_year = new DataTable();
            sqlQuery = "select*from PRE_ORDER_EDIT"; //VIEW PRE_ORDER_EDIT//
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnection);
            sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dt_batch_year);

            string tahun2 = "";
            foreach (DataRow row in dt_batch_year.Rows)
            {
                DateTime startDate = Convert.ToDateTime(row["start"]);
                string tahun1 = startDate.ToString("yyyy");

                if (!cb_year.Items.Contains(tahun1))
                {
                    cb_year.Items.Add(tahun1);
                    tahun2 = tahun1;
                }
            }
        }
        private void tampilan()
        {
            try
            {
                sqlQuery = "call P_report_year(@tahun)";
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@tahun", str_year);

                dt_report = new DataTable();
                sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dt_report);

                dgv_data.DataSource = dt_report;
                dgv_data.Columns["NAMA PRODUK"].Visible = false;
                dgv_data.Columns["QTY"].Visible = false;
                dgv_data.Columns["PO_ID"].Visible = false;
                dgv_data.Columns["TRANSAKSI"].Visible = false;

                chart.Series.Clear();

                // List bulan dari Januari hingga Desember (untuk referensi urutan bulan)
                string[] allMonths = new string[]
                {
                    "January", "February", "March", "April", "May", "June",
                    "July", "August", "September", "October", "November", "December"
                };

                // Struktur data untuk menyimpan jumlah per bulan
                Dictionary<string, Dictionary<string, int>> dataProdukPerBulan = new Dictionary<string, Dictionary<string, int>>();

                // Proses DataTable untuk mengisi struktur data
                foreach (DataRow row in dt_report.Rows)
                {
                    string namaBarang = row["NAMA PRODUK"].ToString();
                    int qty = Convert.ToInt32(row["QTY"]);
                    DateTime tanggal = DateTime.Parse(row["TRANSAKSI"].ToString());
                    string bulan = tanggal.ToString("MMMM");

                    // Pastikan produk ada di dictionary
                    if (!dataProdukPerBulan.ContainsKey(namaBarang))
                    {
                        dataProdukPerBulan[namaBarang] = new Dictionary<string, int>();
                    }

                    // Tambahkan QTY ke bulan terkait
                    if (!dataProdukPerBulan[namaBarang].ContainsKey(bulan))
                    {
                        dataProdukPerBulan[namaBarang][bulan] = 0;
                    }
                    dataProdukPerBulan[namaBarang][bulan] += qty;
                }

                // Tambahkan data ke chart
                foreach (var produk in dataProdukPerBulan)
                {
                    string namaBarang = produk.Key;
                    var series = chart.Series.Add(namaBarang);
                    series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;

                    foreach (var bulan in produk.Value)
                    {
                        int qty = bulan.Value;

                        // Hanya tambahkan bulan dengan nilai QTY > 0
                        if (qty > 0)
                        {
                            series.Points.AddXY(bulan.Key, qty);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cb_year_SelectedIndexChanged(object sender, EventArgs e)
        {
            str_year = cb_year.SelectedItem.ToString();

            tampilan();
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

        private void lb_catalog_Click_1(object sender, EventArgs e)
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

        private void lb_batch_Click_1(object sender, EventArgs e)
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

        private void lb_logout_Click_1(object sender, EventArgs e)
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

        private void lb_teamManagement_Click(object sender, EventArgs e)
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

        private void pb_teamManagement_Click(object sender, EventArgs e)
        {
            Add_Team_Management form = new Add_Team_Management(ismanager, employee);
            form.Show();
            this.Hide();
        }
    }
}
