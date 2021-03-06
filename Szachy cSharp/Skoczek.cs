﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szachy_cSharp
{
    class Skoczek : Figura
    {
        public Skoczek(char dru)
        {
	        UstawNazwe("Skoczek");
            UstawSymbol('S');
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

            if ((new_x == x + 1 && new_y == y + 2) || (new_x == x + 2 && new_y == y + 1) || (new_x == x + 1 && new_y == y - 2) || (new_x == x + 2 && new_y == y - 1) ||
                (new_x == x - 1 && new_y == y + 2) || (new_x == x - 2 && new_y == y + 1) || (new_x == x - 1 && new_y == y - 2) || (new_x == x - 2 && new_y == y - 1)) return true;
            else return false;

        }
    }
}
