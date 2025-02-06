using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Library.Interface
{
    public interface IFlightMethods
    {
        List<DateTime> GetFlightDate(string destination);
    }
}
