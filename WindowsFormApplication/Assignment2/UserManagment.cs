using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;


namespace Assignment2
{
    /* This class is used to management user inforamtion between the program and the file.
     * Which declare the generic list for storing users from the text file.
     * Prvoide the methods that need to override between classes and functions.
     */
    public class UserManagment<T>
    {
        //The index of the specific uers information from the whole users list.
        //lines contains the initial user inforamtion from the text.
        int listIndex = new int();
        string[] lines = File.ReadAllLines("login.txt");
        private List<User> listUsers = new List<User>();

        public List<User>  ListUsers
        {
            get
            {
                return this.listUsers;
            } 
            set
            {
                this.listUsers = value;
            }
        }

        //This method is used collect the users information from the text file under the userInformation format with User type.
        public List<User> LoadedList()
        {
            UserInformation loadedUser;
            foreach (string line in lines)
            {
                string[] column = line.Split(',');
                //Change the date format into the users list;
                DateTime dateOfBirthColumn = DateTime.ParseExact(column[5], "dd-MM-yyyy", CultureInfo.InvariantCulture);
                loadedUser = new UserInformation(column[0], column[1], column[2], column[3], column[4], dateOfBirthColumn);
                listUsers.Add(loadedUser);
            }
            return listUsers;
        }

        //Identify the user type from the users list for the login process
        public string CheckUserType()
        {
            LoadedList();
            string LoginType = "View";
            if (listUsers[listIndex].UserType.Equals("Edit"))
            {
                LoginType = "Edit";
            }

            return LoginType;
        }

        //Check the username between the login information and ths users list.
        //Also, it used to check the exist name in the register
        public bool CheckUsername(string enteredUsername)
        {

            LoadedList();
            bool isCorrectUsername = false;
            for (int indexOfListUsers = 0; indexOfListUsers < listUsers.Count; indexOfListUsers++)
            {
                if (listUsers[indexOfListUsers].UserName.Equals(enteredUsername))
                {
                    listIndex = indexOfListUsers;
                    isCorrectUsername = true;
                    break;                              
                }
            }
            return isCorrectUsername;
        }

        //Check the password between the login information and ths users list
        public bool CheckPassword(string enteredPassword)
        {
            LoadedList();
            bool isCorrectPassword = false;
            for (int indexOfListUsers = 0; indexOfListUsers < listUsers.Count; indexOfListUsers++)
            {
                if (listUsers[indexOfListUsers].PassWord.Equals(enteredPassword))
                {
                    isCorrectPassword = true;
                    break;

                }
            }
            return isCorrectPassword;
        }

        //Saved the users list into the text file
        public bool WriteUsersListToFile()
        {
            StreamWriter streamWriter = new StreamWriter("login.txt");
            for (int indexOfListUsers = 0; indexOfListUsers < listUsers.Count; indexOfListUsers++)
            {
                //If the text file contains the same user information, do not need to override.
                //Just save the new user information only.
                if (indexOfListUsers >= lines.Count())
                {
                    User element = listUsers[indexOfListUsers];
                    string stringUserRecord = element.UserName + "," + element.PassWord + "," + element.UserType + "," + element.FirstName + "," + element.LastName + "," + element.DateOfBirth.ToString("dd-MM-yyyy");
                    streamWriter.WriteLine(stringUserRecord);
                }              
            }
            streamWriter.Close();
            return true;
        }
    }
}
