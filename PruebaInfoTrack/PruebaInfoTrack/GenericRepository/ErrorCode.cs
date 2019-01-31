using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaInfoTrack.GenericRepository
{
    public class ErrorCode
    {

        public string Error(string msj)
        {
            if (msj.Contains("SQL"))
            {
                return "0100";
            }
            else if (msj.Contains("Timeout"))
            {
                return "0200";
            }
            else if (msj.Contains("Object reference not set to an instance") || msj.Contains("System.Linq.Enumerable.First")
                || msj.Contains("with the REFERENCE constraint"))
            {
                return "0400";
            }
            return "0900";
        }
    }
}
