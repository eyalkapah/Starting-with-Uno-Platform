using UnoApp.Shared.Services;
using UnoApp.Shared.ViewModels;
using UnoApp.Shared.Views;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UnoApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPageViewModel ViewModel => DataContext as MainPageViewModel;

        public MainPage()
        {
            this.InitializeComponent();

            DataContext = IoC.Resolve<MainPageViewModel>();

            var navigationService = IoC.Resolve<INavigationService>();
            navigationService.SetContentFrame(MyContentFrame);
        }

        private void NavigationViewItem_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            var navigationService = IoC.Resolve<INavigationService>();

            navigationService.Navigate<ViewAPage>();
        }
    }
}