
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PermissionToFileLibraryClasses.FillComboBox
{
    public class FillComboBoxOnlyUser
    {
        public FillComboBoxOnlyUser(ComboBox listBox, List<User> users)
        {
            foreach (User user in users)
            {
                listBox.Items.Add(user.Username);
            }
        }
    }
}
