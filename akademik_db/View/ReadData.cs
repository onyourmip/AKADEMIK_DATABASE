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
using akademik_db.View;
using MySqlConnector;

namespace akademik_db
{
    public partial class ReadData : Form
    {
        AkademikController akademikController;
        public ReadData()
        {
            akademikController = new AkademikController();
            InitializeComponent();
        }
        bool showTable()
        {
            dgvData.DataSource = akademikController.TampilkanMahasiswa(new MySqlCommand("SELECT * FROM mahasiswa"));
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            return true;
        }
        private void ReadData_Load(object sender, EventArgs e)
        {
           showTable(); 

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddData addData = new AddData();
            addData.Show();
            this.Hide();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateData updateData = new UpdateData();

            updateData.txtNim.Text = dgvData.CurrentRow.Cells[0].Value.ToString();
            updateData.txtNama.Text = dgvData.CurrentRow.Cells[1].Value.ToString();
            updateData.cbFakultas.Text = dgvData.CurrentRow.Cells[2].Value.ToString();
            updateData.cbProdi.Text = dgvData.CurrentRow.Cells[3].Value.ToString();
            updateData.txtAlamat.Text = dgvData.CurrentRow.Cells[4].Value.ToString();
            updateData.txtNoHp.Text = dgvData.CurrentRow.Cells[5].Value.ToString();

            updateData.ShowDialog();
            showTable();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow == null)
            {
                MessageBox.Show("Silakan pilih data yang ingin dihapus.");
                return;
            }

            string nim = dgvData.CurrentRow.Cells[0].Value.ToString();

            DialogResult result = MessageBox.Show(
                "Yakin ingin menghapus data?",
                "Konfirmasi",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                akademikController.DeleteMahasiswa(nim);
                showTable();
            }
        }
    }
}
