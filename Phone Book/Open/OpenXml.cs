using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace Phone_Book.Open
{
    class OpenXml : IOpen
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
            var newNotes = new List<Note>();
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(filename);
            XmlElement xRoot = xDoc.DocumentElement;
            foreach (XmlElement xnode in xRoot)
            {
                Note myRecord = new Note();
                foreach (XmlNode cnode in xnode.ChildNodes)
                {
                    if (cnode.Name == "Lastname") myRecord.LastName = cnode.InnerText;
                    if (cnode.Name == "Name") myRecord.Name = cnode.InnerText;
                    if (cnode.Name == "Patronymic") myRecord.Patronymic = cnode.InnerText;
                    if (cnode.Name == "Street") myRecord.Street = cnode.InnerText;
                    if (cnode.Name == "House") myRecord.House = ushort.Parse(cnode.InnerText);
                    if (cnode.Name == "Flat") myRecord.Flat = ushort.Parse(cnode.InnerText);
                    if (cnode.Name == "Phone") myRecord.Phone = cnode.InnerText;
                }
                newNotes.Add(myRecord);
            }
            return newNotes;
        }
    }
}
