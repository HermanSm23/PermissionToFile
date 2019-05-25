
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PermissionToFileLibraryClasses.LevelOfPermission
{
    public abstract class PermissionLevel
    {
        public bool ReadOnly { get; set; }
        public bool WriteOnly { get; set; }
    }
}
