using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    /* This class defines the user parameters and the structure for the user information,
     * which can store and override the variables for different purpose.
     */
    public abstract class User
    {
        protected string userName;
        protected string passWord;
        protected string userType;
        protected string firstName;
        protected string lastName;
        protected DateTime dateOfBirth;

        public string UserName
        {
            get
            {
                return this.userName;
            }
        }

        public string PassWord
        {
            get
            {
                return this.passWord;
            }
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
        }

        public string UserType
        {
            get
            {
                return this.userType;
            }
        }

        public DateTime DateOfBirth
        {
            get
            {
                return this.dateOfBirth;
            }
        }

    }

}
