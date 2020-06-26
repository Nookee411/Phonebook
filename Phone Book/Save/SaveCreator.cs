using Phone_Book.Classes;
using Phone_Book.Open;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Book.Save
{
    class SaveCreator
    {
        public static ISave Create(string filename, int index)
        {
            ISave saveBehavior;

            switch (index)
            {
                case 1:
                    {
                        //Txt file
                        saveBehavior = new SaveTxt();
                        break;
                    }
                case 2:
                    {
                        saveBehavior = new SerializeXml();
                        //Xml file
                        break;
                    }
                case 3:
                    {
                        //Binary file
                        saveBehavior = new SerializeBin();
                        break;
                    }
                case 4:
                    {
                        saveBehavior = new SerializeJSON();
                        break;
                    }
                default:
                    {
                        saveBehavior = new SaveTxt();
                        break;
                    }
            }

            return saveBehavior;
        }
    }
}
