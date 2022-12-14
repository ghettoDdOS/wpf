using course.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Microsoft.EntityFrameworkCore;

namespace course.View
{
    public class BondContext
    {
        public Bond bond { get; set; }
        public List<FinAsset> finAssets { get; set; }
    }
    /// <summary>
    /// Логика взаимодействия для TikerWindow.xaml
    /// </summary>
    public partial class BondWindow : Window
    {
        ApplicationContext db = new ApplicationContext();
        public BondContext ctx { get; private set; } = new BondContext();
    public BondWindow(Bond bond)
        {
            InitializeComponent();

            ctx.bond = bond;
            db.FinAssets.Load();
            ctx.finAssets = db.FinAssets.Local.ToList();
            DataContext = ctx;
        }

        void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
