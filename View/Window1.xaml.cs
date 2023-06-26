using NoteWPF.Model;
using NoteWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NoteWPF.View
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        string date = string.Empty;
        string header = string.Empty;
        string text = string.Empty;
        DateTime newdate = new DateTime();
        private int change = 0;

        public Window1()
        {
            InitializeComponent();
        }

        public Window1(int change):this()
        {
            this.change = change;

        }

        private void RepeatButton_Click(object sender, RoutedEventArgs e)
        {
            if (change == 0) 
            {
                if (date != string.Empty && header != string.Empty && text != string.Empty)
                {
                    using (MyApplicationContext context = new MyApplicationContext())
                    {

                        context.Notes.Add(new Note() { Date = date, Header = header, Text = text });
                        context.SaveChanges();
                        MessageBox.Show("Note is Created");
                        this.Close();
                    }
                }
                else
                    MessageBox.Show("Fill in all the fields");
            }
            else
            {
                if (date != string.Empty && header != string.Empty && text != string.Empty)
                {
                    using (MyApplicationContext context = new MyApplicationContext())
                    {

                        var oldData = context.Notes.FirstOrDefault(x => x.Id == change);
                        oldData.Date = date;
                        oldData.Header = header;
                        oldData.Text = text;
                        context.Notes.Update(oldData);
                        context.SaveChanges();
                        MessageBox.Show("Note is Update");
                        this.Close();
                    }
                }
                else
                    MessageBox.Show("Fill in all the fields");

            }

        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            newdate = (DateTime)(((DatePicker)sender).SelectedDate);
            date= newdate.ToString("d");
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            header = textBox.Text;
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            text = textBox.Text;
        }
    }
}
