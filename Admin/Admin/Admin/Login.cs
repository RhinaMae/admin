using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace Admin
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbxUser.Text == "" || tbxPass.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    MySqlConnection connection = Connection.GetConnection();
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM account WHERE Username ='" + tbxUser.Text + "' AND Password ='" + tbxPass.Text + "'", connection);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        Connection.saveUpdateDeleteData("INSERT INTO `log_management`( `user_id`, `action`, `info`) VALUES ('" + 2 + "','Log In','Log in successfuly')", "login");
                        AdminDashboard admin = new AdminDashboard();
                        this.Hide();
                        admin.Show();
                    }
                    else
                    {
                        Connection.saveUpdateDeleteData("INSERT INTO `log_management`( `user_id`, `action`, `info`) VALUES ('" + 2 + "','Log In','Log in unsuccessful')", "login");
                        MessageBox.Show("Username or password is incorrect!");
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void lbCreate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateAccount createAccount = new CreateAccount();
            this.Hide();
            createAccount.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbxShow.Checked)
            {
                // If checked, show the password
                tbxPass.UseSystemPasswordChar = true;
            }
            else
            {
                // If unchecked, hide the password
                tbxPass.UseSystemPasswordChar = false;
            }
        }
    }
}
