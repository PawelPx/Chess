using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szachy_cSharp
{
    class Szachownica
    {
        private Figura[,] szachownica = new Figura[8,8];
        //private Figura[][] szachownica;

        public Szachownica()
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    szachownica[i,j] = null;

            Wypelnij();
        }

        public Figura PobierzFigure(int x, int y)
        {
            return szachownica[x,y];
        }

        public void Wypelnij()
        {
            Pionek bp1 = new Pionek('B');
            Pionek bp2 = new Pionek('B');
            Pionek bp3 = new Pionek('B');
            Pionek bp4 = new Pionek('B');
            Pionek bp5 = new Pionek('B');
            Pionek bp6 = new Pionek('B');
            Pionek bp7 = new Pionek('B');
            Pionek bp8 = new Pionek('B');
            Pionek cp1 = new Pionek('C');
            Pionek cp2 = new Pionek('C');
            Pionek cp3 = new Pionek('C');
            Pionek cp4 = new Pionek('C');
            Pionek cp5 = new Pionek('C');
            Pionek cp6 = new Pionek('C');
            Pionek cp7 = new Pionek('C');
            Pionek cp8 = new Pionek('C');
            Wieza bw1 = new Wieza('B');
            Wieza bw2 = new Wieza('B');
            Wieza cw1 = new Wieza('C');
            Wieza cw2 = new Wieza('C');
            Skoczek bs1 = new Skoczek('B');
            Skoczek bs2 = new Skoczek('B');
            Skoczek cs1 = new Skoczek('C');
            Skoczek cs2 = new Skoczek('C');
            Goniec bg1 = new Goniec('B');
            Goniec bg2 = new Goniec('B');
            Goniec cg1 = new Goniec('C');
            Goniec cg2 = new Goniec('C');
            Hetman bh = new Hetman('B');
            Hetman ch = new Hetman('C');
            Krol bk = new Krol('B');
            Krol ck = new Krol('C');
            this.Przypisz(bp1, 6, 0);
            this.Przypisz(bp2, 6, 1);
            this.Przypisz(bp3, 6, 2);
            this.Przypisz(bp4, 6, 3);
            this.Przypisz(bp5, 6, 4);
            this.Przypisz(bp6, 6, 5);
            this.Przypisz(bp7, 6, 6);
            this.Przypisz(bp8, 6, 7);
            this.Przypisz(bw1, 7, 0);
            this.Przypisz(bs1, 7, 1);
            this.Przypisz(bg1, 7, 2);
            this.Przypisz(bh, 7, 3);
            this.Przypisz(bk, 7, 4);
            this.Przypisz(bg2, 7, 5);
            this.Przypisz(bs2, 7, 6);
            this.Przypisz(bw2, 7, 7);
            this.Przypisz(cp1, 1, 0);
            this.Przypisz(cp2, 1, 1);
            this.Przypisz(cp3, 1, 2);
            this.Przypisz(cp4, 1, 3);
            this.Przypisz(cp5, 1, 4);
            this.Przypisz(cp6, 1, 5);
            this.Przypisz(cp7, 1, 6);
            this.Przypisz(cp8, 1, 7);
            this.Przypisz(cw1, 0, 0);
            this.Przypisz(cs1, 0, 1);
            this.Przypisz(cg1, 0, 2);
            this.Przypisz(ch, 0, 3);
            this.Przypisz(ck, 0, 4);
            this.Przypisz(cg2, 0, 5);
            this.Przypisz(cs2, 0, 6);
            this.Przypisz(cw2, 0, 7);
        }

        public void Przypisz(Figura figura, int x, int y)
        {
            szachownica[x,y] = figura;
        }

        public void OproznijPole(int x, int y)
        {
            szachownica[x,y] = null;
        }

        public void Zbij(int x, int y)
        {
            szachownica[x,y] = null;
        }

        public void WykonajRuch(Figura figura, int x, int y, int new_x, int new_y)
        {
            if (figura.Weryfikuj(this.szachownica, x, y, new_x, new_y))
            {
                if (szachownica[new_x,new_y] != null)
                    if (szachownica[new_x,new_y].PobierzDruzyne() != szachownica[x,y].PobierzDruzyne())
                        Zbij(new_x, new_y);
                this.OproznijPole(x, y);
                this.Przypisz(figura, new_x, new_y);
            }
        }
    }
}
