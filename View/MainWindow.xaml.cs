using Azure;
using NoteWPF.Model;
using NoteWPF.View;
using NoteWPF.ViewModel;
using System;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace NoteWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int change = 0;
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainVM();
        }

        private void RepeatButton_Click(object sender, RoutedEventArgs e)
        {
            Window1 win1 = new Window1();
            win1.Show();
        }

        private void RepeatButton_Click_1(object sender, RoutedEventArgs e)
        {

            if (change != 0)
            {
                using (MyApplicationContext context = new MyApplicationContext())
                {

                    int idForRemove = change;
                    context.Notes.Remove(context.Notes.FirstOrDefault(z => z.Id.Equals(idForRemove)));
                    context.SaveChanges();
                    MessageBox.Show("Note is deleted");
                    MainWindow newWindow = new MainWindow();
                    Application.Current.MainWindow = newWindow;
                    newWindow.Show();
                    this.Close();
                }
            }
        }

        private void TextBlock_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            var s = (TextBlock)sender;
            change = int.Parse(s.Text);

        }

        private void RepeatButton_Click_2(object sender, RoutedEventArgs e)
        {
            MainWindow newWindow = new MainWindow();
            Application.Current.MainWindow = newWindow;
            newWindow.Show();
            this.Close();
        }

        private void RepeatButton_Click_3(object sender, RoutedEventArgs e)
        {
            if (change != 0)
            {
                using (MyApplicationContext context = new MyApplicationContext())
                {
                    Window1 win1 = new Window1(change);
                    win1.Show();
                }
            }
        }
    }
    
}