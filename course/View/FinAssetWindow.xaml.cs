using course.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Microsoft.EntityFrameworkCore;

namespace course.View
{
    public class FinAssetContext
    {
        public FinAsset finAsset { get; set; }
        public List<Tiker> Tikers { get; set; }
    }
    /// <summary>
    /// Логика взаимодействия для FinAssetWindow.xaml
    /// </summary>
    public partial class FinAssetWindow : Window
    {
        ApplicationContext db = new ApplicationContext();
        public FinAssetContext ctx { get; private set; } = new FinAssetContext();
        public FinAssetWindow(FinAsset finAsset)
        {
            InitializeComponent();
            ctx.finAsset = finAsset;
            db.Tikers.Load();
            ctx.Tikers = db.Tikers.Local.ToList();
            DataContext = ctx;
        }
        void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
