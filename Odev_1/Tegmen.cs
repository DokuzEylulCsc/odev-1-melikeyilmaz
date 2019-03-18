using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev
{
    class Tegmen : Asker  //abstract Asker classından alınan kalıtım
    {
        public Tegmen(int grup, int x, int y)  //Teğmenlerimiz için değişkenleri tanımladığımız bir  constructor method 
        {
            Oyungrubu = grup;
            Xkordinati = x;
            Ykordinati = y;
        }

        public override void Bekle()
        {
            Console.WriteLine("Tegmen Bekliyor...");//Bekleme methodunda bir şey olmadığı için ekrana yazı yazdırdım.
        }

        public override void Hareket_Et(Object[,] alan)
        {
            Random random = new Random();   //Rasgele bir değer üretiyoruz.
            bool k1, k2;  //kontrol etmek için kulanılan değişkenlerimiz.
            int yon = random.Next(2);
            int xsans = 0, ysans = 0, atesEtme = random.Next(0,2);
            if (yon == 0)           //teğmenimizin sağa sola gitmesi.
            {
                do
                {
                    do
                    {
                        k1 = true;
                        xsans = random.Next(-1, 2);  //rasgele sayı üretme kısmı
                        if (xsans == 0 && ysans == 0)
                            k1 = false;
                    } while (!k1);

                    if (alan[Xkordinati + xsans, Ykordinati] is Bolge b) //bölgenin içinde olup olmama
                    {
                        Xkordinati = +xsans;
                        k2 = true;
                    }
                    else
                    {
                        Bekle();
                        k2 = true;
                    }
                } while (!k2);
            }
            else  //teğmenimizin yukarı ya da aşağı gitmesi
            {
                do
                {
                    do
                    {
                        k1 = true;
                        ysans = random.Next(-1, 2);
                        if (xsans == 0 && ysans == 0)
                            k1 = false;
                    } while (!k1);

                    if (alan[Xkordinati, Ykordinati + ysans] is Bolge b)
                    {
                        Ykordinati = +ysans;
                        k2 = true;
                    }
                    else
                    {
                        k2 = false;
                    }
                } while (!k2);
            }
            if (atesEtme == 1)
            {
                Ates_Et(alan);
            }
        }

        public override void Ates_Et(Object[,] alan)
        {
            Random random = new Random();
            int sans = random.Next(100);
            for (int i = -2; i < 3; i++)       //2 kare komşusu olan tüm askerleri vuruyor.
                for (int j = -2; j < 3; j++)
                {
                    if (alan[i, j] is Asker a && a.Oyungrubu != this.Oyungrubu)
                    {
                        if (sans < 20)       //ateş etmenin %20 olasılığı
                        {
                            a.can = -25;   //teğmen ateş ettiğinde düşman askerin canının 25 azaltması durumu
                        }
                        else if (sans < 50)     //ateş etmenin %30 olasılığı
                        {
                            a.can = -20;  //teğmen ateş ettiğinde düşman askerin canının 20 azaltması durumu

                        }
                        else   //ateş etmenin %50 olasılığı
                        {
                            a.can = -10;  //teğmen ateş ettiğinde düşman askerin canının 25 azaltması durumu

                        }
                        if (a.can <= 0)  //canlar 0 ın altına düşerse ölen askerin yasam özelliğinin false olması
                        {
                            a.hayat= false;        
                            alan[Xkordinati, Ykordinati + 2] = new Bolge(Xkordinati, Ykordinati + 2);
                        }
                    }
                }
        }
    }
}
