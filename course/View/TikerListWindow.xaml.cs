using course.ViewModel;
using System.Windows.Controls;

namespace course.View
{
    /// <summary>
    /// Логика взаимодействия для TikerListWindow.xaml
    /// </summary>
    public partial class TikerListWindow : Page
    {
        public TikerListWindow()
        {
            InitializeComponent();
            DataContext = new TikerViewModel();
        }
    }
}
