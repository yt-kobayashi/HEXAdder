using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HEXAdder.ViewModels
{
    [INotifyPropertyChanged]
    public partial class MainWindowViewModel
    {
        [ObservableProperty]
        private string windowTitle = "HEX 加算器";
    }
}
