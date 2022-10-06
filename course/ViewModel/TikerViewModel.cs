using System.Collections.ObjectModel;
using course.Models;
using course.View;
using Microsoft.EntityFrameworkCore;

namespace course.ViewModel
{
    public class TikerViewModel
    {
        ApplicationContext db = new ApplicationContext();
        RelayCommand? addCommand;
        RelayCommand? editCommand;
        RelayCommand? deleteCommand;
        public ObservableCollection<Tiker> Tikers { get; set; }
        public TikerViewModel()
        {
            db.Database.EnsureCreated();
            db.Tikers.Load();
            Tikers = db.Tikers.Local.ToObservableCollection();
        }
        public RelayCommand AddCommand
        {
            get 
            {
                return addCommand ??
                    (addCommand = new RelayCommand((o) =>
                    {
                        TikerWindow tikerWindow = new TikerWindow(new Tiker());
                        if (tikerWindow.ShowDialog() == true)
                        {
                            Tiker tiker = tikerWindow.Tiker;
                            db.Tikers.Add(tiker);
                            db.SaveChanges();
                        }
                    }));
            }
        }
        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ??
                    (editCommand = new RelayCommand((selectedItem) =>
                    {
                        Tiker? tiker = selectedItem as Tiker;
                        if (tiker == null) return;

                        Tiker vm = new Tiker
                        {
                            ID = tiker.ID,
                            NameTiker = tiker.NameTiker,
                            DealPlace = tiker.DealPlace
                        };
                        TikerWindow tikerWindow = new TikerWindow(vm);

                        if (tikerWindow.ShowDialog() == true)
                        {
                            tiker.NameTiker = tikerWindow.Tiker.NameTiker;
                            tiker.DealPlace = tikerWindow.Tiker.DealPlace;
                            db.Entry(tiker).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                    }));
            }
        }
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                    (deleteCommand = new RelayCommand((selectedItem) =>
                    {
                        Tiker? tiker = selectedItem as Tiker;
                        if (tiker == null) return;
                        db.Tikers.Remove(tiker);
                        db.SaveChanges();
                    }));
            }
        }
    }
}
