using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManagement.Business.Abstract
{
    public interface IUserDetailSercive
    {
        UserDetailViewDto Get(int userID);
    }
}
