using OdzeliNote.Manager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdzeliNote.Manager.Abstract
{
    public interface IUserManager
    {
        User GetUser(Guid id);

        User Create(User user);

        Guid Delete(Guid id);
    }
}
