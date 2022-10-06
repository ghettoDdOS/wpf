using System.Collections.ObjectModel;
using course.Models;
using course.View;
using Microsoft.EntityFrameworkCore;

namespace course.ViewModel
{
    public class BondViewModel
    {
        ApplicationContext db = new ApplicationContext();
        RelayCommand? addCommand;
        RelayCommand? editCommand;
        RelayCommand? deleteCommand;
        public ObservableCollection<Bond> Bonds { get; set; }
    
        public BondViewModel()
        {
            db.Database.EnsureCreated();
            db.Bonds.Load(); 
            Bonds = db.Bonds.Local.ToObservableCollection();
        }
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand((o) =>
                    {
                        BondWindow bondWindow = new BondWindow(new Bond());
                        if (bondWindow.ShowDialog() == true)
                        {
                            Bond bond = bondWindow.ctx.bond;
                            db.Bonds.Add(bond);
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
                        Bond? bond = selectedItem as Bond;
                        if (bond == null) return;

                        Bond vm = new Bond
                        {
                            ID = bond.ID,
                            FinAssetID = bond.FinAssetID,
                            DataRepayment = bond.DataRepayment,
                            Coupon = bond.Coupon,
                            Rate = bond.Rate
                        };
                        BondWindow bondWindow = new BondWindow(vm);

                        if (bondWindow.ShowDialog() == true)
                        {
                            bond.FinAssetID = bondWindow.ctx.bond.FinAssetID;
                            bond.DataRepayment = bondWindow.ctx.bond.DataRepayment;
                            bond.Coupon = bondWindow.ctx.bond.Coupon;
                            bond.Rate = bondWindow.ctx.bond.Rate;
                            db.Entry(bond).State = EntityState.Modified;
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
                        Bond? bond = selectedItem as Bond;
                        if (bond == null) return;
                        db.Bonds.Remove(bond);
                        db.SaveChanges();
                    }));
            }
        }
    }
}
