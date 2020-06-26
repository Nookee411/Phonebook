using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;

namespace Phone_Book.Open
{
    class DeserializeXml : IOpen
    {
        public void AddUnique(ref List<Note> oldNotes, List<Note> newNotes)
        {
            foreach (Note note in newNotes)
            {
                bool unique = true;
                foreach (Note oldNote in oldNotes)
                {
                    if (note.Equals(oldNote))
                    {
                        unique = false;
                        break;
                    }
                }
                if (unique)
                {
                    oldNotes.Add(note);
                }
            }
        }

        public List<Note> OpenFile(string filename)
        {
            XmlSerializer reader = new XmlSerializer(typeof(List<Note>));
            StreamReader file = new StreamReader(filename);
            List<Note>notes = (List<Note>)reader.Deserialize(file);
            file.Close();
            return notes;
        }
    }
}
