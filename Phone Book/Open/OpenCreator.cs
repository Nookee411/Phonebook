using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phone_Book.Open
{
    class OpenCreator
    {
        public static IOpen Create(string filename,int index)
        {
           
            IOpen openBehavior;

            switch (index)
            {
                case 1:
                    {
                        //Txt file
                        openBehavior = new OpenTxt();
                        break;
                    }
                case 2:
                    {
                        openBehavior = new DeserializeXml();
                        //Xml file
                        break;
                    }
                case 3:
                    {
                        //Binary file
                        openBehavior = new DeserializeBin();
                        break;
                    }
                case 4:
                    {
                        //JSON file
                        openBehavior = new DeserializeJSON();
                        break;
                    }
                default:
                    {
                        openBehavior = new OpenTxt();
                        break;
                    }
            }
            
            return openBehavior;
        }
    }
}
