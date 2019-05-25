
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PermissionToFileLibraryClasses
{
    public class FillComboBoxUsers
    {
        public FillComboBoxUsers(ComboBox listBox, List<User> users, List<Moderator> moderators, List<SystemAdmin> systemAdmins, List<HelperAdmin> helperAdmins)
        {
            users.Sort();
            foreach (User user in users)
            {
                listBox.Items.Add(user.Username);
            }
            foreach (Moderator moderator in moderators)
            {
                listBox.Items.Add(moderator.Username);
            }
            foreach (SystemAdmin systemAdmin in systemAdmins)
            {
                listBox.Items.Add(systemAdmin.Username);
            }
            foreach (HelperAdmin helperAdmin in helperAdmins)
            {
                listBox.Items.Add(helperAdmin.Username);
            }
        }
    }
}
