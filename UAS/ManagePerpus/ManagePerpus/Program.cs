using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagePerpus
{
    public class Program
    {
        static void Main(string[] args)
        {
            Perpustakaan perpustakaan = new Perpustakaan();

            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("+========================================+");
                Console.WriteLine("|      Sistem Manajemen Perpustakaan     |");
                Console.WriteLine("+========================================+");
                Console.WriteLine("|1. Lihat Koleksi Buku                   |");
                Console.WriteLine("|2. Tambah Buku                          |");
                Console.WriteLine("|3. Pinjam Buku                          |");
                Console.WriteLine("|4. Kembalikan Buku                      |");
                Console.WriteLine("|5. Keluar                               |");
                Console.WriteLine("+========================================+");
                Console.Write("|      Masukkan Pilihan Anda :           ");
                Console.WriteLine("|");
                Console.WriteLine("+========================================+");

                Console.SetCursorPosition(31, 9);

                string pilihan = Console.ReadLine();

                switch (pilihan)
                {
                    case "1":
                        TampilKoleksi(perpustakaan);
                        break;
                    case "2":
                        TambahItem(perpustakaan);
                        break;
                    case "3":
                        PinjemBuku(perpustakaan);
                        break;
                    case "4":
                        BalikinBuku(perpustakaan);
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Pilihan tidak valid. Coba lagi.");
                        break;
                }
            }
        }
        static void TampilKoleksi(Perpustakaan perpustakaan)
        {
            Console.Clear();
            Console.WriteLine("+==============================================================================+");
            Console.WriteLine("|                             Koleksi Perpustakaan                             |");
            Console.WriteLine("|==============================================================================|");
            var items = perpustakaan.GetItems();
            if (items.Count == 0)
            {
                Console.WriteLine("Belum Ada Buku di Perpustakaan");
            }
            else
            {
                Console.WriteLine("| No |         Judul         |       Penulis       | Dipinjam |     Detail     |");
                Console.WriteLine("|----|-----------------------|---------------------|----------|----------------|");
                int nomor = 1;
                foreach (var item in items)
                {
                    string detail = GetItemDetail(item);
                    Console.WriteLine($"| {nomor,-2} | {item.Judul,-21} | {item.Penulis,-19} | {item.IsDipinjam,-8} | {detail,-14} |");
                    nomor++;
                }
            }
            Console.WriteLine("Tekan tombol apapun untuk kembali ke menu utama...");
            Console.ReadKey();
        }
        static string GetItemDetail(PerpusItem item)
        {
            if (item is Buku)
            {
                Buku buku = (Buku)item;
                return $"Jml Hal = {buku.Halaman}";
            }
            else if (item is Majalah)
            {
                Majalah majalah = (Majalah)item;
                return $"Tema {majalah.Tema}";
            }
            else if (item is Kamus)
            {
                Kamus kamus = (Kamus)item;
                return $"kms bhs {kamus.Bahasa}";
            }
            else if (item is BukuPljran)
            {
                BukuPljran bukuPljran = (BukuPljran)item;
                return $"Buku Kelas {bukuPljran.Kelas}";
            }
            return string.Empty;
        }
        static void TambahItem(Perpustakaan perpustakaan)
        {
            Console.Clear();
            Console.WriteLine("+========================================+");
            Console.WriteLine("|        Tambah Buku Perpustakaan        |");
            Console.WriteLine("+========================================+");
            Console.WriteLine("|1. Tambah Buku Umum                     |");
            Console.WriteLine("|2. Tambah Majalah                       |");
            Console.WriteLine("|3. Tambah Kamus                         |");
            Console.WriteLine("|4. Tambah Buku Pelajaran                |");
            Console.WriteLine("+========================================+");
            Console.Write("|      Masukkan Pilihan Anda :           ");
            Console.WriteLine("|");
            Console.WriteLine("+========================================+");

            Console.SetCursorPosition(31, 8);
            string pilihan = Console.ReadLine();
            Console.WriteLine();
            Console.Write("|Masukkan Judul   :                      ");
            Console.WriteLine("|");
            Console.SetCursorPosition(20, 10);
            string judul = Console.ReadLine();
            Console.Write("|Masukkan Penulis :                      ");
            Console.WriteLine("|");
            Console.SetCursorPosition(20, 11);
            string penulis = Console.ReadLine();

            switch (pilihan)
            {
                case "1":
                    Console.Write("|Jumlah Halaman   :                      ");
                    Console.WriteLine("|");
                    Console.SetCursorPosition(20, 12);
                    int halaman = int.Parse(Console.ReadLine());
                    perpustakaan.Additem(new Buku(judul, penulis, halaman));
                    break;
                case "2":
                    Console.Write("|Tema Majalah     :                      ");
                    Console.WriteLine("|");
                    Console.SetCursorPosition(20, 12);
                    string tema = Console.ReadLine();
                    perpustakaan.Additem(new Majalah(judul, penulis, tema));
                    break;
                case "3":
                    Console.Write("|Bahasa Kamus     :                      ");
                    Console.WriteLine("|");
                    Console.SetCursorPosition(20, 12);
                    string bahasa = Console.ReadLine();
                    perpustakaan.Additem(new Kamus(judul, penulis, bahasa));
                    break;
                case "4":
                    Console.Write("|Buku kelas       :                      ");
                    Console.WriteLine("|");
                    Console.SetCursorPosition(20, 12);
                    string kelas = Console.ReadLine();
                    perpustakaan.Additem(new BukuPljran(judul, penulis, kelas));
                    break;
                default:
                    Console.WriteLine("Pilihan tidak valid.");
                    break;
            }
            Console.WriteLine("+========================================+");
            Console.WriteLine("|       Buku Berhasil DI Tambahkan       |");
            Console.WriteLine("+========================================+");
            Console.WriteLine("Tekan tombol apapun untuk kembali ke menu utama...");
            Console.ReadKey();
        }
        static void PinjemBuku(Perpustakaan perpustakaan)
        {
            Console.Clear();
            Console.WriteLine("+==============================================================================+");
            Console.WriteLine("|                             Koleksi Perpustakaan                             |");
            Console.WriteLine("|==============================================================================|");
            var items = perpustakaan.GetItems();
            if (items.Count == 0)
            {
                Console.WriteLine("Belum Ada Buku di Perpustakaan");
            }
            else
            {
                Console.WriteLine("| No |         Judul         |       Penulis       | Dipinjam |     Detail     |");
                Console.WriteLine("|----|-----------------------|---------------------|----------|----------------|");
                int nomor = 1;
                foreach (var item in items)
                {
                    string detail = GetItemDetail(item);
                    Console.WriteLine($"| {nomor,-2} | {item.Judul,-21} | {item.Penulis,-19} | {item.IsDipinjam,-8} | {detail,-14} |");
                    nomor++;
                }
                Console.WriteLine("+==============================================================================+");
                Console.Write("Masukkan nomor Buku yang ingin dipinjam: ");
                int index = int.Parse(Console.ReadLine()) - 1;
                if (index >= 0 && index < items.Count)
                {
                    items[index].Pinjem();
                }
                else
                {
                    Console.WriteLine("Nomor item tidak valid.");
                }
            }
            Console.WriteLine("Tekan tombol apapun untuk kembali ke menu utama...");
            Console.ReadKey();
        }
        static void BalikinBuku(Perpustakaan perpustakaan)
        {
            Console.Clear();
            Console.WriteLine("+==============================================================================+");
            Console.WriteLine("|                             Koleksi Perpustakaan                             |");
            Console.WriteLine("|==============================================================================|");
            var items = perpustakaan.GetItems();
            if (items.Count == 0)
            {
                Console.WriteLine("Belum Ada Buku di Perpustakaan");
            }
            else
            {
                Console.WriteLine("| No |         Judul         |       Penulis       | Dipinjam |     Detail     |");
                Console.WriteLine("|----|-----------------------|---------------------|----------|----------------|");
                int nomor = 1;
                foreach (var item in items)
                {
                    string detail = GetItemDetail(item);
                    Console.WriteLine($"| {nomor,-2} | {item.Judul,-21} | {item.Penulis,-19} | {item.IsDipinjam,-8} | {detail,-14} |");
                    nomor++;
                }
                Console.WriteLine("+==============================================================================+");
                Console.Write("Masukkan nomor item yang ingin dikembalikan: ");
                int index = int.Parse(Console.ReadLine()) - 1;
                if (index >= 0 && index < items.Count)
                {
                    items[index].Balikin();
                }
                else
                {
                    Console.WriteLine("Nomor item tidak valid.");
                }
            }
            Console.WriteLine("Tekan tombol apapun untuk kembali ke menu utama...");
            Console.ReadKey();
        }
    }
}