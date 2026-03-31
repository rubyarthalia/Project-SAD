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
    public partial class Edit_Team_Management : Form
    {
        MySqlConnection sqlConnection;
        MySqlCommand sqlCommand;
        MySqlDataAdapter sqlDataAdapter;
        DataTable dt_employee;
        DataTable dt_employee_edit;
        int index = 0;
        string sqlQuery;
        bool ismanager;
        string employee;
        public Edit_Team_Management(bool is_manager, string karyawan)
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
            //TAMPILAN DGV//
            dt_employee = new DataTable();
            sqlQuery =
                "select * from all_employee"; //VIEW employee//
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnection);
            sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dt_employee);
            dgv_data.DataSource = dt_employee;

            //BIAR BISA DOUBLE CLICK MUNCUL DATA EMPLOYEE//
            dt_employee_edit = new DataTable();
            sqlQuery =
                "select ID, Name, Position, Pass, Email, `Phone Number`, Status " +
                "from all_employee"; //VIEW employee//
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnection);
            sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dt_employee_edit);
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

        private void dgv_data_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tampilan();

            index = e.RowIndex;

            tb_nama.Text = dt_employee_edit.Rows[e.RowIndex]["Name"].ToString();
            tb_password.Text = dt_employee_edit.Rows[e.RowIndex]["Pass"].ToString();
            tb_email.Text = dt_employee_edit.Rows[e.RowIndex]["Email"].ToString();
            tb_phone.Text = dt_employee_edit.Rows[e.RowIndex]["Phone Number"].ToString();
            cb_position.SelectedItem = dt_employee_edit.Rows[e.RowIndex]["Position"].ToString();
            cb_status.Text = dt_employee_edit.Rows[e.RowIndex]["Status"].ToString();
            if (cb_status.Text == "0")
            {
                cb_status.Text = "AKTIF";
            }
            else
            {
                cb_status.Text = "IN-AKTIF";
            }

        }

        private void pb_addbutton_Click(object sender, EventArgs e)
        {
            Add_Team_Management form = new Add_Team_Management(ismanager, employee);
            form.Show();
            this.Hide();
        }

        private void pb_editbutton_Click(object sender, EventArgs e)
        {
            
        }

        private void pb_done_Click(object sender, EventArgs e)
        {
            try
            {
                sqlConnection.Open();

                // Buat query dengan parameter
                sqlQuery = "CALL edit_karyawan(@id, @nama, @pass, @phone, @email, @jabatan, @status)"; //PROCEDURE edit_karyawan
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnection);

                sqlCommand.Parameters.AddWithValue("@id", dt_employee_edit.Rows[index]["ID"].ToString());
                sqlCommand.Parameters.AddWithValue("@nama", tb_nama.Text);
                sqlCommand.Parameters.AddWithValue("@pass", tb_password.Text);
                sqlCommand.Parameters.AddWithValue("@phone", tb_phone.Text);
                sqlCommand.Parameters.AddWithValue("@email", tb_email.Text);
                sqlCommand.Parameters.AddWithValue("@jabatan", cb_position.SelectedItem);
                sqlCommand.Parameters.AddWithValue("@status", cb_status.SelectedIndex);

                // Eksekusi perintah
                sqlCommand.ExecuteNonQuery();

                MessageBox.Show("Edit Successful");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
            tampilan();
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

        private void p_Sidebar_Paint(object sender, PaintEventArgs e)
        {

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

        }
    }
}
