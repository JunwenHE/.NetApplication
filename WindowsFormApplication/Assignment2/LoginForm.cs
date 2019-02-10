using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Assignment2
{
    /* This class is used to make an interface for user enter username and password to login the text editor
     * If the user is new that provide a button to regiester form.
     * The usernames and password both provided from the login.txt
     */
    public partial class LoginForm : Form
    {
        private string loginUsername;
        private string loginPassword;
        UserManagment<User> userManagment = new UserManagment<User>();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void TextBoxUsername_TextChanged(object sender, EventArgs e)
        {
            TextBox objTextBox = (TextBox)sender;
            loginUsername = objTextBox.Text;
        }

        private void TextBoxPassword_TextChanged(object sender, EventArgs e)
        {
            TextBox objTextBox = (TextBox)sender;
            loginPassword = objTextBox.Text;
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            /* Check the username and password both are correct or not. 
             * Then identify the user type to prepare the edit form interface
             */
            if (userManagment.CheckUsername(loginUsername) == true)
            {
                if (userManagment.CheckPassword(loginPassword) == true)
                {
                    if (userManagment.CheckUserType().Equals("Edit"))
                    {
                        MessageBox.Show("Login success! -- You are in edit mode", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LogginUser logginUser = new LogginUser(loginUsername, userManagment.CheckUserType());
                        EditForm editForm = new EditForm(logginUser);
                        editForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Login success! -- You are in view mode", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LogginUser logginUser = new LogginUser(loginUsername, userManagment.CheckUserType());
                        EditForm editForm = new EditForm(logginUser);
                        editForm.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Error! Incorrect password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Error! Incorrect username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonNewUser_Click(object sender, EventArgs e)
        {
            NewUserForm newUserWindow = new NewUserForm();
            newUserWindow.Show();
            this.Hide();
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}