using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace UnoApp.Shared.Services
{
    public class NavigationService : INavigationService
    {
        private Frame _frame;
        public void SetContentFrame(Frame frame)
        {
            _frame = frame;
        }

        public void GoBack()
        {
            if (_frame.CanGoBack)
            {
                _frame.GoBack();
            }
        }

        public bool Navigate<T>() where T : Page
        {
            return _frame.Navigate(typeof(T), null);
        }

        public bool Navigate<T>(object parameters) where T : Page
        {
            return _frame.Navigate(typeof(T), parameters);
        }
    }
}