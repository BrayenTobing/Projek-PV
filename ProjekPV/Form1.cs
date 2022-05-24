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
    public partial class Form1 : Form
    {
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;
        private SqlDataReader rd;

        Koneksi Konn = new Koneksi();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataReader reader = null;
            SqlConnection conn = Konn.GetConn();
            {
                conn.Open();
                cmd = new SqlCommand("select * from TBL_LOGIN WHERE Username='" + textBox1.Text + "' and Password='" + textBox2.Text + "'", conn);
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Form2 frmUtama = new Form2();
                    frmUtama.Show();
                    MessageBox.Show("Welcome To Our Bussiness");
                }
                else
                {
                    MessageBox.Show("username/password SALAH");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
