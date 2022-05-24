using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ProjekPV
{
    class Koneksi
    {
        public SqlConnection GetConn()
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = "Data Source=LAPTOP-R5277RU6\\BARA;Initial Catalog=Sparepart;Integrated Security=True";
            return Conn;
        }
    }
}
