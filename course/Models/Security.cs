using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace course.Models
{
    public class Security : INotifyPropertyChanged
    {
        public int ID { get; set; }
        public int FinAssetID { get; set; }
        public FinAsset FinAsset
        {
            get { return FinAsset; }
            set
            {
                FinAsset = value;
                OnPropertyChanged("FinAsset");
            }
        }
        public DateOnly DataAccomodation
        {
            get { return DataAccomodation; }
            set
            {
                DataAccomodation = value;
                OnPropertyChanged("DataAccomodation");
            }
        }
        public DateOnly DataReport
        {
            get { return DataReport; }
            set
            {
                DataReport = value;
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
