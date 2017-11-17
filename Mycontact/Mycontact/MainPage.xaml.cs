using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mycontact
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            ContactData contact = new ContactData();
            ListViewContact.ItemsSource = Task.Run((async () => await contact.Fetchdata())).Result;
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            DependencyService.Get<Icall>().Editcontact();
        }
    }
}
