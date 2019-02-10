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
using System.Globalization;


namespace Assignment2
{
    /* Thie class is used to collect new user information and regiester new user.
     * the user information will be stored in login.txt.
     * This winodows will hide once register success or press "Cancel" button.
     */
    public partial class NewUserForm : Form
    {
        UserInformation newUser;
        UserManagment<User> userManagement;
        List<User> listUsers;
        string newUsername;
        string newPassword;
        string confirmPassword;
        string newFirstname;
        string newLastname;
        string newUsertype;
        DateTime newDateOfBirth;
        public NewUserForm()
        {
            InitializeComponent();
            userManagement = new UserManagment<User>();
            userManagement.LoadedList();
            listUsers = userManagement.ListUsers;
            NewDateTimePicker.Format = DateTimePickerFormat.Custom;
            NewDateTimePicker.CustomFormat = "dd-MM-yyyy"; //Set the defulat date format in the form
        }

        private void NewUserWindow_Load(object sender, EventArgs e)
        {

        }

        private void TextBoxNewUsername_TextChanged(object sender, EventArgs e)
        {
            TextBox objTextBox = (TextBox)sender;
            newUsername = objTextBox.Text;
            
        }

        private void TextBoxNewPassword_TextChanged(object sender, EventArgs e)
        {
            TextBox objTextBox = (TextBox)sender;
            newPassword = objTextBox.Text;

        }

        private void TextBoxReEnterPassword_TextChanged(object sender, EventArgs e)
        {
            TextBox objTextBox = (TextBox)sender;
            confirmPassword = objTextBox.Text;
        }

        private void TextBoxNewFirstname_TextChanged(object sender, EventArgs e)
        {
            TextBox objTextBox = (TextBox)sender;
            newFirstname = objTextBox.Text;
        }

        private void TextBoxNewLastname_TextChanged(object sender, EventArgs e)
        {
            TextBox objTextBox = (TextBox)sender;
            newLastname = objTextBox.Text;

        }

        private void NewDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker objDaaeTimePicker = (DateTimePicker)sender;
            newDateOfBirth = objDaaeTimePicker.Value;
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You are back to the login window!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
            
        }

        private void ButtonSubmit_Click(object sender, EventArgs e)
        {
            /* Check the username is existed or not. 
             * Then check the password is same as the another one.
             * Also check the empty input in username and passowrd.
             * The user inforamtion will generate as an UserInforamtion foramt.
             * The new user information will stored into the ListUsers first, then save into file.
             */

            
            if(newUsername != null && newPassword != null && confirmPassword != null)
            {
                if (userManagement.CheckUsername(newUsername) == false)
                {
                    if (newPassword.Equals(confirmPassword))
                    {
                        newUser = new UserInformation(newUsername, newPassword, newUsertype, newFirstname, newLastname, newDateOfBirth);
                        userManagement.ListUsers.Add(newUser);

                        if (userManagement.WriteUsersListToFile())
                        {
                            MessageBox.Show("Registration success!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                            LoginForm login = new LoginForm();
                            login.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error! Password not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Error! Username existed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Error! Invaild input!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Collect the user type from combo box
            string selectItem = comboBox1.Items[comboBox1.SelectedIndex].ToString();
            if (selectItem == "Edit")
            {
                newUsertype = "Edit";
            }

            if (selectItem == "View")
            {
                newUsertype = "View";
            }
        }
    }
}
