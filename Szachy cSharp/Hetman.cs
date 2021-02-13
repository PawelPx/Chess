using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szachy_cSharp
{
    class Hetman : Figura
    {
        public Hetman(char dru)
        {
	        UstawNazwe("Hetman");
            UstawSymbol('H');
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


            if (new_x == x || new_y == y)
            {                                   //sprawdza czy ruch jest mozliwy (w pionie lub poziomie)
                bool test = true;                                           //sprawdza czy po drodze nie ma przeszkody
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
            else
            {
                int l;                                                                  //sprawdza czy ruch jest mozliwy (po skosie)
                if (new_x < x) l = x - new_x;
                else l = new_x - x;
                bool test1 = false, test2 = true;
                if ((new_x == x + l && new_y == y + l) || (new_x == x + l && new_y == y - l) || (new_x == x - l && new_y == y + l) || (new_x == x - l && new_y == y - l)) test1 = true;

                if (new_x < x && new_y < y)
                {                                                                       //sprawdza czy po drodze nie ma przeszkody
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
}
