using PermissionToFileLibraryClasses.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PermissionToFileLibraryClasses
{
    [Serializable]
    [DataContract]
    public class Person : IComparable<Person>
    {
        [DataMember]
        public string Username { get; private set; }
        [DataMember]
        public string Userpassword { get; private set; }
        [DataMember]
        public string Rank { get; private set; }

        public int CompareTo(Person person)
        {
            return this.Username.CompareTo(person.Username);
        }
        public Person()
        { }

        public Person(string username, string password, string rank)
        {
            this.Username = username;
            this.Userpassword = password;
            this.Rank = rank;
        }

        public bool StringValidator(string input)
        {
            string pattern = "[^a-zA-Z]";
            if (Regex.IsMatch(input, pattern))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IntegerValidator(string input)
        {
            string pattern = "[^0-9]";
            if (Regex.IsMatch(input, pattern))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ClearTexts(string username, string password)
        {
            username = String.Empty;
            password = String.Empty;
        }

        public bool IsLoggedIn(string username, string password)
        {
            if (string.IsNullOrEmpty(username))
            {
                return false;
            }
            else if (StringValidator(username) == true)
            {
                ClearTexts(username, password);
                return false;
            }
            else
            {
                if (Username != username)
                {
                    ClearTexts(username, password);
                    return false;
                }
                else
                {
                    if (string.IsNullOrEmpty(password))
                    {
                        return false;
                    }
                    else if (IntegerValidator(password) == true)
                    {
                        return false;
                    }
                    else if (Userpassword != password)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }
    }

    [Serializable]
    [DataContract]
    public class User : Person
    {
        [DataMember]
        public bool Banned { get; set; }
        public User(String Username, String Userpassword, String Rank, Boolean Banned) : base(Username, Userpassword, Rank)
        {
            Banned = false;
        }
    }

    [Serializable]
    [DataContract]
    public class Admin : Person
    {
        [DataMember]
        public bool CreateUser { get; private set; }
        [DataMember]
        public bool DeleteUser { get; private set; }
        [DataMember]
        public bool CreateFile { get; private set; }
        [DataMember]
        public bool DeleteFile { get; private set; }
        [DataMember]
        public bool ChangePermissionOnRead { get; private set; }
        [DataMember]
        public bool ChangePermissionOnWrite { get; private set; }
        [DataMember]
        public bool DeletePermissionOnRead { get; private set; }
        [DataMember]
        public bool DeletePermissionOnWrite { get; private set; }

        public Admin(String Username, String Userpassword, String Rank, Boolean createUser, Boolean deleteUser, Boolean createFile, Boolean deleteFile,
            Boolean changePermissionOnRead, Boolean changePermissionOnWrite, Boolean deletePermissionOnRead, Boolean deletePermissionOnWrite) : base(Username, Userpassword, Rank)
        {
            CreateUser = createUser;
            DeleteUser = deleteUser;
            CreateFile = createFile;
            DeleteFile = deleteFile;
            ChangePermissionOnRead = changePermissionOnRead;
            ChangePermissionOnWrite = changePermissionOnWrite;
            DeletePermissionOnRead = deletePermissionOnRead;
            DeletePermissionOnWrite = deletePermissionOnWrite;
        }

        public void BanUser(User user)
        {
            if (user.Banned == false)
            {
                user.Banned = true;
            }
        }

        public void UnBanUser(User user)
        {
            if (user.Banned == true)
            {
                user.Banned = false;
            }
        }
    }

    [Serializable]
    [DataContract]
    public class SystemAdmin : Admin
    {
        public SystemAdmin(String Username, String Userpassword, String Rank) :
            base(Username, Userpassword, Rank, true, true, true, true, true, true, true, true)
        {

        }
    }

    [Serializable]
    [DataContract]
    public class Moderator : Admin
    {
        public Moderator(String Username, String Userpassword, String Rank) :
            base(Username, Userpassword, Rank, false, false, true, true, true, true, true, true)
        {

        }
    }

    [Serializable]
    [DataContract]
    public class HelperAdmin : Admin
    {
        public HelperAdmin(String Username, String Userpassword, String Rank) :
            base(Username, Userpassword, Rank, false, false, false, false, false, false, false, false)
        {

        }
    }

    public class UsersLists
    {
        public static List<User> users = new List<User>();
        public static List<SystemAdmin> systemAdmins = new List<SystemAdmin>();
        public static List<Moderator> moderators = new List<Moderator>();
        public static List<HelperAdmin> helperAdmins = new List<HelperAdmin>();
        public static List<Filez> files = new List<Filez>();
    }
}