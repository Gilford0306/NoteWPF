using NoteWPF.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;


namespace NoteWPF.ViewModel
{
    internal class MainVM : INotifyPropertyChanged
    {
        public ObservableCollection<Note> notes { get; set; }

        public MainVM()
        {
            notes = new ObservableCollection<Note>();

            using (MyApplicationContext context = new MyApplicationContext())
            {
                foreach (Note note in context.Notes)
                {
                    notes.Add(note);
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
