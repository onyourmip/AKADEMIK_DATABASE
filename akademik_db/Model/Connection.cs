using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using System.Windows.Forms;

namespace akademik_db.Model
{
    internal class Connection
    {
        public MySqlCommand cmd;
        public DataSet ds;
        public MySqlDataAdapter da;

        public MySqlConnection GetConn()
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;user=root;database=akademik";
            try
            {
                conn.Open();
                MessageBox.Show("Koneksi Berhasil!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal Koneksi: " + ex.Message);
            }

            return conn;
        }
    }
}
