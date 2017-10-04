using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SerializersComparison.Models;

namespace SerializersComparison.DAL
{
    public interface ILarRepository  
    {
        IEnumerable<HmdfEntity> GetHmdfRows(int count);

    }
}
