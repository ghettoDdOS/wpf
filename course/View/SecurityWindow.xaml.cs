using course.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Microsoft.EntityFrameworkCore;

namespace course.View
{
    public class SecurityContext
    {
        public Security security { get; set; }
        public List<FinAsset> finAssets { get; set; }
    }
    /// <summary>
    /// Логика взаимодействия для SecurityWindow.xaml
    /// </summary>
    public partial class SecurityWindow : Window
    {
        ApplicationContext db = new ApplicationContext();
        public SecurityContext ctx { get; private set; } = new SecurityContext();
        public SecurityWindow(Security security)
        {
            InitializeComponent();

            ctx.security = security;
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
