using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szachy_cSharp
{
    class Goniec : Figura
    {
        public Goniec(char dru)
        {
	        UstawNazwe("Goniec");
            UstawSymbol('G');
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


            int l;                                                              //sprawdza czy ruch jest mozliwy
            if (new_x < x) l = x - new_x;
            else l = new_x - x;
            bool test1 = false, test2 = true;
            if ((new_x == x + l && new_y == y + l) || (new_x == x + l && new_y == y - l) || (new_x == x - l && new_y == y + l) || (new_x == x - l && new_y == y - l)) test1 = true;

            if (new_x < x && new_y < y)
            {                                                                   //sprawdza czy po drodze nie ma przeszkody
                for (int i = 1; i < l; i++)
                    if (szachownica[x - i,y - i] != null) test2 = false;
            }
            else if (new_x < x && new_y > y)
            {
                for (int i = 1; i < l; i++)
                    if (szachownica[x - i,y + i] != null) test2 = false;
            }
            else if (new_x > x && new_y < y)
            {
                for (int i = 1; i < l; i++)
                    if (szachownica[x + i,y - i] != null) test2 = false;
            }
            else if (new_x > x && new_y > y)
            {
                for (int i = 1; i < l; i++)
                    if (szachownica[x + i,y + i] != null) test2 = false;
            }

            if (test1 && test2) return true;
            else return false;
        }
    }
}
