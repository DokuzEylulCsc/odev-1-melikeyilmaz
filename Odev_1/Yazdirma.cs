using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Odev
{
    public static class Yazdirma
    {
        public static void Yazdır(string cumle) // Dosyaya yazdırma işlemlerimiz.
        //Bu işlemlerimiz hata vermesin diye using System.IO; kütüphanesini ekledik.

        {
            string dosya_yolu = @"C:\hamleler.txt";
            FileStream fs = new FileStream(dosya_yolu, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(cumle);
            sw.Flush();
            sw.Close();
            fs.Close();
        }
    }
}
