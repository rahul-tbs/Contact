using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mycontact.Viewmodel;
using Xamarin.Forms;

namespace Mycontact
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            ContactViewmodel contactViewmodel = new ContactViewmodel();
            BindingContext = contactViewmodel;
            //MyIndicator.IsRunning = false;
            //MyIndicator.IsEnabled = false;
        }

        //private void Button_OnClicked(object sender, EventArgs e)
        //{
        //    MyIndicator.IsRunning = true;
        //    MyIndicator.IsEnabled = true;
        //    ContactData contact = new ContactData();

        //    var data = Task.Run((async () => await contact.Fetchdata())).Result;
        //    ListViewContact.ItemsSource = data;
        //    MyIndicator.IsRunning = false;
        //    MyIndicator.IsEnabled = false;
        //}
    }
}

