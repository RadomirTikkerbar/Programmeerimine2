using KooliProjekt.WpfApp.Api;
using System.Windows;

namespace KooliProjekt.WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Loaded += MainWindow_Loaded;

        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var viewModel = new MainWindowViewModel(new ApiClient());
            viewModel.ConfirmDelete = list =>
            {
                var result = MessageBox.Show(
                    "Are you sure you want to delete selected list?",
                    "Delete list",
                    MessageBoxButton.YesNo
                    );

                return result == MessageBoxResult.Yes;
            };

            DataContext = viewModel;

            await viewModel.Load();
        }
    }
}