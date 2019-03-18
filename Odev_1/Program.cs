using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random(); 
            Object[,] Alan = new Object[16, 16];   //Savaş alanımızı yarattık iki boyutlu dizi kullanarak.
            for (int i = 0; i < 16; i++)
                for (int j = 0; j < 16; j++)
                    Alan[i, j] = new Bolge(i, j);


        }
    }
}

//Kaynakça
//Damla İpçi ile birlikte ödevin mantığını anlamaya çalıştık.Elimizden geleni yapmaya çalıştık birlikte 
//fikir alışverişi yapa yapa ancak bu hale getirebildik.
//http://bilgisayarkavramlari.sadievrenseker.com/2008/11/24/yapici-constructor/
//http://www.buraksecer.com/abstract-class-ve-interface-nedir-c/
//https://docs.microsoft.com/tr-tr/dotnet/csharp/language-reference/keywords/base
//https://www.youtube.com/watch?v=z4oe6RHui4U&list=PLqG356ExoxZU5keiJwuHDpXqULLffwRYD&index=46
//https://www.youtube.com/watch?v=aomLseXFZeg&list=PLqG356ExoxZU5keiJwuHDpXqULLffwRYD&index=37
