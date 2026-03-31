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
    public partial class Edit_Preorder : Form
    {
        MySqlConnection sqlConnection;
        MySqlCommand sqlCommand;
        MySqlDataAdapter sqlDataAdapter;
        string sqlQuery;
        DataTable dt_pre_order;

        int index;
        bool ismanager;
        string employee;
        public Edit_Preorder(bool is_manager, string karyawan)
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

            dt_pre_order = new DataTable();
            sqlQuery =
                "select * from PRE_ORDER_EDIT"; //VIEW PRE_ORDER_EDIT//
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnection);
            sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dt_pre_order);

            for (int i = 0; i < dt_pre_order.Rows.Count; i++)
            {
                cb_batch.Items.Add(i + 1);
            }
        }

        private void pb_add_Click(object sender, EventArgs e)
        {
            Add_Preorder form = new Add_Preorder(ismanager, employee);
            form.Show();
            this.Hide();

        }

        private void tampilan()
        {
            dt_pre_order = new DataTable();
            sqlQuery = "select * from PRE_ORDER_EDIT"; //VIEW PRE_ORDER_EDIT//
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnection);
            sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dt_pre_order);

            dtp_openPO.Value = Convert.ToDateTime(dt_pre_order.Rows[index]["start"]);
            dtp_closePO.Value = Convert.ToDateTime(dt_pre_order.Rows[index]["end"]);
            tb_limit.Text = dt_pre_order.Rows[index]["max"].ToString();

        }

        private void cb_batch_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = cb_batch.SelectedIndex;
            tampilan();
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
                    sqlQuery = "CALL edit_PO(@id, @start, @end, @max)"; //PROCEDURE edit_PO//
                    sqlCommand = new MySqlCommand(sqlQuery, sqlConnection);
                    string batchId = dt_pre_order.Rows[index]["id"].ToString();
                    MessageBox.Show($"Batch ID: {batchId}"); // Debug log BENER IKI KOCAK TAPI KENAPA KEUPDATE SEMUA
                    sqlCommand.Parameters.AddWithValue("@id", batchId);
                    sqlCommand.Parameters.AddWithValue("@start", dtp_openPO.Value.ToString("yyyy-MM-dd"));
                    sqlCommand.Parameters.AddWithValue("@end", dtp_closePO.Value.ToString("yyyy-MM-dd"));
                    sqlCommand.Parameters.AddWithValue("@max", tb_limit.Text);

                    // Eksekusi perintah
                    int rowsAffected = sqlCommand.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show(rowsAffected.ToString());
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
        }

        private void tb_limit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
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

        private void Edit_Preorder_Load(object sender, EventArgs e)
        {
            MyMonthCalander calender = new MyMonthCalander();
            calender.Font = new Font(calender.Font.FontFamily, 20);
            calender.Location = new Point(287, 211);
            calender.Show();
            this.Controls.Add(calender);
        }
    }
}
