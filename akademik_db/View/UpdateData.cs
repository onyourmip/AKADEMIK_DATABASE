using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using akademik_db.Controller;

namespace akademik_db.View
{
    public partial class UpdateData : Form
    {
        AkademikController akademikController;
        public UpdateData()
        {
            akademikController = new AkademikController();
            InitializeComponent();
        }
        private void UpdateData_Load(object sender, EventArgs e)
        {
            LoadProdiAwal();
        }
        private void cbFakultas_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbProdi.Items.Clear();

            if (cbFakultas.Text == "FAKULTAS ILMU KOMPUTER")
            {
                cbProdi.Items.Add("D3 Manajemen Informatika");
                cbProdi.Items.Add("S1 Teknik Informatika");
            }
            else if (cbFakultas.Text == "FAKULTAS EKONOMI")
            {
                cbProdi.Items.Add("S1 Akuntansi");
                cbProdi.Items.Add("S1 Manajemen");
            }
            else if (cbFakultas.Text == "FAKULTAS TEKNIK")
            {
                cbProdi.Items.Add("S1 Teknik Industri");
            }
            else if (cbFakultas.Text == "FAKULTAS SASTRA")
            {
                cbProdi.Items.Add("D3 BAHASA INGGRIS");
                cbProdi.Items.Add("D3 BAHASA JEPANG");
            }
        }

        private void LoadProdiAwal()
        {
            if (cbFakultas.Text == "")
                return;

            cbProdi.Items.Clear();

            if (cbFakultas.Text == "FAKULTAS ILMU KOMPUTER")
            {
                cbProdi.Items.Add("D3 Manajemen Informatika");
                cbProdi.Items.Add("S1 Teknik Informatika");
            }
            else if (cbFakultas.Text == "FAKULTAS EKONOMI")
            {
                cbProdi.Items.Add("S1 Akuntansi");
                cbProdi.Items.Add("S1 Manajemen");
            }
            else if (cbFakultas.Text == "FAKULTAS TEKNIK")
            {
                cbProdi.Items.Add("S1 Teknik Industri");
            }
            else if (cbFakultas.Text == "FAKULTAS SASTRA")
            {
                cbProdi.Items.Add("D3 BAHASA INGGRIS");
                cbProdi.Items.Add("D3 BAHASA JEPANG");
            }
            if (cbProdi.Items.Contains(cbProdi.Text))
            {
                cbProdi.SelectedItem = cbProdi.Text;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (txtNim.Text == "" || txtNama.Text == "" || cbFakultas.Text == "" ||
               cbProdi.Text == "" || txtAlamat.Text == "" || txtNoHp.Text == "")
            {
                MessageBox.Show("Semua field harus diisi!");
                return;
            }

            bool status = akademikController.UpdateMahasiswa(
                txtNim.Text,
                txtNama.Text,
                cbFakultas.Text,
                cbProdi.Text,
                txtAlamat.Text,
                txtNoHp.Text
            );

            if (status)
            {
                MessageBox.Show("Data berhasil diperbarui!");
                ReadData readData = new ReadData();
                readData.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Gagal memperbarui data!");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ReadData readData = new ReadData();
            readData.Show();
            this.Hide();

        }

    }
}
