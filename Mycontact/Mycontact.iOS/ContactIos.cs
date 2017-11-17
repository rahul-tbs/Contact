using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Mycontact.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(ContactIos))]
namespace Mycontact.iOS
{
   public class ContactIos : Icall
    {
        public readonly Xamarin.Contacts.AddressBook _book;
        public static List<MobileUserContact> _contacts = new List<MobileUserContact>();
        public ContactIos()
        {
            _book = new Xamarin.Contacts.AddressBook();
        }

        public async Task<List<MobileUserContact>> GetAllContact()
        {

            var contacts = new List<MobileUserContact>();
            await _book.RequestPermission().ContinueWith(t =>
            {
                if (!t.Result)
                {
                    Console.WriteLine("Sorry ! Permission was denied by user or manifest !");
                    return;
                }
                foreach (var contact in _book.ToList())
                {
                    var phone = contact.Phones.FirstOrDefault();
                    var email = contact.Emails.FirstOrDefault();
                    var image = contact.GetThumbnail();
                    var myMobileUserContact = new MobileUserContact();
                    if (image != null)
                    {
                        var imageData = image.AsPNG().ToArray();
                        myMobileUserContact.imagesource = ImageSource.FromStream(() => new MemoryStream(imageData));
                    }
                    else
                    {
                        myMobileUserContact.imagesource = "avatar.png";
                    }
                    myMobileUserContact.DisplayName = contact.DisplayName;
                    myMobileUserContact.PhoneNumber = phone != null ? phone.Number : string.Empty;
                    myMobileUserContact.Email = email != null ? email.Address : string.Empty;
                    _contacts.Add(myMobileUserContact);
                    //_contacts.Add(new MobileUserContact()
                    //{
                    //   DisplayName = contact.DisplayName,
                    //   PhoneNumber = phone!=null ? phone.Number : string.Empty,
                    //   Email = email!=null ? email.Address : string.Empty,

                    //});
                }
            });
            //contacts = (from c in contacts orderby c.DisplayName select c).ToList();

            return _contacts;
        }

        public void Editcontact()
        {
           
        }
    }
}