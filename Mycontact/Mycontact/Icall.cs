using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mycontact
{
    public interface Icall
    {
        Task<List<MobileUserContact>> GetAllContact();

        void Editcontact();
    }
}
