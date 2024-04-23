using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caravan
{
    public class Caravan
    {
        public int CaravanId { get; set; }
        public ICollection<Wagon> WagonList { get; set; }
    }
}
