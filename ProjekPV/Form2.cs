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
    public partial class Form2 : Form
    {
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;

        public Form2()
        {
            InitializeComponent();
        }
        Koneksi Konn = new Koneksi();

		void Bersihkan()
		{
			textBox1.Text = "";
			textBox2.Text = "";
			textBox3.Text = "0";
			textBox4.Text = "0";
			textBox5.Text = "0";
			comboBox1.Text = "";
			textBox7.Text = "";
			TampilBarang();

		}

		void MunculSatuan()
		{
			comboBox1.Items.Add("Unit");
			comboBox1.Items.Add("Pcs");
			comboBox1.Items.Add("Kg");
			comboBox1.Items.Add("gram");
			comboBox1.Items.Add(7000);
		}

        private void Form2_Load(object sender, EventArgs e)
        {
			TampilBarang();
			Bersihkan();
			MunculSatuan();
		}

        private void button1_Click_1(object sender, EventArgs e)
        {
			if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "" || comboBox1.Text.Trim() == "")
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
					cmd = new SqlCommand("INSERT INTO TBL_ONDERDIL VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + comboBox1.Text + "')", conn);
					conn.Open();
					cmd.ExecuteNonQuery();
					MessageBox.Show("Insert Data Berhasil!");
					TampilBarang();
					Bersihkan();
				}
				catch (Exception X)
				{
					MessageBox.Show("Tidak dapat menyimpan Data");
				}
			}
		}

		void TampilBarang()
		{
			SqlConnection conn = Konn.GetConn();
			try
			{
				conn.Open();
				cmd = new SqlCommand("Select * from TBL_ONDERDIL", conn);
				ds = new DataSet();
				da = new SqlDataAdapter(cmd);
				da.Fill(ds, "TBL_ONDERDIL");
				dataGridView1.DataSource = ds;
				dataGridView1.DataMember = "TBL_ONDERDIL";
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

		void caribarang()
		{
			SqlConnection conn = Konn.GetConn();
			try
			{
				conn.Open();
				cmd = new SqlCommand("Select * from TBL_ONDERDIL where NamaBarang like'% " + textBox7.Text + "%' or KodeBarang like '%" + textBox7.Text + "%'", conn);
				ds = new DataSet();
				da = new SqlDataAdapter(cmd);
				da.Fill(ds, "TBL_ONDERDIL");
				dataGridView1.DataSource = ds;
				dataGridView1.DataMember = "TBL_ONDERDIL";
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
				textBox1.Text = row.Cells["KodeBarang"].Value.ToString();
				textBox2.Text = row.Cells["NamaBarang"].Value.ToString();
				textBox3.Text = row.Cells["HargaJual"].Value.ToString();
				textBox4.Text = row.Cells["HargaBeli"].Value.ToString();
				textBox5.Text = row.Cells["JumlahBarang"].Value.ToString();
				comboBox1.Text = row.Cells["SatuanBarang"].Value.ToString();

			}
			catch (Exception e1)
			{
				MessageBox.Show(e1.ToString());
			}

		}

        private void button2_Click(object sender, EventArgs e)
        {
			if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "" || comboBox1.Text.Trim() == "")
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
					cmd = new SqlCommand("UPDATE TBL_ONDERDIL SET KodeBarang='" + textBox1.Text + "', NamaBarang='" + textBox2.Text + "', HargaJual='" + textBox3.Text + "', HargaBeli='" + textBox4.Text + "', JumlahBarang='" + textBox5.Text + "', SatuanBarang='" + comboBox1.Text + "' WHERE KodeBarang='" + textBox1.Text + "'", Conn);
					Conn.Open();
					cmd.ExecuteNonQuery();
					MessageBox.Show("Update Data Berhasil!");
					TampilBarang();
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
				cmd = new SqlCommand("DELETE TBL_ONDERDIL WHERE KodeBarang='" + textBox1.Text + "'", conn);
				conn.Open();
				cmd.ExecuteNonQuery();
				MessageBox.Show("Hapus Data Berhasil!");
				TampilBarang();
				Bersihkan();
			}
		}

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
			caribarang();
		}

        private void button4_Click(object sender, EventArgs e)
        {
			Bersihkan();
		}

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
			e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
		}

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
			e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
		}

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
			e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
		}

        private void button5_Click(object sender, EventArgs e)
        {
			Form3 f3 = new Form3();
			f3.Show();
			this.Hide();
		}
    }
}
