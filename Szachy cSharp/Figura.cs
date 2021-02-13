using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szachy_cSharp
{
    abstract class Figura
    {
        private string nazwa;
        private char symbol;
        private char druzyna;

        public string PobierzNazwe()
        {
            return nazwa;
        }

        public void UstawNazwe(string naz)
        {
            nazwa = naz;
        }

        public char PobierzSymbol()
        {
            return symbol;
        }

        public void UstawSymbol(char sym)
        {
            symbol = sym;
        }

        public char PobierzDruzyne()
        {
            return druzyna;
        }

        public void UstawDruzyne(char dru)
        {
            druzyna = dru;
        }

        public abstract bool Weryfikuj(Figura[,] szachownica, int x, int y, int new_x, int new_y);           //sprawdza czy mozna wykonac ruch
    }
}
