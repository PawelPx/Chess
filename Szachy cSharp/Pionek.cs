using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szachy_cSharp
{
    class Pionek : Figura
    {
        public Pionek(char dru)
        {
	        UstawNazwe("Pionek");
            UstawSymbol('P');
            UstawDruzyne(dru);
        }

        public override bool Weryfikuj(Figura[,] szachownica, int x, int y, int new_x, int new_y)
        {
            if (new_x < 0 || new_x > 7 || new_y < 0 || new_y > 7)
                return false;

            if (szachownica[new_x,new_y] != null)
            {
                if (szachownica[new_x,new_y].PobierzDruzyne() == this.PobierzDruzyne())
                    return false;
            }

            if (this.PobierzDruzyne() == 'B')
            {
                if (szachownica[new_x,new_y] == null)
                {
                    if (x == 6)
                    {
                        if (new_y == y && (new_x == x - 1 || (new_x == x - 2 && szachownica[x - 1,y] == null))) return true;
                        else return false;
                    }
                    else if (new_x == x - 1 && new_y == y) return true;
                    else return false;
                }
                else if (szachownica[new_x,new_y].PobierzDruzyne() == 'C')
                {
                    if (new_x == x - 1 && (new_y == y + 1 || new_y == y - 1)) return true;
                    else return false;
                }
            }
            else if (this.PobierzDruzyne() == 'C')
            {
                if (szachownica[new_x,new_y] == null)
                {
                    if (x == 1)
                    {
                        if (new_y == y && (new_x == x + 1 || (new_x == x + 2 && szachownica[x + 1,y] == null))) return true;
                        else return false;
                    }
                    else if (new_x == x + 1 && new_y == y) return true;
                    else return false;
                }
                else if (szachownica[new_x,new_y].PobierzDruzyne() == 'B')
                {
                    if (new_x == x + 1 && (new_y == y + 1 || new_y == y - 1)) return true;
                    else return false;
                }
            }
            else return false;

            return false;
        }
    }
}
