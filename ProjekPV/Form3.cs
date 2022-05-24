using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProjekPV
{
    public partial class Form3 : Form
    {
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;

        public Form3()
        {
            InitializeComponent();
        }

        Koneksi Konn = new Koneksi();
        void Bersihkan()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            TampilCustomer();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TampilCustomer();
            Bersihkan();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "")
            {
                MessageBox.Show("Mohon isikan terlebih dahulu kolom-kolom yang tersedia");

            }
            else
            {
                /*************************************************
				 * Simpan Data
				 * **********************************************/
                SqlConnection conn = Konn.GetConn();
                try
                {
                    cmd = new SqlCommand("INSERT INTO TBL_CUSTOMER VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Insert Data Berhasil!");
                    TampilCustomer();
                    Bersihkan();
                }
                catch (Exception X)
                {
                    MessageBox.Show("Tidak dapat menyimpan Data");
                }
            }
        }
        void TampilCustomer()
        {
            SqlConnection conn = Konn.GetConn();
            try
            {
                conn.Open();
                cmd = new SqlCommand("Select * from TBL_CUSTOMER", conn);
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "TBL_CUSTOMER");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "TBL_CUSTOMER";
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            }
            catch (Exception G)
            {
                MessageBox.Show(G.ToString());
            }
            finally
            {
                conn.Close();
            }

        }
        void caricustomer()
        {
            SqlConnection conn = Konn.GetConn();
            try
            {
                conn.Open();
                cmd = new SqlCommand("Select * from TBL_CUSTOMER where NamaCustomer like'% " + textBox5.Text + "%' or IdCustomer like '%" + textBox5.Text + "%'", conn);
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "TBL_CUSTOMER");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "TBL_CUSTOMER";
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            }
            catch (Exception G)
            {
                MessageBox.Show(G.ToString());
            }
            finally
            {
                conn.Close();
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["IdCustomer"].Value.ToString();
                textBox2.Text = row.Cells["NamaCustomer"].Value.ToString();
                textBox3.Text = row.Cells["AlamatCustomer"].Value.ToString();
                textBox4.Text = row.Cells["PesananCustomer"].Value.ToString();

            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "")
            {
                MessageBox.Show("Mohon isikan terlebih dahulu kolom-kolom yang tersedia");

            }
            else
            {
                /*************************************************
				 * Simpan Data
				 * **********************************************/
                SqlConnection Conn = Konn.GetConn();
                try
                {
                    cmd = new SqlCommand("UPDATE TBL_CUSTOMER SET IdCustomer='" + textBox1.Text + "', NamaCustomer='" + textBox2.Text + "', AlamatCustomer='" + textBox3.Text + "', PesananCustomer='" + textBox4.Text + "' WHERE IdCustomer='" + textBox1.Text + "'", Conn);
                    Conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Update Data Berhasil!");
                    TampilCustomer();
                    Bersihkan();
                }
                catch (Exception X)
                {
                    MessageBox.Show("Tidak dapat menyimpan Data");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(textBox2.Text + ", Yakin ingin dihapus?", "Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                /*************************************************
				 * Hapus Data
				 * **********************************************/
                SqlConnection conn = Konn.GetConn();
                cmd = new SqlCommand("DELETE TBL_Customer WHERE IdCustomer='" + textBox1.Text + "'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Hapus Data Berhasil!");
                TampilCustomer();
                Bersihkan();
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            caricustomer();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bersihkan();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }
    }
}
