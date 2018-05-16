using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseSelection.Authorize
{
    public interface IAuthorizeProvider
    {
        bool Execute(TokenEntity token);
    }
}
