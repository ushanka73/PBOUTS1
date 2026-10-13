using System;
using System.Collections.Generic;

namespace ManajemenPerusahaan
{
    public class Karyawan
    {
        public string Nama;
        public double Gaji;

        public Karyawan(string nama, double gaji)
        {
            Nama = nama;
            Gaji = gaji;
        }
        public virtual void Kerja()
        {
            Console.WriteLine($"{Nama} sedang bekerja.");
        }
        public virtual void InfoKaryawan()
        {
            Console.WriteLine($"Karyawan {Nama} memiliki Gaji: {Gaji}");
        }
    }
    public class Tetap : Karyawan
    {
        public double Tunjangan;
        public Tetap(string nama, double gaji, double tunjangan) : base(nama, gaji)
        {
            Tunjangan = tunjangan;
        }
        public double HitungGajiTotal()
        {
            return Gaji + Tunjangan;
        }
        public override void InfoKaryawan()
        {
            base.InfoKaryawan();
            Console.WriteLine($"{Nama} Karyawan Tetap, Tunjangan: {Tunjangan}, Total Gaji: {HitungGajiTotal()}");
        }
    }
    public class Kontrak : Karyawan
    {
        public int Durasi;
        public Kontrak(string nama, double gaji, int durasi) : base(nama, gaji)
        {
            Durasi = durasi;
        }
        public void CekKontrak()
        {
            Console.WriteLine($"Kontrak {Nama} berlaku selama {Durasi} bulan.");
        }
        public override void InfoKaryawan()
        {
            base.InfoKaryawan();
            Console.WriteLine($"Status: Karyawan Kontrak, Durasi: {Durasi} bulan");
        }
    }
    public class Manager : Tetap
    {
        public Manager(string nama, double gaji, double tunjangan) : base(nama, gaji, tunjangan) { }
        public void Memimpin()
        {
            Console.WriteLine($"{Nama} seorang Manager.");
        }
        public override void Kerja()
        {
            Console.WriteLine($"{Nama} sedang mengawasi kinerja tim.");
        }
    }
    public class Staff : Tetap
    {
        public Staff(string nama, double gaji, double tunjangan) : base(nama, gaji, tunjangan) { }
        public void KerjakanTugas()
        {
            Console.WriteLine($"{Nama} sedang menyelesaikan tugas.");
        }
        public override void Kerja()
        {
            Console.WriteLine($"{Nama} sedang mengeksekusi tugas.");
        }
    }
    public class Magang : Kontrak
    {
        public Magang(string nama, double gaji, int durasi) : base(nama, gaji, durasi) { }
        public void Belajar()
        {
            Console.WriteLine($"{Nama} sedang belajar skill baru.");
        }
        public override void Kerja()
        {
            Console.WriteLine($"{Nama} sedang membantu tim.");
        }
    }
    public class Freelancer : Kontrak
    {
        public Freelancer(string nama, double gaji, int durasi) : base(nama, gaji, durasi) { }
        public void AmbilProyek()
        {
            Console.WriteLine($"{Nama} sedang mengambil proyek lepas baru.");
        }
        public override void Kerja()
        {
            Console.WriteLine($"{Nama} sedang mengerjakan proyek sesuai deadline.");
        }
    }
    public class Perusahaan
    {
        public string NamaPerusahaan { get; set; }
        private List<Karyawan> daftarKaryawan = new List<Karyawan>();
        public Perusahaan(string namaPerusahaan)
        {
            NamaPerusahaan = namaPerusahaan;
        }
        public void TambahKaryawan(Karyawan karyawan)
        {
            daftarKaryawan.Add(karyawan);
            Console.WriteLine($"- {karyawan.Nama} berhasil ditambahkan!");
        }
        public void DaftarKaryawan()
        {
            Console.WriteLine($"--- DAFTAR KARYAWAN {NamaPerusahaan.ToUpper()} ---");
            if (daftarKaryawan.Count == 0)
            {
                Console.WriteLine("Belum ada karyawan terdaftar.");
                return;
            }
            foreach (var karyawan in daftarKaryawan)
            {
                karyawan.InfoKaryawan();
            }
        }
        public List<Karyawan> GetDaftarKaryawan()
        {
            return daftarKaryawan;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Perusahaan MulyamovicInd = new Perusahaan("Mulyamovic Industries");
            Console.WriteLine("--- Proses Rekrutmen ---");
            Manager Manager1 = new Manager("Ushanka Mulyamovic", 15000000, 3000000);
            Staff Staff1 = new Staff("Alexey Kurchatov", 7000000, 1500000);
            Magang Magang1 = new Magang("Genady Zyuganov", 2000000, 3);
            Freelancer Freelance1 = new Freelancer("Niko Bellic", 5000000, 6);
            Karyawan kar1 = new Staff("Alekesei", 1000000, 100000);

            MulyamovicInd.TambahKaryawan(Manager1);
            MulyamovicInd.TambahKaryawan(Staff1);
            MulyamovicInd.TambahKaryawan(Magang1);
            MulyamovicInd.TambahKaryawan(Freelance1);
            MulyamovicInd.TambahKaryawan(kar1);
            Console.WriteLine("");
            MulyamovicInd.DaftarKaryawan();

            Console.WriteLine("\n--- Status Kegiatan Pekerjaan ---");
            foreach (Karyawan k in MulyamovicInd.GetDaftarKaryawan())
            {
                k.Kerja();
            }

            Console.WriteLine("\n--- Kegiatan ---");
            Manager1.Memimpin();
            Staff1.KerjakanTugas();
            Magang1.Belajar();
            Freelance1.AmbilProyek();

            Console.WriteLine("\n--- Status Kontrak ---");
            Console.WriteLine($"Total Gaji {Manager1.Nama} adalah Rp {Manager1.HitungGajiTotal()}");
            Magang1.CekKontrak();
            Freelance1.CekKontrak();

            Console.ReadLine();
        }
    }
}