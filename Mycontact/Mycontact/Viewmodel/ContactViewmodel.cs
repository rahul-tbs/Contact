using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Mycontact.Viewmodel
{
    public class ContactViewmodel : INotifyPropertyChanged
    {
        ContactData contact = new ContactData();
        List<MobileUserContact> TempDatalist = new List<MobileUserContact>();
        public ContactViewmodel()
        {
            ClickCommand = new Command(ClickedMethod);
            EmailCommand = new Command(EnailClickCommand);
            PhoneCommand = new Command(PhoneClickCommand);
            ImageCommand = new Command(ImageClickCommand);
        }

        public ICommand ClickCommand
        {
            get;
            private set;
        }

        public ICommand EmailCommand
        {
            get;
            private set;
        }
        public ICommand PhoneCommand
        {
            get;
            private set;
        }
        public ICommand ImageCommand
        {
            get;
            private set;
        }

        private async void ClickedMethod()
        {
            try
            {
                ContactData contact = new ContactData();
                if (TempDatalist.Count > 0)
                {
                    TempDatalist.Clear();
                }
                TempDatalist = await contact.Fetchdata();
                myContactList = TempDatalist;
                NotifyPropertyChanged("MyContactList");
            }
            catch (Exception ex)
            {
            }

        }

        private async void EnailClickCommand()
        {
            
            _isRunning = true;
            _isEnable = true;
            NotifyPropertyChanged("isRunning");
            NotifyPropertyChanged("isEnable");
            myContactList = TempDatalist;
            myContactList = myContactList.Where(s => !string.IsNullOrEmpty(s.Email) && string.IsNullOrEmpty(s.PhoneNumber)).ToList();
            _isRunning = false;
            NotifyPropertyChanged("isRunning");
            NotifyPropertyChanged("MyContactList");
        }
        private async void PhoneClickCommand()
        {
            _isRunning = true;
            _isEnable = true;
            NotifyPropertyChanged("isRunning");
            NotifyPropertyChanged("isEnable");
            myContactList = TempDatalist;
            myContactList = myContactList.Where(s => !string.IsNullOrEmpty(s.PhoneNumber) && string.IsNullOrEmpty(s.Email)).ToList();
            _isRunning = false;
            NotifyPropertyChanged("isRunning");
            NotifyPropertyChanged("MyContactList");
        }
        private async void ImageClickCommand()
        {
            _isRunning = true;
            _isEnable = true;
            NotifyPropertyChanged("isRunning");
            NotifyPropertyChanged("isEnable");
            myContactList = TempDatalist;
            myContactList = myContactList.Where(s => (s.ImageCheck==false)).ToList();
            _isRunning = false;
            NotifyPropertyChanged("isRunning");
            NotifyPropertyChanged("MyContactList");
        }

        private List<MobileUserContact> myContactList = new List<MobileUserContact>();

        public List<MobileUserContact> MyContactList
        {
            get
            {
                return myContactList;
            }
            set
            {
                myContactList = value;
                NotifyPropertyChanged("MyContactList");
            }
        }

        private bool _isRunning;

        public bool isRunning
        {
            get { return _isRunning; }
            set
            {
                isRunning = value;
                NotifyPropertyChanged("isRunning");
            }
        }
        private bool _isEnable;

        public bool isEnable
        {
            get { return _isEnable; }
            set
            {
                isEnable = value;
                NotifyPropertyChanged("isEnable");
            }
        }
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}