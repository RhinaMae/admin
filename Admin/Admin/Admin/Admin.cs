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
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            attendance attend=new attendance();
            this.Hide();
            attend.Show();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Connection.saveUpdateDeleteData("INSERT INTO `log_management`( `user_id`, `action`, `info`) VALUES ('" + 2 + "','Log out','Log out successfuly')", "logout");
            Login login = new Login();
            this.Hide();
            login.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            attendance at = new attendance();
            this.Hide();
            at.Show();
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {

        }
    }
}
