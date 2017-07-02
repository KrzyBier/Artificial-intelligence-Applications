using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kw.Combinatorics;

namespace Wczytywanie_ZPliku
{
    public class Regula
    {
        public int decyzja, support;       

        public Dictionary<int, int> deskryptory = new Dictionary<int, int>();

        public Regula(int _decyzja) 
        {
            this.decyzja = _decyzja;
        }

        public void atrybutIWartosci(int[] _daneZpliku, int [] _kombinacja) //PĘTLA DO DODAWANIA ATRYBUTÓW I WARTOŚCI DO SŁOWNIKA
        {
            int numer;
            for (int i = 0; i < _kombinacja.Length; i++)
            {
                    numer = _kombinacja[i];
                    deskryptory.Add(numer + 1, _daneZpliku[numer]);
            }
        }


    }
}
