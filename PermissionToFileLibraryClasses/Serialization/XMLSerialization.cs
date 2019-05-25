using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PermissionToFileLibraryClasses.Serialization
{
    public class XMLSerialization : ISerialize
    {
        public void SaveData<T>(List<T> data, String filePath)
        {
            DataContractSerializer xmlFormatter = new DataContractSerializer(typeof(T[]));
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                xmlFormatter.WriteObject(fs, data.ToArray());
            }
        }

        public List<T> RestoreData<T>(String filePath)
        {
            DataContractSerializer xmlFormatter = new DataContractSerializer(typeof(T[]));
            List<T> restoredData = new List<T>();
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                T[] data = (T[])xmlFormatter.ReadObject(fs);
                restoredData.AddRange(data);
            }
            return restoredData;
        }
    }
}
