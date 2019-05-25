using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermissionToFileLibraryClasses.LevelOfPermission
{
    public class WriteOnly : PermissionLevel
    {
        public WriteOnly()
        {
            ReadOnly = false;
            WriteOnly = true;
        }
    }
}
