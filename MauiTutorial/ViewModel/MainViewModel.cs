using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MauiTutorial.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {
            Items = new ObservableCollection<string>();
        }
        [ObservableProperty]
        ObservableCollection<string> items;

        [ObservableProperty]
        string text;

        [RelayCommand]
        void add()
        {
            if (string.IsNullOrWhiteSpace(Text))
                return;
            Items.Add(Text);
            // add Item
            Text = string.Empty;
        }

        [RelayCommand]
        void Delete(string datavalue)
        {
            if (Items.Contains(datavalue))
            {
                Items.Remove(datavalue);
            }
        }
    }
}
