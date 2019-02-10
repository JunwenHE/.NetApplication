using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment2
{
    /* Define two different purpose calsses to stored the user information from User class.
     * UserInformation is used to declared the format of the user detail read and write from the login.txt and register.
     * LogginUser is used to collect the corrent user who is logged in and its type.
     */
    class UserInformation : User
    {
        public UserInformation(string username, string password,string usertype, string firstname, string lastname, DateTime dateOfBirth)
        {
            this.userName = username;
            this.passWord = password;
            this.userType = usertype;
            this.firstName = firstname;
            this.lastName = lastname;
            this.dateOfBirth = dateOfBirth;
        }
    }

    public class LogginUser : User
    {
        public LogginUser(string username, string usertype)
        {
            this.userName = username;
            this.userType = usertype;
        }
    }
}
