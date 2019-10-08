using MangagawaPH.ViewModel;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MangagawaPH.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMasterDetailPage : MasterDetailPage
    {
        WelcomePageVM welcomePageVM;
        public MainMasterDetailPage(string email, string img, string fullname)
        {
            InitializeComponent();
            welcomePageVM = new WelcomePageVM(email);
            BindingContext = welcomePageVM;
            navigationDrawerList.ItemsSource = GetMasterPageLists();
            MasterPage.BarBackgroundColor = Color.FromHex("fc2c03");
            LblFullname.Text = fullname;
            if (!string.IsNullOrWhiteSpace(img))
            {
                ProfilePic.Source = img;
            }
            else
            {
                ProfilePic.Source = "default_pic.png";
            }
        }
        private void OnMenuSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (MasterPageList)e.SelectedItem;

            if (item.Title == "Settings")
            {
                Detail.Navigation.PushAsync(new SettingPage());
                IsPresented = false;
            }
            else if (item.Title == "Find Work")
            {
                Detail.Navigation.PushAsync(new FindJobs());
                IsPresented = false;
            }
            else if (item.Title == "My Profile")
            {

                Detail.Navigation.PushAsync(new MyProfile());
                IsPresented = false;
            }
            else if (item.Title == "Earn MPH Coin")
            {

                Detail.Navigation.PushAsync(new MyProfile());
                IsPresented = false;
            }
            else
            {
                Detail.Navigation.PushAsync(new MainPage());
                IsPresented = false;
            }
        }
        List<MasterPageList> GetMasterPageLists()
        {
            return new List<MasterPageList>
            {
                new MasterPageList() { Title = "Find Work", Icon = "\uf002" },
                new MasterPageList() { Title = "My Profile", Icon = "\uf508" },
                new MasterPageList() { Title = "Earn MPH Coin", Icon = "\uf4d3" },
                new MasterPageList() { Title = "Settings", Icon = "\uf085" },
                new MasterPageList() { Title = "Logout", Icon = "\uf2f5" }
            };
        }
    }

    //This class used for binding ListView. We can move it to other separate files as well   
    public class MasterPageList
    {
        public string Title { get; set; }
        public string Icon { get; set; }
    }
}
