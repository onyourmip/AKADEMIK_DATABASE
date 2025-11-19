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
    public partial class AddData : Form
    {
        AkademikController akademikController;
        public AddData()
        {
            akademikController = new AkademikController();
            InitializeComponent();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtNim.Text == "" || txtNama.Text == "" || cbFakultas.Text == "" ||
               cbProdi.Text == "" || txtAlamat.Text == "" || txtNoHp.Text == "")
            {
                MessageBox.Show("Semua field harus diisi!");
                return;
            }

            akademikController.AddMahasiswa(
                txtNim.Text,
                txtNama.Text,
                cbFakultas.Text,
                cbProdi.Text,
                txtAlamat.Text,
                txtNoHp.Text
            );

            MessageBox.Show("Data berhasil disimpan!");
            ReadData readData = new ReadData();
            readData.Show();
            this.Hide();

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ReadData readData = new ReadData();
            readData.Show();
            this.Hide();

        }
    }
}
