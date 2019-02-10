using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

/* Subject: 32998 .Net Applications Development
 * Student name: Junwen HE
 * Student ID: 12207080
 * 
 * The perpose of this windows form application is to produce a text editor that read and write the text file.
 * This program contains servial files that based on the differen functions:
 * User.cs is a class the produce a self declare data type.
 * UserInformation.cs is to declare the user detail in different function based on the User class.
 * UserManagement.cs is used to manage the users information between text file and the program. Such as read and write the login.txt, or check the information correctness
 * LoginForm.cs is program starting point which require user login with their username and password, or register new user.
 * EditFor.cs is the interface of the editor that can open or save the file. Type the text with different edit features.
 * NewUserForm.cs is the interface that used to collect the new user information and register the new user after the username and password checking
 * AboutBox.cs is display the author and program imformation.
 */
namespace Assignment2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
