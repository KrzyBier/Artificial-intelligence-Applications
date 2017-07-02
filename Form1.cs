using Kw.Combinatorics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wczytywanie_ZPliku
{
    public partial class Form1 : Form
    {
        /*              EXHAUSTIVE FUNCTIONS ENDS               */
        static int[] niejakiestamAtrybuty(int[] obj1, int[] obj2)
        {
            List<int> wynik = new List<int>();
            if (obj1.Last() != obj2.Last())
            {
                for (int i = 0; i < obj1.Length; i++)
                {
                    if (obj1[i] == obj2[i])
                    {
                        wynik.Add(i);
                    }
                }
            }
            return wynik.ToArray();
        }
        static bool czyZawiera(int[] rozneAtrybuty, int[] kombinacja)
        {
            for (int i = 0; i < kombinacja.Length; i++)
                if (!rozneAtrybuty.Contains(kombinacja[i]))
                    return false;

            return true;
        }

        static bool CzyKombinacjaSprzeczna(int[][] komDlaObiektu, int[] kombinacja)
        {
            for (int i = 0; i < komDlaObiektu.Length; i++)
            {
                if (czyZawiera(komDlaObiektu[i], kombinacja))
                {
                    return true;
                }
            }
            return false;
        }

        public int sprawdzCzyJestRegula(List<Regula> _listaRegul, Regula _regula)
        {
            //PRZESZUKIWANIE LISTY REGUŁ
            if (_listaRegul.LongCount() == 0)
            {
                return 1;
            }
            foreach (var _regulaZListy in _listaRegul)
            {
                int licznik = 0;
                    foreach (var _deskryptorNowy in _regula.deskryptory)
                    {
                        int value;
                        if (_regulaZListy.deskryptory.TryGetValue(_deskryptorNowy.Key, out value) && _deskryptorNowy.Value == value && _regulaZListy.decyzja == _regula.decyzja)
                        {
                            licznik += 1; 
                            if (_regula.deskryptory.LongCount() > _regulaZListy.deskryptory.LongCount() && _regulaZListy.decyzja == _regula.decyzja && licznik == _regulaZListy.deskryptory.LongCount())
                            {
                                //JEŚLI POSIADAMY REGUŁE KTÓRA JEST TAKA SAMA I JEST NIŻSZEGO RZĘDU NIE DODAJEMY JEJ
                                return 0;
                            }
                        }                        
                    }

                    if (licznik == _regulaZListy.deskryptory.LongCount() && _regula.deskryptory.LongCount() > licznik)
                    {
                        return 0;
                    }
                                    
                    if (licznik == _regulaZListy.deskryptory.LongCount())
                    {
                        //JEŚLI REGUŁA JEST IDENTYCZNA I JEST TEJ SAMEJ DŁUGOŚCI TO ZWIĘKSZAMY SUPPORT I PRZERYWAMY PĘTLĘ
                        _regulaZListy.support += 1;
                        return 0;
                    }
                    if (_listaRegul.Last() == _regulaZListy)
                    {
                        //JEŚLI SPRAWDZILIŚMY WSZYSTKIE REGUŁY I NIE MA TAKIEJ REGUŁY JESZCZE W LIŚCIE DODAJEMY JĄ
                        return 1;
                    }  
            }
            return 1;
        }

        /*              EXHAUSTIVE FUNCTIONS ENDS               */




        /*                  COVERING FUNCTIONS              */

        int coveringFunc(int[] obiekt, int [] kombinacja, int [][] _daneZPliku, List<int> _skip )
        {
            int support = 0;
            int help = 0;
            for (int i = 0; i < _daneZPliku.Length; i++)
            {
                help = coveringCzyKombinacjaJestSprzeczna(obiekt, kombinacja, _daneZPliku[i]);
                if (help == 1)
                {
                    support += 1;
                }
                if (help == 2)
                {
                    support = 0;
                    break;
                }
                if (help == 3)
                {
                    continue;
                }
            }
            if (support >= 1 )
            {
                return support;
            }
            return 0;
        }

        int coveringCzyKombinacjaJestSprzeczna(int[] obiekt, int[] kombinacja, int[] obiekt2)
        {
            int licznik = 0;
            for (int j = 0; j < kombinacja.Length; j++)
            {
                if (obiekt[kombinacja[j]] == obiekt2[kombinacja[j]])
                {

                        licznik += 1;
                        if (licznik == kombinacja.Length && obiekt.Last() == obiekt2.Last())
                        {
                            return 1;
                        }                
                }
                if (licznik == kombinacja.Length && obiekt.Last() != obiekt2.Last())
                {
                    return 2;
                }
            }
            return 3;
        }

        bool coveringCzyZawieraRegule(List<Regula> _listaRegul, Regula _nowa, int [] _kombinacja)
        {
            foreach (var stara in _listaRegul)
            {
                int licznik = 0;
                foreach (var deskryptor in _nowa.deskryptory)
                {
                    int value;
                    if (stara.deskryptory.TryGetValue(deskryptor.Key, out value) && value == deskryptor.Value)
                    {
                        licznik += 1;
                        if ((licznik == _nowa.deskryptory.LongCount()) && (stara.decyzja == _nowa.decyzja))
                        {
                            return true;
                        }
                    }
                }
                
            }
            return false;
        }


        /*                  COVERING FUNCTIONS ENDS              */


        /*                  LEM2 FUNCTIONS                    */

        int[][] lem2PosortujWedlugKlucza(int[][] _daneZPliku) // funkcja sortujaca wedlug klucza
        {
            int[][] posortowana = _daneZPliku;
            int[][] temp = new int[posortowana.Length][];
            for (int i = 0; i < _daneZPliku.Length - 1; i++)
            {
                for (int j = 0; j < _daneZPliku.Length - 1; j++)
                {
                    if (_daneZPliku[j].Last() > _daneZPliku[j+1].Last())
                    {
                        temp[j] = new int[_daneZPliku[j].Length];
                        temp[j] = posortowana[j];
                        _daneZPliku[j] = _daneZPliku[j + 1];
                        _daneZPliku[j + 1] = temp[j];
                    }
                }
            }
            return _daneZPliku;
        }
            


        List<Regula> szukajReguly(List<List<int>> listaDaneZplikuRef, int[][] tab, int decyzja)
        {

            List<List<int>> listaDaneZpliku = listaDaneZplikuRef;
            List<int> doGotowychRegulSkip = new List<int>();
            int ileRegul = 0;
            List<Regula> listaRegulLEM2 = new List<Regula>();

            foreach (var item in listaDaneZpliku)
            {
                if (item.Last() == decyzja)
                {
                    ileRegul += 1;
                }
            }



            while (doGotowychRegulSkip.LongCount() != ileRegul)
            {
                Dictionary<int, int> maxior = new Dictionary<int, int>();
                int licznik, temp, max, maxAllColumn = maxAllColumn = max = licznik = temp = 0;
                int adres = 0;
                List<int> indexList = new List<int>();
                Regula nowa = new Regula(decyzja);


                do
                {
                licznik = 0;
                adres = 0; // TO BEDZIE TRZEBA ZMIENIC BO PRZY DODAWANIU W SLOWNIKU MOGLA WARTOSC JUZ WYSTAPIC
                maxAllColumn = 0;

                for (int i = 0; i < tab[0].LongCount() - 1; i++) // ATRYBUT
                {
                    max = 0;    // NIE MA JESZCZEW TEJ KOLUMNIE MAXYMALNEGO WYSTĄPIENIA WIEC ZERUJEMY

                    if (maxior.ContainsKey(i))
                    {
                        continue;
                    }

                    for (int j = 0; j < listaDaneZpliku.LongCount(); j++) // OBIEKT 1
                    {
                        if (indexList.Contains(j) || doGotowychRegulSkip.Contains(j))
                        {
                            continue;
                        }
                        licznik = 0;    // ZERUJEMY LICZNIK DLA SPRAWDZANEGO ATRYBUTU DANEGO OBIEKTU
                        for (int k = 0; k < listaDaneZpliku.LongCount(); k++) // OBIEKT 2
                        {
                            if (indexList.Contains(k) || doGotowychRegulSkip.Contains(k))
                            {
                                continue;
                            }
                            if (decyzja == listaDaneZpliku[k].Last() && decyzja == listaDaneZpliku[j].Last()) // JEŚLI OBIEKT 2 I OBIEKT 1 MAJĄ TAKĄ SAMA DECYZJE TO SPOKO
                            {
                                if (listaDaneZpliku[j][i] == listaDaneZpliku[k][i]) // JEŚLI OBIEKT 1 I OBIEKT 2 MAJA TAKA SAMA WARTOŚĆ POD TYM SAMYM ATRYBUTEM TO DODAJ DO LICZNIKA
                                {
                                    licznik += 1;
                                }
                            }
                        }
                        if (max < licznik) //JEŚLI MAX JEST MNIEJSZY NIŻ NOWY TO ZMIEŃMY
                        {
                            max = licznik;  // MAXYMALNY LICZNIK W DANEJ SPRAWDZANEJ KOLUMNIE
                            if (maxAllColumn == 0 || maxAllColumn < licznik)
                            {
                                maxAllColumn = licznik; // MAXYMALNY LICZNIK Z WSZYSTKICH SPRAWDZANYCH DOSTEPNYCH KOLUMN
                                adres = i; // NUMER KOLUMNY W KTOREJ ZNALEZIONO NAJWIEKSZE WYSTAPIENIE
                                temp = listaDaneZpliku[j][i]; // wartość maxa
                            }
                        }
                    }
                }
                maxior.Add(adres, temp); // ADRES = NUMER KOLUMNY ATRYBUTU, TEMP = WARTOŚĆ

                
                foreach (var item in listaDaneZpliku) // zawężanie kręgu poszukiwań, kasowanie obiektów które już nie są brane pod uwagę z listy
                {
                    if (!(item[maxior.Last().Key] == maxior.Last().Value) && item.Last() == decyzja && !(indexList.Contains(listaDaneZpliku.IndexOf(item))) && !(doGotowychRegulSkip.Contains(listaDaneZpliku.IndexOf(item))))
                    {
                        indexList.Add(listaDaneZpliku.IndexOf(item)); 
                    }
                }

            } while (sprawdzReguleLEM(maxior, tab, decyzja));
                nowa.deskryptory = maxior;
                nowa.support = sprawdzSupporty(nowa, tab, decyzja);
                listaRegulLEM2.Add(nowa);
                foreach (var item in listaDaneZpliku)
                {
                    if (item.Last() == decyzja && !(indexList.Contains(listaDaneZpliku.IndexOf(item))) && !(doGotowychRegulSkip.Contains(listaDaneZpliku.IndexOf(item))))
                    {
                        doGotowychRegulSkip.Add(listaDaneZpliku.IndexOf(item));
                    }
                }
            } 
            return listaRegulLEM2;
        }

        bool sprawdzReguleLEM(Dictionary<int, int> _maxior, int[][] _daneZPliku, int decyzja)
        {
                for (int i = 0; i < _daneZPliku.LongCount(); i++)
                {
                    // jesli wartość jest ta sama i klucze są różne
                    if (_daneZPliku[i][_maxior.Last().Key] == _maxior.Last().Value && _daneZPliku[i].Last() != decyzja)
                    {
                        return true;
                    }
                }                
            return false;
        }

        int sprawdzSupporty(Regula regula, int[][] _daneZPliku, int decyzja)
        {
            int support = 0;
            var licznik = regula.deskryptory.LongCount();
            int licznik2 = 0;
            
            foreach (var j in _daneZPliku)
            {
                licznik2 = 0;
                foreach (var item in regula.deskryptory)
                {
                    if (j[item.Key] == item.Value && j.Last() == regula.decyzja)
                    {
                        licznik2++;
                        if (licznik2 == licznik)
                        {
                            support++;
                        }    
                    }
                }
                
            }


            return support;
        }





        public Form1()
        {
            InitializeComponent();
        }

        private void btnWybierz_Click(object sender, EventArgs e)
        {
            listaRegulTextBox.Clear();
            var wynik = ofd.ShowDialog();
            if (wynik != DialogResult.OK)
                return;


            if (wynik == DialogResult.OK)
            {
                tbScieszka.Text = ofd.FileName;
                string trescPliku = System.IO.File.ReadAllText(ofd.FileName);

                string[] poziomy = trescPliku.Split('\n');

                int[][] daneZPliku = new int[poziomy.Length][];

                for (int i = 0; i < poziomy.Length; i++)
                {
                    string poziom = poziomy[i].Trim();
                    string[] miejscaParkingowe = poziom.Split(' ');
                    daneZPliku[i] = new int[miejscaParkingowe.Length];
                    for (int j = 0; j < miejscaParkingowe.Length; j++)
                    {
                        daneZPliku[i][j] = int.Parse(miejscaParkingowe[j]);
                    }


                }


                if (exhaustiveRadioButton.Checked)
                {
                    // EXHAUSTIVE         

                    //TWORZENIE MACIERZY NIEODROZNIALNOSCI

                    int[][][] macierzNieodroznialnosci = new int[daneZPliku.Length][][];

                    for (int j = 0; j < daneZPliku.Length; j++)
                    {
                        macierzNieodroznialnosci[j] = new int[daneZPliku.Length][];
                        for (int k = 0; k < daneZPliku.Length; k++)
                        {
                            int[] tabTemp = niejakiestamAtrybuty(daneZPliku[j], daneZPliku[k]);
                            macierzNieodroznialnosci[j][k] = new int[tabTemp.Length];
                            macierzNieodroznialnosci[j][k] = tabTemp;
                        }
                    }


                    Combination cam = new Combination(daneZPliku.First().Length - 1);

                    List<Regula> listaRegul = new List<Regula>();



                    //GŁÓWNA PĘTLA ALGORYTMU EXHAUSTIVE

                    foreach (var k in cam.GetRowsForAllPicks())
                    {
                        int[] kombinacja = k.ToArray();
                        for (int i = 0; i < macierzNieodroznialnosci.Length; i++)
                        {
                            if (CzyKombinacjaSprzeczna(macierzNieodroznialnosci[i], kombinacja))
                                continue;
                            else // TWORZYMY REGUŁE KTÓRĄ W FUNKCJI SPRAWDZIMY CZY MOŻEMY DODAĆ
                            {
                                Regula nowaReg = new Regula(daneZPliku[i].Last());
                                nowaReg.atrybutIWartosci(daneZPliku[i], kombinacja);

                                if (sprawdzCzyJestRegula(listaRegul, nowaReg) == 1) // JEŚLI NIE ISTNIEJE TAKA REGUŁA WTEDY DODAJEMY JĄ DO LISTY REGUŁ
                                {
                                    nowaReg.support = 1;
                                    listaRegul.Add(nowaReg);
                                }
                            };
                        }
                    }

                    foreach (var regula in listaRegul)
                    {

                        foreach (var deskryptor in regula.deskryptory)
                        {
                            listaRegulTextBox.Text += "( a" + deskryptor.Key + " ) = " + deskryptor.Value;
                            if (!(deskryptor.Equals(regula.deskryptory.Last())))
                            {
                                listaRegulTextBox.Text += " && ";
                            }
                        }

                        listaRegulTextBox.Text += " => " + " d = " + regula.decyzja;
                        if (regula.support != 1)
                        {
                            listaRegulTextBox.Text += " [" + regula.support + "]";
                        }
                        listaRegulTextBox.AppendText(Environment.NewLine);
                    }
                }


                if (coveringRadioButton.Checked)
                {
                    /* covering */

                    Combination cam = new Combination(daneZPliku.First().Length - 1);

                    List<Regula> listaRegul = new List<Regula>();
                    List<int> skip = new List<int>();
                    int supp = 0;
                    foreach (var k in cam.GetRowsForAllPicks())
                    {
                        int[] kombinacja = k.ToArray();
                        for (int i = 0; i < daneZPliku.Length; i++)
                        {
                            if (skip.Contains(i))
                            {
                                continue;
                            }
                            supp = coveringFunc(daneZPliku[i], kombinacja, daneZPliku, skip);
                            if (supp == 0)
                                continue;
                            else
                            {

                                Regula nowa = new Regula(daneZPliku[i].Last());
                                nowa.atrybutIWartosci(daneZPliku[i], kombinacja);
                                nowa.support = supp;
                                skip.Add(i);
                                if (coveringCzyZawieraRegule(listaRegul, nowa, kombinacja))
                                {
                                    continue;
                                }
                                listaRegul.Add(nowa);
                            };
                        }
                    }
                    foreach (var regula in listaRegul)
                    {

                        foreach (var deskryptor in regula.deskryptory)
                        {
                            listaRegulTextBox.Text += "( a" + deskryptor.Key + " ) = " + deskryptor.Value;
                            if (!(deskryptor.Equals(regula.deskryptory.Last())))
                            {
                                listaRegulTextBox.Text += " && ";
                            }
                        }

                        listaRegulTextBox.Text += " => " + " d = " + regula.decyzja;
                        if (regula.support != 1)
                        {
                            listaRegulTextBox.Text += " [" + regula.support + "]";
                        }
                        listaRegulTextBox.AppendText(Environment.NewLine);
                    }
                }

                if (lem2RadioButton.Checked)
                {
                    var posortowana = lem2PosortujWedlugKlucza(daneZPliku);
                                        
                    List<List<int>> listaDaneZPliku = new List<List<int>>();
                    List<int> listaKlas = new List<int>();
                    List<Regula> listaRegul = new List<Regula>();

                    for (int i = 0; i < posortowana.Length; i++)
                    {
                        listaDaneZPliku.Add(posortowana[i].ToList());
                    }

                    foreach (var item in listaDaneZPliku)
                    {
                        if (!listaKlas.Contains(item.Last()))
                        {
                            listaKlas.Add(item.Last());
                        }
                    }

                    foreach (var item in listaKlas)
                    {
                        List<Regula> listaRegulKl1 = szukajReguly(listaDaneZPliku, daneZPliku, item);
                        foreach (var regula in listaRegulKl1)
                        {
                            foreach (var deskryptor in regula.deskryptory)
                            {
                                listaRegulTextBox.Text += "( a" + (Convert.ToInt32(deskryptor.Key) + 1 ) + " ) = " + deskryptor.Value;
                                if (!(deskryptor.Equals(regula.deskryptory.Last())))
                                {
                                    listaRegulTextBox.Text += " && ";
                                }
                            }

                            listaRegulTextBox.Text += " => " + " d = " + regula.decyzja;
                            if (regula.support != 1)
                            {
                                listaRegulTextBox.Text += " [" + regula.support + "]";
                            }
                            listaRegulTextBox.AppendText(Environment.NewLine);
                        }
                    }
                    
                    }
                    

                }



            }
        
        

        private void Form1_Load(object sender, EventArgs e)
        {
            ofd.Filter = "Text Filrd (.txt) |*.txt";
        }
    }
}
