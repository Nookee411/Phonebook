using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phone_Book.Save;
using System.Xml;

namespace Phone_Book.Save
{
    class SaveXml : ISave
    {
        public void Save(List<Note> notes, string filename)
        {

            XmlTextWriter textWriter = new XmlTextWriter(filename, Encoding.UTF8);
            textWriter.WriteStartDocument();
            textWriter.WriteStartElement("Notes");
            textWriter.WriteEndDocument();
            textWriter.Close();

            XmlDocument document = new XmlDocument();
            document.Load(filename);

            int index = 0;
            foreach (Note MyRecord in notes)
            {
                XmlElement element = document.CreateElement("Note");
                document.DocumentElement.AppendChild(element);

                XmlAttribute attribute = document.CreateAttribute("id");
                attribute.Value = index.ToString();
                element.Attributes.Append(attribute);

                XmlNode lastNameElem = document.CreateElement("Lastname");
                lastNameElem.InnerText = MyRecord.LastName;
                element.AppendChild(lastNameElem);

                XmlNode nameElem = document.CreateElement("Name");
                nameElem.InnerText = MyRecord.Name;
                element.AppendChild(nameElem);

                XmlNode patronymicElem = document.CreateElement("Patronymic");
                patronymicElem.InnerText = MyRecord.Patronymic;
                element.AppendChild(patronymicElem);

                XmlNode streetElem = document.CreateElement("Street");
                streetElem.InnerText = MyRecord.Street;
                element.AppendChild(streetElem);

                XmlNode houseElem = document.CreateElement("House");
                houseElem.InnerText = MyRecord.House.ToString();
                element.AppendChild(houseElem);

                XmlNode flatElem = document.CreateElement("Flat");
                flatElem.InnerText = MyRecord.Flat.ToString();
                element.AppendChild(flatElem);

                XmlNode phoneElem = document.CreateElement("Phone");
                phoneElem.InnerText = MyRecord.Phone;
                element.AppendChild(phoneElem);

                index++;
            }
            document.Save(filename);
        }

    }
}
