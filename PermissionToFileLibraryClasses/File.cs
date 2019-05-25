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
    [KnownType(typeof(FullPermission))]
    [KnownType(typeof(ReadOnly))]
    [KnownType(typeof(WriteOnly))]
    [KnownType(typeof(WithoutPermission))]
    public class Filez
    {
        [DataMember]
        public string Filename { get; private set; }
        [DataMember]
        public Dictionary<string, Permission> permissionList;
        public Filez(string Filename)
        {
            this.Filename = Filename;
            permissionList = new Dictionary<string, Permission>();
        }
    }
}
