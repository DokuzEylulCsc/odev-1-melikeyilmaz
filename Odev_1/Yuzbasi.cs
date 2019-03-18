using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev
{
    class YuzBasi : Asker  //abstract Asker classından alınan kalıtım
    {
        public YuzBasi(int grup, int x, int y) //Yüzbaşımız için değişkenleri tanımladığımız bir  constructor method 
        {
            Oyungrubu = grup;
            Xkordinati = x;
            Ykordinati = y;
        }
        public override void Bekle()
        {
            Console.WriteLine("Yuzbasi Bekliyor...");//Bekleme methodunda bir şey olmadığı için ekrana yazı yazdırdım.
        }
        public override void Hareket_Et(Object[,] alan)
        {
            Random random = new Random();   //Rasgele bir değer üretiyoruz.
            bool k1, k2;  //kontrol etmek için kulanılan değişkenlerimiz.
            int xsans, ysans, atesEtme;
            do
            {
                do
                {
                    k1 = true;
                    xsans = random.Next(-1, 2);  //rasgele sayı üretme kısmı
                    ysans = random.Next(-1, 2);  //rasgele sayı üretme kısmı
                    if (xsans == 0 && ysans == 0)
                        k1 = false;
                } while (!k1);

                if (alan[Xkordinati + xsans, Ykordinati + ysans] is Bolge b) //bölgenin içinde olup olmama
                {
                    Xkordinati = +xsans;
                    Ykordinati = +ysans;
                    k2 = true;
                }
                else
                {
                    Bekle();
                    k2 = true;
                }
            } while (!k2);
            atesEtme = random.Next(0, 2);
            if (atesEtme == 1)
            {
                Ates_Et(alan);
            }
        }
        public override void Ates_Et(Object[,] alan)
        {
            Random random = new Random();
            int sans = random.Next(100);
            for (int i = -3; i < 4; i++)       //3 kare komşusu olan tüm askerleri vuruyor.
                for (int j = -3; j < 4; j++)
                {
                    if (alan[i, j] is Asker a && a.Oyungrubu != this.Oyungrubu)
                    {
                        if (sans < 10)       //10
                        {
                            a.can = -40;       //yüzbaşı ateş ettiğinde düşman askerin canının 40 azaltması durumu
                            Yazdirma.Yazdır("");
                        }
                        else if (sans < 40)     //30
                        {
                            a.can = -25;  //yüzbaşı ateş ettiğinde düşman askerin canının 25 azaltması durumu
                            Yazdirma.Yazdır("");
                        }
                        else    //60
                        {
                            a.can = -15;    //yüzbaşı ateş ettiğinde düşman askerin canının 15 azaltması durumu
                            Yazdirma.Yazdır("");
                        }
                        if (a.can <= 0)  //canlar 0 ın altına düşerse ölen askerin yasam özelliğinin false olması
                        {
                            a.hayat = false;
                            Yazdirma.Yazdır("");
                            alan[Xkordinati, Ykordinati + 2] = new Bolge(Xkordinati, Ykordinati + 2);
                        }
                    }
                }
        }

    }
}
