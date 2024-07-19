using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagePerpus
{
    class Buku : PerpusItem
    {
        public int Halaman {  get; set; }

        public Buku(string judul, string penulis, int halaman) : base(judul, penulis)
        {
            Halaman = halaman;
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
            return base.ToString() + $", Halaman : {Halaman}";
        }
    }
}
