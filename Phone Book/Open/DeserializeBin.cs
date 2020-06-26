using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Phone_Book.Open
{
    class DeserializeBin : IOpen
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
            List<Note> notes;
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                IFormatter formatter = new BinaryFormatter();
                notes = (List<Note>)formatter.Deserialize(fs);

            }
            
            return notes;
        }
    }
}
