using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Book.Save
{
    interface ISave
    {
        void Save(List<Note> notes, String fileName);
    }
}
