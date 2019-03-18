using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev
{
    class Er : Asker    //abstract Asker classından alınan kalıtım
    {
        public Er(int grup, int x, int y)  //Erlerimiz için değişkenleri tanımladığımız bir  constructor method 
        {
            Oyungrubu = grup;
            Xkordinati = x;
            Ykordinati = y;
        }
        public override void Bekle()
        {
            Console.WriteLine("Er Bekliyor...");  //Bekleme methodunda bir şey olmadığı için ekrana yazı yazdırdım.
        }
        public override void Hareket_Et(Object[,] alan)
        {
            Random random = new Random();  //Rasgele bir değer üretiyoruz.
            bool k1, k2;  //kontrol etmek için kulanılan değişkenlerimiz.
            int ysans = 0;              
            do  // yukarı aşağı gitme kısmı
            {
                do
                {
                    k1 = true;
                    ysans = random.Next(-1, 2);  //rasgele sayı üretme kısmı
                    if (ysans == 0)
                        k1 = false;
                } while (!k1);

                if (alan[Xkordinati, Ykordinati + ysans] is Bolge b) //bölgenin içinde olup olmama
                {
                    Ykordinati = +ysans;  
                    k2 = true;
                }
                else
                {
                    Bekle();
                    k2 = true;
                }
            } while (!k2);


        }
        public override void Ates_Et(Object[,] alan)
        {
            Random random = new Random();
            int sans = random.Next(100);
            for (int i = -1; i < 2; i++)       //1 kare komşusu olan tüm askerleri vuruyor.
                for (int j = -1; j < 2; j++)
                {
                    if (alan[i, j] is Asker a && a.Oyungrubu != this.Oyungrubu)
                    {
                        if (sans < 25)       //ateş etmenin %25 olasılığı
                        {
                            a.can = -15;  // er ateş ettiğinde düşman askerin canının 15 azaltması durumu


                        }
                        else if (sans < 55)     //ateş etmenin %55 olasılığı
                        {
                            a.can = -10;   //er ateş ettiğinde düşman askerin canının 10 azaltması durumu

                        }
                        else    //ateş etmenin %45 olasılığı
                        {
                            a.can = - 5;  //er ateş ettiğinde düşman askerin canının 5 azaltması durumu


                        }
                        if (a.can <= 0) //canlar 0 ın altına düşerse ölen askerin yasam özelliğinin false olması
                        {
                            a.hayat = false;        
                            alan[Xkordinati, Ykordinati + 2] = new Bolge(Xkordinati, Ykordinati + 2);
                        }
                    }
                }
        }
    }
}
