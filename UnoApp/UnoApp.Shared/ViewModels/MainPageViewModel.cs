using GalaSoft.MvvmLight;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnoApp.Shared.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(IConfiguration config)
        {
            Title = "Hello Eyal";

            var hello = config["Hello"];
        }

        public string Title { get; }
    }
}