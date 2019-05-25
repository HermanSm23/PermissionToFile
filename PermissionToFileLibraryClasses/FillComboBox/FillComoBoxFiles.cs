using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PermissionToFileLibraryClasses
{
    public class FillComboBoxFiles
    {
        public FillComboBoxFiles(ComboBox listBox, List<Filez> list)
        {
            foreach (Filez file in list)
            {
                listBox.Items.Add(file.Filename);
            }
        }
    }
}
