using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagePerpus
{
    class Perpustakaan
    {
        private List<PerpusItem> items = new List<PerpusItem>();

        public void Additem(PerpusItem item)
        {
            items.Add(item);
        }
        public List<PerpusItem> GetItems() 
        { 
            return items; 
        }
    }
}
