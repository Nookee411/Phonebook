using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Phone_Book
{
    public partial class MainForm : Form
    {
        private List<Note> PhoneNote;
        private int current;

        public MainForm()
        {
            InitializeComponent();
            PhoneNote = new List<Note>();
            current = -1;
        }
        private void PrintElement()
        {
            if ((current >= 0) && (current < PhoneNote.Count))
            {   // если есть что выводить
                // MyRecord - запись списка PhoneNote номер current
                Note MyRecord = PhoneNote[current];
                // записываем в соответствующие элементы на форме 
                // поля из записи MyRecord 
                LastNameTextBox.Text = MyRecord.LastName;
                NameTextBox.Text = MyRecord.Name;
                PatronymicTextBox.Text = MyRecord.Patronymic;
                PhoneMaskedTextBox.Text = MyRecord.Phone;
                StreetTextBox.Text = MyRecord.Street;
                HouseNumericUpDown.Value = MyRecord.House;
                FlatNumericUpDown.Value = MyRecord.Flat;
            }
            else // если current равно -1, т. е. список пуст
            {   // очистить поля формы 
                LastNameTextBox.Text = "";
                NameTextBox.Text = "";
                PatronymicTextBox.Text = "";
                PhoneMaskedTextBox.Text = "";
                StreetTextBox.Text = "";
                HouseNumericUpDown.Value = 1;
                FlatNumericUpDown.Value = 1;
            }
            // обновление строки состояния
            NumberToolStripStatusLabel.Text = (current + 1).ToString();
            QuantityToolStripStatusLabel.Text = PhoneNote.Count.ToString();
        }
        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }



        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void QuantityToolStripStatusLabel_Click(object sender, EventArgs e)
        {

        }

        private void добавитьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            // создаем запись - экземпляр класса Note
            Note MyRecord = new Note();

            // создаем экземпляр формы AddForm
            AddForm _AddForm = new AddForm(MyRecord, AddOrEdit.Add);

            // открываем форму для добавления записи
            _AddForm.ShowDialog();

            // текущей записью становится последняя
            current = PhoneNote.Count;

            // добавляем к списку PhoneNote новый элемент - запись MyRecord,
            // взятую из формы AddForm
            if(_AddForm.added)
                PhoneNote.Add(_AddForm.MyRecord);

            // выводим текущий элемент
            PrintElement();
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            if (current <= 0)
                MessageBox.Show("Предыдущего номера не сушествует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            { 
                current--;      // уменьшаем номер текущей записи на 1
            PrintElement();
            }

        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (PhoneNote.Count-1 <= current)
                MessageBox.Show("Следующего номера не сушествует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                current++;      // уменьшаем номер текущей записи на 1
                PrintElement();
            }

        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            // Если в диалоговом окне нажали ОК
            {
                try         // обработчик исключительных ситуаций
                {
                    // используя sw (экземпляр класса StreamWriter),
                    // создаем файл с заданным в диалоговом окне именем
                    using (StreamWriter sw =
                    new StreamWriter(saveFileDialog1.FileName))
                    {
                        // проходим по всем элементам списка
                        foreach (Note MyRecord in PhoneNote)
                        {
                            // записываем каждое поле в отдельной строке
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
                catch (Exception ex)    // перехватываем ошибку
                {
                    // выводим информацию об ошибке
                    MessageBox.Show("Не удалось сохранить данные! Ошибка: " +
                    ex.Message);
                }
            }

        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Note MyRecord;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            // если в диалоговом окне нажали ОК
            {
                try         // обработчик исключительных ситуаций
                {
                    // считываем из указанного в диалоговом окне файла
                    using (StreamReader sr =
                    new StreamReader(openFileDialog1.FileName))
                    {
                        // пока не дошли до конца файла
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
                            PhoneNote.Add(MyRecord);
                        }
                    }
                    // если список пуст, то current устанавливаем в -1,
                    // иначе текущей является первая с начала запись (номер 0)
                    if (PhoneNote.Count == 0) current = -1;
                    else current = 0;
                    // выводим текущий элемент
                    PrintElement();
                }
                catch (Exception ex)    // если произошла ошибка
                {
                    // выводим сообщение об ошибке
                    MessageBox.Show("При открытии файла произошла ошибка: " +
                    ex.Message);
                }
            }

        }

        private void поискToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void поискПоФИОToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchNameForm _Search = new SearchNameForm(PhoneNote);
            _Search.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void поФамилииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PhoneNote.Count > 0)    // если список не пуст
            {
                // сортировка списка по фамилии
                PhoneNote.Sort((x, y) => x.LastName.CompareTo(y.LastName));
                current = 0;        // задаем номер текущего элемента
                PrintElement(); // вывод текущего элемента

            }
        }

        private void поКвартиреToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(PhoneNote.Count>0)
            {
                PhoneNote.Sort((x, y) => x.Flat.CompareTo(y.Flat));
                current = 0;
                PrintElement();
            }
        }

        private void поИмениToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PhoneNote.Count > 0)
            {
                PhoneNote.Sort((x, y) => x.Name.CompareTo(y.Name));
                current = 0;
                PrintElement();
            }
        }

        private void отчествуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PhoneNote.Count > 0)
            {
                PhoneNote.Sort((x, y) => x.Patronymic.CompareTo(y.Flat));
                current = 0;
                PrintElement();
            }
        }

        private void домуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PhoneNote.Count > 0)
            {
                PhoneNote.Sort((x, y) => x.House.CompareTo(y.House));
                current = 0;
                PrintElement();
            }
        }

        private void улицеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PhoneNote.Count > 0)
            {
                PhoneNote.Sort((x, y) => x.Street.CompareTo(y.Street));
                current = 0;
                PrintElement();
            }
        }

        private void телефонуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PhoneNote.Count > 0)
            {
                PhoneNote.Sort((x, y) => x.Phone.CompareTo(y.Phone));
                current = 0;
                PrintElement();
            }
        }

        private void поУбываниюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PhoneNote.Count > 0)    // если список не пуст
            {
                // сортировка списка по фамилии
                PhoneNote.Sort((x, y) => y.LastName.CompareTo(x.LastName));
                current = 0;        // задаем номер текущего элемента
                PrintElement(); // вывод текущего элемента

            }
        }

        private void поУбываниюToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (PhoneNote.Count > 0)
            {
                PhoneNote.Sort((x, y) => y.Flat.CompareTo(x.Flat));
                current = 0;
                PrintElement();
            }
        }

        private void поУбываниюToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            
                if (PhoneNote.Count > 0)
                {
                    PhoneNote.Sort((x, y) => y.Name.CompareTo(x.Name));
                    current = 0;
                    PrintElement();
                }
        }

        private void поУбываниюToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (PhoneNote.Count > 0)
            {
                PhoneNote.Sort((x, y) => y.Patronymic.CompareTo(x.Flat));
                current = 0;
                PrintElement();
            }
        }

        private void поУбываниюToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (PhoneNote.Count > 0)
            {
                PhoneNote.Sort((x, y) => y.Street.CompareTo(x.Street));
                current = 0;
                PrintElement();
            }
        }

        private void поУбываниюToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (PhoneNote.Count > 0)
            {
                PhoneNote.Sort((x, y) => y.House.CompareTo(x.House));
                current = 0;
                PrintElement();
            }
        }

        private void поУбываниюToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (PhoneNote.Count > 0)
            {
                PhoneNote.Sort((x, y) => y.Phone.CompareTo(x.Phone));
                current = 0;
                PrintElement();
            }
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PhoneNote.Count > 0)
{
                // создаем запись - экземпляр класса Note
                Note MyRecord = new Note();
                // определяем поля записи
                // (берем значения из соответствующих компонентов на форме)
                MyRecord.LastName = LastNameTextBox.Text;
                MyRecord.Name = NameTextBox.Text;
                MyRecord.Patronymic = PatronymicTextBox.Text;
                MyRecord.Phone = PhoneMaskedTextBox.Text;
                MyRecord.Street = StreetTextBox.Text;
                MyRecord.House = (ushort)HouseNumericUpDown.Value;
                MyRecord.Flat = (ushort)FlatNumericUpDown.Value;
                // создаем экземпляр формы и открываем эту форму
                AddForm _AddForm = new AddForm(MyRecord, AddOrEdit.Edit);
                _AddForm.ShowDialog();
                // изменяем текущую запись
                PhoneNote[current] = _AddForm.MyRecord;
            }
            PrintElement();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
           if(PhoneNote.Count>0)
            {
                PhoneNote.RemoveAt(current);
                if (current != 0)
                    current--;
                PrintElement();
                
            }
        }
    }

    class CompareByLastName : IComparer<Note>
    {
        #region IComparer<Note> Members

        public int Compare(Note x, Note y)
        {
            return string.Compare(x.LastName, y.LastName);
        }

        #endregion

    }

    class CompareByFlat : IComparer<Note>
    {
        #region IComparer<Note> Members

        public int Compare(Note x, Note y)
        {
            return x.Flat.CompareTo(y.Flat);
        }

        #endregion
    }


    public enum AddOrEdit
    {
        Add,
        Edit
    }


}
