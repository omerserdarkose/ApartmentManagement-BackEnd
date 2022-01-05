using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManagement.Core.Utilities.Result
{
    /// <summary>
    /// data donusu olmayan sadece isleme dair sonucu bildirirken kullanilacak result yapisi
    /// sadece success durumu donebilir veya hem success durumu hemde mesaj donebilir
    /// </summary>
    public class Result : IResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public Result(bool success, string message):this(success)
        {
            Message = message;
        }

        public Result(bool success)
        {
            Success = success;
        }

        
    }
}
