using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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

        [ObservableProperty]
        private string hexString = string.Empty;

        [ObservableProperty]
        private string total = string.Empty;

        [RelayCommand]
        private void SumHEX()
        {
            List<string> splitHexStrings = HexString.Split(new char[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            List<string> hexStrings = new();
            foreach (string hexValue in splitHexStrings)
            {
                string paddingedHex = (hexValue.Length % 2 == 1) ? "0" +  hexValue : hexValue;

                for (int start = 0; start < paddingedHex.Length; start += 2)
                {
                    hexStrings.Add(paddingedHex.Substring(start, 2));
                }
            }

            string canonicalizeHexString = string.Join(" ", hexStrings);
            List<int> hexValues = canonicalizeHexString.Split(new char[] { ' ' })
                                                       .Select(h => Convert.ToInt32(h, 16))
                                                       .ToList();
            int total = hexValues.Sum();
            Total = "16進数 : " + total.ToString("X2") + " / 10進数 : " + total.ToString();
        }
    }
}
