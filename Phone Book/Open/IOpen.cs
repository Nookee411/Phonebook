using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Book.Open
{
    interface IOpen
    {
        List<Note> OpenFile(string filename);
        void AddUnique(ref List<Note> oldNotes, List<Note> newNotes);
    }
}
