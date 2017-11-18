using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mycontact
{
   public class MobileUserContact
    {
        public string DisplayName { get; set; }
        public ImageSource imagesource { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public bool ImageCheck { get; set; }
        
    }
}

