using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace course.Models
{
    public class FinAsset : INotifyPropertyChanged
    {
        public int ID { get; set; }
        public int TikerID { get; set; }
        public Tiker Tiker
        {
            get { return Tiker; }
            set
            {
                Tiker = value;
                OnPropertyChanged("Tiker");
            }
        }
        public string Registration 
        { 
            get { return Registration; } 
            set 
            {
                Registration = value;
                OnPropertyChanged("Registration");
            }
        }
        public DateOnly DataRegistration
        {
            get { return DataRegistration; }
            set
            {
                DataRegistration = value;
                OnPropertyChanged("DataRegistration");
            }
        }
        public string Emitent
        {
            get { return Emitent; }
            set
            {
                Emitent = value;
                OnPropertyChanged("Emitent");
            }
        }
        public string FormIssue
        {
            get { return FormIssue; }
            set
            {
                FormIssue = value;
                OnPropertyChanged("FormIssue");
            }
        }
        public string Principal
        {
            get { return Principal; }
            set
            {
                Principal = value;
                OnPropertyChanged("Principal");
            }
        }
        public int Amount
        {
            get { return Amount; }
            set
            {
                Amount = value;
                OnPropertyChanged("Amount");
            }
        }

        public List<Security> Securities { get; set; }
        public List<Bond> Bonds { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
