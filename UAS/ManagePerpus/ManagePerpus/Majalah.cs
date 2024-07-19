using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagePerpus
{
    class Majalah : PerpusItem
    {
        public string Tema {  get; set; }

        public Majalah(string judul, string penulis, string tema) : base(judul, penulis)
        {
            Tema = tema;
        }
        public override void Pinjem()
        {
            base.Pinjem();
        }
        public override void Balikin()
        {
            base.Balikin();
        }
        public override string ToString()
        {
            return base.ToString() + $", Tema : {Tema}";
        }
    }
}
