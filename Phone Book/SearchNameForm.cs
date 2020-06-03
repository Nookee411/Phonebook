using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phone_Book
{
    public partial class SearchNameForm : Form
    {
        List<Note> PhoneNote;
        public SearchNameForm(List<Note> _PhoneNote)
        {
            InitializeComponent();
            PhoneNote = _PhoneNote;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void SearchNameForm_Load(object sender, EventArgs e)
        {

        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            // очищаем окно для вывода результатов
            resultTextBox.Text = "";
            // количество найденных результатов
            int i = 0;
            // цикл for для каждого элемента списка - foreach
            foreach (Note MyRecord in PhoneNote)
            {
                // если выполняются условия поиска
                if (LastNameTextBox.Text.Length + NameTextBox.Text.Length + PatronymicTextBox.Text.Length > 0)
                {
                    if (MyRecord.LastName.Contains(LastNameTextBox.Text) &&
                    MyRecord.Name.Contains(NameTextBox.Text) && MyRecord.Patronymic.Contains(PatronymicTextBox.Text))
                    {

                        // увеличиваем счетчик найденных записей
                        i++;
                        // дописываем элемент и его номер к результату 
                        resultTextBox.Text = resultTextBox.Text + i.ToString() + ". " + MyRecord.LastName + " " + MyRecord.Name + " " + MyRecord.Patronymic + ", ул. " + MyRecord.Street + ", д." + MyRecord.House + ", кв. " + MyRecord.Flat + ", тел. " + MyRecord.Phone + "\r\n";
                    }
                }
                else if (FlatTextBox.Text.Length + StreetTextBox.Text.Length + HouseTextBox.Text.Length > 0)
                {
                    if (MyRecord.Street.Contains(StreetTextBox.Text) &&
                        MyRecord.Flat.ToString().Contains(FlatTextBox.Text) && MyRecord.House.ToString().Contains(HouseTextBox.Text))
                    {
                        i++;
                        resultTextBox.Text = resultTextBox.Text + i.ToString() + ". " + MyRecord.LastName + " " + MyRecord.Name + " " + MyRecord.Patronymic + ", ул. " + MyRecord.Street + ", д." + MyRecord.House + ", кв. " + MyRecord.Flat + ", тел. " + MyRecord.Phone + "\r\n";
                    }
                }
                else if(PhoneTextBox.Text.Length>0)
                {
                    if(MyRecord.Phone.Contains(PhoneTextBox.Text))
                    {
                        i++;
                        resultTextBox.Text = resultTextBox.Text + i.ToString() + ". " + MyRecord.LastName + " " + MyRecord.Name + " " + MyRecord.Patronymic + ", ул. " + MyRecord.Street + ", д." + MyRecord.House + ", кв. " + MyRecord.Flat + ", тел. " + MyRecord.Phone + "\r\n";
                    }
                }
            }
            // если не найдено ни одной записи, выводим сообщение
            if (i == 0) resultTextBox.Text = "Записей, удовлетворяющих поставленным условиям, в списке абонентов нет! "; 

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
