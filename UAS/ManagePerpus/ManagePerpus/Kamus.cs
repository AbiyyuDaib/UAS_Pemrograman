using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagePerpus
{
    class Kamus : PerpusItem
    {
        public string Bahasa {  get; set; }
        public Kamus(string judul, string penulis, string bahasa) : base(judul, penulis)
        {
            Bahasa = bahasa;
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
            return base.ToString() + $", Bahasa : {Bahasa}";
        }
    }
}
