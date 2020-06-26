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
using Phone_Book.Open;
using Phone_Book.Save;
using Phone_Book.Classes;


namespace Phone_Book
{
    public partial class MainForm : Form
    {
        private List<Note> PhoneNote;
        private int current;
        private ISave saveBehavior;
        private IOpen openBehavior;

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
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) // Если в диалоговом окне нажали ОК
            {
                try         // обработчик исключительных ситуаций
                {
                    switch (saveFileDialog1.FilterIndex)
                    {
                        case 1:
                            {
                                //Txt file
                                saveBehavior = new SaveTxt();
                                break;
                            }
                        case 2:
                            {
                                saveBehavior= new SaveXml();
                                //Xml file
                                break;
                            }
                        case 3:
                            {
                                //Binary file
                                saveBehavior= new SerializeBin();
                                break;
                            }
                    }
                    saveBehavior.Save(PhoneNote, saveFileDialog1.FileName);
                }
                catch (Exception ex)  // перехватываем ошибку
                {
                    // выводим информацию об ошибке
                    MessageBox.Show("Не удалось сохранить данные! Ошибка: " +
                    ex.Message);
                }
            }

        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var newNotes = new List<Note>();
                    switch (openFileDialog1.FilterIndex)
                    {
                        case 1:
                            {
                                //Txt file
                                openBehavior = new OpenTxt();
                                break;
                            }
                        case 2:
                            {
                                openBehavior = new OpenXml();
                                //Xml file
                                break;
                            }
                        case 3:
                            {
                                //Binary file
                                openBehavior = new DeserializeBin();
                                break;
                            }
                    }
                    newNotes = openBehavior.OpenFile(openFileDialog1.FileName);
                    openBehavior.AddUnique(ref PhoneNote, newNotes);
                    if (PhoneNote.Count == 0) current = -1;
                    else current = 0;
                    PrintElement();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
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
                PhoneNote.Sort((x, y) => x.Patronymic.CompareTo(y.Patronymic));
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
                PhoneNote.Sort((x, y) => y.Patronymic.CompareTo(x.Patronymic));
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

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.O && ModifierKeys == Keys.Control)
                открытьToolStripMenuItem_Click(sender, e);
            else if (e.KeyCode == Keys.S && ModifierKeys == Keys.Control)
                сохранитьToolStripMenuItem_Click(sender, e);
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
