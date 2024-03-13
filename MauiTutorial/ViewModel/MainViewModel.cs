using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MauiTutorial.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        IConnectivity connectivity;
        public MainViewModel(IConnectivity connectivity)
        {
            Items = new ObservableCollection<string>();
            this.connectivity = connectivity;
        }
        [ObservableProperty]
        ObservableCollection<string> items;

        [ObservableProperty]
        string text;

        [RelayCommand]
        async Task add()
        {
            if (string.IsNullOrWhiteSpace(Text))
                return;
            if (connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Shell.Current.DisplayAlert("Hay Aksi!", "İnternet Baglantısı Yok!", "OK");
                return;
            }
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

        // New added
        [RelayCommand]
        async Task Tap(string s)
        {
            await Shell.Current.GoToAsync($"{nameof(DetailPage)}?Text={s}");
        }
    }
}
