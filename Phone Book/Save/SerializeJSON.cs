using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Phone_Book.Save
{
    class SerializeJSON : ISave
    {
        public void Save(List<Note> notes, String fileName)
        {

            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Note>));

            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, notes);
            }

        }
    }
}
