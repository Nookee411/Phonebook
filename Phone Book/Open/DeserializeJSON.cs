using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Phone_Book.Open
{
    class DeserializeJSON : IOpen
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

            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Note>));

            List<Note> notes = new List<Note>();
            using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                notes = (List<Note>)jsonFormatter.ReadObject(fs);
            }
            return notes;
        }
    }
}
