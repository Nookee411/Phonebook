using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phone_Book.Open;
using System.IO;

namespace Phone_Book.Open
{
    class OpenTxt : IOpen
    {
        public List<Note> OpenFile(string filename)
        {
            var newNotes = new List<Note>();
            using (StreamReader sr = new StreamReader(filename))
            {
                Note MyRecord;
                while (!sr.EndOfStream)
                {
                    //выделяем место под запись
                    MyRecord = new Note();
                    // считываем значения полей записи из файла
                    MyRecord.LastName = sr.ReadLine();
                    MyRecord.Name = sr.ReadLine();
                    MyRecord.Patronymic = sr.ReadLine();
                    MyRecord.Street = sr.ReadLine();
                    MyRecord.House = ushort.Parse(sr.ReadLine());
                    MyRecord.Flat = ushort.Parse(sr.ReadLine());
                    MyRecord.Phone = sr.ReadLine();
                    //добавляем запись в список
                    newNotes.Add(MyRecord);
                }
            }
            return newNotes;
        }

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
    }
}
