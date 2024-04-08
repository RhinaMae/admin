using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admin
{
    public partial class attendance : Form
    {
        public attendance()
        {
            InitializeComponent();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.Show();
        }

        private void lblAdDash_Click(object sender, EventArgs e)
        {
            AdminDashboard addash = new AdminDashboard();
            this.Hide();
            addash.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
           
        }

        private async void attendance_Load(object sender, EventArgs e)
        {
            await APICon.DgvViewlate(dgvAtt, dtpDate.Value.ToString("MM-dd-yyyy"));

        }

        private async void btnlate_Click(object sender, EventArgs e)
        {
            await APICon.DgvViewingAsync(dgvAtt);
        }

        private async void bntList_Click(object sender, EventArgs e)
        {
           await APICon.DgvViewlate(dgvAtt, dtpDate.Value.ToString("MM-dd-yyyy"));
        }

        private async void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            await APICon.DgvViewlate(dgvAtt, dtpDate.Value.ToString("MM-dd-yyyy"));

        }
    }
}
