using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace course.Models
{
    public class Security : INotifyPropertyChanged
    {
        DateTime dataAccomodation { get; set; }
        DateTime dataReport{ get; set; }
        FinAsset finAsset { get; set; }

        public int ID { get; set; }
        public int FinAssetID { get; set; }
        public FinAsset FinAsset
        {
            get { return finAsset; }
            set
            {
                finAsset = value;
                OnPropertyChanged("FinAsset");
            }
        }
        public DateTime DataAccomodation
        {
            get { return dataAccomodation; }
            set
            {
                dataAccomodation = value;
                OnPropertyChanged("DataAccomodation");
            }
        }
        public DateTime DataReport
        {
            get { return dataReport; }
            set
            {
                dataReport = value;
                OnPropertyChanged("DataReport");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
