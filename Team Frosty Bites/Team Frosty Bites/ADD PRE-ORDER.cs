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
    public partial class Add_Preorder : Form
    {
        MySqlConnection sqlConnection;
        MySqlCommand sqlCommand;
        MySqlDataAdapter sqlDataAdapter;
        string sqlQuery;
        DataTable dt_po;
        DataTable dt_id_karyawan = new DataTable();

        int index = 0;
        bool ismanager;
        string employee;
        public Add_Preorder(bool is_manager, string karyawan)
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
            DataTable dt_batch = new DataTable();
            sqlQuery = "select PO_BATCH();"; //VIEW PO_BATCH//
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnection);
            sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dt_batch);

            lb_batchid.Text = $"BATCH {dt_batch.Rows[0]["PO_BATCH()"].ToString()}";

            //NGAMBIL ID KARYAWAN
            sqlQuery =              //VIEW empoyee//
                "select ID " +
                "from employee " +
                $"where Name = '{employee}'";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnection);
            sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dt_id_karyawan);
        }

        private void lb_homepage_Click(object sender, EventArgs e)
        {
            Home_Page form = new Home_Page(ismanager, employee);
            form.Show();
            this.Hide();

        }

        private void pb_done_Click(object sender, EventArgs e)
        {
            if (tb_limit.Text == "")
            {
                MessageBox.Show("ISI SEMUA DULU");
            }
            else
            {
                try
                {
                    sqlConnection.Open();

                    // Buat query dengan parameter
                    sqlQuery = "CALL add_PO(@id_karyawan, @start, @end, @max)";
                    sqlCommand = new MySqlCommand(sqlQuery, sqlConnection);

                    sqlCommand.Parameters.AddWithValue("@id_karyawan", dt_id_karyawan.Rows[0]["ID"].ToString());
                    sqlCommand.Parameters.AddWithValue("@start", dtp_openPO.Value.ToString("yyyy-MM-dd"));
                    sqlCommand.Parameters.AddWithValue("@end", dtp_closePO.Value.ToString("yyyy-MM-dd"));
                    sqlCommand.Parameters.AddWithValue("@max", tb_limit.Text);
                    //sqlCommand.Parameters.AddWithValue("@count", 0);

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
                    tb_limit.Clear();
                }
            }
        }

        private void dtp_openPO_ValueChanged(object sender, EventArgs e)
        {
            if (dtp_openPO.Value.Date < DateTime.Today)
            {
                MessageBox.Show("Tanggal tidak boleh kurang dari hari ini.");
                dtp_openPO.Value = DateTime.Today;
            }
        }

        private void tb_limit_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void lb_preorder_Click(object sender, EventArgs e)
        {

        }

        private void pb_edit_Click(object sender, EventArgs e)
        {
            Edit_Preorder form = new Edit_Preorder(ismanager, employee);
            form.Show();
            this.Close();
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

        private void Add_Preorder_Load(object sender, EventArgs e)
        {
            MyMonthCalander calender = new MyMonthCalander();
            calender.Font = new Font(calender.Font.FontFamily, 20);
            calender.Location = new Point(287, 211);
            calender.Show();
            this.Controls.Add(calender);
        }
    }
}
