using System.Windows;

namespace TempCleanner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Cleaner _cleaner = new Cleaner();

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = _cleaner;
        }

        private void CleanButton_Click(object sender, RoutedEventArgs e) => this._cleaner.Clean();
    }
}
