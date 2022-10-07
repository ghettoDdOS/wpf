using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace course.Models
{
    public class Bond : INotifyPropertyChanged
    {
        int finAssetID { get; set; }
        FinAsset finAsset { get; set; }
        DateTime dataRepayment { get; set; }
        int coupon { get; set; }
        int rate { get; set; }

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
        public DateTime DataRepayment
        {
            get { return dataRepayment; }
            set
            {
                dataRepayment = value;
                OnPropertyChanged("DataRepayment");
            }
        }
        public int Coupon
        {
            get { return coupon; }
            set
            {
                coupon = value;
                OnPropertyChanged("Coupon");
            }
        }
        public int Rate
        {
            get { return rate; }
            set
            {
                rate = value;
                OnPropertyChanged("Rate");
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
