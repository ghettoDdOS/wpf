using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace course.Models
{
    public class Tiker : INotifyPropertyChanged
    {
        string? nameTiker;
        string? dealPlace;
        public int ID { get; set; }
        public string? NameTiker
        {
            get { return nameTiker; }
            set
            {
                nameTiker = value;
                OnPropertyChanged("NameTiker");
            }
        }
        public string DealPlace
        {
            get { return dealPlace; }
            set
            {
                dealPlace = value;
                OnPropertyChanged("DealPlace");
            }
        }

        public List<FinAsset> FinAssetes { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
