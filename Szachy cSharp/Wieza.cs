using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szachy_cSharp
{
    class Wieza : Figura
    {
        public Wieza(char dru)
        {
	        UstawNazwe("Wieza");
            UstawSymbol('W');
            UstawDruzyne(dru);
        }

        public override bool Weryfikuj(Figura[,] szachownica, int x, int y, int new_x, int new_y)
        {
            if (new_x < 0 || new_x > 7 || new_y < 0 || new_y > 7) return false;
            if (szachownica[new_x,new_y] != null)
            {
                if (szachownica[new_x,new_y].PobierzDruzyne() == this.PobierzDruzyne())
                    return false;
            }

            if (new_x != x && new_y != y) return false;                     //sprawdza czy ruch jest mozliwy

            bool test = true;                                               //sprawdza czy po drodze nie ma przeszkody
            if (new_x < x)
            {
                for (int i = x - 1; i > new_x; i--)
                    if (szachownica[i,y] != null) test = false;
            }
            else if (new_x > x)
            {
                for (int i = x + 1; i < new_x; i++)
                    if (szachownica[i,y] != null) test = false;
            }
            else if (new_y < y)
            {
                for (int i = y - 1; i > new_y; i--)
                    if (szachownica[x,i] != null) test = false;
            }
            else if (new_y > y)
            {
                for (int i = y + 1; i < new_y; i++)
                    if (szachownica[x,i] != null) test = false;
            }
            return test;
        }
    }
}
