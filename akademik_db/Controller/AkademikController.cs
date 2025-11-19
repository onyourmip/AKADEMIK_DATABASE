using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using System.Windows.Forms;

namespace akademik_db.Controller
{
    internal class AkademikController : Model.Connection
    {
        public DataTable TampilkanMahasiswa(MySqlCommand cmd)
        {
            DataTable data = new DataTable();

            try
            {
                string show = "SELECT * FROM mahasiswa";
                da = new MySqlDataAdapter(show, GetConn());
                da.Fill(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menampilkan data: " + ex.Message);
            }

            return data;
        }

        public bool AddMahasiswa(string Nim, string Nama, string Fakultas, string Prodi, string Alamat, string NoHp)
        {
            string addMhs = "INSERT INTO mahasiswa (nim, nama, fakultas, prodi, alamat, no_hp) " +
                            "VALUES (@nim, @nama, @fakultas, @prodi, @alamat, @no_hp)";

            try
            {
                cmd = new MySqlCommand(addMhs, GetConn());
                cmd.Parameters.Add("@nim", MySqlDbType.VarChar).Value = Nim;
                cmd.Parameters.Add("@nama", MySqlDbType.VarChar).Value = Nama;
                cmd.Parameters.Add("@fakultas", MySqlDbType.VarChar).Value = Fakultas;
                cmd.Parameters.Add("@prodi", MySqlDbType.VarChar).Value = Prodi;
                cmd.Parameters.Add("@alamat", MySqlDbType.VarChar).Value = Alamat;
                cmd.Parameters.Add("@no_hp", MySqlDbType.VarChar).Value = NoHp;

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    MessageBox.Show("NIM sudah digunakan, masukkan NIM lain!");
                }
                else
                {
                    MessageBox.Show("Tambah Mahasiswa gagal: " + ex.Message);
                }
                return false;
            }
        }

        public bool UpdateMahasiswa(string Nim, string Nama, string Fakultas, string Prodi, string Alamat, string NoHp)
        {
            string update = "UPDATE mahasiswa SET nama=@nama, fakultas=@fakultas, prodi=@prodi, " +
                            "alamat=@alamat, no_hp=@no_hp WHERE nim=@nim";

            try
            {
                cmd = new MySqlCommand(update, GetConn());
                cmd.Parameters.Add("@nim", MySqlDbType.VarChar).Value = Nim;
                cmd.Parameters.Add("@nama", MySqlDbType.VarChar).Value = Nama;
                cmd.Parameters.Add("@fakultas", MySqlDbType.VarChar).Value = Fakultas;
                cmd.Parameters.Add("@prodi", MySqlDbType.VarChar).Value = Prodi;
                cmd.Parameters.Add("@alamat", MySqlDbType.VarChar).Value = Alamat;
                cmd.Parameters.Add("@no_hp", MySqlDbType.VarChar).Value = NoHp;

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Mahasiswa gagal: " + ex.Message);
                return false;
            }
        }

        public bool DeleteMahasiswa(string Nim)
        {
            string delete = "DELETE FROM mahasiswa WHERE nim=@nim";

            try
            {
                cmd = new MySqlCommand(delete, GetConn());
                cmd.Parameters.Add("@nim", MySqlDbType.VarChar).Value = Nim;

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hapus Mahasiswa gagal: " + ex.Message);
                return false;
            }
        }


    }
}
