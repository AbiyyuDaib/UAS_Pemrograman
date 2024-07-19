using System;

namespace ManagePerpus
{
    abstract class PerpusItem : IPinjaman
    {
        public string Judul { get; set; }
        public string Penulis { get; set; }
        public bool IsDipinjam { get; set; }

        public PerpusItem(string judul, string penulis)
        {
            Judul = judul;
            Penulis = penulis;
            IsDipinjam = false;
        }

        public virtual void Pinjem()
        {
            if (!IsDipinjam)
            {
                IsDipinjam = true;
                Console.WriteLine($"Yeayyyy!!!, Buku dengan judul {Judul} berhasil dipinjam");
            }
            else
            {
                Console.WriteLine($"Mohon Maaf Buku dengan judul {Judul} sedang dipinjam");
            }
        }

        public virtual void Balikin()
        {
            if (IsDipinjam)
            {
                IsDipinjam = false;
                Console.WriteLine($"Yeayyyy!!!, Buku dengan judul {Judul} berhasil dikembalikan");
            }
            else
            {
                Console.WriteLine($"Mohon Maaf Buku dengan judul {Judul} tidak sedang dipinjam");
            }
        }

        public override string ToString()
        {
            return $"Judul : {Judul}, Penulis : {Penulis}";
        }
    }
}
