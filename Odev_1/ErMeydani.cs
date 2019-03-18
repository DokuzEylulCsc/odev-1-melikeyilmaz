using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev
{
    class Ermeydani
    {
        
            Bolge[,] harita = new Bolge[16, 16];

            public Bolge[,] Harita { get { return harita; } set { harita = value; } }
        //Bolgeler olusturulduktan sonra bir daha set edilemeyecek sadece get edilebilicektir.
    }
}
