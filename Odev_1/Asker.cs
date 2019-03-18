using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev
{
    abstract class Asker // abstract classların içinde abstract olan veya olmayan yapıları(method,property)
     //kullanabiliriz.
    {
        public bool hayat = true;
        public int Oyungrubu, can = 100, Xkordinati = 0, Ykordinati = 0;

        //teğmenin ates ettiğinde candaki azalamayı belirleyecek degısken(can)

        public abstract void Bekle();                       //Kalıtım alacağımız abstract methodlarımız.
        public abstract void Hareket_Et(Object[,] alan); //Abstract elemanların sadece imza kısımları burda.
        public abstract void Ates_Et(Object[,] alan);  //Gövde kısmı(methodların yazıldığı kısım) türetilen classlarda.

    }
}
