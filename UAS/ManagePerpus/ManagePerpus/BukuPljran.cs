using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagePerpus
{
    class BukuPljran : PerpusItem
    {
        public string Kelas {  get; set; }
        public BukuPljran(string judul, string penulis, string kelas) : base (judul, penulis) 
        {
            Kelas = kelas;
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
            return base.ToString() + $", Buku untuk Kelas : {Kelas}";
        }
    }
}
