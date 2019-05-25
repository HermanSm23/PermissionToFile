using PermissionToFileLibraryClasses.LevelOfPermission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PermissionToFileLibraryClasses
{
    [Serializable]
    [DataContract]
    [KnownType(typeof(User))]
    [KnownType(typeof(Moderator))]
    [KnownType(typeof(HelperAdmin))]
    [KnownType(typeof(SystemAdmin))]
    public class Permission
    {
        public static bool operator true(Permission permission)
        {
            return permission.WriteOnly;
        }
        public static bool operator false(Permission permission)
        {
            return !permission.WriteOnly;
        }

        [DataMember]
        public Person Person { get; private set; }
        [DataMember]
        public bool ReadOnly { get; set; }
        [DataMember]
        public bool WriteOnly { get; set; }

        public Permission(Person person, PermissionLevel permissionLevel)
        {
            Person = person;
            ReadOnly = permissionLevel.ReadOnly;
            WriteOnly = permissionLevel.WriteOnly;
        }
    }
}
