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

namespace Customer_Frosty_Bites
{
    public partial class Order_Page : Form
    {
        MySqlConnection sqlConnection;
        MySqlCommand sqlCommand;
        MySqlDataAdapter sqlDataAdapter;
        string sqlQuery;
        DataTable dt_catalog;
        DataTable cust;
        DataTable dt_pesan_berapa = new DataTable();
        int index = 0;
        string cust_name;

        int produk_1 = 0;
        int produk_2 = 0;
        int produk_3 = 0;
        int produk_4 = 0;
        int produk_5 = 0;
        int produk_6 = 0;

        int shipping;
        int total_payment;
        int point_cust;
        string alamat_before;
        string alamat_after;
        string status_bayar;
        public Order_Page(string customer)
        {
            InitializeComponent();
            sqlConnection = new MySqlConnection("server=sub4.sift-uc.id; user=subsift5_user_b1; pwd=e0PFR9[Z+pj@; database=subsift5_db_b1;");
            cust_name = customer;
            lb_namaC_catalogpage.Text = customer;
            tampilan();
            ngitung();

            alamat_before = tb_address.Text;
        }
        private void ngitung()
        {
            //Product Subtotal
            int total_harga = 0;
            for (int i = 0; i < dt_pesan_berapa.Rows.Count; i++)
            {
                total_harga +=
                    int.Parse(dt_pesan_berapa.Rows[i]["Harga"].ToString()) *
                    int.Parse(dt_pesan_berapa.Rows[i]["jmlh_pesan"].ToString());
            }
            lb_subTotal.Text = "Rp. " + total_harga.ToString("#,0");

            //Shipping Fee
            shipping = 0;
            DataTable dt_harga = new DataTable();
            sqlQuery = $"select Shipping_Price('{cust_name}') as harga"; //VIEW catalog//
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnection);
            sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dt_harga);
            shipping = int.Parse(dt_harga.Rows[0]["harga"].ToString());
            lb_shippingfee.Text = "Rp. " + shipping.ToString("#,0");

            //Discount
            int diskon = 0;
            if (point_cust % 10 == 0 && point_cust != 0) // GANTIIIII
            {
                diskon = (total_harga + shipping) * 10 / 100;
            }
            lb_discount.Text = "Rp. " + diskon.ToString("#,0");

            //Total Payment
            total_payment = 0;
            total_payment = total_harga + shipping - diskon;
            lb_totalPayment.Text = total_payment.ToString("#,0");
        }
        private void menghilanglah()
        {
            lb_product1.Visible = false;
            lb_product2.Visible = false;
            lb_product3.Visible = false;
            lb_product4.Visible = false;
            lb_product5.Visible = false;
            lb_product6.Visible = false;

            pb_minusproduct1.Visible = false;
            pb_minusproduct2.Visible = false;
            pb_minusproduct3.Visible = false;
            pb_minusproduct4.Visible = false;
            pb_minusproduct5.Visible = false;
            pb_minusproduct6.Visible = false;

            pb_plusproduct1.Visible = false;
            pb_plusproduct2.Visible = false;
            pb_plusproduct3.Visible = false;
            pb_plusproduct4.Visible = false;
            pb_plusproduct5.Visible = false;
            pb_plusproduct6.Visible = false;

            tb_product1.Visible = false;
            tb_product2.Visible = false;
            tb_product3.Visible = false;
            tb_product4.Visible = false;
            tb_product5.Visible = false;
            tb_product6.Visible = false;
        }

        private void tampilan()
        {
            tb_product1.Text = produk_1.ToString();
            tb_product2.Text = produk_2.ToString();
            tb_product3.Text = produk_3.ToString();
            tb_product4.Text = produk_4.ToString();
            tb_product5.Text = produk_5.ToString();
            tb_product6.Text = produk_6.ToString();

            dt_catalog = new DataTable();
            sqlQuery = "select*from catalog"; //VIEW catalog//
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnection);
            sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dt_catalog);
            sqlDataAdapter.Fill(dt_pesan_berapa);

            dt_pesan_berapa.Columns.Add("jmlh_pesan", typeof(int));
            for (int i = 0; i < dt_catalog.Rows.Count; i++)
            {
                dt_pesan_berapa.Rows[i]["jmlh_pesan"] = 0;
            }

            lb_product1.Text = dt_catalog.Rows[index]["Nama"].ToString();
            lb_product2.Text = dt_catalog.Rows[index + 1]["Nama"].ToString();
            lb_product3.Text = dt_catalog.Rows[index + 2]["Nama"].ToString();
            lb_product4.Text = dt_catalog.Rows[index + 3]["Nama"].ToString();
            lb_product5.Text = dt_catalog.Rows[index + 4]["Nama"].ToString();
            lb_product6.Text = dt_catalog.Rows[index + 5]["Nama"].ToString();

            cust = new DataTable();
            sqlQuery = $"CALL cust_order('{cust_name}')";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnection);
            sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(cust);

            tb_namaCustomer.Text = cust.Rows[0]["nama"].ToString();
            tb_phonenumber.Text = cust.Rows[0]["notelp"].ToString();
            tb_email.Text = cust.Rows[0]["email"].ToString();
            tb_address.Text = cust.Rows[0]["address"].ToString();

            point_cust = int.Parse(cust.Rows[0]["point"].ToString());
        }

        private void lb_cataloglabel_Click(object sender, EventArgs e)
        {
            Catalog_Page catalogpage = new Catalog_Page(cust_name);
            catalogpage.Show();
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

        private void pb_previous_Click(object sender, EventArgs e)
        {
            if (index == 6)
            {
                index -= 6;
            }
            else
            {
                MessageBox.Show("Anda udah di ujung");
            }
            int counter = dt_catalog.Rows.Count - index;

            menghilanglah();

            if (counter > 0)
            {
                produk_1 = int.Parse(dt_pesan_berapa.Rows[index]["jmlh_pesan"].ToString());
                tb_product1.Text = produk_1.ToString();
                lb_product1.Text = dt_catalog.Rows[index]["Nama"].ToString();
                lb_product1.Visible = true;
                pb_plusproduct1.Visible = true;
                pb_minusproduct1.Visible = true;
                tb_product1.Visible = true;
            }
            if (counter > 1)
            {
                produk_2 = int.Parse(dt_pesan_berapa.Rows[index + 1]["jmlh_pesan"].ToString());
                tb_product2.Text = produk_2.ToString();
                lb_product2.Text = dt_catalog.Rows[index + 1]["Nama"].ToString();
                lb_product2.Visible = true;
                pb_plusproduct2.Visible = true;
                pb_minusproduct2.Visible = true;
                tb_product2.Visible = true;
            }
            if (counter > 2)
            {
                produk_3 = int.Parse(dt_pesan_berapa.Rows[index + 2]["jmlh_pesan"].ToString());
                tb_product3.Text = produk_3.ToString();
                lb_product3.Text = dt_catalog.Rows[index + 2]["Nama"].ToString();
                lb_product3.Visible = true;
                pb_plusproduct3.Visible = true;
                pb_minusproduct3.Visible = true;
                tb_product3.Visible = true;
            }
            if (counter > 3)
            {
                produk_4 = int.Parse(dt_pesan_berapa.Rows[index + 4]["jmlh_pesan"].ToString());
                tb_product4.Text = produk_4.ToString();
                lb_product4.Text = dt_catalog.Rows[index + 3]["Nama"].ToString();
                lb_product4.Visible = true;
                pb_plusproduct4.Visible = true;
                pb_minusproduct4.Visible = true;
                tb_product4.Visible = true;
            }
            if (counter > 4)
            {
                produk_5 = int.Parse(dt_pesan_berapa.Rows[index + 4]["jmlh_pesan"].ToString());
                tb_product5.Text = produk_5.ToString();
                lb_product5.Text = dt_catalog.Rows[index + 4]["Nama"].ToString();
                lb_product5.Visible = true;
                pb_plusproduct5.Visible = true;
                pb_minusproduct5.Visible = true;
                tb_product5.Visible = true;
            }
            if (counter > 5)
            {
                produk_6 = int.Parse(dt_pesan_berapa.Rows[index + 6]["jmlh_pesan"].ToString());
                tb_product6.Text = produk_6.ToString();
                lb_product6.Text = dt_catalog.Rows[index + 5]["Nama"].ToString();
                lb_product6.Visible = true;
                pb_plusproduct6.Visible = true;
                pb_minusproduct6.Visible = true;
                tb_product6.Visible = true;
            }
        }

        private void pb_next_Click(object sender, EventArgs e)
        {
            index = index + 6;
            int counter = dt_catalog.Rows.Count - index;
            if (counter <= 0)
            {
                MessageBox.Show("Anda udh di ujung");
                index = index - 6;
            }
            else
            {
                menghilanglah();
                produk_1 = 0;
                produk_2 = 0;
                produk_3 = 0;
                produk_4 = 0;
                produk_5 = 0;
                produk_6 = 0;

                if (counter > 0)
                {
                    produk_1 = int.Parse(dt_pesan_berapa.Rows[index]["jmlh_pesan"].ToString());
                    tb_product1.Text = produk_1.ToString();
                    lb_product1.Text = dt_catalog.Rows[index]["Nama"].ToString();
                    lb_product1.Visible = true;
                    pb_plusproduct1.Visible = true;
                    pb_minusproduct1.Visible = true;
                    tb_product1.Visible = true;
                }
                if (counter > 1)
                {
                    produk_2 = int.Parse(dt_pesan_berapa.Rows[index + 1]["jmlh_pesan"].ToString());
                    tb_product2.Text = produk_2.ToString();
                    lb_product2.Text = dt_catalog.Rows[index + 1]["Nama"].ToString();
                    lb_product2.Visible = true;
                    pb_plusproduct2.Visible = true;
                    pb_minusproduct2.Visible = true;
                    tb_product2.Visible = true;
                }
                if (counter > 2)
                {
                    produk_3 = int.Parse(dt_pesan_berapa.Rows[index + 2]["jmlh_pesan"].ToString());
                    tb_product3.Text = produk_3.ToString();
                    lb_product3.Text = dt_catalog.Rows[index + 2]["Nama"].ToString();
                    lb_product3.Visible = true;
                    pb_plusproduct3.Visible = true;
                    pb_minusproduct3.Visible = true;
                    tb_product3.Visible = true;
                }
                if (counter > 3)
                {
                    produk_4 = int.Parse(dt_pesan_berapa.Rows[index + 4]["jmlh_pesan"].ToString());
                    tb_product4.Text = produk_4.ToString();
                    lb_product4.Text = dt_catalog.Rows[index + 3]["Nama"].ToString();
                    lb_product4.Visible = true;
                    pb_plusproduct4.Visible = true;
                    pb_minusproduct4.Visible = true;
                    tb_product4.Visible = true;
                }
                if (counter > 4)
                {
                    produk_5 = int.Parse(dt_pesan_berapa.Rows[index + 4]["jmlh_pesan"].ToString());
                    tb_product5.Text = produk_5.ToString();
                    lb_product5.Text = dt_catalog.Rows[index + 4]["Nama"].ToString();
                    lb_product5.Visible = true;
                    pb_plusproduct5.Visible = true;
                    pb_minusproduct5.Visible = true;
                    tb_product5.Visible = true;
                }
                if (counter > 5)
                {
                    produk_6 = int.Parse(dt_pesan_berapa.Rows[index + 6]["jmlh_pesan"].ToString());
                    tb_product6.Text = produk_6.ToString();
                    lb_product6.Text = dt_catalog.Rows[index + 5]["Nama"].ToString();
                    lb_product6.Visible = true;
                    pb_plusproduct6.Visible = true;
                    pb_minusproduct6.Visible = true;
                    tb_product6.Visible = true;
                }
            }
        }

        private void pb_minusproduct1_Click(object sender, EventArgs e)
        {
            if (produk_1 > 0)
            {
                produk_1--;
                tb_product1.Text = produk_1.ToString();
                dt_pesan_berapa.Rows[index]["jmlh_pesan"] = tb_product1.Text;

                ngitung();
            }
        }

        private void pb_plusproduct1_Click(object sender, EventArgs e)
        {
            produk_1++;
            tb_product1.Text = produk_1.ToString();
            dt_pesan_berapa.Rows[index]["jmlh_pesan"] = tb_product1.Text;

            ngitung();
        }

        private void pb_minusproduct2_Click(object sender, EventArgs e)
        {
            if (produk_2 > 0)
            {
                produk_2--;
                tb_product2.Text = produk_2.ToString();
                dt_pesan_berapa.Rows[index + 1]["jmlh_pesan"] = tb_product2.Text;

                ngitung();
            }
        }

        private void pb_plusproduct2_Click(object sender, EventArgs e)
        {
            produk_2++;
            tb_product2.Text = produk_2.ToString();
            dt_pesan_berapa.Rows[index + 1]["jmlh_pesan"] = tb_product2.Text;

            ngitung();
        }

        private void pb_minusproduct3_Click(object sender, EventArgs e)
        {
            if (produk_3 > 0)
            {
                produk_3--;
                tb_product3.Text = produk_3.ToString();
                dt_pesan_berapa.Rows[index + 2]["jmlh_pesan"] = tb_product3.Text;

                ngitung();
            }
        }

        private void pb_plusproduct3_Click(object sender, EventArgs e)
        {
            produk_3++;
            tb_product3.Text = produk_3.ToString();
            dt_pesan_berapa.Rows[index + 2]["jmlh_pesan"] = tb_product3.Text;

            ngitung();
        }

        private void pb_minusproduct4_Click(object sender, EventArgs e)
        {
            if (produk_4 > 0)
            {
                produk_4--;
                tb_product4.Text = produk_4.ToString();
                dt_pesan_berapa.Rows[index + 3]["jmlh_pesan"] = tb_product4.Text;

                ngitung();
            }
        }

        private void pb_plusproduct4_Click(object sender, EventArgs e)
        {
            produk_4++;
            tb_product4.Text = produk_4.ToString();
            dt_pesan_berapa.Rows[index + 3]["jmlh_pesan"] = tb_product4.Text;

            ngitung();
        }

        private void pb_minusproduct5_Click(object sender, EventArgs e)
        {
            if (produk_5 > 0)
            {
                produk_5--;
                tb_product5.Text = produk_5.ToString();
                dt_pesan_berapa.Rows[index + 4]["jmlh_pesan"] = tb_product5.Text;

                ngitung();
            }
        }

        private void pb_plusproduct5_Click(object sender, EventArgs e)
        {
            produk_5++;
            tb_product5.Text = produk_5.ToString();
            dt_pesan_berapa.Rows[index + 4]["jmlh_pesan"] = tb_product5.Text;

            ngitung();
        }

        private void pb_minusproduct6_Click(object sender, EventArgs e)
        {
            if (produk_6 > 0)
            {
                produk_6--;
                tb_product6.Text = produk_6.ToString();
                dt_pesan_berapa.Rows[index + 5]["jmlh_pesan"] = tb_product6.Text;

                ngitung();
            }
        }

        private void pb_plusproduct6_Click(object sender, EventArgs e)
        {
            produk_6++;
            tb_product6.Text = produk_6.ToString();
            dt_pesan_berapa.Rows[index + 5]["jmlh_pesan"] = tb_product6.Text;

            ngitung();
        }

        private void pb_catalogbutton_Click(object sender, EventArgs e)
        {
            Catalog_Page catalogpage = new Catalog_Page(cust_name);
            catalogpage.Show();
            this.Hide();
        }

        private void pb_redNext_Click(object sender, EventArgs e)
        {
            if (cb_paymentmethod.SelectedIndex == -1)
            {
                MessageBox.Show("Choose Payment Method first");
            }
            else
            {
                alamat_after = tb_address.Text;

                if (alamat_before != alamat_after) // UPDATE JIKA CUSTOMER GANTI ALAMAT
                {
                    sqlConnection.Open();
                    sqlQuery =
                        "UPDATE CUSTOMER " +
                        "SET CUST_ALAMAT = @alamat " +
                        "WHERE CUST_PHONE = @notelp";

                    sqlCommand = new MySqlCommand(sqlQuery, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@alamat", tb_address.Text);
                    sqlCommand.Parameters.AddWithValue("@notelp", tb_phonenumber.Text);
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();

                    ngitung();
                }
                // 0 = QRIS
                // 1 = TRANSFER
                // 2 = COD
                if (cb_paymentmethod.SelectedIndex == 0)
                {
                    status_bayar = "1";
                    p_pembayaran.Visible = true;
                    pb_qris.Visible = true;
                    lb_bankTf.Visible = false;
                }
                else if (cb_paymentmethod.SelectedIndex == 1)
                {
                    status_bayar = "1";
                    p_pembayaran.Visible = true;
                    lb_bankTf.Visible = true;
                    pb_qris.Visible = false;
                }
                else if (cb_paymentmethod.SelectedIndex == 2)
                {
                    status_bayar = "0";
                    proses_transaksi_update();

                    Catalog_Page form15 = new Catalog_Page(cust_name);
                    form15.Show();
                    this.Hide();
                }

            }
        }
        private void proses_transaksi_update()
        {
            try
            {
                sqlConnection.Open();
                if (point_cust % 10 == 0 && point_cust != 0)
                {
                    int diskon_total = total_payment * 10 / 100;
                    sqlQuery =
                    "CALL P_Transaction" +
                    "(@notelp, @metode_pembayaran, @bukti_pembayaran, @ongkos_kirim, @total_pembayaran, @status_bayar)";

                    sqlCommand = new MySqlCommand(sqlQuery, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@notelp", tb_phonenumber.Text);
                    sqlCommand.Parameters.AddWithValue("@metode_pembayaran", cb_paymentmethod.SelectedItem.ToString());
                    sqlCommand.Parameters.AddWithValue("@bukti_pembayaran", tb_linkFile.Text);
                    sqlCommand.Parameters.AddWithValue("@ongkos_kirim", shipping);
                    sqlCommand.Parameters.AddWithValue("@total_pembayaran", total_payment - diskon_total);
                    sqlCommand.Parameters.AddWithValue("@status_bayar", status_bayar);
                    sqlCommand.ExecuteNonQuery();
                }
                else
                {
                    sqlQuery =
                    "CALL P_Transaction" +
                    "(@notelp, @metode_pembayaran, @bukti_pembayaran, @ongkos_kirim, @total_pembayaran, @status_bayar)";

                    sqlCommand = new MySqlCommand(sqlQuery, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@notelp", tb_phonenumber.Text);
                    sqlCommand.Parameters.AddWithValue("@metode_pembayaran", cb_paymentmethod.SelectedItem.ToString());
                    sqlCommand.Parameters.AddWithValue("@bukti_pembayaran", tb_linkFile.Text);
                    sqlCommand.Parameters.AddWithValue("@ongkos_kirim", shipping);
                    sqlCommand.Parameters.AddWithValue("@total_pembayaran", total_payment);
                    sqlCommand.Parameters.AddWithValue("@status_bayar", status_bayar);
                    sqlCommand.ExecuteNonQuery();
                }

                sqlQuery = "CALL transaction_poin_cust(@notelp)";
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@notelp", tb_phonenumber.Text);
                sqlCommand.ExecuteNonQuery();

                for (int i = 0; i < dt_pesan_berapa.Rows.Count; i++)
                {
                    if (int.Parse(dt_pesan_berapa.Rows[i]["jmlh_pesan"].ToString()) > 0)
                    {
                        int harga_satuan = int.Parse(dt_pesan_berapa.Rows[i]["Harga"].ToString());
                        int jmlh_beli = int.Parse(dt_pesan_berapa.Rows[i]["jmlh_pesan"].ToString());
                        int tot = harga_satuan * jmlh_beli;

                        sqlQuery = "CALL update_detail_transaksi(@id, @jumlah, @total, @satuan)";
                        sqlCommand = new MySqlCommand(sqlQuery, sqlConnection);
                        sqlCommand.Parameters.AddWithValue("@id", dt_pesan_berapa.Rows[i]["ID"].ToString());
                        sqlCommand.Parameters.AddWithValue("@jumlah", jmlh_beli);
                        sqlCommand.Parameters.AddWithValue("@total", tot);
                        sqlCommand.Parameters.AddWithValue("@satuan", harga_satuan);
                        sqlCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        private void pb_cancelbutton_Click(object sender, EventArgs e)
        {
            p_pembayaran.Visible = false;
        }

        private void pb_donebutton_Click(object sender, EventArgs e)
        {
            alamat_after = tb_address.Text;

            if (alamat_before != alamat_after) // UPDATE JIKA CUSTOMER GANTI ALAMAT
            {
                sqlConnection.Open();
                sqlQuery =
                    "UPDATE CUSTOMER " +
                    "SET CUST_ALAMAT = @alamat " +
                    "WHERE CUST_PHONE = @notelp";

                sqlCommand = new MySqlCommand(sqlQuery, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@alamat", tb_address.Text);
                sqlCommand.Parameters.AddWithValue("@notelp", tb_phonenumber.Text);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

                ngitung();
                proses_transaksi_update(); // NGISI DATA BARU TABEL TRANSAKSI SAMA DETAIL TRANSAKSI

                Catalog_Page form15 = new Catalog_Page(cust_name);
                form15.Show();
                this.Hide();
            }
            else // KALO GA GANTI ALAMAT
            {
                proses_transaksi_update();

                Catalog_Page form15 = new Catalog_Page(cust_name);
                form15.Show();
                this.Hide();
            }

            MessageBox.Show("Payment Confirmed");
        }
    }
}
