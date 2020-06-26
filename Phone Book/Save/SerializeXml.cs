using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;

namespace Phone_Book.Save
{
    class SerializeXml : ISave
    {
        public void Save(List<Note> notes, string fileName)
        {
            XmlSerializer writer = new XmlSerializer(typeof(List<Note>));
            FileStream file = File.Create(fileName);
            writer.Serialize(file, notes);
            file.Close();
        }
    }
}
