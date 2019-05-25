using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermissionToFileLibraryClasses
{
    public interface ISerialize
    {
        void SaveData<T>(List<T> data, String filePath);
        List<T> RestoreData<T>(String filePath);
    }
}
