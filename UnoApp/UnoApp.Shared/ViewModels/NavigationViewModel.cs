using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnoApp.Shared.ViewModels
{
    public class NavigationViewModel : ViewModelBase
    {
        public virtual void OnNavigatedTo(object parameter)
        {
        }

        internal virtual void OnNavigatedFrom(object parameter)
        {
        }
    }
}