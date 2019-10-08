using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MangagawaPH.Models;
namespace MangagawaPH.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FindJobs : ContentPage
    {
        public FindJobs()
        {
            InitializeComponent();
            MainListView.ItemsSource = new List<ListViewTemplate>
            {
            new ListViewTemplate
                {
                    Name = "Xamarin.Forms",
                    Position = "One",
                    Image = ""
               },
               new ListViewTemplate
               {
                   Name = "Xamarin.Forms",
                   Position = "One",
                   Image = ""
                }
           };
        }
        async private void MainListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var Selected = e.Item as ListViewTemplate;

            /*switch (Selected.OrderNumber)
            {
                case 1:
                    await Navigation.PushAsync(new Page1());
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
            }*/
            await Navigation.PushAsync(new MyProfile()).ConfigureAwait(false);
            //((ListView)sender).SelectedItem = null;


        }
    }
}