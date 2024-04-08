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

namespace Admin
{
    public partial class CreateAccount : Form
    {
       
        public CreateAccount()
        {

            InitializeComponent();
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbxLname.Text == "" || tbxFname.Text == "")
            {
                Connection.saveUpdateDeleteData("INSERT INTO `log_management`( `user_id`, `action`, `info`) VALUES ('" + 2 + "','new account','create unsuccesful')", "Missing Information");
            }
            if (tbxLname.Text != "" || tbxFname.Text != "")
            {
                Connection.saveUpdateDeleteData("INSERT INTO `log_management`( `user_id`, `action`, `info`) VALUES ('" + 2 + "','new account','new account saved')", "added new acount");
                Connection.saveUpdateDeleteData("Insert INTO account (First_Name,Last_Name,Username,Password) values ('" + tbxFname.Text + "','" + tbxLname.Text + "','" + tbxUname.Text + "','" + tbxPass.Text + "')", "Saved");
                Login login = new Login();
                this.Hide();
                login.Show();
            }
        }

        private void tbxConPass_TextChanged(object sender, EventArgs e)
        {
            if (tbxPass.Text == tbxConPass.Text)
            {
                lblResult.Text = "Passwords match!";
                lblResult.ForeColor = Color.Green;
            }
            else
            {
                lblResult.Text = "Passwords do not match!";
                lblResult.ForeColor = Color.Red;
            }
        }

        private void CreateAccount_Load(object sender, EventArgs e)
        {

        }
    }
}
