using course.ViewModel;
using System.Windows.Controls;

namespace course.View
{
    /// <summary>
    /// Логика взаимодействия для BondListWindow.xaml
    /// </summary>
    public partial class BondListWindow : Page
    {
        public BondListWindow()
        {
            InitializeComponent();
            DataContext = new BondViewModel();
        }
    }
}
