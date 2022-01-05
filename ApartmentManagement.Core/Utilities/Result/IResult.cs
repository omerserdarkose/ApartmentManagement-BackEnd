using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManagement.Core.Utilities.Result
{
    public interface IResult
    {
        bool Success { get; set; }
        string Message { get; set; }
    }
}
