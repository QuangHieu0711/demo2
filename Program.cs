using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Lab2
{
    class PHO
    {
        private float thit, banh, hanh;

        public PHO()
        {
            this.thit = this.banh = this.hanh = 0;
        }

        public PHO(float thit, float banh, float hanh)
        {
            this.thit = thit;
            this.banh = banh;
            this.hanh = hanh;
        }

        public float getTinhtien()
        {
            return this.thit * 15000 + this.banh * 10000 + this.hanh * 2000;
        }

        public void xuat()
        {
            Console.WriteLine($"{this.thit}\t{this.banh}\t{this.hanh}\t{this.getTinhtien()}");
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            PHO[] dsPHO = new PHO[5];
            for (int i = 0; i < dsPHO.Length; i++)
            {
                try
                {
                    Console.WriteLine("Nhap du lieu cho bat pho thu " + (i + 1) + ":");
                    dsPHO[i] = NhapPho();
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine("Loi: " + ex.Message);
                    Console.WriteLine("Chuong trinh se ket thuc.");
                    return;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Loi: " + ex.Message);
                    Console.WriteLine("Vui long nhap lai.");
                    i--; // Nhập lại giá trị cho i
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Loi: " + ex.Message);
                    Console.WriteLine("Chuong trinh se ket thuc.");
                    return;
                }
            }

            Console.WriteLine();

            Console.WriteLine("Thong tin 5 bat pho vua nhap la:");
            Console.WriteLine("STT\tThit\tBanhpho\tHanh\tThanhtien");
            for (int i = 0; i < dsPHO.Length; i++)
            {
                Console.Write($"{i + 1}\t");
                dsPHO[i]?.xuat(); // Kiểm tra trước khi gọi phương thức xuat()
            }
            Console.WriteLine();

            // Hienthi MIN
            try
            {
                PHO phoGiaNhoNhat = TimPhoGiaNhoNhat(dsPHO);
                Console.WriteLine($"Bat pho thu {Array.IndexOf(dsPHO, phoGiaNhoNhat) + 1} co gia tri thap nhat la {phoGiaNhoNhat.getTinhtien()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi: " + ex.Message);
            }

            // Hienthi MAX
            try
            {
                PHO phoGiaCaoNhat = TimPhoGiaCaoNhat(dsPHO);
                Console.WriteLine($"Bat pho thu {Array.IndexOf(dsPHO, phoGiaCaoNhat) + 1} co gia tri cao nhat la {phoGiaCaoNhat.getTinhtien()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi: " + ex.Message);
            }

            Console.ReadLine();
        }

        static PHO NhapPho()
        {
            Console.Write("Luong thit = ");
            float thit;
            if (!float.TryParse(Console.ReadLine(), out thit))
                throw new FormatException("Loi: Du lieu nhap khong hop le.");

            Console.Write("Luong banh pho = ");
            float banh;
            if (!float.TryParse(Console.ReadLine(), out banh))
                throw new FormatException("Loi: Du lieu nhap khong hop le.");

            Console.Write("Luong hanh = ");
            float hanh;
            if (!float.TryParse(Console.ReadLine(), out hanh))
                throw new FormatException("Loi: Du lieu nhap khong hop le.");

            return new PHO(thit, banh, hanh);
        }

        static PHO TimPhoGiaCaoNhat(PHO[] dsPho)
        {
            if (dsPho.Length == 0)
                throw new Exception("Mang dsPho khong co phan tu nao.");

            PHO phoGiaCaoNhat = dsPho[0];
            foreach (var pho in dsPho)
            {
                if (pho.getTinhtien() > phoGiaCaoNhat.getTinhtien())
                {
                    phoGiaCaoNhat = pho;
                }
            }
            return phoGiaCaoNhat;
        }

        static PHO TimPhoGiaNhoNhat(PHO[] dsPho)
        {
            if (dsPho.Length == 0)
                throw new Exception("Mang dsPho khong co phan tu nao.");

            PHO phoGiaNhoNhat = dsPho[0];
            foreach (var pho in dsPho)
            {
                if (pho.getTinhtien() < phoGiaNhoNhat.getTinhtien())
                {
                    phoGiaNhoNhat = pho;
                }
            }
            return phoGiaNhoNhat;
        }
    }

}