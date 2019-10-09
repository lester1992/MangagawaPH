using MangagawaPH.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MangagawaPH.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        SignUpVM signUpVM;
        public SignUpPage()
        {            
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            signUpVM = new SignUpVM();            
            BindingContext = signUpVM;
            
        }
    }
}