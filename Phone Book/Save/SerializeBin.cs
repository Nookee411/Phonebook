using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Phone_Book.Save
{
    class SerializeBin:ISave
    {

        
        public void Save(List<Note> notes, string fileName)
        {
            if (fileName.Substring(fileName.Length - 4) != ".dat")
                fileName += ".dat";
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, notes);
            stream.Close();
        }
    }
}
