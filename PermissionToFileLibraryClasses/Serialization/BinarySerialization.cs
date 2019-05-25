using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace PermissionToFileLibraryClasses.Serialization
{
    public class BinarySerialization : ISerialize
    {
        public void SaveData<T>(List<T> data, String filePath)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, data);
            }
        }

        public List<T> RestoreData<T>(String filePath)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            List<T> restoredData;
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                restoredData = (List<T>)formatter.Deserialize(fs);
            }
            return restoredData;
        }
    }
}
