using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Szachy_cSharp
{
    public partial class Form1 : Form
    {
        Szachownica plansza = new Szachownica();
        int w_pola = 75;
        int h_pola = 75;
        Image black = Image.FromFile("czarnepole.png");
        Image white = Image.FromFile("bialepole.png");
        Image im_bk = Image.FromFile("bk.png");
        Image im_bp = Image.FromFile("bp.png");
        Image im_bw = Image.FromFile("bw.png");
        Image im_bs = Image.FromFile("bs.png");
        Image im_bg = Image.FromFile("bg.png");
        Image im_bh = Image.FromFile("bh.png");
        Image im_ck = Image.FromFile("ck.png");
        Image im_cp = Image.FromFile("cp.png");
        Image im_cw = Image.FromFile("cw.png");
        Image im_cs = Image.FromFile("cs.png");
        Image im_cg = Image.FromFile("cg.png");
        Image im_ch = Image.FromFile("ch.png");
        Image pods = Image.FromFile("pods.png");
        Image win_white = Image.FromFile("win_white.png");
        Image win_black = Image.FromFile("win_black.png");
        bool gracz = true;                              // okresla czyja jest tura
        bool wygrana = false;                           // okresla czy ktos wygral
        char winner;
        bool tura = false;                                   // okresla czy to 1. czy 2. faza tury
        int i_pods;                                     // wspolrzedne podswietlonego pola
        int j_pods;										// wspolrzedne podswietlonego pola
        int h_pocz, w_pocz, h_nowe, w_nowe;

        public Form1()
        {
            InitializeComponent();
        }

        void Wyswietl(Figura figura, int y, int x, System.Windows.Forms.PaintEventArgs e)
        {
            if (figura.PobierzDruzyne() == 'B')
            {
                if (figura.PobierzSymbol() == 'P') e.Graphics.DrawImage(im_bp, x * w_pola, y * h_pola, w_pola, h_pola);
                if (figura.PobierzSymbol() == 'W') e.Graphics.DrawImage(im_bw, x * w_pola, y * h_pola, w_pola, h_pola);
                if (figura.PobierzSymbol() == 'S') e.Graphics.DrawImage(im_bs, x * w_pola, y * h_pola, w_pola, h_pola);
                if (figura.PobierzSymbol() == 'G') e.Graphics.DrawImage(im_bg, x * w_pola, y * h_pola, w_pola, h_pola);
                if (figura.PobierzSymbol() == 'H') e.Graphics.DrawImage(im_bh, x * w_pola, y * h_pola, w_pola, h_pola);
                if (figura.PobierzSymbol() == 'K') e.Graphics.DrawImage(im_bk, x * w_pola, y * h_pola, w_pola, h_pola);
            }
            if (figura.PobierzDruzyne() == 'C')
            {
                if (figura.PobierzSymbol() == 'P') e.Graphics.DrawImage(im_cp, x * w_pola, y * h_pola, w_pola, h_pola);
                if (figura.PobierzSymbol() == 'W') e.Graphics.DrawImage(im_cw, x * w_pola, y * h_pola, w_pola, h_pola);
                if (figura.PobierzSymbol() == 'S') e.Graphics.DrawImage(im_cs, x * w_pola, y * h_pola, w_pola, h_pola);
                if (figura.PobierzSymbol() == 'G') e.Graphics.DrawImage(im_cg, x * w_pola, y * h_pola, w_pola, h_pola);
                if (figura.PobierzSymbol() == 'H') e.Graphics.DrawImage(im_ch, x * w_pola, y * h_pola, w_pola, h_pola);
                if (figura.PobierzSymbol() == 'K') e.Graphics.DrawImage(im_ck, x * w_pola, y * h_pola, w_pola, h_pola);
            }
        }

        bool SprawdzGracza(int x, int y)
        {
            if (plansza.PobierzFigure(x, y) != null)
            {
                if ((gracz && plansza.PobierzFigure(x, y).PobierzDruzyne() == 'B') || (!gracz && plansza.PobierzFigure(x, y).PobierzDruzyne() == 'C')) return true;
                else return false;
            }
            else return false;
        }


        void ZmianaGracza()
        {
            if (gracz) gracz = false;
            else gracz = true;
        }

        bool SprawdzWygrana()
        {
            bool bk = false;
            bool ck = false;
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    Figura figura = plansza.PobierzFigure(i, j);
                    if (figura != null)
                    {
                        if (figura.PobierzSymbol() == 'K' && figura.PobierzDruzyne() == 'B') bk = true;
                        if (figura.PobierzSymbol() == 'K' && figura.PobierzDruzyne() == 'C') ck = true;
                    }
                }
            if (!bk)
            {
                wygrana = true;
                winner = 'C';
            }
            if (!ck)
            {
                wygrana = true;
                winner = 'B';
            }
            return wygrana;
        }

        private void Form1_Paint(System.Object sender, System.Windows.Forms.PaintEventArgs e)
        {

            if (wygrana)
            {                                                                                   //operacja jezeli ktos juz wygral
                if (winner == 'B')
                    e.Graphics.DrawImage(win_white, 0, 0, 8 * w_pola, 8 * h_pola);
                else
                    e.Graphics.DrawImage(win_black, 0, 0, 8 * w_pola, 8 * h_pola);
            }
            else
            {                                                                                           //standardowa operacja
                for (int i = 0; i < 8; i++)
                    for (int j = 0; j < 8; j++)
                        if ((i % 2 == 0 && j % 2 == 0) || (i % 2 == 1 && j % 2 == 1))
                            e.Graphics.DrawImage(white, i * w_pola, j * h_pola, w_pola, h_pola);
                        else
                            e.Graphics.DrawImage(black, i * w_pola, j * h_pola, w_pola, h_pola);

                for (int i = 0; i < 8; i++)
                    for (int j = 0; j < 8; j++)
                    {
                        Figura figura = plansza.PobierzFigure(i, j);
                        if (plansza.PobierzFigure(i, j) != null) Wyswietl(figura, i, j, e);
                    }

                if (tura) e.Graphics.DrawImage(pods, i_pods * w_pola, j_pods * h_pola, w_pola, h_pola);       //podswietla pole
            }
        }

        private void Form1_Click(System.Object sender, System.EventArgs e)
        {

            if (wygrana)
            {                                                                               //operacja jezeli ktos juz wygral
                                                                                            //                delete plansza;
                Close();
            }
            else
            {                                                                                       //standardowa operacja
                Point p = this.PointToClient(MousePosition);

                int x = p.X;
                int y = p.Y;

                int i = x / w_pola;
                int j = y / h_pola;


                if (!tura)
                {                                   //pierwsza faza tury
                    if (SprawdzGracza(j, i))
                    {
                        h_pocz = j;
                        w_pocz = i;
                        i_pods = i;
                        j_pods = j;
                        tura = true;
                        this.Refresh();
                    }
                }
                else
                {                                               //druga faza tury
                    h_nowe = j;
                    w_nowe = i;
                    if (h_nowe == h_pocz && w_nowe == w_pocz)
                    {
                        tura = false;
                        this.Refresh();
                    }
                    else
                    {
                        Figura figura = plansza.PobierzFigure(h_pocz, w_pocz);
                        plansza.WykonajRuch(figura, h_pocz, w_pocz, h_nowe, w_nowe);
                        Figura figura2 = plansza.PobierzFigure(h_nowe, w_nowe);
                        if (figura2 == figura)
                        {                                           //sprawdza czy ruch zostal wykonany
                            SprawdzWygrana();
                            if (!wygrana)
                            {
                                tura = false;
                                ZmianaGracza();
                            }
                            this.Refresh();
                        }
                        else
                        {
                            tura = false;
                            this.Refresh();
                        }
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
