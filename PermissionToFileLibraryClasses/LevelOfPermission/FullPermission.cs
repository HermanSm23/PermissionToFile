using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermissionToFileLibraryClasses.LevelOfPermission
{
    public class FullPermission : PermissionLevel
    {
        public FullPermission()
        {
            ReadOnly = true;
            WriteOnly = true;
        }
    }
}
