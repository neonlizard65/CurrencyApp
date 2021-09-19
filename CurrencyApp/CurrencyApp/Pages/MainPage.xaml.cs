using Xamarin.Forms;


namespace CurrencyApp
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            CurrentPage = Children[1];
            
        }

    }
}
