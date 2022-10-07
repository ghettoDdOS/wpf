using System.Collections.ObjectModel;
using System.Diagnostics;
using course.Models;
using course.View;
using Microsoft.EntityFrameworkCore;

namespace course.ViewModel
{
    public class FinAssetViewModel
    {
        ApplicationContext db = new ApplicationContext();
        RelayCommand? addCommand;
        RelayCommand? editCommand;
        RelayCommand? deleteCommand;
        public ObservableCollection<FinAsset> FinAssets { get; set; }
        public FinAssetViewModel()
        {
            db.FinAssets.Load();
            FinAssets = db.FinAssets.Local.ToObservableCollection();
        }
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand((o) =>
                    {
                        FinAssetWindow finAssetWindow = new FinAssetWindow(new FinAsset());
                        if (finAssetWindow.ShowDialog() == true)
                        {
                            FinAsset finAsset = finAssetWindow.ctx.finAsset;
                            finAsset.Tiker = db.Tikers.Find(finAsset.TikerID);
                            db.FinAssets.Add(finAsset);
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
                        FinAsset? finAsset = selectedItem as FinAsset;
                        if (finAsset == null) return;

                        FinAsset vm = new FinAsset
                        {
                            ID = finAsset.ID,
                            TikerID = finAsset.TikerID,
                            Tiker=finAsset.Tiker,
                            Registration = finAsset.Registration,
                            DataRegistration = finAsset.DataRegistration,
                            Emitent = finAsset.Emitent,
                            FormIssue = finAsset.FormIssue,
                            Principal = finAsset.Principal,
                            Amount = finAsset.Amount

                        };
                        FinAssetWindow finAssetWindow = new FinAssetWindow(vm);

                        if (finAssetWindow.ShowDialog() == true)
                        {
                            finAsset.Tiker = finAssetWindow.ctx.finAsset.Tiker;
                            finAsset.TikerID = finAssetWindow.ctx.finAsset.TikerID;
                            finAsset.Registration = finAssetWindow.ctx.finAsset.Registration;
                            finAsset.DataRegistration = finAssetWindow.ctx.finAsset.DataRegistration;
                            finAsset.Emitent = finAssetWindow.ctx.finAsset.Emitent;
                            finAsset.FormIssue = finAssetWindow.ctx.finAsset.FormIssue;
                            finAsset.Principal = finAssetWindow.ctx.finAsset.Principal;
                            finAsset.Amount = finAssetWindow.ctx.finAsset.Amount;

                            db.Entry(finAsset).State = EntityState.Modified;
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
                        FinAsset? finAsset = selectedItem as FinAsset;
                        if (finAsset == null) return;
                        db.FinAssets.Remove(finAsset);
                        db.SaveChanges();
                    }));
            }
        }
    }
}
