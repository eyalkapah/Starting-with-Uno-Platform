using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace UnoApp.Shared.Services
{
    public interface INavigationService
    {
        void SetContentFrame(Frame frame);

        bool Navigate<T>() where T : Page;

        bool Navigate<T>(object parameters) where T : Page;

        void GoBack();
    }
}