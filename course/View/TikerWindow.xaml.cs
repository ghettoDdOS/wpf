using course.Models;
using System.Windows;

namespace course.View
{
    /// <summary>
    /// Логика взаимодействия для TikerWindow.xaml
    /// </summary>
    public partial class TikerWindow : Window
    {
        public Tiker Tiker { get; private set; }
        public TikerWindow(Tiker tiker)
        {
            InitializeComponent();
            Tiker = tiker;
            DataContext = Tiker;
        }

        void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
