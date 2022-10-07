using System.Collections.ObjectModel;
using course.Models;
using course.View;
using Microsoft.EntityFrameworkCore;

namespace course.ViewModel
{
    public class SecurityViewModel
    {
        ApplicationContext db = new ApplicationContext();
        RelayCommand? addCommand;
        RelayCommand? editCommand;
        RelayCommand? deleteCommand;
        public ObservableCollection<Security> Securities { get; set; }

        public SecurityViewModel()
        {
            db.Securities.Load();
            Securities = db.Securities.Local.ToObservableCollection();
        }
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand((o) =>
                    {
                        SecurityWindow securityWindow = new SecurityWindow(new Security());
                        if (securityWindow.ShowDialog() == true)
                        {
                            Security security = securityWindow.ctx.security;
                            security.FinAsset = db.FinAssets.Find(security.FinAssetID);
                            db.Securities.Add(security);
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
                        Security? security = selectedItem as Security;
                        if (security == null) return;

                        Security vm = new Security
                        {
                            ID = security.ID,
                            FinAssetID = security.FinAssetID,
                            FinAsset = security.FinAsset,
                            DataAccomodation = security.DataAccomodation,
                            DataReport = security.DataReport,
         
                        };
                        SecurityWindow securityWindow = new SecurityWindow(vm);

                        if (securityWindow.ShowDialog() == true)
                        {
                            security.FinAssetID = securityWindow.ctx.security.FinAssetID;
                            security.FinAsset = securityWindow.ctx.security.FinAsset;
                            security.DataAccomodation = securityWindow.ctx.security.DataAccomodation;
                            security.DataReport = securityWindow.ctx.security.DataReport;
                            db.Entry(security).State = EntityState.Modified;
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
                        Security? security = selectedItem as Security;
                        if (security == null) return;
                        db.Securities.Remove(security);
                        db.SaveChanges();
                    }));
            }
        }
    }
}
