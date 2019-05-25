using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermissionToFileLibraryClasses.LevelOfPermission
{
    public class WithoutPermission : PermissionLevel
    {
        public WithoutPermission()
        {
            ReadOnly = false;
            WriteOnly = false;
        }
    }
}
