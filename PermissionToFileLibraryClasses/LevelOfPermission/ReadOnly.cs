using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermissionToFileLibraryClasses.LevelOfPermission
{
    public class ReadOnly : PermissionLevel
    {
        public ReadOnly()
        {
            ReadOnly = true;
            WriteOnly = false;
        }
    }
}
