using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phone_Book.Save;
using System.IO;

namespace Phone_Book.Classes
{
    public class SaveTxt : ISave
    {
        public void Save(List<Note> notes, string filename)
        {

            using (StreamWriter sw = new StreamWriter(filename))
            {
                foreach (Note MyRecord in notes)
                {
                    sw.WriteLine(MyRecord.LastName);
                    sw.WriteLine(MyRecord.Name);
                    sw.WriteLine(MyRecord.Patronymic);
                    sw.WriteLine(MyRecord.Street);
                    sw.WriteLine(MyRecord.House);
                    sw.WriteLine(MyRecord.Flat);
                    sw.WriteLine(MyRecord.Phone);
                }
            }

        }
    }
}
