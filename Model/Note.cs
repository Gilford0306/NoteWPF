
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace NoteWPF.Model
{
    public class Note
    {
        public int id;
        private string date;
        private string header;
        private string text;
        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged("Id"); }
        }

        public string Date
        {
            get { return date; }
            set { date = value; OnPropertyChanged("Date"); }
        }


        public string Header
        {
            get { return header; }
            set { header = value; OnPropertyChanged("Header"); }
        }


        public string Text
        {
            get { return text; }
            set { text = value; OnPropertyChanged("Text"); }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}