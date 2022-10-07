using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace course.Models
{
    public class FinAsset : INotifyPropertyChanged
    {
        int tikerID { get; set; }
        Tiker tiker { get; set; }
        string registration { get; set; }
        DateTime dataRegistration { get; set; }
        string emitent { get; set; }
        string formIssue { get; set; }
        string principal { get; set; }
        int amount { get; set; }
        public int ID { get; set; }
        public int TikerID { get; set; }
        public Tiker Tiker
        {
            get { return tiker; }
            set
            {
                tiker = value;
                OnPropertyChanged("Tiker");
            }
        }
        public string Registration 
        { 
            get { return registration; } 
            set 
            {
                registration = value;
                OnPropertyChanged(null);
            }
        }
        public DateTime DataRegistration
        {
            get { return dataRegistration; }
            set
            {
                dataRegistration = value;
                OnPropertyChanged("DataRegistration");
            }
        }
        public string Emitent
        {
            get { return emitent; }
            set
            {
                emitent = value;
                OnPropertyChanged("Emitent");
            }
        }
        public string FormIssue
        {
            get { return formIssue; }
            set
            {
                formIssue = value;
                OnPropertyChanged("FormIssue");
            }
        }
        public string Principal
        {
            get { return principal; }
            set
            {
                principal = value;
                OnPropertyChanged("Principal");
            }
        }
        public int Amount
        {
            get { return amount; }
            set
            {
                amount = value;
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
