using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnoApp.Shared.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace UnoApp.Shared.Views
{
    public partial class BasePage : Page
    {
        private NavigationViewModel _dataContext => DataContext as NavigationViewModel;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _dataContext?.OnNavigatedTo(e.Parameter);
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            _dataContext?.OnNavigatedFrom(e.Parameter);
        }
    }
}