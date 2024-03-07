using LogBook.LogBookCore.ViewModels;

namespace LogBook.LogBookApp
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();
            this.BindingContext = viewModel;
        }

        
    }

}
