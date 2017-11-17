using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mycontact
{
   public class ContactData
    {
        public async Task<List<MobileUserContact>> Fetchdata()
        {
          var result = await DependencyService.Get<Icall>().GetAllContact();

          return result;
        }
    }
}
