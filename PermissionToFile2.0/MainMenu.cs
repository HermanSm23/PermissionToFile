using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PermissionToFileLibraryClasses;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Runtime.Serialization;
using PermissionToFileLibraryClasses.LevelOfPermission;
using PermissionToFileLibraryClasses.FillComboBox;
using PermissionToFileLibraryClasses.Serialization;
using System.Text.RegularExpressions;

namespace PermissionToFile2._0
{
    public partial class MainMenu : Form
    {
        public static string username;
        public static string result;
        public bool admin;

        public MainMenu()
        {
            InitializeComponent();
            usernameLb.Text = username;
        }

        private void addUserBtn_Click(object sender, EventArgs e)
        {
            admin = false;

            foreach(SystemAdmin systemAdmin in UsersLists.systemAdmins)
            {
                    if (systemAdmin.Username == username && systemAdmin.CreateUser == true)
                    {
                        admin = true;
                        addUserPanel.Visible = true;
                        addFilePanel.Visible = false;
                        givePermissionPanel.Visible = false;
                        banUserPanel.Visible = false;
                        unbanUserPanel.Visible = false;
                        changePermissionPanel.Visible = false;
                        removePermissionPanel.Visible = false;
                        writeInfoToFilePanel.Visible = false;
                        panelCheckOnWrite.Visible = false;
                    }
                    else if (admin == false)
                    {
                        MessageBox.Show("Створювати користувача може тільки систмений адміністратор");
                        break;
                    }
            }
        }
        
        private void addNewUserBtn_Click(object sender, EventArgs e)
        {
            string regexForUsername = "^[a-zA-Z]";
            string regexForPassword = "^[0-9]";
            if (newUserTb.Text != "" && typeOfNewUserCmb.Text != "" && passwordTb.Text != "" && Regex.IsMatch(newUserTb.Text, regexForUsername) && Regex.IsMatch(passwordTb.Text, regexForPassword))
            {
                bool contains = false;

                foreach (User user in UsersLists.users)
                {
                    if (user.Username == newUserTb.Text)
                    {
                        contains = true;
                        break;
                    }
                }
                foreach (Moderator moderator in UsersLists.moderators)
                {
                    if (moderator.Username == newUserTb.Text)
                    {
                        contains = true;
                        break;
                    }
                }

                foreach (SystemAdmin systemAdmin in UsersLists.systemAdmins)
                {
                    if (systemAdmin.Username == newUserTb.Text)
                    {
                        contains = true;
                        break;
                    }
                }

                foreach (HelperAdmin helperAdmin in UsersLists.helperAdmins)
                {
                    if (helperAdmin.Username == newUserTb.Text)
                    {
                        contains = true;
                        break;
                    }
                }

                if (!contains)
                {
                    switch (typeOfNewUserCmb.Text)
                    {
                        case "Звичайний користувач":
                            UsersLists.users.Add(new User(newUserTb.Text, passwordTb.Text, "user", false));
                            ClearTextboxInAddUser();
                            break;
                        case "Системний адміністратор":
                            UsersLists.systemAdmins.Add(new SystemAdmin(newUserTb.Text, passwordTb.Text, "systemAdmin"));
                            ClearTextboxInAddUser();
                            break;
                        case "Модератор":
                            UsersLists.moderators.Add(new Moderator(newUserTb.Text, passwordTb.Text, "moder"));
                            ClearTextboxInAddUser();
                            break;
                        case "Помічник адміністратора":
                            UsersLists.helperAdmins.Add(new HelperAdmin(newUserTb.Text, passwordTb.Text, "helper"));
                            ClearTextboxInAddUser();
                            break;
                    }
                }
                else MessageBox.Show("Користувач вже існує");
            }
            else
            {
                MessageBox.Show("Не залишайте поля пустими, ім'я користувача потрібно заповнювати англійскими буквами, а його пароль числами");
            }
        }

        private void addFileBtn_Click(object sender, EventArgs e)
        {
            admin = false;

            foreach (SystemAdmin systemAdmin in UsersLists.systemAdmins)
            {
                    if (systemAdmin.Username == username && systemAdmin.CreateFile == true)
                    {
                        admin = true;
                        addUserPanel.Visible = false;
                        givePermissionPanel.Visible = false;
                        banUserPanel.Visible = false;
                        unbanUserPanel.Visible = false;
                        changePermissionPanel.Visible = false;
                        removePermissionPanel.Visible = false;
                        writeInfoToFilePanel.Visible = false;
                        panelCheckOnWrite.Visible = false;
                        addFilePanel.Visible = true;
                    }
                    else if(admin == false)
                    {
                        MessageBox.Show("Створювати файл може тільки систмений адміністратор");
                        break;
                    }
            }
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            if (filenameTb.Text != "")
            {
                bool contains = false;
                foreach (Filez file in UsersLists.files)
                {
                    if (file.Filename == filenameTb.Text)
                    {
                        contains = true;
                        break;
                    }
                }
                if (!contains)
                {
                    Filez newFile = new Filez(filenameTb.Text);
                    UsersLists.files.Add(newFile);
                }
                else
                {
                    MessageBox.Show("Файл вже існує");
                }
            }
            else
            {
                MessageBox.Show("Введіть назву файлу");
            }
            filenameTb.Text = "";
        }

        private void givePermissionBtn_Click(object sender, EventArgs e)
        {
            admin = false;
            foreach (SystemAdmin systemAdmin in UsersLists.systemAdmins)
            {
                foreach (Moderator moderator in UsersLists.moderators)
                {
                    if (systemAdmin.Username == username || moderator.Username == username)
                    { 
                        admin = true;
                        addUserPanel.Visible = false;
                        addFilePanel.Visible = false;
                        banUserPanel.Visible = false;
                        unbanUserPanel.Visible = false;
                        changePermissionPanel.Visible = false;
                        removePermissionPanel.Visible = false;
                        writeInfoToFilePanel.Visible = false;
                        panelCheckOnWrite.Visible = false;
                        givePermissionPanel.Visible = true;
                        cmbUsers.Items.Clear();
                        cmbFiles.Items.Clear();
                        FillComboBoxUsers fillListBoxUser = new FillComboBoxUsers(cmbUsers, UsersLists.users, UsersLists.moderators, UsersLists.systemAdmins, UsersLists.helperAdmins);
                        FillComboBoxFiles fillListBoxFiles = new FillComboBoxFiles(cmbFiles, UsersLists.files);
                    }
                    else if (admin == false)
                    {
                        MessageBox.Show("Видавати права може тільки систмений адміністратор або модератор");
                        break;
                    }
                }
            }
        }

        private void givePermisionBtn_Click(object sender, EventArgs e)
        {
            if (cmbUsers.Text != "" && cmbFiles.Text != "" && cmbTypeOfPermission.Text != "")
            {
                foreach (Filez file in UsersLists.files.Where(i => i.Filename == cmbFiles.Text))
                {
                    foreach (User user in UsersLists.users.Where(y => y.Username == cmbUsers.Text))
                    {
                        if(user.Banned == false)
                        {
                            switch (cmbTypeOfPermission.Text)
                            {
                                case "На все":
                                    if (file.permissionList.Keys.Contains(user.Username))
                                    {
                                        MessageUserHasPermission();
                                    }
                                    else
                                    {
                                        file.permissionList.Add(user.Username, new Permission(user, new FullPermission()));
                                    }
                                    break;
                                case "Перегляд":
                                    if (file.permissionList.Keys.Contains(user.Username))
                                    {
                                        MessageUserHasPermission();
                                    }
                                    else
                                    {
                                        file.permissionList.Add(user.Username, new Permission(user, new ReadOnly()));
                                    }
                                    break;

                                case "Запис":
                                    if (file.permissionList.Keys.Contains(user.Username))
                                    {
                                        MessageUserHasPermission();
                                    }
                                    else
                                    {
                                        file.permissionList.Add(user.Username, new Permission(user, new WriteOnly()));
                                    }
                                    break;

                                case "Без прав":
                                    if (file.permissionList.Keys.Contains(user.Username))
                                    {
                                        MessageUserHasPermission();
                                    }
                                    else
                                    {
                                        file.permissionList.Add(user.Username, new Permission(user, new WithoutPermission()));
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Користувач заблокований!");
                        }
                    }
                    foreach(SystemAdmin systemAdmin in UsersLists.systemAdmins.Where(y => y.Username == cmbUsers.Text))
                    {
                        switch(cmbTypeOfPermission.Text)
                        {
                            case "На все":
                                if(file.permissionList.Keys.Contains(systemAdmin.Username))
                                {
                                    MessageUserHasPermission();
                                }
                                else
                                {
                                    file.permissionList.Add(systemAdmin.Username, new Permission(systemAdmin, new FullPermission()));
                                }
                                break;
                            case "Перегляд":
                                if(file.permissionList.Keys.Contains(systemAdmin.Username))
                                {
                                    MessageUserHasPermission();
                                }
                                else
                                {
                                    file.permissionList.Add(systemAdmin.Username, new Permission(systemAdmin, new ReadOnly()));
                                }
                                break;
                            case "Запис":
                                if (file.permissionList.Keys.Contains(systemAdmin.Username))
                                {
                                    MessageUserHasPermission();
                                }
                                else
                                {
                                    file.permissionList.Add(systemAdmin.Username, new Permission(systemAdmin, new WriteOnly()));
                                }
                                break;
                            case "Без прав":
                                if (file.permissionList.Keys.Contains(systemAdmin.Username))
                                {
                                    MessageUserHasPermission();
                                }
                                else
                                {
                                    file.permissionList.Add(systemAdmin.Username, new Permission(systemAdmin, new WithoutPermission()));
                                }
                                break;
                        }
                    }
                    foreach(Moderator moderator in UsersLists.moderators.Where(y => y.Username == cmbUsers.Text))
                    {
                        switch (cmbTypeOfPermission.Text)
                        {
                            case "На все":
                                if (file.permissionList.Keys.Contains(moderator.Username))
                                {
                                    MessageUserHasPermission();
                                }
                                else
                                {
                                    file.permissionList.Add(moderator.Username, new Permission(moderator, new FullPermission()));
                                }
                                break;
                            case "Перегляд":
                                if (file.permissionList.Keys.Contains(moderator.Username))
                                {
                                    MessageUserHasPermission();
                                }
                                else
                                {
                                    file.permissionList.Add(moderator.Username, new Permission(moderator, new ReadOnly()));
                                }
                                break;
                            case "Запис":
                                if (file.permissionList.Keys.Contains(moderator.Username))
                                {
                                    MessageUserHasPermission();
                                }
                                else
                                {
                                    file.permissionList.Add(moderator.Username, new Permission(moderator, new WriteOnly()));
                                }
                                break;
                            case "Без прав":
                                if (file.permissionList.Keys.Contains(moderator.Username))
                                {
                                    MessageUserHasPermission();
                                }
                                else
                                {
                                    file.permissionList.Add(moderator.Username, new Permission(moderator, new WithoutPermission()));
                                }
                                break;
                        }
                    }
                    foreach(HelperAdmin helperAdmin in UsersLists.helperAdmins.Where(y => y.Username == cmbUsers.Text))
                    {
                        switch (cmbTypeOfPermission.Text)
                        {
                            case "На все":
                                if (file.permissionList.Keys.Contains(helperAdmin.Username))
                                {
                                    MessageUserHasPermission();
                                }
                                else
                                {
                                    file.permissionList.Add(helperAdmin.Username, new Permission(helperAdmin, new FullPermission()));
                                }
                                break;
                            case "Перегляд":
                                if (file.permissionList.Keys.Contains(helperAdmin.Username))
                                {
                                    MessageUserHasPermission();
                                }
                                else
                                {
                                    file.permissionList.Add(helperAdmin.Username, new Permission(helperAdmin, new ReadOnly()));
                                }
                                break;
                            case "Запис":
                                if (file.permissionList.Keys.Contains(helperAdmin.Username))
                                {
                                    MessageUserHasPermission();
                                }
                                else
                                {
                                    file.permissionList.Add(helperAdmin.Username, new Permission(helperAdmin, new WriteOnly()));
                                }
                                break;
                            case "Без прав":
                                if (file.permissionList.Keys.Contains(helperAdmin.Username))
                                {
                                    MessageUserHasPermission();
                                }
                                else
                                {
                                    file.permissionList.Add(helperAdmin.Username, new Permission(helperAdmin, new WithoutPermission()));
                                }
                                break;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Не залишайте поля пустими");
            }
        }

        public void MessageUserHasPermission()
        {
            MessageBox.Show("Користувач вже має права");
        }

        public void ClearTextboxInAddUser()
        {
            newUserTb.Clear();
            passwordTb.Clear();
        }

        private void changePermissionBtn_Click(object sender, EventArgs e)
        {
            admin = false;
            foreach (SystemAdmin systemAdmin in UsersLists.systemAdmins)
            {
                foreach (Moderator moderator in UsersLists.moderators)
                {
                    foreach(HelperAdmin helperAdmin in UsersLists.helperAdmins)
                    {
                        if (systemAdmin.Username == username || moderator.Username == username || helperAdmin.Username == username)
                        {
                            admin = true;
                            addUserPanel.Visible = false;
                            addFilePanel.Visible = false;
                            banUserPanel.Visible = false;
                            unbanUserPanel.Visible = false;
                            givePermissionPanel.Visible = false;
                            removePermissionPanel.Visible = false;
                            writeInfoToFilePanel.Visible = false;
                            panelCheckOnWrite.Visible = false;
                            changePermissionPanel.Visible = true;
                            cmbUseers.Items.Clear();
                            cmbFilez.Items.Clear();
                            FillComboBoxUsers fillListBoxUseer = new FillComboBoxUsers(cmbUseers, UsersLists.users, UsersLists.moderators, UsersLists.systemAdmins, UsersLists.helperAdmins);
                            FillComboBoxFiles fillListBoxFilez = new FillComboBoxFiles(cmbFilez, UsersLists.files);
                        }
                        else if (admin == false)
                        {
                            MessageBox.Show("Змінювати права може тільки адмін");
                            break;
                        }
                    }
                }
            }
        }

        private void btnChangePermission_Click(object sender, EventArgs e)
        {
            if (cmbUseers.Text != "" && cmbFilez.Text != "" && cmbLevelofPermission.Text != "")
            {
                foreach (Filez file in UsersLists.files.Where(i => i.Filename == cmbFilez.Text))
                {
                    foreach (User user in UsersLists.users.Where(y => y.Username == cmbUseers.Text))
                    {
                        if(user.Banned == false)
                        {
                            switch (cmbLevelofPermission.Text)
                            {
                                case "На все":
                                    foreach(HelperAdmin helperAdmin in UsersLists.helperAdmins)
                                    {
                                        if(helperAdmin.Username == username)
                                        {
                                            MessageBox.Show("Помічник адмніністратора не може змінювати права на повний доступ");
                                            break;
                                        }
                                    }
                                    if (file.permissionList.Keys.Contains(user.Username))
                                    {
                                        file.permissionList[user.Username] = new Permission(user, new FullPermission());
                                    }
                                    else
                                    {
                                        MessageUserHasNotPermission();
                                    }
                                    break;
                                case "Перегляд":
                                    if (file.permissionList.Keys.Contains(user.Username))
                                    {
                                        file.permissionList[user.Username] = new Permission(user, new ReadOnly());
                                    }
                                    else
                                    {
                                        MessageUserHasNotPermission();
                                    }
                                    break;

                                case "Запис":
                                    if (file.permissionList.Keys.Contains(user.Username))
                                    {
                                        file.permissionList[user.Username] = new Permission(user, new WriteOnly());
                                    }
                                    else
                                    {
                                        MessageUserHasNotPermission();
                                    }
                                    break;
                            }
                        } 
                        else
                        {
                            MessageBox.Show("Користувач заблокований");
                        }
                    }
                    foreach (SystemAdmin systemAdmin in UsersLists.systemAdmins.Where(y => y.Username == cmbUseers.Text))
                    {
                        switch (cmbTypeOfPermission.Text)
                        {
                            case "На все":
                                foreach (HelperAdmin helperAdmin in UsersLists.helperAdmins)
                                {
                                    if (helperAdmin.Username == username)
                                    {
                                        MessageBox.Show("Помічник адмніністратора не може змінювати права на повний доступ");
                                        break;
                                    }
                                }
                                if (file.permissionList.Keys.Contains(systemAdmin.Username))
                                {
                                    file.permissionList[systemAdmin.Username] = new Permission(systemAdmin, new FullPermission());
                                }
                                else
                                {
                                    MessageUserHasNotPermission();
                                }
                                break;
                            case "Перегляд":
                                if (file.permissionList.Keys.Contains(systemAdmin.Username))
                                {
                                    file.permissionList[systemAdmin.Username] = new Permission(systemAdmin, new ReadOnly());
                                }
                                else
                                {
                                    MessageUserHasNotPermission();
                                }
                                break;
                            case "Запис":
                                if (file.permissionList.Keys.Contains(systemAdmin.Username))
                                {
                                    file.permissionList[systemAdmin.Username] = new Permission(systemAdmin, new WriteOnly());
                                }
                                else
                                {
                                    MessageUserHasNotPermission();
                                }
                                break;
                        }
                    }
                    foreach (Moderator moderator in UsersLists.moderators.Where(y => y.Username == cmbUseers.Text))
                    {
                        switch (cmbTypeOfPermission.Text)
                        {
                            case "На все":
                                foreach (HelperAdmin helperAdmin in UsersLists.helperAdmins)
                                {
                                    if (helperAdmin.Username == username)
                                    {
                                        MessageBox.Show("Помічник адмніністратора не може змінювати права на повний доступ");
                                        break;
                                    }
                                }
                                if (file.permissionList.Keys.Contains(moderator.Username))
                                {
                                    file.permissionList[moderator.Username] = new Permission(moderator, new FullPermission());
                                }
                                else
                                {
                                    MessageUserHasNotPermission();
                                }
                                break;
                            case "Перегляд":
                                if (file.permissionList.Keys.Contains(moderator.Username))
                                {
                                    file.permissionList[moderator.Username] = new Permission(moderator, new ReadOnly());
                                }
                                else
                                {
                                    MessageUserHasNotPermission();
                                }
                                break;
                            case "Запис":
                                if (file.permissionList.Keys.Contains(moderator.Username))
                                {
                                    file.permissionList[moderator.Username] = new Permission(moderator, new WriteOnly());
                                }
                                else
                                {
                                    MessageUserHasNotPermission();
                                }
                                break;
                        }
                    }
                    foreach (HelperAdmin helperAdmin in UsersLists.helperAdmins.Where(y => y.Username == cmbUseers.Text))
                    {
                        switch (cmbTypeOfPermission.Text)
                        {
                            case "На все":
                                if (helperAdmin.Username == username)
                                {
                                    MessageBox.Show("Помічник адмніністратора не може змінювати права на повний доступ");
                                    break;
                                }
                                else if (file.permissionList.Keys.Contains(helperAdmin.Username))
                                {
                                    file.permissionList[helperAdmin.Username] = new Permission(helperAdmin, new FullPermission());
                                }
                                else
                                {
                                    MessageUserHasNotPermission();
                                }
                                break;
                            case "Перегляд":
                                if (file.permissionList.Keys.Contains(helperAdmin.Username))
                                {
                                    file.permissionList[helperAdmin.Username] = new Permission(helperAdmin, new ReadOnly());
                                }
                                else
                                {
                                    MessageUserHasNotPermission();
                                }
                                break;
                            case "Запис":
                                if (file.permissionList.Keys.Contains(helperAdmin.Username))
                                {
                                    file.permissionList[helperAdmin.Username] = new Permission(helperAdmin, new WriteOnly());
                                }
                                else
                                {
                                    MessageUserHasNotPermission();
                                }
                                break;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Не залишайте поля пустими");
            }
        }

        public void MessageUserHasNotPermission()
        {
            MessageBox.Show("Користувач не має права, потрібно видати права");
        }

        private void takePermissionBtn_Click(object sender, EventArgs e)
        {
            admin = false;
            foreach (SystemAdmin systemAdmin in UsersLists.systemAdmins)
            {
                foreach (Moderator moderator in UsersLists.moderators)
                {
                    if (systemAdmin.Username == username || moderator.Username == username)
                    {
                        admin = true;
                        addUserPanel.Visible = false;
                        addFilePanel.Visible = false;
                        banUserPanel.Visible = false;
                        unbanUserPanel.Visible = false;
                        givePermissionPanel.Visible = false;
                        changePermissionPanel.Visible = false;
                        writeInfoToFilePanel.Visible = false;
                        panelCheckOnWrite.Visible = false;
                        removePermissionPanel.Visible = true;
                        cbUseers.Items.Clear();
                        cbFilees.Items.Clear();
                        FillComboBoxUsers fillListBoxUseers = new FillComboBoxUsers(cbUseers, UsersLists.users, UsersLists.moderators, UsersLists.systemAdmins, UsersLists.helperAdmins);
                        FillComboBoxFiles fillListBoxFileez = new FillComboBoxFiles(cbFilees, UsersLists.files);
                    }
                    else if (admin == false)
                    {
                        MessageBox.Show("Забирати права може тільки  систмений адміністратор або модератор");
                        break;
                    }
                }
            }
        }

        private void removePermissoBtn_Click(object sender, EventArgs e)
        {
            if(cbUseers.Text != "" && cbFilees.Text != "")
            {
                foreach(Filez filez in UsersLists.files.Where(x => x.Filename == cbFilees.Text))
                {
                    foreach (User user in UsersLists.users.Where(x => x.Username == cbUseers.Text))
                    {
                        if (filez.permissionList.Keys.Contains(user.Username))
                        {
                            filez.permissionList[user.Username] = new Permission(user, new WithoutPermission());
                        }
                        else
                        {
                            MessageUserHasNotPermission();
                        }
                    }
                    foreach (SystemAdmin systemAdmin in UsersLists.systemAdmins.Where(x => x.Username == cmbOfUsers.Text))
                    {
                        if (filez.permissionList.Keys.Contains(systemAdmin.Username))
                        {
                            filez.permissionList[systemAdmin.Username] = new Permission(systemAdmin, new WithoutPermission());
                        }
                        else
                        {
                            MessageUserHasNotPermission();
                        }
                    }
                    foreach (Moderator moderator in UsersLists.moderators.Where(x => x.Username == cmbOfUsers.Text))
                    {
                        if (filez.permissionList.Keys.Contains(moderator.Username))
                        {
                            filez.permissionList[moderator.Username] = new Permission(moderator, new WithoutPermission());
                        }
                        else
                        {
                            MessageUserHasNotPermission();
                        }
                    }
                    foreach (HelperAdmin helperAdmin in UsersLists.helperAdmins.Where(x => x.Username == cmbOfUsers.Text))
                    {
                        if (filez.permissionList.Keys.Contains(helperAdmin.Username))
                        {
                            filez.permissionList[helperAdmin.Username] = new Permission(helperAdmin, new WithoutPermission());
                        }
                        else
                        {
                            MessageUserHasNotPermission();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Заповніть всі поля");
            }
        }

        private void btnCheckOnWrite_Click(object sender, EventArgs e)
        {
            admin = false;
            foreach (SystemAdmin systemAdmin in UsersLists.systemAdmins)
            {
                foreach (Moderator moderator in UsersLists.moderators)
                {
                    if (systemAdmin.Username == username || moderator.Username == username)
                    {
                        admin = true;
                        addUserPanel.Visible = false;
                        addFilePanel.Visible = false;
                        givePermissionPanel.Visible = false;
                        banUserPanel.Visible = false;
                        changePermissionPanel.Visible = false;
                        removePermissionPanel.Visible = false;
                        writeInfoToFilePanel.Visible = false;
                        unbanUserPanel.Visible = false;
                        panelCheckOnWrite.Visible = true;
                        comboBoxUsers.Items.Clear();
                        comboBoxFiles.Items.Clear();
                        FillComboBoxOnlyUser fillListBoxUserxex = new FillComboBoxOnlyUser(comboBoxUsers, UsersLists.users);
                        FillComboBoxFiles fillComboBoxFiless = new FillComboBoxFiles(comboBoxFiles, UsersLists.files);
                    }
                    else if (admin == false)
                    {
                        MessageBox.Show("Перевірити чи має змогу користувач змінювати файл, може тільки  систмений адміністратор або модератор");
                        break;
                    }
                }
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (comboBoxFiles.Text != "" && comboBoxUsers.Text != "")
            {
                foreach (Filez filez in UsersLists.files.Where(x => x.Filename == comboBoxFiles.Text))
                {
                    foreach (User user in UsersLists.users.Where(x => x.Username == comboBoxUsers.Text))
                    {
                        foreach (Permission permission in filez.permissionList.Values)
                        {
                            if (permission.Person.Username != user.Username)
                            {
                                continue;
                            }

                            if (permission) MessageBox.Show("Має право змінювати файл");
                            else MessageBox.Show("Не має право змінювати файл");
                            break;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Заповніть поля");
            }
        }

        private void writeToFileInfoBtn_Click(object sender, EventArgs e)
        {
            admin = false;
            foreach (SystemAdmin systemAdmin in UsersLists.systemAdmins)
            {
                foreach (Moderator moderator in UsersLists.moderators)
                {
                    if (systemAdmin.Username == username || moderator.Username == username)
                    {
                        admin = true;
                        addUserPanel.Visible = false;
                        addFilePanel.Visible = false;
                        banUserPanel.Visible = false;
                        unbanUserPanel.Visible = false;
                        givePermissionPanel.Visible = false;
                        changePermissionPanel.Visible = false;
                        removePermissionPanel.Visible = false;
                        panelCheckOnWrite.Visible = false;
                        writeInfoToFilePanel.Visible = true;
                        cmbOfUsers.Items.Clear();
                        cmbOfFiles.Items.Clear();
                        FillComboBoxUsers fillListBoxUseerz = new FillComboBoxUsers(cmbOfUsers, UsersLists.users, UsersLists.moderators, UsersLists.systemAdmins, UsersLists.helperAdmins);
                        FillComboBoxFiles fillListBoxFileezz = new FillComboBoxFiles(cmbOfFiles, UsersLists.files);
                    }
                    else if (admin == false)
                    {
                        MessageBox.Show("Записувати інформацію, може тільки  систмений адміністратор або модератор");
                        break;
                    }
                }
            }
        }

        private void writeInfobtn_Click(object sender, EventArgs e)
        {
            if(cmbOfUsers.Text != "" && cmbOfFiles.Text != "")
            {
                foreach(Filez filez in UsersLists.files.Where(x => x.Filename == cmbOfFiles.Text))
                {
                    foreach(User user in UsersLists.users.Where(x => x.Username == cmbOfUsers.Text))
                    {
                        foreach (Permission permission in filez.permissionList.Values)
                        {
                            if (filez.permissionList.Keys.Contains(user.Username))
                            {
                                string filename = "InformationAboutFile.txt";
                                StreamWriter sw = new StreamWriter(filename, true, Encoding.Default);
                                string text = "Назва файлу - " + filez.Filename + "\t Користувач - " + user.Username + "\r\n" +
                                "Перегляд(" + permission.ReadOnly + ")\t Запис(" + permission.WriteOnly + ")\r\n " + result + "\t" + "\r\n";
                                sw.WriteLine(text);
                                sw.Close();
                                MessageBox.Show("Успішно записано");
                                break;
                            }
                            else
                            {
                                MessageUserHasNotPermission();
                                break;
                            }
                        }
                    }
                    foreach(SystemAdmin systemAdmin in UsersLists.systemAdmins.Where(x => x.Username == cmbOfUsers.Text))
                    {
                        foreach (Permission permission in filez.permissionList.Values)
                        {
                            if (filez.permissionList.Keys.Contains(systemAdmin.Username))
                            {
                                string filename = "InformationAboutFile.txt";
                                StreamWriter sw = new StreamWriter(filename, true, Encoding.Default);
                                string text = "Назва файлу - " + filez.Filename + "\t Користувач - " + systemAdmin.Username + "\r\n" +
                                "Перегляд(" + permission.ReadOnly + ")\t Запис(" + permission.WriteOnly + ")\r\n " + result + "\t" + "\r\n";
                                sw.WriteLine(text);
                                sw.Close();
                                MessageBox.Show("Успішно записано");
                                break;
                            }
                            else
                            {
                                MessageUserHasNotPermission();
                                break;
                            }
                        }
                    }
                    foreach (Moderator moderator in UsersLists.moderators.Where(x => x.Username == cmbOfUsers.Text))
                    {
                        foreach (Permission permission in filez.permissionList.Values)
                        {
                            if (filez.permissionList.Keys.Contains(moderator.Username))
                            {
                                string filename = "InformationAboutFile.txt";
                                StreamWriter sw = new StreamWriter(filename, true, Encoding.Default);
                                string text = "Назва файлу - " + filez.Filename + "\t Користувач - " + moderator.Username + "\r\n" +
                                "Перегляд(" + permission.ReadOnly + ")\t Запис(" + permission.WriteOnly + ")\r\n " + result + "\t" + "\r\n";
                                sw.WriteLine(text);
                                sw.Close();
                                MessageBox.Show("Успішно записано");
                                break;
                            }
                            else
                            {
                                MessageUserHasNotPermission();
                                break;
                            }
                        }
                    }
                    foreach (HelperAdmin helperAdmin in UsersLists.helperAdmins.Where(x => x.Username == cmbOfUsers.Text))
                    {
                        foreach (Permission permission in filez.permissionList.Values)
                        {
                            if (filez.permissionList.Keys.Contains(helperAdmin.Username))
                            {
                                string filename = "InformationAboutFile.txt";
                                StreamWriter sw = new StreamWriter(filename, true, Encoding.Default);
                                string text = "Назва файлу - " + filez.Filename + "\t Користувач - " + helperAdmin.Username + "\r\n" +
                                "Перегляд(" + permission.ReadOnly + ")\t Запис(" + permission.WriteOnly + ")\r\n " + result + "\t" + "\r\n";
                                sw.WriteLine(text);
                                sw.Close();
                                MessageBox.Show("Успішно записано");
                                break;
                            }
                            else
                            {
                                MessageUserHasNotPermission();
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Заповніть поля");
            }
        }

        private void banUserBtn_Click(object sender, EventArgs e)
        {
            admin = false;
            foreach (SystemAdmin systemAdmin in UsersLists.systemAdmins)
            {
                    if (systemAdmin.Username == username)
                    {
                        admin = true;
                        addUserPanel.Visible = false;
                        addFilePanel.Visible = false;
                        givePermissionPanel.Visible = false;
                        unbanUserPanel.Visible = false;
                        changePermissionPanel.Visible = false;
                        removePermissionPanel.Visible = false;
                        writeInfoToFilePanel.Visible = false;
                        panelCheckOnWrite.Visible = false;
                        banUserPanel.Visible = true;
                        usersComboBox.Items.Clear();
                        FillComboBoxOnlyUser fillListBoxUserx = new FillComboBoxOnlyUser(usersComboBox, UsersLists.users);
                    }
                    else if(admin == false)
                    {
                        MessageBox.Show("Блокувати користувача може тільки систмений адміністратор");
                        break;
                    }
                
            }
        }

        private void banBtn_Click(object sender, EventArgs e)
        {
            if (usersComboBox.Text != usernameLb.Text)
            {
                foreach (SystemAdmin systemAdmin in UsersLists.systemAdmins)
                {
                    foreach (User user in UsersLists.users.Where(x => x.Username == usersComboBox.Text))
                    {
                        systemAdmin.BanUser(user);
                        if(user.Banned == true)
                        {
                            MessageBox.Show("Користувач був успішно заблокований");
                        }
                        else
                        {
                            MessageBox.Show("Користувач вже заблокований або не блокували");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Не можливо забанити самого себе");
            }
        }

        private void unBanUserBtn_Click(object sender, EventArgs e)
        {
            admin = false;
            foreach (SystemAdmin systemAdmin in UsersLists.systemAdmins)
            {
                foreach (Moderator moderator in UsersLists.moderators)
                {
                    if (systemAdmin.Username == username || moderator.Username == username)
                    {
                        admin = true;
                        addUserPanel.Visible = false;
                        addFilePanel.Visible = false;
                        givePermissionPanel.Visible = false;
                        banUserPanel.Visible = false;
                        changePermissionPanel.Visible = false;
                        removePermissionPanel.Visible = false;
                        writeInfoToFilePanel.Visible = false;
                        panelCheckOnWrite.Visible = false;
                        unbanUserPanel.Visible = true;
                        bannedUsersCmb.Items.Clear();
                        FillComboBoxOnlyUser fillListBoxUserxe = new FillComboBoxOnlyUser(bannedUsersCmb, UsersLists.users);
                    }
                    else if (admin == false)
                    {
                        MessageBox.Show("Розблокувати користувача може тільки адмін");
                        break;
                    }
                }
            }
        }

        private void unbanUsersBtn_Click(object sender, EventArgs e)
        {
            if (bannedUsersCmb.Text != usernameLb.Text)
            {
                foreach (SystemAdmin systemAdmin in UsersLists.systemAdmins)
                {
                    foreach (User user in UsersLists.users.Where(x => x.Username == bannedUsersCmb.Text))
                    {
                        systemAdmin.UnBanUser(user);
                        if (user.Banned == false)
                        {
                            MessageBox.Show("Користувач був успішно розблокований");
                        }
                        else
                        {
                            MessageBox.Show("Користувач не є заблокованим");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Не можливо забанити самого себе");
            }
        }

        private void SerializeData(ISerialize serialization, String userPath, String systemAdminPath, String moderatorPath, String helperAdminPath, String filePath)
        {
            serialization.SaveData(UsersLists.users, userPath);
            serialization.SaveData(UsersLists.systemAdmins, systemAdminPath);
            serialization.SaveData(UsersLists.moderators, moderatorPath);
            serialization.SaveData(UsersLists.helperAdmins, helperAdminPath);
            serialization.SaveData(UsersLists.files, filePath);
        }

        private void backToLoginMenu_Click(object sender, EventArgs e)
        {    
            String userPath = Environment.CurrentDirectory.ToString() + "\\SerializationTest\\JSON\\Users.json";
            String systemAdminPath = Environment.CurrentDirectory.ToString() + "\\SerializationTest\\JSON\\SystemAdmins.json";
            String moderatorPath = Environment.CurrentDirectory.ToString() + "\\SerializationTest\\JSON\\Moderators.json";
            String helperAdminPath = Environment.CurrentDirectory.ToString() + "\\SerializationTest\\JSON\\HelperAdmins.json";
            String filePath = Environment.CurrentDirectory.ToString() + "\\SerializationTest\\JSON\\Files.json";

            JSONSerialization serialization = new JSONSerialization();
            SerializeData(serialization, userPath, systemAdminPath, moderatorPath, helperAdminPath, filePath);

            UsersLists.users.Clear();
            UsersLists.systemAdmins.Clear();
            UsersLists.moderators.Clear();
            UsersLists.helperAdmins.Clear();

            Form form = Application.OpenForms[0];
            form.Show();
            this.Hide();
        }

        private void btnSerializationInXML_Click(object sender, EventArgs e)
        {
            String userPath = Environment.CurrentDirectory.ToString() + "\\SerializationTest\\XML\\Users.xml";
            String systemAdminPath = Environment.CurrentDirectory.ToString() + "\\SerializationTest\\XML\\SystemAdmins.xml";
            String moderatorPath = Environment.CurrentDirectory.ToString() + "\\SerializationTest\\XML\\Moderators.xml";
            String helperAdminPath = Environment.CurrentDirectory.ToString() + "\\SerializationTest\\XML\\HelperAdmins.xml";
            String filePath = Environment.CurrentDirectory.ToString() + "\\SerializationTest\\XML\\Files.xml";

            XMLSerialization serialization = new XMLSerialization();
            SerializeData(serialization, userPath, systemAdminPath, moderatorPath, helperAdminPath, filePath);
        }

        private void btnSerializationInBinary_Click(object sender, EventArgs e)
        {
            String userPath = Environment.CurrentDirectory.ToString() + "\\SerializationTest\\BINARY\\Users.dat";
            String systemAdminPath = Environment.CurrentDirectory.ToString() + "\\SerializationTest\\BINARY\\SystemAdmins.dat";
            String moderatorPath = Environment.CurrentDirectory.ToString() + "\\SerializationTest\\BINARY\\Moderators.dat";
            String helperAdminPath = Environment.CurrentDirectory.ToString() + "\\SerializationTest\\BINARY\\HelperAdmins.dat";
            String filePath = Environment.CurrentDirectory.ToString() + "\\SerializationTest\\BINARY\\Files.dat";

            BinarySerialization serialization = new BinarySerialization();
            SerializeData(serialization, userPath, systemAdminPath, moderatorPath, helperAdminPath, filePath);
        }

        private void btnSerializationInJSON_Click(object sender, EventArgs e)
        {
            String userPath = Environment.CurrentDirectory.ToString() + "\\SerializationTest\\JSON\\Users.json";
            String systemAdminPath = Environment.CurrentDirectory.ToString() + "\\SerializationTest\\JSON\\SystemAdmins.json";
            String moderatorPath = Environment.CurrentDirectory.ToString() + "\\SerializationTest\\JSON\\Moderators.json";
            String helperAdminPath = Environment.CurrentDirectory.ToString() + "\\SerializationTest\\JSON\\HelperAdmins.json";
            String filePath = Environment.CurrentDirectory.ToString() + "\\SerializationTest\\JSON\\Files.json";

            JSONSerialization serialization = new JSONSerialization();
            SerializeData(serialization, userPath, systemAdminPath, moderatorPath, helperAdminPath, filePath);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}