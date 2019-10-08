using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MangagawaPH.ViewModel;
namespace MangagawaPH
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        LoginViewModel loginViewModel;
        public MainPage()
        {
            loginViewModel = new LoginViewModel();
            InitializeComponent();
            BindingContext = loginViewModel;
        }       
    }
}
