using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography;
using PermissionToFileLibraryClasses;
using System.IO;
using PermissionToFileLibraryClasses.Serialization;

namespace PermissionToFile2._0
{
    public partial class LoginMenu : Form
    {
        public LoginMenu()
        {
            InitializeComponent();
        }

        private void DeserializeData(ISerialize serialization, String userPath, String systemAdminPath, String moderatorPath, String helperAdminPath, String filePath)
        {
            UsersLists.users = serialization.RestoreData<User>(userPath);
            UsersLists.systemAdmins = serialization.RestoreData<SystemAdmin>(systemAdminPath);
            UsersLists.moderators = serialization.RestoreData<Moderator>(moderatorPath);
            UsersLists.helperAdmins = serialization.RestoreData<HelperAdmin>(helperAdminPath);
            UsersLists.files = serialization.RestoreData<Filez>(filePath);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = usernameBox.Text;
            string pass = passwordBox.Text;

            void OpenMainWindow()
            {
                MainMenu.username = user;
                Hide();
                MainMenu mainMenu = new MainMenu();
                mainMenu.Show();
            }

            void ClearTextBox()
            {
                usernameBox.Clear();
                passwordBox.Clear();
                loginPasswordError.Visible = true;
            }

            // Десеріалізація JSON
            
            String userPath = Environment.CurrentDirectory.ToString() + "\\SerializationTEST\\JSON\\Users.json";
            String systemAdminPath = Environment.CurrentDirectory.ToString() + "\\SerializationTEST\\JSON\\SystemAdmins.json";
            String moderatorPath = Environment.CurrentDirectory.ToString() + "\\SerializationTEST\\JSON\\Moderators.json";
            String helperAdminPath = Environment.CurrentDirectory.ToString() + "\\SerializationTEST\\JSON\\HelperAdmins.json";
            String filePath = Environment.CurrentDirectory.ToString() + "\\SerializationTEST\\JSON\\Files.json";

            JSONSerialization serialization = new JSONSerialization();
            DeserializeData(serialization, userPath, systemAdminPath, moderatorPath, helperAdminPath, filePath);

            foreach (Person person in UsersLists.users)
            {
                if (person.IsLoggedIn(user, pass) == true)
                {
                    OpenMainWindow();
                }
                else
                {
                    ClearTextBox();
                }
            }

            foreach (Person person in UsersLists.systemAdmins)
            {
                if (person.IsLoggedIn(user, pass) == true)
                {
                    OpenMainWindow();
                    break;
                }
                else
                {
                    ClearTextBox();
                }
            }

            foreach (Person person in UsersLists.moderators)
            {
                if (person.IsLoggedIn(user, pass) == true)
                {
                    OpenMainWindow();
                    break;
                }
                else
                {
                    ClearTextBox();
                }
            }

            foreach(Person person in UsersLists.helperAdmins)
            {
                if (person.IsLoggedIn(user, pass) == true)
                {
                    OpenMainWindow();
                    break;
                }
                else
                {
                    ClearTextBox();
                }
            }
        }

        private void btnLogInXML_Click(object sender, EventArgs e)
        {
            string user = usernameBox.Text;
            string pass = passwordBox.Text;

            void OpenMainWindow()
            {
                MainMenu.username = user;
                Hide();
                MainMenu mainMenu = new MainMenu();
                mainMenu.Show();
            }

            void ClearTextBox()
            {
                usernameBox.Clear();
                passwordBox.Clear();
                loginPasswordError.Visible = true;
            }

            // Десеріалізація для XML
            
            String usersFilePath = Environment.CurrentDirectory.ToString() + "\\SerializationTEST\\XML\\Users.xml";
            String systemAdminsFilePath = Environment.CurrentDirectory.ToString() + "\\SerializationTEST\\XML\\SystemAdmins.xml";
            String moderatorsFilePath = Environment.CurrentDirectory.ToString() + "\\SerializationTEST\\XML\\Moderators.xml";
            String helperAdminPath = Environment.CurrentDirectory.ToString() + "\\SerializationTEST\\XML\\HelperAdmins.xml";
            String filePath = Environment.CurrentDirectory.ToString() + "\\SerializationTEST\\XML\\Files.xml";

            XMLSerialization serialization = new XMLSerialization();
            DeserializeData(serialization, usersFilePath, systemAdminsFilePath, moderatorsFilePath, helperAdminPath, filePath);


            foreach (Person person in UsersLists.users)
            {
                if (person.IsLoggedIn(user, pass) == true)
                {
                    OpenMainWindow();
                }
                else
                {
                    ClearTextBox();
                }
            }

            foreach (Person person in UsersLists.systemAdmins)
            {
                if (person.IsLoggedIn(user, pass) == true)
                {
                    OpenMainWindow();
                    break;
                }
                else
                {
                    ClearTextBox();
                }
            }

            foreach (Person person in UsersLists.moderators)
            {
                if (person.IsLoggedIn(user, pass) == true)
                {
                    OpenMainWindow();
                    break;
                }
                else
                {
                    ClearTextBox();
                }
            }

            foreach (Person person in UsersLists.helperAdmins)
            {
                if (person.IsLoggedIn(user, pass) == true)
                {
                    OpenMainWindow();
                    break;
                }
                else
                {
                    ClearTextBox();
                }
            }
        }

        private void btnLogInBinary_Click(object sender, EventArgs e)
        {
            string user = usernameBox.Text;
            string pass = passwordBox.Text;

            void OpenMainWindow()
            {
                MainMenu.username = user;
                Hide();
                MainMenu mainMenu = new MainMenu();
                mainMenu.Show();
            }

            void ClearTextBox()
            {
                usernameBox.Clear();
                passwordBox.Clear();
                loginPasswordError.Visible = true;
            }

            // Десеріалізація для Binary

            String usersFilePath = Environment.CurrentDirectory.ToString() + "\\SerializationTEST\\BINARY\\Users.dat";
            String systemAdminsFilePath = Environment.CurrentDirectory.ToString() + "\\SerializationTEST\\BINARY\\SystemAdmins.dat";
            String moderatorsFilePath = Environment.CurrentDirectory.ToString() + "\\SerializationTEST\\BINARY\\Moderators.dat";
            String helperAdminPath = Environment.CurrentDirectory.ToString() + "\\SerializationTEST\\BINARY\\HelperAdmins.dat";
            String filePath = Environment.CurrentDirectory.ToString() + "\\SerializationTEST\\BINARY\\Files.dat";

            BinarySerialization serialization = new BinarySerialization();
            DeserializeData(serialization, usersFilePath, systemAdminsFilePath, moderatorsFilePath, helperAdminPath, filePath);


            foreach (Person person in UsersLists.users)
            {
                if (person.IsLoggedIn(user, pass) == true)
                {
                    OpenMainWindow();
                }
                else
                {
                    ClearTextBox();
                }
            }

            foreach (Person person in UsersLists.systemAdmins)
            {
                if (person.IsLoggedIn(user, pass) == true)
                {
                    OpenMainWindow();
                    break;
                }
                else
                {
                    ClearTextBox();
                }
            }

            foreach (Person person in UsersLists.moderators)
            {
                if (person.IsLoggedIn(user, pass) == true)
                {
                    OpenMainWindow();
                    break;
                }
                else
                {
                    ClearTextBox();
                }
            }

            foreach (Person person in UsersLists.helperAdmins)
            {
                if (person.IsLoggedIn(user, pass) == true)
                {
                    OpenMainWindow();
                    break;
                }
                else
                {
                    ClearTextBox();
                }
            }
        }
    }
}
