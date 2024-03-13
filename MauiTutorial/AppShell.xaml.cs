namespace MauiTutorial
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Yeni Sayfaları Tanımlıyoruz
            Routing.RegisterRoute(nameof(DetailPage), typeof(DetailPage));
        }
    }
}
